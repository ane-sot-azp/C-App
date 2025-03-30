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
    public partial class Fakturak : Form
    {
        int idBazkidea = 0;
        public Fakturak()
        {
            InitializeComponent();
            KargatuDatuak();
        }
        public Fakturak(int idBazk)
        {
            InitializeComponent();
            idBazkidea = idBazk;
            KargatuDatuak();
        }

        private void KargatuDatuak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT idFaktura AS 'Faktura Zenbakia', erreserbaZkia AS 'Erreserba zenbakia', data AS 'Data', totala AS 'Totala' FROM fakturak WHERE idBazkidea = @bazkideZkia ORDER BY idFaktura DESC";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@bazkideZkia", idBazkidea);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_Frak.DataSource = dt;

            db.conn.Close();
        }

        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_itxi_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }

        
    }
}
