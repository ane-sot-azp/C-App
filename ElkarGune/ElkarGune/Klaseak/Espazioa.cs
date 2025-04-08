using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ElkarGune.Klaseak
{
    class Espazioa
    {
        private int idEspazioa;
        private string izena;
        private int gaitasuna;
        private bool egoera;

        public bool EspazioaErreserbatutaDago(int idEspazioa, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string checkQuery = "SELECT COUNT(*) FROM erreserbaelementua ee " +
                                "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                "WHERE ee.idEspazioa = @idEspazioa AND er.mota = @mota AND er.data = @data";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn))
            {
                checkCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);
                checkCmd.Parameters.AddWithValue("@mota", mota);
                checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                return Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
            }
        }
        public List<(int index, int egoera)> LortuEspazioEgoerak()
    {
        List<(int index, int egoera)> egoerak = new List<(int, int)>();
        DBKonexioa db = new DBKonexioa();
        db.konektatu();
        
        string select = "SELECT egoera FROM espazioa";
        using (MySqlCommand cmd = new MySqlCommand(select, db.conn))
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            int i = 1;
            while (reader.Read() && i <= 21)
            {
                int egoera = Convert.ToInt32(reader["egoera"]);
                egoerak.Add((i, egoera));
                i++;
            }
        }

        db.conn.Close();
        return egoerak;
    }

    public List<(int espazioaId, int idBazkidea)> LortuErreserbak(int mota, DateTime data)
    {
        List<(int espazioaId, int idBazkidea)> erreserbak = new List<(int, int)>();
        DBKonexioa db = new DBKonexioa();
        db.konektatu();

        string select = "SELECT e.idEspazioa, er.idBazkidea " +
                        "FROM espazioa e " +
                        "JOIN erreserbaelementua ee ON e.idEspazioa = ee.idEspazioa " +
                        "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                        "WHERE er.mota = @mota AND er.data = @data";

        MySqlCommand cmd = new MySqlCommand(select, db.conn);
        cmd.Parameters.AddWithValue("@mota", mota);
        cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            if (reader["idEspazioa"] != DBNull.Value)
            {
                int espazioaId = Convert.ToInt32(reader["idEspazioa"]);
                int idBazkidea = Convert.ToInt32(reader["idBazkidea"]);
                erreserbak.Add((espazioaId, idBazkidea));
            }
        }

        db.conn.Close();
        return erreserbak;
    }
    }
    
}
