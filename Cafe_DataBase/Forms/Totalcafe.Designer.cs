namespace Cafe_DataBase.Forms
{
    partial class Totalcafe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Totalcafe));
            this.PnTop = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnTop
            // 
            this.PnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(90)))), ((int)(((byte)(187)))));
            this.PnTop.Controls.Add(this.Label1);
            this.PnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnTop.Location = new System.Drawing.Point(0, 0);
            this.PnTop.Name = "PnTop";
            this.PnTop.Size = new System.Drawing.Size(1010, 40);
            this.PnTop.TabIndex = 63;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(10, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(134, 29);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Total Café";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 527);
            this.panel1.TabIndex = 65;
            // 
            // Totalcafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Totalcafe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TotalProductos";
            this.PnTop.ResumeLayout(false);
            this.PnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PnTop;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
    }
}