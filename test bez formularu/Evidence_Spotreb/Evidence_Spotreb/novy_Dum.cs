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
    public partial class novy_Dum : Form
    {
        public dum novy_dum;
        public novy_Dum()
        {
            InitializeComponent();
        }

        private void novy_Dum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                novy_dum.popis = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nevyplněný popis!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

