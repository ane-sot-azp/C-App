using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ElkarGune
{
    class KontrolKontsumizioak
    {
        public void Txertatu(int idProd, int kop, int fraZkia, float prezioa)
        {
            int idProduk = idProd;
            int kopurua = kop;
            int idFra = fraZkia;
            float prezio = prezioa;
            //MessageBox.Show(idProd.ToString() + kop.ToString() + fraZkia.ToString());
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                MySqlTransaction tr = db.conn.BeginTransaction();
                try
                {
                    string insert = "INSERT INTO kontsumizioak (IdFaktura, IdBodega, kopurua, prezioa) VALUES (@idFra, @idBod, @kop, @prezioa)";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = db.conn;
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@idFra", idFra);
                    cmd.Parameters.AddWithValue("@idBod", idProduk);
                    cmd.Parameters.AddWithValue("@kop", kopurua);
                    cmd.Parameters.AddWithValue("@prezioa", prezio);

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
    }
}
