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
    public partial class Menu: Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

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
            Kontsumizioak kontsumizioak = new Kontsumizioak();
            kontsumizioak.Show();
        }
    }
}
