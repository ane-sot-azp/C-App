namespace ElkarGune
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Erabiltzailea = new System.Windows.Forms.TextBox();
            this.txt_Pasahitza = new System.Windows.Forms.TextBox();
            this.lbl_Sartu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Erabiltzailea:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pasahitza:";
            // 
            // txt_Erabiltzailea
            // 
            this.txt_Erabiltzailea.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Erabiltzailea.Location = new System.Drawing.Point(193, 152);
            this.txt_Erabiltzailea.Name = "txt_Erabiltzailea";
            this.txt_Erabiltzailea.Size = new System.Drawing.Size(246, 34);
            this.txt_Erabiltzailea.TabIndex = 2;
            // 
            // txt_Pasahitza
            // 
            this.txt_Pasahitza.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pasahitza.Location = new System.Drawing.Point(193, 208);
            this.txt_Pasahitza.Name = "txt_Pasahitza";
            this.txt_Pasahitza.PasswordChar = '·';
            this.txt_Pasahitza.Size = new System.Drawing.Size(246, 34);
            this.txt_Pasahitza.TabIndex = 3;
            // 
            // lbl_Sartu
            // 
            this.lbl_Sartu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Sartu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Sartu.Location = new System.Drawing.Point(210, 335);
            this.lbl_Sartu.Name = "lbl_Sartu";
            this.lbl_Sartu.Size = new System.Drawing.Size(134, 47);
            this.lbl_Sartu.TabIndex = 4;
            this.lbl_Sartu.Click += new System.EventHandler(this.lbl_Sartu_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(831, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 47);
            this.label3.TabIndex = 5;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.FONDO_LOGIN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(882, 410);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Sartu);
            this.Controls.Add(this.txt_Pasahitza);
            this.Controls.Add(this.txt_Erabiltzailea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Erabiltzailea;
        private System.Windows.Forms.TextBox txt_Pasahitza;
        private System.Windows.Forms.Label lbl_Sartu;
        private System.Windows.Forms.Label label3;
    }
}

