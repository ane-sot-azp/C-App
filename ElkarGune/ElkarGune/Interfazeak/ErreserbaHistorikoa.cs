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
    public partial class ErreserbaHistorikoa : Form
    {
        int idBazkidea = 0;
        DateTime data = DateTime.Today;
        public ErreserbaHistorikoa()
        {
            InitializeComponent();
        }
        public ErreserbaHistorikoa(int idBazk)
        {
            idBazkidea = idBazk;
            InitializeComponent();
            KargatuDatuak();
        }
        private void KargatuDatuak()
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT CONCAT(b.izena, ' ' , b.abizenak) AS 'Bazkidea', e.idErreserba AS 'Erreserba zenbakia', e. data AS 'Data', CASE e.mota WHEN 1 THEN 'Bazkaria' WHEN 2 THEN 'Afaria' END AS 'Mota' FROM erreserba e JOIN bazkidea b ON e.idBazkidea = b.idBazkidea WHERE e.idBazkidea = @idBazk AND e.data<@data";

            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@idBazk", idBazkidea);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgv_Frak.DataSource = dt;

            db.conn.Close();
        }

        private void lbl_itxi_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(idBazkidea);
            menu.Show();
            this.Close();
        }
    }
}
