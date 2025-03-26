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

namespace ElkarGune.Interfazeak
{
    public partial class Konfirmazioa: Form
    {
        int idBazkidea;
        int fraZkia;
        public Konfirmazioa()
        {
            InitializeComponent();
        }
        public Konfirmazioa(int idBazk, int fraZenbakia)
        {
            InitializeComponent();
            idBazkidea = idBazk;
            fraZkia = fraZenbakia;
            float totala = 0;
            label1.Text=idBazkidea.ToString();
            DateTime data = DateTime.Today;
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT b.izena AS 'Produktua', k.prezioa AS 'Prezioa', k.kopurua AS 'Kopurua', k.totala AS 'Totala' FROM bodega b JOIN kontsumizioak k ON b.idProduktua=k.IdBodega WHERE k.IdFaktura = @fraZkia";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@fraZkia", fraZkia);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                // Asegúrate de que el valor de 'Totala' es un número decimal.
                if (row["Totala"] != DBNull.Value)
                {
                    totala += Convert.ToSingle(row["Totala"]);
                }
            }

            // Mostrar el total en alguna etiqueta o variable.
            // Puedes mostrarlo en un label o hacer cualquier cosa con el total.
            lbl_Totala.Text = totala.ToString("F2")+" €";

            // Asignar el DataTable como origen de datos del DataGridView
            dataGridView1.DataSource = dt;

            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);

            db.conn.Close();
        }

        private void lbl_Atzera_Click(object sender, EventArgs e)
        {
            //int idBazkidea = Convert.ToInt32(label1.Text);
            Kontsumizioak kontsumizioak = new Kontsumizioak(idBazkidea, fraZkia);
            kontsumizioak.Show();
            this.Close();
        }


        private void lab_konfirm_Click(object sender, EventArgs e)
        {
            int fraZkia = 0;
            float totala = 0;

            try
            {
                DateTime data = DateTime.Today;
                DBKonexioa db2 = new DBKonexioa();
                db2.konektatu();

                string select = "SELECT idFaktura FROM fakturak WHERE idBazkidea=@idBazkidea AND data=@data AND totala is null";
                MySqlCommand cmd2 = new MySqlCommand(select, db2.conn);
                cmd2.Parameters.AddWithValue("@idBazkidea", idBazkidea);
                cmd2.Parameters.AddWithValue("@data", data);

                MySqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    fraZkia = Convert.ToInt32(dr2["idFaktura"]);
                }
                dr2.Close();
                db2.conn.Close(); // Cerramos conexión manualmente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea faktura bilatzean: " + ex.Message);
                return;
            }

            try
            {
                DBKonexioa db = new DBKonexioa();
                db.konektatu();

                string query = "SELECT totala FROM kontsumizioak WHERE IdFaktura=@fraZkia";
                MySqlCommand cmd = new MySqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@fraZkia", fraZkia);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    totala += Convert.ToSingle(dr["totala"]);
                }
                dr.Close();
                db.conn.Close(); // Cerramos conexión manualmente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea totala kalkulatzean: " + ex.Message);
                return;
            }

            if (fraZkia > 0)
            {
                KontrolKontsumizioak kk = new KontrolKontsumizioak();
                kk.KontsumizioaErregistratu(fraZkia, totala);
            }
            else
            {
                MessageBox.Show("Ezin da faktura aurkitu.");
            }
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }

        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Menura bueltatu nahi duzu?",
                                         "Konfirmatu irteera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                Menu menu = new Menu(idBazkidea);
                menu.Show();
                this.Close();  // Cierra la aplicación si el usuario elige "Bai" (Sí)
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ajustar las columnas del DataGridView con porcentajes después de la carga de datos
            AjustarColumnasPorcentaje(dataGridView1);
        }
        private void AjustarColumnasPorcentaje(DataGridView dataGridView)
        {
            // Calcula el ancho total del DataGridView
            int anchoTotal = dataGridView.Width;

            // Define el porcentaje para cada columna (por ejemplo, 30% para la primera columna, 50% para la segunda, etc.)
            double[] porcentajes = { 0.50, 0.20, 0.10, 0.20 }; // Asegúrate de que la suma sea 1 o 100%

            // Ajusta la anchura de cada columna basado en los porcentajes
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                // Calcula el ancho de la columna basado en el porcentaje
                int anchoColumna = (int)(anchoTotal * porcentajes[i]);

                // Establece el ancho de la columna
                dataGridView.Columns[i].Width = anchoColumna;
            }
        }


    }
}
