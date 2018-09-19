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
    public partial class vyber_Domu : Form
    {
        string[] domy;
        public string vybrany_dum;
        public vyber_Domu()
        {
            InitializeComponent();
        }
        public vyber_Domu( string[] domy)
        {
            InitializeComponent();
            this.domy = domy;
        }

        private void vyber_Domu_Load(object sender, EventArgs e)
        {
            vybrany_dum = "";
            foreach (String jeden_dum in domy)
            {
                if (jeden_dum.Substring(jeden_dum.Length - 4) == ".xml")
                {
                    this.listBox1.Items.Add(jeden_dum);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            vybrany_dum = (String)listBox1.SelectedItem;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vybrany_dum = "";
            this.Close();
        }
    }
}
