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
    public partial class LoginAdmin: Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Administratzailea");
        }

        private void btn_Bazkidea_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bazkidea");
        }
    }
}
