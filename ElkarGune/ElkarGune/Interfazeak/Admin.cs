using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ElkarGune
{
    public partial class Admin : Form
    {

        public Admin(int idBazkidea, String erabiltzailea)
        {
            InitializeComponent();
            lbl_erab.Text = erabiltzailea;
            lbl_IdBaz.Text = idBazkidea.ToString();
            label2.Text = "Kaixo " + erabiltzailea + "!";
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;

                
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = currentDir + @"ElkarGuneJava.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process == null)
                    {
                        MessageBox.Show("El proceso no pudo iniciarse.");
                        return;
                    }

                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(output))
                    {
                        MessageBox.Show("Salida: " + output);
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el archivo: " + ex.Message);
            }
            Application.Exit();
        }

        private void btn_Bazkidea_Click(object sender, EventArgs e)
        {
            String erabiltzailea = lbl_erab.Text;
            int idBazkidea = Convert.ToInt32(lbl_IdBaz.Text);
            this.Close();
            Menu menu = new Menu(idBazkidea, erabiltzailea);
            menu.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
