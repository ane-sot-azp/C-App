using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ElkarGune
{
    class DBKonexioa : IDisposable
    {
        //Local
        // public virtual string Servidor { get; set; } = "localhost";
        // public virtual string Puerto { get; set; } = "3306";
        // public virtual string Usuario { get; set; } = "root";
        // public virtual string Contraseña { get; set; } = "1MG2024";
        // public virtual string BaseDeDatos { get; set; } = "elkargune";
        // public virtual string SslMode { get; set; } = "None";

        //Serbidorea

        public virtual string Servidor { get; set; } = "172.16.237.119";
        public virtual string Puerto { get; set; } = "3306";
        public virtual string Usuario { get; set; } = "java";
        public virtual string Contraseña { get; set; } = "1mg3";
        public virtual string BaseDeDatos { get; set; } = "elkargune";
        public virtual string SslMode { get; set; } = "None";

        // MySqlConnection instantzia
        public MySqlConnection conn;

        // Konexio katea sortzeko metodoa
        public string konexioKatea()
        {
            return $"Server={Servidor};Port={Puerto};Database={BaseDeDatos};User ID={Usuario};Password={Contraseña};SslMode={SslMode};";
        }

        // Konexioa lortzeko metodoa
        public void konektatu()
        {
            conn = new MySqlConnection(konexioKatea());
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konexio errorea: " + ex.Message);
            }
        }

        // **IDisposable inplementatu**
        public void Dispose()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}

