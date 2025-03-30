namespace ElkarGune.Interfazeak
{
    partial class ErreserbakMenua
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
            this.lbl_ErreKud = new System.Windows.Forms.Label();
            this.lbl_ErreIkus = new System.Windows.Forms.Label();
            this.lbl_ItxiMenu = new System.Windows.Forms.Label();
            this.lbl_Atzera = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ErreKud
            // 
            this.lbl_ErreKud.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ErreKud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ErreKud.Location = new System.Drawing.Point(254, 134);
            this.lbl_ErreKud.Name = "lbl_ErreKud";
            this.lbl_ErreKud.Size = new System.Drawing.Size(455, 434);
            this.lbl_ErreKud.TabIndex = 1;
            this.lbl_ErreKud.Click += new System.EventHandler(this.lbl_ErreKud_Click);
            // 
            // lbl_ErreIkus
            // 
            this.lbl_ErreIkus.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ErreIkus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ErreIkus.Location = new System.Drawing.Point(758, 134);
            this.lbl_ErreIkus.Name = "lbl_ErreIkus";
            this.lbl_ErreIkus.Size = new System.Drawing.Size(455, 434);
            this.lbl_ErreIkus.TabIndex = 2;
            this.lbl_ErreIkus.Click += new System.EventHandler(this.lbl_ErreIkus_Click);
            // 
            // lbl_ItxiMenu
            // 
            this.lbl_ItxiMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ItxiMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ItxiMenu.Location = new System.Drawing.Point(1445, 9);
            this.lbl_ItxiMenu.Name = "lbl_ItxiMenu";
            this.lbl_ItxiMenu.Size = new System.Drawing.Size(58, 63);
            this.lbl_ItxiMenu.TabIndex = 10;
            this.lbl_ItxiMenu.Click += new System.EventHandler(this.lbl_ItxiMenu_Click);
            // 
            // lbl_Atzera
            // 
            this.lbl_Atzera.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Atzera.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Atzera.Location = new System.Drawing.Point(12, 9);
            this.lbl_Atzera.Name = "lbl_Atzera";
            this.lbl_Atzera.Size = new System.Drawing.Size(170, 71);
            this.lbl_Atzera.TabIndex = 67;
            // 
            // ErreserbakMenua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.ERRESERBAK_MENUA;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1522, 696);
            this.Controls.Add(this.lbl_Atzera);
            this.Controls.Add(this.lbl_ItxiMenu);
            this.Controls.Add(this.lbl_ErreIkus);
            this.Controls.Add(this.lbl_ErreKud);
            this.DoubleBuffered = true;
            this.Name = "ErreserbakMenua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErreserbakMenua";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ErreKud;
        private System.Windows.Forms.Label lbl_ErreIkus;
        private System.Windows.Forms.Label lbl_ItxiMenu;
        private System.Windows.Forms.Label lbl_Atzera;
    }
}