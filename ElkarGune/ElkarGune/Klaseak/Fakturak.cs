using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune.Klaseak
{
    class Fakturak
    {
        private int idFaktura;
        private int idBazkidea;
        private DateTime data;
        private float totala;
        private string fakturaPDF;
        public DataTable FakturakIkusi(int idBazkidea)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT idFaktura AS 'Faktura Zenbakia', data AS 'Data', totala AS 'Totala' FROM fakturak WHERE idBazkidea = @bazkideZkia ORDER BY idFaktura DESC";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@bazkideZkia", idBazkidea);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
        public void SartuFaktura(int idBazkidea)
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
            KontsumizioakAukeratu kontsumizioak = new KontsumizioakAukeratu(idBazkidea, fraZkia);
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
        public void EguneratuFaktura(int fraZenbakia, float total)
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
        public MySqlDataReader FakturaDetailea(int fraZkia)
        {
            DBKonexioa db = new DBKonexioa();
                    db.konektatu();

                    string query = "SELECT totala, idProduktua, kopurua FROM kontsumizioak WHERE IdFaktura=@fraZkia";
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@fraZkia", fraZkia);
            
            return cmd.ExecuteReader();
        }
    }
}
