﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElkarGune
{
    public partial class KontsumizioElementuak : Form
    {
        private int idBazk;
        public KontsumizioElementuak()
        {
            InitializeComponent();

        }
        public KontsumizioElementuak(int idProduktuMota, int idBazkidea)
        {
            idBazk = idBazkidea;
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                Control pic = Controls.Find("pictureBox" + i, true).FirstOrDefault();
                if (pic is PictureBox)
                {
                    ((PictureBox)pic).SizeMode = PictureBoxSizeMode.Zoom;
                    ((PictureBox)pic).Click += PictureBox_Click;
                }
            }
            KontrolProduktuak kp = new KontrolProduktuak();
            // Ejecuta la consulta y obtiene los resultados
            MySqlDataReader dr = kp.ProduktuakIkusi(idProduktuMota);

            int index = 1;
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            while (dr.Read() && index <= 12)
            {
                // Crea un DataTable y carga los resultados
                String imageUrl = dr["irudia"].ToString();
                int idProduktua = Convert.ToInt32(dr["idProduktua"]);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        string imagePath = Path.Combine(basePath, imageUrl);
                        if (File.Exists(imagePath))
                        {
                            Control pic = Controls.Find("pictureBox" + index, true).FirstOrDefault();
                            if (pic is PictureBox)
                            {
                                ((PictureBox)pic).Load(imagePath);
                                ((PictureBox)pic).Tag = idProduktua;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Imagen no encontrada: " + imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen:" + ex.Message);
                    }
                }
                index++;
            }

            // Cierra el lector y la conexión
            dr.Close();
        }
        private void lbl_ItxiMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag != null)
            {
                int idProduktua = (int)pictureBox.Tag;
                Kopurua kopurua = new Kopurua(idProduktua, idBazk);
                kopurua.Show();                
            }
        }

        
    }
}
