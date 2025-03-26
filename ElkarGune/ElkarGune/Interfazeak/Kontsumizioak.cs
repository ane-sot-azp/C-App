using ElkarGune.Interfazeak;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
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
    public partial class Kontsumizioak : Form
    {
        public virtual int idBazk { get; set; }
        private int fraZkia;
        public Kontsumizioak()
        {
            InitializeComponent();
        }
        public Kontsumizioak(int idBazkidea)
        {
            InitializeComponent();
            idBazk = idBazkidea;
            label1.Text=idBazk.ToString();
        }
        public Kontsumizioak(int idBazkidea, int fraZenbakia)
        {
            InitializeComponent();
             idBazk = idBazkidea;
            fraZkia = fraZenbakia;
        }

        private void lbl_ItxiMenu_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Menura bueltatu nahi duzu?",
                                         "Konfirmatu irteera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                Menu menu = new Menu(idBazk);
                menu.Show();
                this.Close(); // Cierra la aplicación si el usuario elige "Bai" (Sí)
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

        private void Kontsumizioak_Load(object sender, EventArgs e)
        {

        }

        private void lbl_Ordaindu_Click(object sender, EventArgs e)
        {

            Konfirmazioa konfirmazioa = new Konfirmazioa(idBazk, fraZkia);
            konfirmazioa.Show();
            this.Close();
        }


    }
}
