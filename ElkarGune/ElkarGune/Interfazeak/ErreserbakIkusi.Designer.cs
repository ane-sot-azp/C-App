namespace ElkarGune.Interfazeak
{
    partial class ErreserbakIkusi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErreserbakIkusi));
            this.dgv_Frak = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_itxi = new System.Windows.Forms.Label();
            this.lbl_Atzera = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Frak)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Frak
            // 
            this.dgv_Frak.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Frak.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Frak.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Frak.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Frak.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Frak.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Frak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Frak.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Frak.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_Frak.Location = new System.Drawing.Point(329, 110);
            this.dgv_Frak.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_Frak.Name = "dgv_Frak";
            this.dgv_Frak.RowHeadersWidth = 51;
            this.dgv_Frak.RowTemplate.Height = 24;
            this.dgv_Frak.Size = new System.Drawing.Size(1368, 629);
            this.dgv_Frak.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Location = new System.Drawing.Point(1809, 624);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 129);
            this.label1.TabIndex = 68;
            // 
            // lbl_itxi
            // 
            this.lbl_itxi.BackColor = System.Drawing.Color.Transparent;
            this.lbl_itxi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_itxi.Location = new System.Drawing.Point(1928, 17);
            this.lbl_itxi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_itxi.Name = "lbl_itxi";
            this.lbl_itxi.Size = new System.Drawing.Size(77, 71);
            this.lbl_itxi.TabIndex = 67;
            this.lbl_itxi.Click += new System.EventHandler(this.lbl_itxi_Click);
            // 
            // lbl_Atzera
            // 
            this.lbl_Atzera.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Atzera.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Atzera.Location = new System.Drawing.Point(17, 17);
            this.lbl_Atzera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Atzera.Name = "lbl_Atzera";
            this.lbl_Atzera.Size = new System.Drawing.Size(227, 87);
            this.lbl_Atzera.TabIndex = 66;
            // 
            // ErreserbakIkusi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.FONDOAK_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 857);
            this.Controls.Add(this.dgv_Frak);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_itxi);
            this.Controls.Add(this.lbl_Atzera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ErreserbakIkusi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Erreserbak Ikusi";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Frak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Frak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_itxi;
        private System.Windows.Forms.Label lbl_Atzera;
    }
}