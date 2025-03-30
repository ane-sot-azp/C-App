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
    public partial class ErreserbakMenua: Form
    {
        int idBazkidea = 0;
        public ErreserbakMenua()
        {
            InitializeComponent();
        }
        public ErreserbakMenua(int idBazk)
        {
            InitializeComponent();
            idBazkidea=idBazk;
        }

        private void lbl_ErreKud_Click(object sender, EventArgs e)
        {
            ErreserbaKudeaketa erreserbakud = new ErreserbaKudeaketa(idBazkidea);
            erreserbakud.Show();
            this.Close();

        }

        private void lbl_ErreIkus_Click(object sender, EventArgs e)
        {
            ErreserbakIkusi erreserbakIkusi = new ErreserbakIkusi(idBazkidea);
            erreserbakIkusi.Show();
            this.Close();
        }

        private void lbl_ItxiMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }
    }
}
