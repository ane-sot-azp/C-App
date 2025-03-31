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
        public void ProduktuakIkusi()
        {

        }
    }
}
