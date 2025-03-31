using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune.Klaseak
{
    class Mezuak
    {
        private int idMezua;
        private int idBazkidea;
        private string mezua;
        private DateTime data;
        public DataTable MezuakIkusi(int idBazkidea)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string select = "SELECT data AS 'Data', mezua AS 'Mezua'FROM mezuak where idBazkidea = @idBazk";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
    }
}
