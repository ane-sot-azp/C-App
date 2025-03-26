namespace ElkarGune.Interfazeak
{
    partial class Konfirmazioa
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
            this.lbl_Atzera = new System.Windows.Forms.Label();
            this.lbl_itxi = new System.Windows.Forms.Label();
            this.lab_konfirm = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Totala = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Atzera
            // 
            this.lbl_Atzera.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Atzera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Atzera.Location = new System.Drawing.Point(10, 21);
            this.lbl_Atzera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Atzera.Name = "lbl_Atzera";
            this.lbl_Atzera.Size = new System.Drawing.Size(165, 58);
            this.lbl_Atzera.TabIndex = 48;
            this.lbl_Atzera.Click += new System.EventHandler(this.lbl_Atzera_Click);
            // 
            // lbl_itxi
            // 
            this.lbl_itxi.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itxi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_itxi.Location = new System.Drawing.Point(1444, 14);
            this.lbl_itxi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_itxi.Name = "lbl_itxi";
            this.lbl_itxi.Size = new System.Drawing.Size(59, 58);
            this.lbl_itxi.TabIndex = 49;
            this.lbl_itxi.Click += new System.EventHandler(this.lbl_itxi_Click);
            // 
            // lab_konfirm
            // 
            this.lab_konfirm.BackColor = System.Drawing.Color.Transparent;
            this.lab_konfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_konfirm.Location = new System.Drawing.Point(1361, 498);
            this.lab_konfirm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_konfirm.Name = "lab_konfirm";
            this.lab_konfirm.Size = new System.Drawing.Size(103, 110);
            this.lab_konfirm.TabIndex = 50;
            this.lab_konfirm.Click += new System.EventHandler(this.lab_konfirm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(263, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(996, 487);
            this.dataGridView1.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(62, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(557, 621);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 39);
            this.label2.TabIndex = 53;
            this.label2.Text = "Totala:";
            // 
            // lbl_Totala
            // 
            this.lbl_Totala.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Totala.Location = new System.Drawing.Point(707, 621);
            this.lbl_Totala.Name = "lbl_Totala";
            this.lbl_Totala.Size = new System.Drawing.Size(233, 39);
            this.lbl_Totala.TabIndex = 54;
            // 
            // Konfirmazioa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.FONDOAK_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1520, 688);
            this.Controls.Add(this.lbl_Totala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lab_konfirm);
            this.Controls.Add(this.lbl_itxi);
            this.Controls.Add(this.lbl_Atzera);
            this.DoubleBuffered = true;
            this.Name = "Konfirmazioa";
            this.Text = "Konfirmazioa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Atzera;
        private System.Windows.Forms.Label lbl_itxi;
        private System.Windows.Forms.Label lab_konfirm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Totala;
    }
}