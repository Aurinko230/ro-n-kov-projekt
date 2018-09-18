using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidence_Spotreb
{
    public partial class zmenit_zalohy : Form
    {
        public zmenit_zalohy()
        {
            InitializeComponent();
        }
        public byt tento_byt;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nova_hodnota;
            if (Int32.TryParse(textBox1.Text, out nova_hodnota))
            {
                tento_byt.zaloha = nova_hodnota;
                this.Close();

            }
            else
            {
                MessageBox.Show("neplatná hodnota", "Chyba", MessageBoxButtons.OK);
            }
        
        }

        private void zmenit_zalohy_Load(object sender, EventArgs e)
        {
            label2.Text = tento_byt.zaloha.ToString()+"Kč";

        }
    }
}
