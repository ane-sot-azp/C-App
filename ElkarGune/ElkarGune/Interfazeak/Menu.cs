using ElkarGune.Interfazeak;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune
{
    public partial class Menu: Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }
        public Menu(int idBazkidea)
        {
            InitializeComponent();
            int idBaz = idBazkidea;
            lbl_idBaz.Text = idBaz.ToString();
        }
        public Menu(int idBazkidea, String erabiltzailea)
        {
            InitializeComponent();
            String erab = erabiltzailea;
            int idBaz = idBazkidea;
            lbl_idBaz.Text = idBaz.ToString();
            lbl_erab.Text = erab;

        }



        private void label3_Click(object sender, EventArgs e)
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

        private void lbl_SaioaItxiMenu_Click(object sender, EventArgs e)
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

        private void lbl_Kontsumizioak_Click(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            KontrolProduktuak kk = new KontrolProduktuak();
            kk.SartuFaktura(idBazkidea);
            this.Close();


        }

        private void lbl_Erreserbak_Click(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            ErreserbakMenua erreserbamenu = new ErreserbakMenua(idBazkidea);
            erreserbamenu.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            FakturakIkusi faktura = new FakturakIkusi(idBazkidea);
            faktura.Show();
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            MezuakIkusi mezuak = new MezuakIkusi(idBazkidea);
            mezuak.Show();
            this.Close();
        }

        private void lbl_Abisuak_Click(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            AbisuaIkusi abisuak = new AbisuaIkusi(idBazkidea);
            abisuak.Show();
            this.Close();

        }

        private void lbl_ErresHist_Click(object sender, EventArgs e)
        {
            int idBazkidea = Convert.ToInt32(lbl_idBaz.Text);
            ErreserbaHistorikoa erresHis = new ErreserbaHistorikoa(idBazkidea);
            erresHis.Show();
            this.Close();
        }
    }
}
