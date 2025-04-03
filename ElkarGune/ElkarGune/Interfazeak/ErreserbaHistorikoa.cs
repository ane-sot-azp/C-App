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
    public partial class ErreserbaHistorikoa : Form
    {
        int idBazkidea = 0;
        DateTime data = DateTime.Today;
        public ErreserbaHistorikoa()
        {
            InitializeComponent();
        }
        public ErreserbaHistorikoa(int idBazk)
        {
            idBazkidea = idBazk;
            InitializeComponent();
            HistorikoaIkusi();
        }
        private void HistorikoaIkusi()
        {
            KontrolErreserbak ke = new KontrolErreserbak();
            DataTable dt = ke.HistorikoaIkusi(idBazkidea, data);
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
