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
    public partial class Abisuak: Form
    {
        int idBazkidea = 0;
        public Abisuak()
        {
            InitializeComponent();
            KargatuDatuak();
        }
        public Abisuak(int idBazk)
        {
            InitializeComponent();
            idBazkidea=idBazk;
            KargatuDatuak();
        }
        private void KargatuDatuak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT data AS 'Data', mezua AS 'Mezua'FROM abisuak";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);

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
