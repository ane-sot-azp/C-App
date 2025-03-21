namespace ElkarGune
{
    partial class Menu
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
            this.lbl_ItxiMenu = new System.Windows.Forms.Label();
            this.lbl_SaioaItxiMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ItxiMenu
            // 
            this.lbl_ItxiMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ItxiMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ItxiMenu.Location = new System.Drawing.Point(1460, 18);
            this.lbl_ItxiMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ItxiMenu.Name = "lbl_ItxiMenu";
            this.lbl_ItxiMenu.Size = new System.Drawing.Size(59, 58);
            this.lbl_ItxiMenu.TabIndex = 6;
            this.lbl_ItxiMenu.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_SaioaItxiMenu
            // 
            this.lbl_SaioaItxiMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SaioaItxiMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_SaioaItxiMenu.Location = new System.Drawing.Point(13, 666);
            this.lbl_SaioaItxiMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SaioaItxiMenu.Name = "lbl_SaioaItxiMenu";
            this.lbl_SaioaItxiMenu.Size = new System.Drawing.Size(153, 58);
            this.lbl_SaioaItxiMenu.TabIndex = 7;
            this.lbl_SaioaItxiMenu.Click += new System.EventHandler(this.lbl_SaioaItxiMenu_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ElkarGune.Properties.Resources.MENUA;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1522, 696);
            this.Controls.Add(this.lbl_SaioaItxiMenu);
            this.Controls.Add(this.lbl_ItxiMenu);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_ItxiMenu;
        private System.Windows.Forms.Label lbl_SaioaItxiMenu;
    }
}