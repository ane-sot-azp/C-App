namespace ElkarGune
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Admin = new System.Windows.Forms.Button();
            this.btn_Bazkidea = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_erab = new System.Windows.Forms.Label();
            this.lbl_IdBaz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nola hasi nahi duzu saioa?";
            // 
            // btn_Admin
            // 
            this.btn_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Admin.Location = new System.Drawing.Point(57, 102);
            this.btn_Admin.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(201, 50);
            this.btn_Admin.TabIndex = 1;
            this.btn_Admin.Text = "Administratzailea";
            this.btn_Admin.UseVisualStyleBackColor = true;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Admin_Click);
            // 
            // btn_Bazkidea
            // 
            this.btn_Bazkidea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bazkidea.Location = new System.Drawing.Point(315, 102);
            this.btn_Bazkidea.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Bazkidea.Name = "btn_Bazkidea";
            this.btn_Bazkidea.Size = new System.Drawing.Size(201, 50);
            this.btn_Bazkidea.TabIndex = 2;
            this.btn_Bazkidea.Text = "Bazkidea";
            this.btn_Bazkidea.UseVisualStyleBackColor = true;
            this.btn_Bazkidea.Click += new System.EventHandler(this.btn_Bazkidea_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 3;
            // 
            // lbl_erab
            // 
            this.lbl_erab.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_erab.Location = new System.Drawing.Point(12, 9);
            this.lbl_erab.Name = "lbl_erab";
            this.lbl_erab.Size = new System.Drawing.Size(100, 23);
            this.lbl_erab.TabIndex = 11;
            // 
            // lbl_IdBaz
            // 
            this.lbl_IdBaz.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_IdBaz.Location = new System.Drawing.Point(12, 48);
            this.lbl_IdBaz.Name = "lbl_IdBaz";
            this.lbl_IdBaz.Size = new System.Drawing.Size(100, 23);
            this.lbl_IdBaz.TabIndex = 12;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(579, 172);
            this.Controls.Add(this.lbl_IdBaz);
            this.Controls.Add(this.lbl_erab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Bazkidea);
            this.Controls.Add(this.btn_Admin);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin";
            this.Text = " Sartzeko modua";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Admin;
        private System.Windows.Forms.Button btn_Bazkidea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_erab;
        private System.Windows.Forms.Label lbl_IdBaz;
    }
}