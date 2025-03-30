using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;

namespace ElkarGune
{
    class KontrolProduktuak
    {
        public void Txertatu(int idProd, int kop, int fraZkia, float prezioa)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT idProduktua, kopurua FROM kontsumizioak WHERE IdFaktura=@fraZkia AND idProduktua=@idProd";
                    MySqlCommand cmd1 = new MySqlCommand(query, db.conn);
                    cmd1.Parameters.AddWithValue("@fraZkia", fraZkia);
                    cmd1.Parameters.AddWithValue("@idProd", idProd);

                    MySqlDataReader dr = cmd1.ExecuteReader();
                    bool exists = dr.Read(); // Verificar si hay datos
                    int dagoenKop = exists ? Convert.ToInt32(dr["kopurua"]) : 0;
                    dr.Close(); // Cerrar antes de cualquier otra consulta

                    MySqlTransaction tr = db.conn.BeginTransaction(); // Iniciar transacción solo si es necesario

                    if (!exists)
                    {
                        // INSERT porque no existe el producto en la factura
                        string insert = "INSERT INTO kontsumizioak (IdFaktura, idProduktua, kopurua, prezioa) VALUES (@idFra, @idBod, @kop, @prezioa)";
                        MySqlCommand cmd = new MySqlCommand(insert, db.conn, tr);
                        cmd.Parameters.AddWithValue("@idFra", fraZkia);
                        cmd.Parameters.AddWithValue("@idBod", idProd);
                        cmd.Parameters.AddWithValue("@kop", kop);
                        cmd.Parameters.AddWithValue("@prezioa", prezioa);

                        cmd.ExecuteNonQuery();
                        tr.Commit();
                    }
                    else
                    {
                        // Preguntar al usuario si quiere actualizar
                        DialogResult erantzuna = MessageBox.Show($"Dagoeneko {dagoenKop} apuntatu dituzu. Gehiago sartu nahi dituzu?",
                                         "Konfirmatu kopurua",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                        if (erantzuna == DialogResult.Yes)
                        {
                            // UPDATE porque ya existe el producto en la factura
                            string update = "UPDATE kontsumizioak SET kopurua = kopurua + @kop WHERE idProduktua = @idProd AND IdFaktura = @fakt";
                            MySqlCommand cmd = new MySqlCommand(update, db.conn, tr);
                            cmd.Parameters.AddWithValue("@kop", kop);
                            cmd.Parameters.AddWithValue("@idProd", idProd);
                            cmd.Parameters.AddWithValue("@fakt", fraZkia);

                            cmd.ExecuteNonQuery();
                            tr.Commit();
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea: " + ex.Message);
                }
                finally
                {
                    db.conn.Close();
                }
            }
        }

        public void FakturaSortu(int idBazkidea)
        {
            DateTime data = DateTime.Today;
            int fraZkia = 0;

            if (!FakturaBilatu(idBazkidea, data)) // Faktura existitzen ez bada bakarrik sortu
            {
                using (DBKonexioa db = new DBKonexioa())
                {
                    db.konektatu();

                    if (db.conn.State == ConnectionState.Open)
                    {
                        MySqlTransaction tr = db.conn.BeginTransaction();
                        try
                        {
                            string insert = "INSERT INTO fakturak (idBazkidea, erreserbaZkia, data) VALUES (@idBazkidea, @erreserbaZkia, @data)";
                            using (MySqlCommand cmd = new MySqlCommand(insert, db.conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@idBazkidea", idBazkidea);
                                cmd.Parameters.AddWithValue("@erreserbaZkia", 1);
                                cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                                cmd.ExecuteNonQuery();
                            }

                            tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            MessageBox.Show("Errorea faktura sortzean: " + ex.Message);
                            return;
                        }
                    }
                }
            }

            // Fakturaren ID-a lortu
            using (DBKonexioa db2 = new DBKonexioa())
            {
                db2.konektatu();

                string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data AND totala is null";
                using (MySqlCommand cmd2 = new MySqlCommand(select, db2.conn))
                {
                    cmd2.Parameters.AddWithValue("@idBazkidea", idBazkidea);
                    cmd2.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader dr = cmd2.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            fraZkia = Convert.ToInt32(dr["idFaktura"]);
                        }
                        else
                        {
                            MessageBox.Show("Arazoren bat egon da faktura aurkitzean.");
                            return;
                        }
                    }
                }
            }


            // Kontsumizioak pantaila ireki
            Kontsumizioak kontsumizioak = new Kontsumizioak(idBazkidea, fraZkia);
            kontsumizioak.Show();
        }
        public bool FakturaBilatu(int idBazkidea, DateTime data)
        {
            bool exists = false; // Hasieran, faktura ez dagoela suposatuko dugu

            using (DBKonexioa db = new DBKonexioa())
            {
                db.konektatu();

                string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data AND totala IS NULL";
                using (MySqlCommand cmd = new MySqlCommand(select, db.conn))
                {
                    cmd.Parameters.AddWithValue("@idBazkidea", idBazkidea);
                    cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Datu bat irakurtzen badu, faktura existitzen da
                        {
                            exists = true;
                        }
                    }
                }
            }

            return exists; // Faktura existitzen bada true, bestela false
        }

        public void KontsumizioaErregistratu(int fraZenbakia, float total)
        {
            int fraZkia = fraZenbakia;
            float totala = total;

            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                MySqlTransaction tr = db.conn.BeginTransaction();
                try
                {
                    string update = "UPDATE fakturak SET totala = @totala WHERE idFaktura= @fraZkia";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = db.conn;
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@totala", totala);
                    cmd.Parameters.AddWithValue("@fraZkia", fraZkia);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.conn.Close();
                }

            }
        }
        public void StockAldaketa(int idProduktua, int kopurua)
        {
            int idProd = idProduktua;
            int kop = kopurua;

            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                MySqlTransaction tr = db.conn.BeginTransaction();
                try
                {
                    string update = "UPDATE produktua SET stock = stock-@kop WHERE idProduktua= @prod";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = db.conn;
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@kop", kop);
                    cmd.Parameters.AddWithValue("@prod", idProd);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.conn.Close();
                }

            }
        }
        public void ProduktuaEzabatu(int idProd, int fraZkia)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                MySqlTransaction tr = db.conn.BeginTransaction();

                try
                {
                    DialogResult erantzuna = MessageBox.Show($"Erregistro hau ezabatu nahi duzu?",
                                         "Ezabaketa konfirmatu",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                    if (erantzuna == DialogResult.Yes)
                    {
                        string delete = "DELETE FROM kontsumizioak WHERE IdFaktura = @idfra AND idProduktua = @idbod";
                        MySqlCommand cmd = new MySqlCommand(delete, db.conn, tr);
                        cmd.Parameters.AddWithValue("@idfra", fraZkia);
                        cmd.Parameters.AddWithValue("@idbod", idProd);

                        cmd.ExecuteNonQuery();
                        tr.Commit();
                    }
                    else
                    {
                        tr.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.conn.Close();
                }
            }
        }
    }
}
