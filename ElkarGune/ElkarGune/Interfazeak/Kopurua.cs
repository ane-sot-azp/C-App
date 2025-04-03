using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string query = "SELECT * FROM produktua WHERE idProduktua=" + idProduktua;

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
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                String imageUrl = dr["irudia"].ToString();

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        string imagePath = Path.Combine(basePath, imageUrl);
                        if (File.Exists(imagePath))
                        {
                            pictureBox1.Load(imagePath);
                        }
                        else
                        {
                            MessageBox.Show("Imagen no encontrada: " + imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen:" + ex.Message);
                    }
                }
                lbl_izena.Text = izena;
                lbl_preziobase.Text = prezioa.ToString("F2") + "€";
                

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
            KontrolProduktuak kk = new KontrolProduktuak();
            int idProduktua = Convert.ToInt32(idProd.Text);

            DateTime data = DateTime.Today;
            if (string.IsNullOrEmpty(lbl_kopurua.Text))
            {
                MessageBox.Show("Kopurua sartu behar duzu jarraitu ahal izateko!");
                return;
            }
            else
            {

                int kopurua = Convert.ToInt32(lbl_kopurua.Text);
                DBKonexioa db = new DBKonexioa();
                db.konektatu();

                string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data AND totala is null";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = db.conn;
                cmd.CommandText = select;
                cmd.Parameters.AddWithValue("@idBazkidea", idBazk);
                cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));


                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int fraZkia = Convert.ToInt32(dr["idFaktura"]);
                    //MessageBox.Show("Produktua: " + idProduktua + " Kopurua: " + kopurua + " FraZkia: " + fraZkia);
                    kk.SartuKontsumizioa(idProduktua, kopurua, fraZkia, prezioa);
                }
                else
                {
                    MessageBox.Show("Ups");
                }
                this.Close();
            }
        }

        private void lbl_ItxiMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
