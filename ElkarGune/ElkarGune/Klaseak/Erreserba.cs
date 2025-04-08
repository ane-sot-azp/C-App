using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElkarGune.Interfazeak;

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

            string select = "SELECT e.idErreserba AS 'Erreserba zenbakia', e. data AS 'Data', CASE e.mota WHEN 1 THEN 'Bazkaria' WHEN 2 THEN 'Afaria' END AS 'Mota' FROM erreserba e JOIN bazkidea b ON e.idBazkidea = b.idBazkidea WHERE e.idBazkidea = @idBazk AND e.data<@data ORDER BY data DESC";

            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
        public void Erreserbatu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            KontrolErreserbak ke = new KontrolErreserbak();

            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            // Verificar si ya existe una reserva para esta mesa
            string checkQuery = "SELECT COUNT(*) FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            checkCmd.Parameters.AddWithValue("@mota", mota);
            checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (exists > 0)
            {
                int idErreserba = ErreserbaIdLortu(idBazkidea, mota, erreserbaData);

                ke.ErreserbaEguneratu(idErreserba);
            }
        }
        public int ErreserbaIdLortu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string query = "SELECT idErreserba FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@mota", mota);
            cmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                db.conn.Close();
                return Convert.ToInt32(result);
            }
            KontrolErreserbak ke = new KontrolErreserbak();
            return ke.ErreserbaSartu(idBazkidea, mota, erreserbaData);

        }
        public bool Ezabatu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
           string checkQuery = "SELECT COUNT(*) FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            checkCmd.Parameters.AddWithValue("@mota", mota);
            checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (exists > 0)
            {
                return true;                
            }else{
                return false;
            }
        }
        public void ErreserbaKudeatu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select1 = "SELECT COUNT(*) FROM espazioa WHERE idEspazioa=@idEspazioa AND egoera=1";
            MySqlCommand selectCmd = new MySqlCommand(select1, db.conn);
            selectCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);

            int egoera = Convert.ToInt32(selectCmd.ExecuteScalar());
            KontrolErreserbak ke = new KontrolErreserbak();
            if (egoera > 0)
            {
                if (ErreserbaDagoeneko(idEspazioa, idBazkidea, mota, erreserbaData)) // Comprobar si la reserva ya existe
                {
                    ke.ErreEleEzabatu(idEspazioa, idBazkidea, mota, erreserbaData);
                     // Eliminar reserva existente
                }
                else
                {
                    if (ke.EspazioaErreserbatutaDago(idEspazioa, mota, erreserbaData)) // Verificar si otro usuario lo reservó
                    {
                        ErreserbaKudeaketa ek = new ErreserbaKudeaketa();
                        ek.EspazioKoloreak();

                    }
                    else
                    {
                        ke.ErreEleSartu(idEspazioa, idBazkidea, mota, erreserbaData); // Insertar nueva reserva
                    }
                }
            }
            else
            {
                ErreserbaKudeaketa ek = new ErreserbaKudeaketa();
                ek.MezuaEspazioa();
            }
            db.conn.Close();
            ErreserbaKudeaketa ek1 = new ErreserbaKudeaketa();
            ek1.ErreEleIkusi();
        }
        public bool ErreserbaDagoeneko(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string checkQuery = "SELECT COUNT(*) FROM erreserbaelementua ee " +
                                "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                "WHERE ee.idEspazioa = @idEspazioa AND er.idBazkidea = @idBazk " +
                                "AND er.mota = @mota AND er.data = @data";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn))
            {
                checkCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);
                checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
                checkCmd.Parameters.AddWithValue("@mota", mota);
                checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                return Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
            }
        }
    }
}
