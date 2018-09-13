using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidence_Spotreb
{
    public class My_TextBox : TextBox
    {
        public meric zadavany_meric;
        public bool platna_hodnota;
        public double rozdil_hodnot;
        private void zmena_v_textboxu(object sender, EventArgs e)
        {
           // zadavani_hodnot formular = zadavani_hodnot(this.Parent.Parent);
            double zadana_hodnota;
            
            if (Double.TryParse(this.Text, out zadana_hodnota))
            {
                if (zadana_hodnota >= zadavany_meric.posledni_hodnota)
                {
                    this.BackColor = System.Drawing.Color.Green;
                    this.platna_hodnota = true;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Red;
                    this.platna_hodnota = false;
                }
            }
            else
            {
                if (this.Text == "")
                {
                    this.BackColor = System.Drawing.Color.White;
                    this.platna_hodnota = false;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Red;
                    this.platna_hodnota = false;
                }
                
            }
            
            
        }
        public My_TextBox()
        {
            
            this.TextChanged += new EventHandler(zmena_v_textboxu);
            this.platna_hodnota = false;
        }


        

    }

   
}
