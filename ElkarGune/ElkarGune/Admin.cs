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
        public Admin(String erabiltzailea)
        {
            InitializeComponent();
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
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
