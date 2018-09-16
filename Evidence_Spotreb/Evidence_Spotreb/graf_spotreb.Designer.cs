namespace Evidence_Spotreb
{
    partial class graf_spotreb
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Graf = new System.Windows.Forms.TabPage();
            this.Hodnoty = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.Graf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Graf);
            this.tabControl1.Controls.Add(this.Hodnoty);
            this.tabControl1.Location = new System.Drawing.Point(12, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(851, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // Graf
            // 
            this.Graf.Controls.Add(this.pictureBox1);
            this.Graf.Location = new System.Drawing.Point(4, 22);
            this.Graf.Name = "Graf";
            this.Graf.Padding = new System.Windows.Forms.Padding(3);
            this.Graf.Size = new System.Drawing.Size(843, 510);
            this.Graf.TabIndex = 0;
            this.Graf.Text = "Graf";
            this.Graf.UseVisualStyleBackColor = true;
            // 
            // Hodnoty
            // 
            this.Hodnoty.Location = new System.Drawing.Point(4, 22);
            this.Hodnoty.Name = "Hodnoty";
            this.Hodnoty.Padding = new System.Windows.Forms.Padding(3);
            this.Hodnoty.Size = new System.Drawing.Size(843, 510);
            this.Hodnoty.TabIndex = 1;
            this.Hodnoty.Text = "Hodnoty";
            this.Hodnoty.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "popis bytu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(830, 402);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // graf_spotreb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 616);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "graf_spotreb";
            this.Text = "pict";
            this.Load += new System.EventHandler(this.graf_spotreb_Load);
            this.tabControl1.ResumeLayout(false);
            this.Graf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Graf;
        private System.Windows.Forms.TabPage Hodnoty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}