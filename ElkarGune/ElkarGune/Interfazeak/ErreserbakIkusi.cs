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
    public partial class ErreserbakIkusi : Form
    {
        int idBazkidea = 0;
        DateTime data = DateTime.Today;
        public ErreserbakIkusi()
        {
            InitializeComponent();
            ErreserbaIkusi();
        }
        public ErreserbakIkusi(int idBazk)
        {
            idBazkidea = idBazk;
            InitializeComponent();
            ErreserbaIkusi();
        }
        private void ErreserbaIkusi()
        {
            KontrolErreserbak ke = new KontrolErreserbak();
            DataTable dt = ke.ErreserbaIkusi(data);
            dgv_Frak.DataSource = dt;
        }
        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            ErreserbakMenua menu = new ErreserbakMenua(idBazkidea);
            menu.Show();
            this.Close();
        }

        
    }
}
