using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune.Klaseak
{
    class Erreserba
    {
        private int idErreserba;
        private int idBazkidea;
        private int mota;
        private DateTime data;
        public int ErreserbaSartu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string insertQuery = "INSERT INTO erreserba (idBazkidea, mota, data) VALUES (@idBazk, @mota, @data)";
            MySqlCommand insertCmd = new MySqlCommand(insertQuery, db.conn);
            insertCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            insertCmd.Parameters.AddWithValue("@mota", mota);
            insertCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            insertCmd.ExecuteNonQuery();

            // Obtener el nuevo ID
            int newId = (int)insertCmd.LastInsertedId;
            db.conn.Close();
            return newId;
        }
        public void ErreserbaEguneratu(int idErreserba)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string updateQuery = "UPDATE erreserba e SET komentsalak = (SELECT SUM(esp.gaitasuna)FROM erreserbaelementua ee JOIN espazioa esp ON ee.idEspazioa = esp.idEspazioa WHERE ee.idErreserba = e.idErreserba)WHERE e.idErreserba = @idErreserba ";
            MySqlCommand updateCmd = new MySqlCommand(updateQuery, db.conn);
            updateCmd.Parameters.AddWithValue("@idErreserba", idErreserba);
            updateCmd.ExecuteNonQuery();
        }
        public void ErreserbaEzabatu(int idErreserba)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string deleteQuery = "DELETE ee FROM erreserbaelementua ee " +
                                     "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                     "WHERE er.idErreserba = @idErreserba";
            MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, db.conn);
            deleteCmd.Parameters.AddWithValue("@idErreserba", idErreserba);
            deleteCmd.ExecuteNonQuery();
            string deleteQuery1 = "DELETE FROM erreserba WHERE idErreserba = @idErreserba";
            MySqlCommand deleteCmd1 = new MySqlCommand(deleteQuery1, db.conn);
            deleteCmd1.Parameters.AddWithValue("@idErreserba", idErreserba);
            deleteCmd1.ExecuteNonQuery();
        }
        public DataTable ErreserbaIkusi(DateTime data)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string select = "SELECT b.idBazkidea AS 'Bazkidea',e. data AS 'Data', CASE e.mota WHEN 1 THEN 'Bazkaria' WHEN 0 THEN 'Afaria' END AS 'Mota', e.komentsalak AS 'Komentsalak' FROM erreserba e JOIN bazkidea b ON e.idBazkidea = b.idBazkidea WHERE data>=@data ORDER BY data ASC";
            //CONCAT(b.izena, ' ' , b.abizenak)
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
        public DataTable HistorikoaIkusi(int idBazkidea, DateTime data)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT CONCAT(b.izena, ' ' , b.abizenak) AS 'Bazkidea', e.idErreserba AS 'Erreserba zenbakia', e. data AS 'Data', CASE e.mota WHEN 1 THEN 'Bazkaria' WHEN 2 THEN 'Afaria' END AS 'Mota' FROM erreserba e JOIN bazkidea b ON e.idBazkidea = b.idBazkidea WHERE e.idBazkidea = @idBazk AND e.data<@data ORDER BY data DESC";

            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
    }
}
