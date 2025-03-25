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
            int idBaz = idBazkidea;
            DateTime data = DateTime.Today;

            if (!FakturaBilatu(idBaz, data))
            {
                DBKonexioa db = new DBKonexioa();
                db.konektatu();

                if (db.conn.State == ConnectionState.Open)
                {
                    MySqlTransaction tr = db.conn.BeginTransaction();
                    try
                    {
                        string insert = "INSERT INTO fakturak (idBazkidea, erreserbaZkia, data) VALUES (@idBazkidea, @erreserbaZkia, @data)";
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = db.conn;
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@idBazkidea", idBaz);
                        cmd.Parameters.AddWithValue("@erreserbaZkia", 1);
                        cmd.Parameters.AddWithValue("@data", data);

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

            DBKonexioa db2 = new DBKonexioa();
            db2.konektatu();

            string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data";
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = db2.conn;
            cmd2.CommandText = select;
            cmd2.Parameters.AddWithValue("@idBazkidea", idBaz);
            cmd2.Parameters.AddWithValue("@data", data);

            MySqlDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                int fraZkia = Convert.ToInt32(dr["idFaktura"]);
                MessageBox.Show("FraZkia: " + fraZkia);
                db2.conn.Close();
            }
            else
            {
                MessageBox.Show("Arazoren bat egon da.");
                db2.conn.Close();
            }
        }
        public bool FakturaBilatu(int idBazkidea, DateTime data)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = select;
            cmd.Parameters.AddWithValue("@idBazkidea", idBazkidea);
            cmd.Parameters.AddWithValue("@data", data);

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
