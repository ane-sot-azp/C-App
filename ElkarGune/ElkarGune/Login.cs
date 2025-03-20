using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lbl_Sartu_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string erabiltzailea = txt_Erabiltzailea.Text;
            string pasahitza = txt_Pasahitza.Text;
            MessageBox.Show(erabiltzailea + " " + pasahitza);

            if (string.IsNullOrEmpty(erabiltzailea) || string.IsNullOrEmpty(pasahitza))
            {
                MessageBox.Show("Erabiltzailea edo pasahitza hutsik dago");
                return;
            }

            try
            {
                string query = "SELECT * FROM bazkidea WHERE erabiltzailea=@erabiltzailea AND pasahitza=@pasahitza";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = db.conn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@erabiltzailea", erabiltzailea);
                cmd.Parameters.AddWithValue("@pasahitza", pasahitza);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    dr.Dispose();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = db.conn;
                    cmd2.CommandText = "SELECT * FROM bazkidea WHERE erabiltzailea='" + erabiltzailea + "' AND pasahitza='" + pasahitza + "' AND admin=1";
                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    if (dr2.Read())
                    {
                        Admin admin = new Admin();
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ongi etorri " + erabiltzailea);
                    this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Erabiltzailea edo pasahitza ez da zuzena");
                }
                

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Errorea: " + ex.Message);
            }
            finally
            {
                db.conn.Close();
            }
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
    }
}
