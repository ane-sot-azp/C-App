using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune
{
    class DBKonexioa
    {
        public virtual string Servidor { get; set; } = "localhost";
        public virtual string Puerto { get; set; } = "3306";
        public virtual string Usuario { get; set; } = "root";
        public virtual string Contraseña { get; set; } = "1MG2024";
        public virtual string BaseDeDatos { get; set; } = "elkargune";
        public virtual string SslMode { get; set; } = "None";

        // Konexio katea sortzeko metodoa
        public string konexioKatea()
        {
            return $"Server={Servidor};Port={Puerto};Database={BaseDeDatos};User ID={Usuario};Password={Contraseña};SslMode={SslMode};";
        }


        //konexioa lortzeko metodoa
        public MySqlConnection conn;
        public void konektatu()
        {
            conn = new MySqlConnection(konexioKatea());
            try
            {
                conn.Open();
                //MessageBox.Show("Ongi konektatu da " + BaseDeDatos + " datu basera.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konexio errorea: " + ex.Message);
            }
        }
    }
}
