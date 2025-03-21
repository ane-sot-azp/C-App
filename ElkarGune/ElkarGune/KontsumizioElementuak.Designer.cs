namespace ElkarGune
{
    partial class KontsumizioElementuak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ProdMota = new System.Windows.Forms.Label();
            this.taula1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.taula1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ProdMota
            // 
            this.lbl_ProdMota.Location = new System.Drawing.Point(156, 94);
            this.lbl_ProdMota.Name = "lbl_ProdMota";
            this.lbl_ProdMota.Size = new System.Drawing.Size(44, 16);
            this.lbl_ProdMota.TabIndex = 0;
            // 
            // taula1
            // 
            this.taula1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taula1.Location = new System.Drawing.Point(172, 62);
            this.taula1.Name = "taula1";
            this.taula1.RowTemplate.Height = 24;
            this.taula1.Size = new System.Drawing.Size(872, 565);
            this.taula1.TabIndex = 1;
            // 
            // KontsumizioElementuak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.KOPURUAK;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1522, 696);
            this.Controls.Add(this.taula1);
            this.Controls.Add(this.lbl_ProdMota);
            this.DoubleBuffered = true;
            this.Name = "KontsumizioElementuak";
            this.Text = "KontsumizioElementuak";
            this.Load += new System.EventHandler(this.KontsumizioElementuak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taula1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ProdMota;
        private System.Windows.Forms.DataGridView taula1;
    }
}