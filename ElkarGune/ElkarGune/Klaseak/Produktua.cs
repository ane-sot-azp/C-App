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
    class Produktua
    {
        private int idProduktua;
        private int idHornitzailea;
        private string mota;
        private string izena;
        private float eroskeraPrezioa;
        private float salmentaPrezioa;
        private int stock;

        public void EguneratuProduktua(int idProduktua, int kopurua)
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
        public MySqlDataReader ProduktuakIkusi(int idProduktuMota)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            int idPM = idProduktuMota;
            string query = "SELECT idProduktua, irudia FROM produktua WHERE idProduktuMota= @idPM";

            // Crea el comando para la consulta
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@idPM", idPM);
            cmd.Connection = db.conn;
            cmd.CommandText = query;
            return cmd.ExecuteReader();
            db.conn.Close();

        }
        public MySqlDataReader ProduktuaKop(int idProduktua){
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string query = "SELECT * FROM produktua WHERE idProduktua=" + idProduktua;

            // Crea el comando para la consulta
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = query;
            return cmd.ExecuteReader();
            db.conn.Close();
        }
        public MySqlDataReader KontsFakturaBilatu(int idBazkidea, DateTime data){
            DBKonexioa db = new DBKonexioa();
                db.konektatu();

                string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data AND totala is null";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = db.conn;
                cmd.CommandText = select;
                cmd.Parameters.AddWithValue("@idBazkidea", idBazkidea);
                cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                return cmd.ExecuteReader();
        }
    }
}
