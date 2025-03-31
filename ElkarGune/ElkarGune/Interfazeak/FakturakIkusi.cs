using ElkarGune.Kontrolak;
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
    public partial class FakturakIkusi : Form
    {
        int idBazkidea = 0;
        public FakturakIkusi()
        {
            InitializeComponent();
            KargatuDatuak();
        }
        public FakturakIkusi(int idBazk)
        {
            InitializeComponent();
            idBazkidea = idBazk;
            KargatuDatuak();
        }

        private void KargatuDatuak()
        {
            KontrolAdmin ka = new KontrolAdmin();
            DataTable dt = ka.FakturakIkusi(idBazkidea);
            dgv_Frak.DataSource = dt;
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
