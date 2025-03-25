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

namespace ElkarGune
{

    public partial class Kopurua : Form
    {
        private float prezioa;
        private int idBazk;

        public Kopurua(int idProduktua, int idBazkidea)
        {
            InitializeComponent();
            int idProdutkua = idProduktua;
            idBazk = idBazkidea;
            idProd.Text = idProdutkua.ToString();
        }

        private void Kopurua_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            int idProduktua = Convert.ToInt32(idProd.Text);
            string query = "SELECT * FROM bodega WHERE idProduktua=" + idProduktua;

            // Crea el comando para la consulta
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = query;

            // Ejecuta la consulta y obtiene los resultados
            MySqlDataReader dr = cmd.ExecuteReader();

            int index = 1;
            if (dr.Read())
            {
                // Crea un DataTable y carga los resultados

                String izena = dr["izena"].ToString();
                prezioa = Convert.ToSingle(dr["salmentaPrezioa"]);
                String imageUrl = dr["irudia"].ToString();

                lbl_izena.Text = izena;
                lbl_preziobase.Text = prezioa.ToString("F2") + "€";
                pictureBox1.Load(imageUrl);

            }
        }

        private void kop_1_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "1";
                kalkulatu();
            }

        }

        private void kop_2_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "2";
                kalkulatu();
            }

        }

        private void kop_3_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "3";
                kalkulatu();
            }
        }

        private void kop_4_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "4";
                kalkulatu();
            }
        }

        private void kop_5_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "5";
                kalkulatu();
            }
        }

        private void kop_6_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "6";
                kalkulatu();
            }
        }

        private void kop_7_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "7";
                kalkulatu();
            }
        }

        private void kop_8_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "8";
                kalkulatu();
            }
        }

        private void kop_9_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "9";
                kalkulatu();
            }
        }

        private void kop_0_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length > 0 && lbl_kopurua.Text.Length < 2)
            {
                lbl_kopurua.Text += "0";
                kalkulatu();
            }

        }

        private void kop_ezab_Click(object sender, EventArgs e)
        {
            if (lbl_kopurua.Text.Length > 1)
            {
                lbl_kopurua.Text = lbl_kopurua.Text.Substring(0, lbl_kopurua.Text.Length - 1);
            }
            else if (lbl_kopurua.Text.Length == 1)
            {
                lbl_kopurua.Text = "";
            }
            kalkulatu();
        }
        public void kalkulatu()
        {
            if (lbl_kopurua.Text != "")
            {
                int kop = Convert.ToInt32(lbl_kopurua.Text);
                float total = kop * prezioa;
                lbl_prezioa.Text = total.ToString("F2") + "€";
            }
            else
            {
                lbl_prezioa.Text = null;
            }

        }

        private void kop_ok_Click(object sender, EventArgs e)
        {
            KontrolKontsumizioak kk = new KontrolKontsumizioak();
            int idProduktua = Convert.ToInt32(idProd.Text);
            int kopurua = Convert.ToInt32(lbl_kopurua.Text);
            DateTime data = DateTime.Today;

            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = select;
            cmd.Parameters.AddWithValue("@idBazkidea", idBazk);
            cmd.Parameters.AddWithValue("@data", data);


            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int fraZkia = Convert.ToInt32(dr["idFaktura"]);
                //MessageBox.Show("Produktua: " + idProduktua + " Kopurua: " + kopurua + " FraZkia: " + fraZkia);
                kk.Txertatu(idProduktua, kopurua, fraZkia, prezioa);
            }
            else
            {
                MessageBox.Show("Ups");
            }
            this.Close();
        }
    }
}
