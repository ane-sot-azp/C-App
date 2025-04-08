using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune.Kontrolak
{
    class Logina
    {
        public MySqlDataReader LoginaEgin(string erabiltzailea, string pasahitza)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string query = "SELECT * FROM bazkidea WHERE erabiltzailea=@erabiltzailea AND pasahitza=@pasahitza";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@erabiltzailea", erabiltzailea);
            cmd.Parameters.AddWithValue("@pasahitza", pasahitza);
            return cmd.ExecuteReader();
            db.conn.Close();
        }
    }
}
