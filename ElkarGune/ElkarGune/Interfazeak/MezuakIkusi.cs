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
    public partial class MezuakIkusi: Form
    {
        int idBazkidea = 0;
        public MezuakIkusi()
        {
            InitializeComponent();
        }
        public MezuakIkusi(int idBazk)
        {
            InitializeComponent();
            idBazkidea=idBazk;
            KargatuDatuak();
        }
        private void KargatuDatuak()
        {
            KontrolMezuak km = new KontrolMezuak();
            DataTable dt = km.MezuakIkusi(idBazkidea);
            
            dgv_Frak.DataSource = dt;
        }

        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }
    }
}
