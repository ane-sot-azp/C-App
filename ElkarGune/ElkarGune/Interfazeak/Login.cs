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
            string erabiltzailea = txt_Erabiltzailea.Text.Trim();
            string pasahitza = txt_Pasahitza.Text.Trim();

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

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int idBazkidea = Convert.ToInt32(dr["IdBazkidea"]);
                        bool isAdmin = dr["admin"] != DBNull.Value && Convert.ToInt32(dr["admin"]) == 1;
                        dr.Close(); // Cierra el DataReader antes de abrir otro formulario

                        this.Hide();
                        if (isAdmin)
                        {
                            Admin admin = new Admin(idBazkidea, erabiltzailea);
                            admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ongi etorri " + erabiltzailea);
                            Menu menu = new Menu(idBazkidea, erabiltzailea);
                            menu.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erabiltzailea edo pasahitza ez da zuzena");
                        txt_Pasahitza.Text = "";
                    }
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

        private void txt_Pasahitza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Llama al método cuando el usuario presiona Enter
                login();
                e.SuppressKeyPress = true; // Evita que se haga el sonido de "beep"
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
