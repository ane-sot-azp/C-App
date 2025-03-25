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
    public partial class Admin: Form
    {
        public Admin(int idBazkidea, String erabiltzailea)
        {
            InitializeComponent();
            String erab = erabiltzailea;
            int idBaz = idBazkidea;
            lbl_erab.Text = erab.ToString();
            lbl_IdBaz.Text = idBazkidea.ToString();
            label2.Text = "Kaixo " + erabiltzailea + "!";
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Administratzaile moduan sartzeko beste programan sartu beharko zara.");
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btn_Bazkidea_Click(object sender, EventArgs e)
        {
            String erabiltzailea = lbl_erab.Text;
            int idBazkidea = Convert.ToInt32(lbl_IdBaz.Text);
            this.Hide();
            Menu menu = new Menu(idBazkidea, erabiltzailea);
            menu.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
