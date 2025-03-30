using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune.Interfazeak
{
    public partial class Mezuak: Form
    {
        int idBazkidea = 0;
        public Mezuak()
        {
            InitializeComponent();
        }
        public Mezuak(int idBazk)
        {
            InitializeComponent();
            idBazkidea=idBazk;
            KargatuDatuak();
        }
        private void KargatuDatuak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT data AS 'Data', mezua AS 'Mezua'FROM mezuak where idBazkidea = @idBazk";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_Frak.DataSource = dt;

            db.conn.Close();
        }

        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }
    }
}
