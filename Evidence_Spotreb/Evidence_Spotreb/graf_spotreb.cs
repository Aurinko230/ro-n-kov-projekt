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
            List<trojice> zobrazovana_cast = vyber_zobrazovane();
            zobraz_graf(g, zobrazovana_cast);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();


        }

        List<trojice> vyber_zobrazovane()
        {
           
            List<trojice> zobrazovane= new List<trojice>();
            if (rozdily_elektrina.Count() > 6) //>6 zobrazit posledních 6
            {
                int startindex = rozdily_voda.Count() - 6;

                for (int index = startindex; index < rozdily_voda.Count(); index++)
                {
                    if (tento_byt.plyn != null)
                    {
                        zobrazovane.Add(new trojice(rozdily_voda[index], rozdily_elektrina[index], rozdily_plyn[index]));
                    }
                    else
                    {
                        zobrazovane.Add(new trojice(rozdily_voda[index], rozdily_elektrina[index], 0));
                    }
                }


            }
            else if (rozdily_elektrina.Count > 0)// 1-6 zobrazit vše
            {
                //nemusí mít plyn
                for (int index = 0; index < rozdily_voda.Count(); index++)
                {
                    if (tento_byt.plyn != null)
                    {
                        zobrazovane.Add(new trojice(rozdily_voda[index], rozdily_elektrina[index], rozdily_plyn[index]));
                    }
                    else
                    {
                        zobrazovane.Add(new trojice(rozdily_voda[index], rozdily_elektrina[index],0));
                    }
                }

            }


            return zobrazovane;

        }

        void spocti_rozdily()
        {
            double minula_hodnota = 0;
            int pocet_hodnot;
            pocet_hodnot = tento_byt.elektrina.hodnoty.Count();
            double[] voda_soucet = new double[pocet_hodnot];

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

            foreach (meric vodomer in tento_byt.vodomery)
            {
                int poradi = 0;
                foreach (double hodnota in vodomer.hodnoty)
                {
                    voda_soucet[poradi] = voda_soucet[poradi] + hodnota;
                    poradi++;
                }

            }

            for (int i = 0; i < voda_soucet.Count(); i++)
            {
                rozdily_voda.Add(voda_soucet[i] - minula_hodnota);
                minula_hodnota = voda_soucet[i];

            }
            
            

            // voda součet vodoměrů

        }

        void zobraz_graf(Graphics g,List<trojice> co_zobrazit)
        {
            Pen plyn_pero = new Pen(Brushes.Red, 30);
            Pen ele_pero = new Pen(Brushes.Yellow, 30);
            Pen voda_pero = new Pen(Brushes.CornflowerBlue, 30);

            Font font = new Font("Arial", 15);
            SolidBrush brush = new SolidBrush(Color.Black);

            g.TranslateTransform(0, pictureBox1.Height);
            int posun = 130;
            int meritko=urci_meritko(co_zobrazit);
            Point pozice = new Point(20, 0);

            foreach (trojice rozdily in co_zobrazit)
            {
                g.DrawLine(voda_pero, pozice.X, 0, pozice.X, -(float)(rozdily.voda * meritko));
                g.DrawString(Convert.ToString(rozdily.voda), font, brush, pozice.X-15, -20);
                
               
                g.DrawLine(ele_pero, pozice.X+33, 0, pozice.X+33, -(float)(rozdily.elektrina *meritko));
                g.DrawString(Convert.ToString(rozdily.elektrina), font, brush, pozice.X + 18, -20);
                
                
                g.DrawLine(plyn_pero, pozice.X+66, 0, pozice.X+66, -(float)(rozdily.plyn * meritko));
                g.DrawString(Convert.ToString(rozdily.plyn), font, brush, pozice.X +51, -20);
                

                pozice.X = pozice.X + posun;

            }
            

        }

        int urci_meritko(List<trojice>zobrazovane)
        {       //maximum vykreslovat do 3/4 boxu
            int meritko;
            double maximum=0.1;
            foreach (trojice jednatrojice in zobrazovane)
            {
                if (jednatrojice.voda > maximum)
                {
                    maximum = jednatrojice.voda;
                }

                if (jednatrojice.elektrina > maximum)
                {
                    maximum = jednatrojice.elektrina;
                }
                if (jednatrojice.plyn > maximum)
                {
                    maximum = jednatrojice.plyn;
                }
            }

            meritko = (int)Math.Ceiling(300 / maximum);
            return meritko;
        }


    }
}
