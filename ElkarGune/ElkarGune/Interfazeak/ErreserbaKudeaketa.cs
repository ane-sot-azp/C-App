using ElkarGune.Interfazeak;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune
{
    public partial class ErreserbaKudeaketa : Form
    {
        int mota = 0;
        int erreserbaBueltak = 0;
        int idBazkidea = 0;
        DateTime erreserbaData = DateTime.MinValue;
        DateTime gaur = DateTime.Today;
        DateTime fechaLimite = DateTime.Today.AddMonths(2);

        public ErreserbaKudeaketa()
        {
            InitializeComponent();
            data.CustomFormat = " ";
            data.CloseUp += data_CloseUp;
            label3.Text = mota.ToString();
            label4.Text = idBazkidea.ToString();
            ErreEleIkusi();
            LabelEbentoak();
        }
        public ErreserbaKudeaketa(int idBaz)
        {
            InitializeComponent();
            idBazkidea = idBaz;
            data.CustomFormat = " ";
            data.CloseUp += data_CloseUp;
            label3.Text = mota.ToString();
            label4.Text = idBazkidea.ToString();
            ErreEleIkusi();
            LabelEbentoak();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            if (erreserbaData != DateTime.MinValue && mota != 0)
            {
                Label label = sender as Label;
                if (label != null)
                {
                    int idEspazioa = Convert.ToInt32(label.Tag);
                    ErreserbaKudeatu(idEspazioa, label);
                }
            }
            else
            {
                MessageBox.Show("Data eta erreserba mota adierazi behar dituzu lehenengo!");
            }
        }
        private void lbl_itxi_Click(object sender, EventArgs e)
        {

            DialogResult erantzuna = MessageBox.Show("Orain bueltatzen bazara, erreserba gordeko da. Ziur zaude bueltatu nahi duzula?",
                                         "Konfirmatu irteera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                DialogResult erantzuna2 = MessageBox.Show("Zure erreserba gorde egingo da! Ziur zaude?",
                                         "Konfirmatu irteera",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                if (erantzuna2 == DialogResult.Yes)
                {
                    Erreserbatu();
                    ErreserbakMenua menu = new ErreserbakMenua(idBazkidea);
                    menu.Show();
                    this.Close();
                }
            }
        }
        private void data_CloseUp(object sender, EventArgs e)
        {
            if (!data.Checked) return; // Si el DateTimePicker no está activado, salir.

            data.Format = DateTimePickerFormat.Short;
            DateTime gaur = DateTime.Today; // Fecha actual
            DateTime fechaLimite = gaur.AddMonths(2); // Fecha límite (hoy + 2 meses)

            if (data.Value >= gaur)
            {
                erreserbaData = data.Value;
                label2.Text = erreserbaData.ToString();

                if (erreserbaData > fechaLimite)
                {
                    MessageBox.Show("Ezin duzu data horretarako erreserbarik egin oraindik. Gehienez " + fechaLimite.ToString("yyyy-MM-dd") + " arte egin ditzazkezu erreserbak!");
                    data.CustomFormat = " "; // Borra la fecha visualmente
                    data.Value = fechaLimite;
                }
            }
            else
            {
                MessageBox.Show("Sartutako data ez da baliozkoa!");
                data.CustomFormat = " ";
                data.Value = gaur;
            }
            ErreEleIkusi();
        }
        private void lbl_bazkaria_Click(object sender, EventArgs e)
        {
            mota = 1;
            label3.Text = mota.ToString();
            ErreEleIkusi();
        }
        private void lbl_afaria_Click(object sender, EventArgs e)
        {
            mota = 0;
            label3.Text = mota.ToString();
            ErreEleIkusi();

        }
        private void ErreEleIkusi()
        {
            KontrolErreserbak ke = new KontrolErreserbak();
            DataTable dt = ke.ErreEleIkusi(idBazkidea, mota, erreserbaData);
            dgv_erres.DataSource = dt;
            ErreserbaKoloreak();
        }
        private void ErreserbaKoloreak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string select1 = "SELECT egoera FROM espazioa";
            using (MySqlCommand cmd1 = new MySqlCommand(select1, db.conn))
            using (MySqlDataReader reader1 = cmd1.ExecuteReader())
            {
                int i = 1; // Contador para asignar a los labels dinámicamente
                while (reader1.Read() && i <= 21)  // Leer cada fila del resultado
                {
                    int egoera = Convert.ToInt32(reader1["egoera"]); // Obtener el valor de egoera

                    Label label = this.Controls.Find("lbl_esp" + i, true).FirstOrDefault() as Label;
                    if (label != null)
                    {
                        if (egoera != 0)
                            KoloreBeltza(label);
                        else
                            KoloreGrisa(label);
                    }

                    i++; // Incrementar el contador para el siguiente label
                }
            }
            string select = "SELECT e.egoera, ee.idEspazioa, er.idBazkidea, e.izena " +
                            "FROM espazioa e " +
                            "JOIN erreserbaelementua ee ON e.idEspazioa = ee.idEspazioa " +
                            "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                            "WHERE er.mota = @mota AND er.data = @data";

            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@mota", mota);
            cmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader["idEspazioa"] != DBNull.Value)
                {
                    int espazioZKia = Convert.ToInt32(reader["idEspazioa"]);
                    int rowIdBazkidea = Convert.ToInt32(reader["idBazkidea"]);

                    Label label = this.Controls.Find("lbl_esp" + espazioZKia, true).FirstOrDefault() as Label;

                    if (rowIdBazkidea == idBazkidea)
                    {
                        KoloreUrdina(label);
                    }
                    else
                    {
                        KoloreGorria(label);
                    }
                }

            }
            // Close the database connection
            db.conn.Close();
        }    
        public void KoloreGorria(Label label)
        {
            if (label != null)
            {
                label.ForeColor = Color.FromArgb(255, 255, 0, 0);
                label.BackColor = Color.FromArgb(50, 255, 0, 0);
                label.Refresh();
            }
            else
            {
                MessageBox.Show("Label is null");
            }
        }
        public void KoloreUrdina(Label label)
        {
            if (label != null)
            {
                label.ForeColor = Color.FromArgb(255, 0, 20, 255);
                label.BackColor = Color.FromArgb(50, 0, 20, 255);
                label.Refresh();
            }
            else
            {
                MessageBox.Show("Label is null");
            }
        }
        public void KoloreBeltza(Label label)
        {
            if (label != null)
            {
                label.ForeColor = Color.Black;
                label.BackColor = Color.Transparent;
                label.Refresh();
            }
            else
            {
                MessageBox.Show("Label is null");
            }
        }
        public void KoloreGrisa(Label label)
        {
            if (label != null)
            {
                label.ForeColor = Color.FromArgb(255, 0, 0, 0);
                label.BackColor = Color.FromArgb(50, 0, 0, 0);
                label.Refresh();
            }
            else
            {
                MessageBox.Show("Label is null");
            }
        }
        public void LabelEbentoak()
        {
            for (int i = 1; i <= 21; i++)
            {
                Label label = this.Controls.Find("lbl_esp" + i, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Click += Label_Click;
                }
            }
        }
        public void ErreserbaKudeatu(int idEspazioa, Label label)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select1 = "SELECT COUNT(*) FROM espazioa WHERE idEspazioa=@idEspazioa AND egoera=1";
            MySqlCommand selectCmd = new MySqlCommand(select1, db.conn);
            selectCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);

            int egoera = Convert.ToInt32(selectCmd.ExecuteScalar());
            KontrolErreserbak ke = new KontrolErreserbak();
            if (egoera > 0)
            {
                if (ErreserbaDagoeneko(idEspazioa)) // Comprobar si la reserva ya existe
                {
                    ke.ErreEleEzabatu(idEspazioa, idBazkidea, mota, erreserbaData); // Eliminar reserva existente
                }
                else
                {
                    if (EspazioaErreserbatutaDago(idEspazioa)) // Verificar si otro usuario lo reservó
                    {
                        MessageBox.Show("Dagoeneko beste bazkide batek erreserbatu du!");
                    }
                    else
                    {
                        ke.ErreEleSartu(idEspazioa, idBazkidea, mota, erreserbaData); // Insertar nueva reserva
                    }
                }
            }
            else
            {
                MessageBox.Show("Elementu hau ez dago erabilgarri");
            }
            db.conn.Close();
            ErreEleIkusi();
        }
        public bool ErreserbaDagoeneko(int idEspazioa)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string checkQuery = "SELECT COUNT(*) FROM erreserbaelementua ee " +
                                "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                "WHERE ee.idEspazioa = @idEspazioa AND er.idBazkidea = @idBazk " +
                                "AND er.mota = @mota AND er.data = @data";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn))
            {
                checkCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);
                checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
                checkCmd.Parameters.AddWithValue("@mota", mota);
                checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                return Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
            }
        }
        public bool EspazioaErreserbatutaDago(int idEspazioa)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            string checkQuery = "SELECT COUNT(*) FROM erreserbaelementua ee " +
                                "JOIN erreserba er ON ee.idErreserba = er.idErreserba " +
                                "WHERE ee.idEspazioa = @idEspazioa AND er.mota = @mota AND er.data = @data";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn))
            {
                checkCmd.Parameters.AddWithValue("@idEspazioa", idEspazioa);
                checkCmd.Parameters.AddWithValue("@mota", mota);
                checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

                return Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
            }
        }
        public int ErreserbaIdLortu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string query = "SELECT idErreserba FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@mota", mota);
            cmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                db.conn.Close();
                return Convert.ToInt32(result);
            }
            KontrolErreserbak ke = new KontrolErreserbak();
            return ke.ErreserbaSartu(idBazkidea, mota, erreserbaData);
            
        }
        public void lbl_erreserbatu_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Erreserba egitera/eguneratzera zoaz. Erreserbaren datuak ongi daude?",
                                 "Erreserba konfirmatu",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                Erreserbatu();
            }
        }
        public void lbl_ezabatu_Click(object sender, EventArgs e)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            // Verificar si ya existe una reserva para esta mesa
            string checkQuery = "SELECT COUNT(*) FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            checkCmd.Parameters.AddWithValue("@mota", mota);
            checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (exists > 0)
            {
                int idErreserba = ErreserbaIdLortu(idBazkidea, mota, erreserbaData);
                MessageBox.Show(idErreserba.ToString());
                DialogResult erantzuna = MessageBox.Show(erreserbaData.ToString("yyyy-MM-dd") + " eguneko erreserba ezabatzera zoaz. Ziur zaude?",
                                         "Erreserba ezabatu",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                if (erantzuna == DialogResult.Yes)
                {
                    KontrolErreserbak ke = new KontrolErreserbak();
                    ke.ErreserbaEzabatu(idErreserba);
                    
                    ErreEleIkusi(); // Volver al color original
                    DialogResult erantzuna2 = MessageBox.Show("Beste erreserba bat egin nahi duzu?",
                                         "Erreserba berria?",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                    if (erantzuna2 != DialogResult.Yes)
                    {
                        ErreserbakMenua erreserbakMenua = new ErreserbakMenua(idBazkidea);
                        erreserbakMenua.Show();
                        this.Close();
                    }
                }
            }
        }
        public void Erreserbatu()
        {
            KontrolErreserbak ke = new KontrolErreserbak();
            
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            // Verificar si ya existe una reserva para esta mesa
            string checkQuery = "SELECT COUNT(*) FROM erreserba WHERE idBazkidea = @idBazk AND mota = @mota AND data = @data";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            checkCmd.Parameters.AddWithValue("@mota", mota);
            checkCmd.Parameters.AddWithValue("@data", erreserbaData.ToString("yyyy-MM-dd"));

            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (exists > 0)
            {
                int idErreserba = ErreserbaIdLortu(idBazkidea, mota, erreserbaData);

                ke.ErreserbaEguneratu(idErreserba);
                
                ErreserbakMenua erreserbakMenua = new ErreserbakMenua(idBazkidea);
                erreserbakMenua.Show();
                this.Close();

            }
        }
    }

}
