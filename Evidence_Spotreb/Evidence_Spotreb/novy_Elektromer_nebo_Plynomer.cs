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
    public partial class novy_Elektromer_nebo_Plynomer : Form
    {
        char co_to_je;
        byt byt_kde_je;
        public meric pl;
        public meric ele;
        public meric vod;
        public novy_Elektromer_nebo_Plynomer(meric vod, meric ele, meric pl, char co, int id_noveho)
        {

            InitializeComponent();
            this.vod = vod;
            this.ele = ele;
            this.pl = pl;
            co_to_je = co;
            labelID.Text = id_noveho.ToString();
            this.ControlBox = false;
        }



        private void button2_Click(object sender, EventArgs e)//pridat
        {
            if (this.textBox1.Text != "")
            {
                if (co_to_je == 'E')// je to elektromer
                {
                    meric novy_elektromer = new meric(Typ_merice.Elektromer);
                    novy_elektromer.Popis = this.textBox1.Text;
                    novy_elektromer.Id = Int32.Parse(this.labelID.Text);
                    ele = novy_elektromer;
                    novy_elektromer.typ = Typ_merice.Elektromer;
                    this.Close();

                }
                if (co_to_je == 'P') // je to plynomer
                {
                    meric novy_plynomer = new meric(Typ_merice.Plynomer);
                    novy_plynomer.Popis = this.textBox1.Text;
                    novy_plynomer.Id = Int32.Parse(this.labelID.Text);
                    pl = novy_plynomer;
                    novy_plynomer.typ = Typ_merice.Plynomer;
                    this.Close();

                }

                //tohle by nemělo nikdy nastat vyvolává se jiné okno pro vodoměry(jedině pro celkový vodoměr)
                if (co_to_je == 'V') // je to voda
                {
                    meric novy_vodomer = new meric(Typ_merice.Vodomer);
                    novy_vodomer.Popis = this.textBox1.Text;
                    novy_vodomer.Id = Int32.Parse(this.labelID.Text);
                    vod = novy_vodomer;
                    novy_vodomer.typ = Typ_merice.Vodomer;
                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("neni zadaný popis", "neni jmeno", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vod = null;
            pl = null;
            ele = null;
            this.Close();
        }

        private void novy_Elektromer_nebo_Plynomer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vod = null;
            pl = null;
            ele = null;
            
            Close();
        }
    }
}
