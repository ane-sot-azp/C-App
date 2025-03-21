using MySql.Data.MySqlClient;
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
    public partial class KontsumizioElementuak: Form
    {
        public KontsumizioElementuak()
        {
            InitializeComponent();
        }
        public KontsumizioElementuak(int idProduktuMota)
        {
            InitializeComponent();

            // Establece la conexión a la base de datos
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            int idPM = idProduktuMota;
            string query = "SELECT * FROM bodega WHERE idProduktuMota=" + idPM;

            // Crea el comando para la consulta
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = query;

            // Ejecuta la consulta y obtiene los resultados
            MySqlDataReader dr = cmd.ExecuteReader();

            // Crea un DataTable y carga los resultados
            DataTable dt = new DataTable();
            dt.Load(dr);

            taula1.DataSource = dt;

            // Cierra el lector y la conexión
            dr.Close();
            db.conn.Close();


        }

        private void KontsumizioElementuak_Load(object sender, EventArgs e)
        {

        }
    }
}
