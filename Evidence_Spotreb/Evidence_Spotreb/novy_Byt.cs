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
    public partial class novy_Byt : Form
    { 
        bool kontrola()
        {
            if (this.tehle_byt.Popis != "")
            {
                if (tehle_byt.elektrina != null)
                {
                    if (tehle_byt.vodomery.Count > 0)
                    {
                        int zalohy;
                        if (Int32.TryParse(textBox2.Text, out zalohy))
                        {

                            if (!tehle_byt.Popis.Contains('/') && !tehle_byt.Popis.Contains('\\') && !tehle_byt.Popis.Contains('@') && zalohy > 0)
                            {
                                tehle_byt.zaloha = zalohy;
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public dum zobrazovany_dum;
        byt tehle_byt;

        public novy_Byt()
        {
            InitializeComponent();
        }

        private void novy_Byt_Load(object sender, EventArgs e)
        {
            tehle_byt = new byt();
            tehle_byt.vodomery = new List<meric>();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            meric novy_ele = new meric();

            if (tehle_byt.elektrina == null)
            {
                int id = zobrazovany_dum.id_pro_dum.noveID();
                novy_Elektromer_nebo_Plynomer novy_elektromer = new novy_Elektromer_nebo_Plynomer(null, novy_ele, null, 'E', id);
                novy_elektromer.Text = "Nový Elektroměr";
                novy_elektromer.ShowDialog();
                Console.WriteLine("ulozenej ele");
                if (novy_elektromer.ele != null)//jinak byl zrušen
                {
                    tehle_byt.elektrina = novy_elektromer.ele;
                }
                else// meric byl zrušin, vygenerovane id je nevyužité
                {
                    zobrazovany_dum.id_pro_dum.zruseni_merice();
                }
            }
            else
            {
                Existuje dotaz = new Existuje("Už existuje elektromer pro tento byt, chcete ho nahradit jiným?", 'E', null, novy_ele, null);
                dotaz.zobrazovany = zobrazovany_dum;
                dotaz.ShowDialog();
                if (dotaz.ele != null)
                {
                    tehle_byt.elektrina = dotaz.ele;
                }

            }
            //this.Controls.Remove(groupBox1);
            //this.Refresh();
            zobraz_byt(tehle_byt);
            this.Refresh();


            this.Refresh();

        }

        void zobraz_byt(byt tehle_byt)
        {
           
            int pocet = groupBox1.Controls.Count;
            for (int i = 0; i < pocet; i++)
            {
                groupBox1.Controls.RemoveAt(0);
            }
            this.groupBox1.Refresh();

            Point zobrazeni = new Point(20, 20);
            foreach (meric jeden_vodomer in tehle_byt.vodomery)
            {
                zobraz_meric(groupBox1, jeden_vodomer, zobrazeni);
                zobrazeni.Y = zobrazeni.Y + 25;
            }

            if (tehle_byt.elektrina != null)
            {
                zobraz_meric(groupBox1, tehle_byt.elektrina, zobrazeni);
                zobrazeni.Y = zobrazeni.Y + 25;
            }
            if (tehle_byt.plyn != null)
            {
                zobraz_meric(groupBox1, tehle_byt.plyn, zobrazeni);
                zobrazeni.Y = zobrazeni.Y + 25;

            }
            
        }

        void zobraz_meric(GroupBox kam_zobrazit, meric co_zobrazit, Point kde)
        {
            int id_merice = 0;
            string popis = "";

            Label nadpis = new Label();
            nadpis.Width = 50;
            if (co_zobrazit.typ == Typ_merice.Vodomer)
            {
               // vodomer meric = (vodomer)co_zobrazit;
                nadpis.Text = "vodomer";
                id_merice = co_zobrazit.Id;
                popis = co_zobrazit.Popis;
            }
            if (co_zobrazit.typ == Typ_merice.Elektromer)
            {
                //elektromer meric = (elektromer)co_zobrazit;
                nadpis.Text = "elektromer";
                id_merice = co_zobrazit.Id;
                popis = co_zobrazit.Popis;
            }
            if (co_zobrazit.typ == Typ_merice.Plynomer)
            {
                //plynomer meric = (plynomer)co_zobrazit;
                nadpis.Text = "plynomer";
                id_merice = co_zobrazit.Id;
                popis = co_zobrazit.Popis;
            }
            nadpis.Location = kde;
            nadpis.Parent = kam_zobrazit;

            kde.X = 80;
            Label id_merice_label = new Label();
            id_merice_label.Width = 20;
            id_merice_label.Text = id_merice.ToString();
            id_merice_label.Location = kde;
            id_merice_label.Parent = kam_zobrazit;


            kde.X = 100;
            Label popis_label = new Label();
            popis_label.Text = popis;
            popis_label.Location = kde;
            popis_label.Parent = kam_zobrazit;
            kde.X = 20;




        }

        private void button4_Click(object sender, EventArgs e)
        {
            meric novy_plyn = new meric();
            if (tehle_byt.plyn == null)
            {

                int id = zobrazovany_dum.id_pro_dum.noveID();
                novy_Elektromer_nebo_Plynomer novy_plynomer = new novy_Elektromer_nebo_Plynomer(null, null, novy_plyn, 'P', id);
                novy_plynomer.Text = "Nový Plynoměr";
                novy_plynomer.ShowDialog();
                //tehle_byt.plyn = (plynomer)novy_plyn;
                Console.WriteLine("ulozenej plyn");

                if (novy_plynomer.pl != null)//jinak byl zrušen
                {
                    tehle_byt.plyn = novy_plynomer.pl;
                }
                else// meric byl zrušin, vygenerovane id je nevyužité
                {
                    zobrazovany_dum.id_pro_dum.zruseni_merice();
                }


            }
            else
            {
                Existuje dotaz = new Existuje("Už existuje plynoměr pro tento byt, chcete ho nahradit jiným?", 'P', null, null, novy_plyn);
                dotaz.zobrazovany = zobrazovany_dum;
                dotaz.ShowDialog();
                if (dotaz.pl != null)
                {
                    tehle_byt.plyn = dotaz.pl;
                }

            }

            zobraz_byt(tehle_byt);
           
            this.Refresh();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = zobrazovany_dum.id_pro_dum.noveID();
            pridat pridani = new pridat();
            pridani.ano = false;
            meric voda_novy = new meric(Typ_merice.Vodomer);
            novy_Vodomer form_vodomer = new novy_Vodomer(id, voda_novy, zobrazovany_dum, pridani);

            form_vodomer.ShowDialog();
            if (pridani.ano)
            {
                tehle_byt.vodomery.Add(voda_novy);
                

                zobraz_byt(tehle_byt);
                this.Refresh();
            }
            else// meric byl zrušin, vygenerovane id je nevyužité
            {
                zobrazovany_dum.id_pro_dum.zruseni_merice();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tehle_byt.Popis = textBox1.Text;
            if (this.kontrola() == true)
            {
                zobrazovany_dum.byty.Add(tehle_byt);
                foreach (meric voda in tehle_byt.vodomery)
                {
                    zobrazovany_dum.vsechny_vodomery_v_dome.Add(voda);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Někde je chyba \n neni zadaný popis \n popis obsahuje divné znaky \n zálohy nejsou číslo(nebo jsou záporné) nebo \n byt nemá elektroměr nebo \n byt nemá vodoměr", "chyba", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //odoznacit ostatni použité kokud byl do bytu přidan dopočítavaný vodoměr a ten se nyní nezapíše
            foreach (meric vodomer in tehle_byt.vodomery)
            {
                if (vodomer.dopocitavany == true)
                {
                    foreach (int ID in vodomer.odecitane)
                    {
                        zobrazovany_dum.oznac_pouzity_vodomer(ID, false);
                    }
                    zobrazovany_dum.oznac_pouzity_vodomer(vodomer.spolecnyID, true);

                }
            }
            this.Close();
        }
    }
}
