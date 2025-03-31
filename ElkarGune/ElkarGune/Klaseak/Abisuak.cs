using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune.Klaseak
{
    class Abisuak
    {
        private int idAbisua;
        private string mezua;
        private DateTime data;
        public DataTable AbisuakIkusi()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT data AS 'Data', mezua AS 'Mezua'FROM abisuak";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            return dt;
        }
    }
}
