using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune.Klaseak
{
    class Kontsumizioak
    {
        private int idKontsumizioa;
        private int idFaktura;
        private int idProduktua;
        private int kopurua;
        private float prezioa;
        private float subtotala;

        public void SartuKontsumizioa(int idProd, int kop, int fraZkia, float prezioa)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT idProduktua, kopurua FROM kontsumizioak WHERE IdFaktura=@fraZkia AND idProduktua=@idProd";
                    MySqlCommand cmd1 = new MySqlCommand(query, db.conn);
                    cmd1.Parameters.AddWithValue("@fraZkia", fraZkia);
                    cmd1.Parameters.AddWithValue("@idProd", idProd);

                    MySqlDataReader dr = cmd1.ExecuteReader();
                    bool exists = dr.Read(); // Verificar si hay datos
                    int dagoenKop = exists ? Convert.ToInt32(dr["kopurua"]) : 0;
                    dr.Close(); // Cerrar antes de cualquier otra consulta

                    MySqlTransaction tr = db.conn.BeginTransaction(); // Iniciar transacción solo si es necesario

                    if (!exists)
                    {
                        // INSERT porque no existe el producto en la factura
                        string insert = "INSERT INTO kontsumizioak (IdFaktura, idProduktua, kopurua, prezioa) VALUES (@idFra, @idBod, @kop, @prezioa)";
                        MySqlCommand cmd = new MySqlCommand(insert, db.conn, tr);
                        cmd.Parameters.AddWithValue("@idFra", fraZkia);
                        cmd.Parameters.AddWithValue("@idBod", idProd);
                        cmd.Parameters.AddWithValue("@kop", kop);
                        cmd.Parameters.AddWithValue("@prezioa", prezioa);

                        cmd.ExecuteNonQuery();
                        tr.Commit();
                    }
                    else
                    {
                        // Preguntar al usuario si quiere actualizar
                        DialogResult erantzuna = MessageBox.Show($"Dagoeneko {dagoenKop} apuntatu dituzu. Gehiago sartu nahi dituzu?",
                                         "Konfirmatu kopurua",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                        if (erantzuna == DialogResult.Yes)
                        {
                            // UPDATE porque ya existe el producto en la factura
                            string update = "UPDATE kontsumizioak SET kopurua = kopurua + @kop, totala = kopurua * prezioa WHERE idProduktua = @idProd AND IdFaktura = @fakt";
                            MySqlCommand cmd = new MySqlCommand(update, db.conn, tr);
                            cmd.Parameters.AddWithValue("@kop", kop);
                            cmd.Parameters.AddWithValue("@idProd", idProd);
                            cmd.Parameters.AddWithValue("@fakt", fraZkia);

                            cmd.ExecuteNonQuery();
                            tr.Commit();
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea: " + ex.Message);
                }
                finally
                {
                    db.conn.Close();
                }
            }
        }
        public void EzabatuKontsumizioa(int idProd, int fraZkia)
        {
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            if (db.conn.State == ConnectionState.Open)
            {
                MySqlTransaction tr = db.conn.BeginTransaction();

                try
                {
                    DialogResult erantzuna = MessageBox.Show($"Erregistro hau ezabatu nahi duzu?",
                                         "Ezabaketa konfirmatu",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                    if (erantzuna == DialogResult.Yes)
                    {
                        string delete = "DELETE FROM kontsumizioak WHERE IdFaktura = @idfra AND idProduktua = @idbod";
                        MySqlCommand cmd = new MySqlCommand(delete, db.conn, tr);
                        cmd.Parameters.AddWithValue("@idfra", fraZkia);
                        cmd.Parameters.AddWithValue("@idbod", idProd);

                        cmd.ExecuteNonQuery();
                        tr.Commit();
                    }
                    else
                    {
                        tr.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.conn.Close();
                }
            }
        }
        public MySqlDataAdapter KontsumizioZerrenda(int fraZkia){
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT k.idProduktua, b.izena AS 'Produktua', k.prezioa AS 'Prezioa', k.kopurua AS 'Kopurua', k.totala AS 'Totala' FROM produktua b JOIN kontsumizioak k ON b.idProduktua=k.idProduktua WHERE k.IdFaktura = @fraZkia";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@fraZkia", fraZkia);
            return new MySqlDataAdapter(cmd);
        }
        public MySqlDataAdapter KargatuDatuak(int fraZkia){
            DBKonexioa db = new DBKonexioa();
            db.konektatu();

            string select = "SELECT k.idProduktua, b.izena AS 'Produktua', k.prezioa AS 'Prezioa', k.kopurua AS 'Kopurua', k.totala AS 'Totala' FROM produktua b JOIN kontsumizioak k ON b.idProduktua=k.idProduktua WHERE k.IdFaktura = @fraZkia";
            MySqlCommand cmd = new MySqlCommand(select, db.conn);
            cmd.Parameters.AddWithValue("@fraZkia", fraZkia);
            return new MySqlDataAdapter(cmd);
        }
        
    }
}
