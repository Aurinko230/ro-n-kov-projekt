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
    public partial class novy_Vodomer : Form
    {

        dum zobrazovany;
        meric voda;
        pridat pridani;
        public novy_Vodomer(int id, meric v, dum zobrazovany, pridat pridani)
        {
            InitializeComponent();
            label5.Text = id.ToString();
            voda = v;
            voda.typ = Typ_merice.Vodomer;
            this.zobrazovany = zobrazovany;
            this.pridani = pridani;
            this.ControlBox = false;
        }

        private void novyvodomer_Load(object sender, EventArgs e)
        {

        }
        bool kontrola_bezny()
        {
            if (textBox1.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool kontrola_dopocitavany()
        {
            int id_spolecny;
            if (textBox1.Text != null)
            {
                if (Int32.TryParse(textBox3.Text, out id_spolecny))
                {
                    if (existuje_vodomer(id_spolecny))
                    {
                        if (listBox1.Items.Count > 0)
                        {
                            return true;

                        }
                        else
                        {
                            MessageBox.Show("seznam odečítaných vodoměrů je prázdný.", "žádné odečítané", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("vodoměr zadaný jako společný neexistuje (neplatné ID)", "Neplatné ID", MessageBoxButtons.OK);
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Není zadáno čílo pro ID společného vodoměru.", "Neplatné ID", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.groupBox1.Enabled = true;
            }
            else
            {
                this.groupBox1.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        { //přidat vodoměr

            if (textBox1.Text != "")
            {
                voda.Id = Int32.Parse(label5.Text);

                if (checkBox1.Checked == true)
                {
                    voda.dopocitavany = true;
                    //TODO kontrola dopocitavaneho
                    if (kontrola_dopocitavany())
                    {
                        pridani.ano = true;
                        voda.Popis = textBox1.Text;
                        voda.spolecnyID = Int32.Parse(textBox3.Text);
                        voda.odecitane = new List<int>();
                        foreach (int id in listBox1.Items)
                        {
                            //int odecitany = Int32.Parse(id);
                            voda.odecitane.Add(id);
                        }

                        this.Close();
                    }



                }
                else
                {
                    if (kontrola_bezny())
                    {
                        pridani.ano = true;
                        voda.Popis = textBox1.Text;
                        voda.typ = Typ_merice.Vodomer;
                        this.Close();
                        //tehlebyt.vodomery.Add(novy_vodomer);
                    }

                }

            }
            else
            {
                MessageBox.Show("neni zadaný popis", "neni jmeno", MessageBoxButtons.OK);
            }
        }

       
        bool existuje_vodomer(int id)
        {
            foreach (meric voda in zobrazovany.vsechny_vodomery_v_dome)
            {
                if (voda.Id == id)
                {
                    return true;
                }
            }
            return false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(textBox2.Text, out id))
            {
                if (existuje_vodomer(id))
                {
                    listBox1.Items.Add(id);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("vodoměr s tímto ID neexistuje", "Neplatné ID", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("zadané ID není číslo!", "Neplatné ID", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            voda = null;
            this.Close();
        }

        private void novy_Vodomer_Load(object sender, EventArgs e)
        {

        }

       
    }
}
