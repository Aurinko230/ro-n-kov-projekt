namespace Evidence_Spotreb
{
    partial class ceny_Energii
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
            this.label1 = new System.Windows.Forms.Label();
            this.Voda = new System.Windows.Forms.Label();
            this.Elektřina = new System.Windows.Forms.Label();
            this.Plyn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_voda = new System.Windows.Forms.TextBox();
            this.textBox_elektrina = new System.Windows.Forms.TextBox();
            this.textBox_plyn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Voda
            // 
            this.Voda.AutoSize = true;
            this.Voda.Location = new System.Drawing.Point(16, 81);
            this.Voda.Name = "Voda";
            this.Voda.Size = new System.Drawing.Size(32, 13);
            this.Voda.TabIndex = 1;
            this.Voda.Text = "Voda";
            // 
            // Elektřina
            // 
            this.Elektřina.AutoSize = true;
            this.Elektřina.Location = new System.Drawing.Point(16, 108);
            this.Elektřina.Name = "Elektřina";
            this.Elektřina.Size = new System.Drawing.Size(49, 13);
            this.Elektřina.TabIndex = 2;
            this.Elektřina.Text = "Elektřina";
            // 
            // Plyn
            // 
            this.Plyn.AutoSize = true;
            this.Plyn.Location = new System.Drawing.Point(16, 135);
            this.Plyn.Name = "Plyn";
            this.Plyn.Size = new System.Drawing.Size(27, 13);
            this.Plyn.TabIndex = 3;
            this.Plyn.Text = "Plyn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "kč/m3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "kč/kwh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "kč/m3";
            // 
            // textBox_voda
            // 
            this.textBox_voda.Location = new System.Drawing.Point(92, 74);
            this.textBox_voda.Name = "textBox_voda";
            this.textBox_voda.Size = new System.Drawing.Size(100, 20);
            this.textBox_voda.TabIndex = 7;
            // 
            // textBox_elektrina
            // 
            this.textBox_elektrina.Location = new System.Drawing.Point(92, 101);
            this.textBox_elektrina.Name = "textBox_elektrina";
            this.textBox_elektrina.Size = new System.Drawing.Size(100, 20);
            this.textBox_elektrina.TabIndex = 8;
            // 
            // textBox_plyn
            // 
            this.textBox_plyn.Location = new System.Drawing.Point(92, 128);
            this.textBox_plyn.Name = "textBox_plyn";
            this.textBox_plyn.Size = new System.Drawing.Size(100, 20);
            this.textBox_plyn.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "zrušit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "uložit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ceny_Energii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_plyn);
            this.Controls.Add(this.textBox_elektrina);
            this.Controls.Add(this.textBox_voda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Plyn);
            this.Controls.Add(this.Elektřina);
            this.Controls.Add(this.Voda);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ceny_Energii";
            this.Text = "ceny_Energii";
            this.Load += new System.EventHandler(this.ceny_Energii_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Voda;
        private System.Windows.Forms.Label Elektřina;
        private System.Windows.Forms.Label Plyn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_voda;
        private System.Windows.Forms.TextBox textBox_elektrina;
        private System.Windows.Forms.TextBox textBox_plyn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}