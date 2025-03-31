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
    class ErreserbaElementua
    {
        private int idErreserbaElementua;
        private int idErreserba;
        private int idEspazioa;

        public DataTable ErreEleIkusi(int idBazkidea, int mota, DateTime erreserbaData)
        {

            DataTable dt = new DataTable();
            using (DBKonexioa db = new DBKonexioa())
            {
                db.konektatu();

                string select = "SELECT e.izena FROM espazioa e " +
                                "JOIN erreserbaelementua ee ON e.idEspazioa = ee.idEspazioa " +
                                "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                "WHERE er.idBazkidea = @idBazk AND er.mota = @mota AND er.data = @data";

                using (MySqlCommand cmd = new MySqlCommand(select, db.conn))
                {
                    cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
                    cmd.Parameters.AddWithValue("@mota", mota);
                    cmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                db.conn.Close();
            }
            return dt;
        }
        public void ErreEleSartu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string insertQuery = "INSERT INTO erreserbaelementua (idErreserba, idEspazioa) VALUES (@idErreserba, @idEspazioa)";

            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, db.conn))
            {
                ErreserbaKudeaketa ek = new ErreserbaKudeaketa();
                insertCmd.Parameters.AddWithValue("@idErreserba", ek.ErreserbaIdLortu(idBazkidea, mota, erreserbaData));
                insertCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);

                insertCmd.ExecuteNonQuery();
            }
        }
        public void ErreEleEzabatu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string deleteQuery = "DELETE ee FROM erreserbaelementua ee " +
                                 "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                 "WHERE ee.idEspazioa = @idEspazioa AND er.idBazkidea = @idBazk " +
                                 "AND er.mota = @mota AND er.data = @data";

            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, db.conn))
            {
                deleteCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);
                deleteCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
                deleteCmd.Parameters.AddWithValue("@mota", mota);
                deleteCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                deleteCmd.ExecuteNonQuery();
            }
        }

    }

}
