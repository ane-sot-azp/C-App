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
            
            KontrolProduktuak kk = new KontrolProduktuak();
            MySqlDataAdapter da = kk.KontsumizioZerrenda(fraZkia);
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

        }
        private void KargatuDatuak()
        {
            float totala = 0;
            KontrolProduktuak kk = new KontrolProduktuak();
            MySqlDataAdapter da = kk.KontsumizioZerrenda(fraZkia);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                if (row["Totala"] != DBNull.Value)
                {
                    totala += Convert.ToSingle(row["Totala"]);
                }
            }

            lbl_Totala.Text = totala.ToString("F2") + " €";
            dataGridView1.DataSource = dt;

        }


        private void lbl_Atzera_Click(object sender, EventArgs e)
        {
            //int idBazkidea = Convert.ToInt32(label1.Text);
            KontsumizioakAukeratu kontsumizioak = new KontsumizioakAukeratu(idBazkidea, fraZkia);
            kontsumizioak.Show();
            this.Close();
        }


        private void lab_konfirm_Click(object sender, EventArgs e)
        {
            int fraZkia = 0;
            float totala = 0;
            DialogResult erantzuna = MessageBox.Show("Zuzena da kontsumizioa?",
                                         "Konfirmatu kontsumizioa.",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                try
                {
                    DateTime data = DateTime.Today;
                    KontrolAdmin ka = new KontrolAdmin();
                    MySqlDataReader dr2 = ka.FakturaBilatu(idBazkidea, data);
                    if (dr2.Read())
                    {
                        fraZkia = Convert.ToInt32(dr2["idFaktura"]);
                    }
                    dr2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea faktura bilatzean: " + ex.Message);
                    return;
                }

                try
                {
                    KontrolAdmin ka = new KontrolAdmin();
                    MySqlDataReader dr = ka.FakturaDetailea(fraZkia);
                    while (dr.Read())
                    {
                        totala += Convert.ToSingle(dr["totala"]);
                        int idProd = Convert.ToInt32(dr["idProduktua"]);
                        int kop = Convert.ToInt32(dr["kopurua"]);
                        KontrolProduktuak kk2 = new KontrolProduktuak();
                        kk2.EguneratuProduktua(idProd, kop);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea totala kalkulatzean: " + ex.Message);
                    return;
                }

                if (fraZkia > 0)
                {
                    KontrolAdmin ka = new KontrolAdmin();
                    ka.EguneratuFaktura(fraZkia, totala);
                }
                else
                {
                    MessageBox.Show("Ezin da faktura aurkitu.");
                }
                Menu menu = new Menu(idBazkidea);
                menu.Show();
                this.Close();
            }
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
            double[] porcentajes = {0, 0.50, 0.20, 0.10, 0.20 }; // Asegúrate de que la suma sea 1 o 100%

            // Ajusta la anchura de cada columna basado en los porcentajes
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                // Calcula el ancho de la columna basado en el porcentaje
                int anchoColumna = (int)(anchoTotal * porcentajes[i]);

                // Establece el ancho de la columna
                dataGridView.Columns[i].Width = anchoColumna;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de la fila sea válido (para evitar errores en el encabezado)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // Obtener el valor de una celda por índice de columna
                //string valorCelda = fila.Cells[0].Value?.ToString(); // Cambia 1 por el índice de la columna deseada
                int idProduktua = Convert.ToInt32(fila.Cells[0].Value?.ToString());
                // Obtener el valor de una celda por nombre de columna
                //string idProduktua = fila.Cells["Produktua"].Value?.ToString(); // Cambia "NombreColumna" por el nombre real

                KontrolProduktuak kk = new KontrolProduktuak();
                kk.EzabatuKontsumizioa(idProduktua, fraZkia);
                this.KargatuDatuak();
                
            }
        }
    }
}
