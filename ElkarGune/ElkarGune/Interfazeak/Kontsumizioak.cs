using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune
{
    public partial class Kontsumizioak: Form
    {
        private int idBazk;
        public Kontsumizioak()
        {
            InitializeComponent();
        }
        public Kontsumizioak(int idBazkidea)
        {
            InitializeComponent();
            idBazk = idBazkidea;
        }

        private void lbl_ItxiMenu_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Programatik atera nahi duzu?",
                                         "Konfirmatu irteera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                Application.Exit(); // Cierra la aplicación si el usuario elige "Bai" (Sí)
            }
        }

        private void lbl_SaioaItxiKontsumizioak_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Saioa itxi nahi duzu?",
                                         "Konfirmatu saio itxiera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void lbl_Ardoak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 1;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        private void lbl_Sagardoak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 5;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        private void lbl_Garagardoak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 3;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        private void lbl_Freskagarriak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 2;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        private void lbl_Kafeak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 6;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        private void lbl_Likoreak_Click(object sender, EventArgs e)
        {
            int idProduktuMota = 4;
            KontsumizioElementuak kElem = new KontsumizioElementuak(idProduktuMota, idBazk);
            kElem.Show();
        }

        
    }
}
