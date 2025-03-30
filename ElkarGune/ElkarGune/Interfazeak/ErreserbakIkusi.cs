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
    public partial class ErreserbakIkusi : Form
    {
        int idBazkidea = 0;
        DateTime data = DateTime.Today;
        public ErreserbakIkusi()
        {
            InitializeComponent();
            KargatuDatuak();
        }
        public ErreserbakIkusi(int idBazk)
        {
            idBazkidea = idBazk;
            InitializeComponent();
            KargatuDatuak();
        }
        private void KargatuDatuak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT b.idBazkidea AS 'Bazkidea',e. data AS 'Data', CASE e.mota WHEN 1 THEN 'Bazkaria' WHEN 2 THEN 'Afaria' END AS 'Mota', e.komentsalak AS 'Komentsalak' FROM erreserba e JOIN bazkidea b ON e.idBazkidea = b.idBazkidea WHERE data>=@data";
            //CONCAT(b.izena, ' ' , b.abizenak)
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_Frak.DataSource = dt;

            db.conn.Close();
        }


        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            ErreserbakMenua menu = new ErreserbakMenua(idBazkidea);
            menu.Show();
            this.Close();
        }
    }
}
