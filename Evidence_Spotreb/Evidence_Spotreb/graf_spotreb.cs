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
    public partial class graf_spotreb : Form
    {
        public graf_spotreb()
        {
            InitializeComponent();
        }
        public byt tento_byt;
        List<double> rozdily_voda;
        List<double> rozdily_elektrina;
        List<double> rozdily_plyn;

        private void graf_spotreb_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            Graphics g = Graphics.FromImage(bmp);
            
            label1.Text = tento_byt.Popis;

            rozdily_voda= new List<double>();
            rozdily_elektrina =new List< double > ();
            rozdily_plyn= new List<double>();

            spocti_rozdily();




        }
        void spocti_rozdily()
        {
            double minula_hodnota = 0;

            foreach (double hodnota in tento_byt.elektrina.hodnoty)
            {
                rozdily_elektrina.Add(hodnota - minula_hodnota);
                minula_hodnota = hodnota;
            }
            minula_hodnota = 0;

            if (tento_byt.plyn != null)
            {
                foreach (double hodnota in tento_byt.plyn.hodnoty)
                {
                    rozdily_plyn.Add(hodnota - minula_hodnota);
                    minula_hodnota = hodnota;
                }
                minula_hodnota = 0;
            }

            // voda součet vodoměrů

        }


    }
}
