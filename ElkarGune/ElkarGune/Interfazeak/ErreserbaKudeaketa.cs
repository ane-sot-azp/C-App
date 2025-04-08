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
            if (erreserbaData != DateTime.MinValue && (mota == 0 || mota == 1))
            {
                Label label = sender as Label;
                if (label != null)
                {
                    int idEspazioa = Convert.ToInt32(label.Tag);
                    KontrolErreserbak ke = new KontrolErreserbak();
                    ke.ErreserbaKudeatu(idEspazioa, idBazkidea, mota, erreserbaData);
                    EspazioKoloreak();
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
                    KontrolErreserbak ke = new KontrolErreserbak();
                    ke.Erreserbatu(idBazkidea, mota, erreserbaData);
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
            lbl_bazkaria.BackColor = Color.FromArgb(50, 141, 115, 26);
            lbl_afaria.BackColor = Color.Transparent;
            lbl_afaria.Refresh();
            lbl_bazkaria.Refresh();
            ErreEleIkusi();
        }
        private void lbl_afaria_Click(object sender, EventArgs e)
        {
            mota = 0;
            label3.Text = mota.ToString();
            lbl_afaria.BackColor = Color.FromArgb(50, 141, 115, 26);
            lbl_bazkaria.BackColor = Color.Transparent;
            lbl_afaria.Refresh();
            lbl_bazkaria.Refresh();
            ErreEleIkusi();

        }
        public void ErreEleIkusi()
        {
            KontrolErreserbak ke = new KontrolErreserbak();
            DataTable dt = ke.ErreEleIkusi(idBazkidea, mota, erreserbaData);
            dgv_erres.DataSource = dt;
            EspazioKoloreak();
        }
        public void EspazioKoloreak()
        {
            var kontrol = new KontrolErreserbak();

            var egoerak = kontrol.LortuEspazioEgoerak();
            foreach (var (index, egoera) in egoerak)
            {
                Label label = this.Controls.Find("lbl_esp" + index, true).FirstOrDefault() as Label;
                if (label != null)
                {
                if (egoera != 0)
                    KoloreBeltza(label);
                else
                    KoloreGrisa(label);
                }
            }

            var erreserbak = kontrol.LortuErreserbak(mota, erreserbaData);
            foreach (var (espazioaId, bazkideaId) in erreserbak)
            {
                Label label = this.Controls.Find("lbl_esp" + espazioaId, true).FirstOrDefault() as Label;
                if (label != null)
                {
                if (bazkideaId == idBazkidea)
                    KoloreUrdina(label);
                else
                    KoloreGorria(label);
                }
            }
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
        public void MezuaErreserba(){
            MessageBox.Show("Dagoeneko beste bazkide batek erreserbatu du!");
        }
        public void MezuaEspazioa(){
            MessageBox.Show("Elementu hau ez dago erabilgarri");
        }       
        public void lbl_erreserbatu_Click(object sender, EventArgs e)
        {
            DialogResult erantzuna = MessageBox.Show("Erreserba egitera/eguneratzera zoaz. Erreserbaren datuak ongi daude?",
                                 "Erreserba konfirmatu",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (erantzuna == DialogResult.Yes)
            {
                KontrolErreserbak ke = new KontrolErreserbak();
                ke.Erreserbatu(idBazkidea, mota, erreserbaData);
                ErreserbakMenua menu = new ErreserbakMenua(idBazkidea);
                    menu.Show();
                    this.Close();
            }
        }
        public void lbl_ezabatu_Click(object sender, EventArgs e)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();
            KontrolErreserbak ke = new KontrolErreserbak();
            if(ke.Ezabatu(idBazkidea, mota, erreserbaData)){
            DialogResult erantzuna = MessageBox.Show(erreserbaData.ToString("yyyy-MM-dd") + " eguneko erreserba ezabatzera zoaz. Ziur zaude?",
                                         "Erreserba ezabatu",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                if (erantzuna == DialogResult.Yes)
                {
                    KontrolErreserbak ke2 = new KontrolErreserbak();
                    ke2.ErreserbaEzabatu(ke2.ErreserbaIdLortu(idBazkidea, mota, erreserbaData));

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
        
    }

}
