using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Evidence_Spotreb
{
    public partial class start : Form
    {
        public dum zobrazovany;

        public start()
        {
            InitializeComponent();
        }

        private void novýDůmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novy_Dum novy = new novy_Dum();
            zobrazovany = new dum(this, this.panel1);
            zobrazovany.ulozeny = false;
            novy.novy_dum = zobrazovany;
            novy.ShowDialog();
            if (zobrazovany.popis != null)
            {
                zobrazovany.zobraz_dum();
            }

        }

        private void start_Load(object sender, EventArgs e)
        {

        }

        private void bytToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null && zobrazovany.popis != null)
            {
                int pocetBytu = zobrazovany.byty.Count;
                novy_Byt novy_byt_formular = new novy_Byt();
                novy_byt_formular.zobrazovany_dum = zobrazovany;
                novy_byt_formular.ShowDialog();
                if (zobrazovany.byty.Count > pocetBytu)// byl přidán nový byt
                {
                    zobrazovany.zobraz_dum();
                    zobrazovany.ulozeny = false;
                }

            }
            else
            {
                MessageBox.Show("není načten žádný dům, kam by se přidal byt", "není dům", MessageBoxButtons.OK);
            }

        }

        private void celkovýVodoměrToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_voda = new meric(Typ_merice.Vodomer);
                if (zobrazovany.Spolecny_Voda == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(novy_voda, null, null, 'V', id);
                    novy_meric.Text = "celkový vodoměr";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenej voda");

                    if (novy_meric.vod != null)//jinak byl zrušen
                    {
                        zobrazovany.Celkovy_Voda = novy_meric.vod;
                        zobrazovany.vsechny_vodomery_v_dome.Add(novy_meric.vod);
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  společný vodoměr pro tento byt, chcete ho nahradit jiným?", 'V', novy_voda, null, null);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.vod != null)
                    {
                        zobrazovany.Celkovy_Voda = dotaz.vod;
                        zobrazovany.vsechny_vodomery_v_dome.Add(dotaz.vod);
                        zobrazovany.ulozeny = false;
                    }

                }
                zobrazovany.zobraz_dum();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial vodoměr", "není dům", MessageBoxButtons.OK);
            }

        }

        private void celkovýPlynoměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_plyn = new meric(Typ_merice.Plynomer);
                if (zobrazovany.Spolecny_Voda == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(null, null, novy_plyn, 'P', id);
                    novy_meric.Text = "Celkový plynoměr";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenejplyn");

                    if (novy_meric.pl != null)//jinak byl zrušen
                    {
                        zobrazovany.Celkovy_Plyn = novy_meric.pl;
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  Celkový plynomer pro tento byt, chcete ho nahradit jiným?", 'P', null, null, novy_plyn);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.pl != null)
                    {
                        zobrazovany.Celkovy_Plyn = dotaz.pl;
                        zobrazovany.ulozeny = false;
                    }

                }

                zobrazovany.zobraz_dum();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial plynoměr", "není dům", MessageBoxButtons.OK);
            }

        }

        private void celkovýElektroměrToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_elektrina = new meric(Typ_merice.Elektromer);
                if (zobrazovany.Spolecny_Elektrina == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(null, novy_elektrina, null, 'E', id);
                    novy_meric.Text = "Celkovýý elektromer";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenej ele");

                    if (novy_meric.ele != null)//jinak byl zrušen
                    {
                        zobrazovany.Celkovy_Elektrina = novy_meric.ele;
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  Celkový elektromer pro tento byt, chcete ho nahradit jiným?", 'E', null, novy_elektrina, null);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.ele != null)
                    {
                        zobrazovany.Celkovy_Elektrina = dotaz.ele;
                        zobrazovany.ulozeny = false;
                    }

                }

                zobrazovany.zobraz_dum();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial elektroměr", "není dům", MessageBoxButtons.OK);
            }


        }

        private void ostatníVodoměrToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_voda = new meric(Typ_merice.Vodomer);

                int id = zobrazovany.id_pro_dum.noveID();
                novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(novy_voda, null, null, 'V', id);
                novy_meric.Text = "Ostatní vodoměr";
                novy_meric.ShowDialog();
                Console.WriteLine("ulozenej voda");

                if (novy_meric.vod != null)//jinak byl zrušen
                {
                    if (zobrazovany.Dalsi_Vodomery == null)
                    {
                        zobrazovany.Dalsi_Vodomery = new List<meric>();
                    }
                    zobrazovany.Dalsi_Vodomery.Add(novy_meric.vod);
                    zobrazovany.vsechny_vodomery_v_dome.Add(novy_meric.vod);
                    zobrazovany.ulozeny = false;
                }

                zobrazovany.zobraz_dum();
                this.Refresh();

            }
            else
            {
                MessageBox.Show("Není načten žádný dům kam by se přial vodoměr", "Není dům", MessageBoxButtons.OK);
            }

        }

        private void společnýPlynoměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_plyn = new meric(Typ_merice.Plynomer);
                if (zobrazovany.Spolecny_Voda == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(null, null, novy_plyn, 'P', id);
                    novy_meric.Text = "Společný plynoměr";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenejplyn");

                    if (novy_meric.pl != null)//jinak byl zrušen
                    {
                        zobrazovany.Spolecny_Plyn = novy_meric.pl;
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  společný plynomer pro tento byt, chcete ho nahradit jiným?", 'P', null, null, novy_plyn);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.pl != null)
                    {
                        zobrazovany.Spolecny_Plyn = dotaz.pl;
                        zobrazovany.ulozeny = false;
                    }

                }
                //zobrazovany.Spolecny_Voda = (vodomer)novy_voda;
                zobrazovany.zobraz_dum();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial plynoměr", "není dům", MessageBoxButtons.OK);
            }
        }

        private void společnýElektroměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_elektrina = new meric(Typ_merice.Elektromer);
                if (zobrazovany.Spolecny_Elektrina == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(null, novy_elektrina, null, 'E', id);
                    novy_meric.Text = "Společný elektromer";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenej ele");

                    if (novy_meric.ele != null)//jinak byl zrušen
                    {
                        zobrazovany.Spolecny_Elektrina = novy_meric.ele;
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  společný elektromer pro tento byt, chcete ho nahradit jiným?", 'E', null, novy_elektrina, null);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.ele != null)
                    {
                        zobrazovany.Spolecny_Elektrina = dotaz.ele;
                        zobrazovany.ulozeny = false;
                    }

                }

                zobrazovany.zobraz_dum();
                this.Refresh();
                this.panel1.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial elektroměr", "není dům", MessageBoxButtons.OK);
            }



        }

        private void společnýVodoměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null && zobrazovany.popis != null)
            {
                meric novy_voda = new meric(Typ_merice.Vodomer);
                if (zobrazovany.Spolecny_Voda == null)
                {

                    int id = zobrazovany.id_pro_dum.noveID();
                    novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(novy_voda, null, null, 'V', id);
                    novy_meric.Text = "Společný vodoměr";
                    novy_meric.ShowDialog();
                    Console.WriteLine("ulozenej voda");

                    if (novy_meric.vod != null)//jinak byl zrušen
                    {
                        zobrazovany.Spolecny_Voda = novy_meric.vod;
                        zobrazovany.vsechny_vodomery_v_dome.Add(novy_meric.vod);
                        zobrazovany.ulozeny = false;
                    }

                }
                else
                {
                    Existuje dotaz = new Existuje("Už existuje  společný vodoměr pro tento byt, chcete ho nahradit jiným?", 'V', novy_voda, null, null);
                    dotaz.zobrazovany = zobrazovany;
                    dotaz.ShowDialog();

                    if (dotaz.vod != null)
                    {
                        zobrazovany.Spolecny_Voda = dotaz.vod;
                        zobrazovany.vsechny_vodomery_v_dome.Add(dotaz.vod);
                        zobrazovany.ulozeny = false;
                    }

                }
                //zobrazovany.Spolecny_Voda = (vodomer)novy_voda;
                zobrazovany.zobraz_dum();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("není načten žádný dům kam by se přial vodoměr", "není dům", MessageBoxButtons.OK);
            }
        }

        private void uložDůmToolStripMenuItem_Click(object sender, EventArgs e)
        {


            // System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(zobrazovany.GetType());
            // x.Serialize(Console.Out, zobrazovany);
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;

            XmlSerializer serializer = new XmlSerializer(typeof(byt));
            XmlSerializer serializer2 = new XmlSerializer(typeof(dum));
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, zobrazovany.byty.ElementAt(0));
            Console.WriteLine(sw.ToString());
            Console.WriteLine(typeof(dum));

        }
    }
}

