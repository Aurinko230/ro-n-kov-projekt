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
                this.uložDůmToolStripMenuItem.Enabled = true;
                this.přidatBytToolStripMenuItem.Enabled = true;
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

                   
                    if (novy_meric.vod != null)
                    {
                        zobrazovany.Celkovy_Voda = novy_meric.vod;
                        zobrazovany.vsechny_vodomery_v_dome.Add(novy_meric.vod);
                        zobrazovany.ulozeny = false;
                    }
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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

                    //pokud je měřič nul bylo vytvoření zrušeno
                    if (novy_meric.pl != null)
                    {
                        zobrazovany.Celkovy_Plyn = novy_meric.pl;
                        zobrazovany.ulozeny = false;
                    }
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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
                    if (zobrazovany.dalsi_vodomery == null)
                    {
                        zobrazovany.dalsi_vodomery = new List<meric>();
                    }
                    zobrazovany.dalsi_vodomery.Add(novy_meric.vod);
                    zobrazovany.vsechny_vodomery_v_dome.Add(novy_meric.vod);
                    zobrazovany.ulozeny = false;
                }
                else// meric byl zrušin, vygenerovane id je nevyužité
                {
                    zobrazovany.id_pro_dum.zruseni_merice();
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
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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
                    else// meric byl zrušin, vygenerovane id je nevyužité
                    {
                        zobrazovany.id_pro_dum.zruseni_merice();
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
            if (zobrazovany.kontrola_pred_ulozenim())
            {

                // System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(zobrazovany.GetType());
                // x.Serialize(Console.Out, zobrazovany);

                dum_ulozeni ukladany = new dum_ulozeni(zobrazovany);

                StringWriter sw = new StringWriter();
                XmlTextWriter tw = null;
                XmlSerializer serializer = new XmlSerializer(typeof(dum_ulozeni));
                tw = new XmlTextWriter(sw);
                using (StreamWriter swr = new StreamWriter("DOMY\\" + ukladany.popis + ".xml"))
                {
                    serializer.Serialize(tw, ukladany);
                    swr.Write(sw.ToString());
                }
                
                Console.WriteLine(sw.ToString());
            }
          

        }

        public void nacti_schema_domu(string vybrany)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(dum_ulozeni));
            System.IO.StreamReader file = new System.IO.StreamReader(vybrany);
            dum_ulozeni overview = (dum_ulozeni)reader.Deserialize(file);
            file.Close();
            this.zobrazovany = new dum(overview, this.panel1, this);
            //zakazat další úpravy domu, pouze zadání počátečních hodnot
            zakazat_upravy();

        }
        private void zakazat_upravy()
        {
            this.uložDůmToolStripMenuItem.Enabled = false;
            this.přidatBytToolStripMenuItem.Enabled = false;
        }

        private void načtiExistujícíDůmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            



            if (Directory.Exists("DOMY"))
            {
                String[] domy = Directory.GetFiles("DOMY");
                
                Console.WriteLine("nacteno");
                if (domy.Length > 0)
                {
                    vyber_Domu vyber = new vyber_Domu(domy);
                    vyber.ShowDialog();
                    if (vyber.vybrany_dum!= "")
                    {
                        nacti_schema_domu(vyber.vybrany_dum);
                        
                        zobrazovany.panel_s_byty = this.panel1;
                        zobrazovany.zobraz_dum();
                        zobrazovany.ulozeny = true;
                    }
                }
                else
                {
                    MessageBox.Show("neexistují žádné uložené domy", "neexistují", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("neexistují žádné uložené domy", "neexistují", MessageBoxButtons.OK);
            }





        }
       

        private void cenyEnergiíToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (zobrazovany != null)
            {
                ceny kopie_cen = zobrazovany.ceny_energii;
                ceny_Energii ceny_pro_tento_dum = new ceny_Energii(kopie_cen);
                ceny_pro_tento_dum.ShowDialog();
                zobrazovany.ceny_energii = ceny_pro_tento_dum.nastavovane_ceny;
                ///udelat z toho samostatnou metodu a volat ji.. to samý i při běžnym uložení


                //kontrola by neměla být potřeba pokud se ceny přidávají jen do už uloženého domu a ten je tedy už zkontrolovaný
                // if (zobrazovany.kontrola_pred_ulozenim())
                // {



                dum_ulozeni ukladany = new dum_ulozeni(zobrazovany);

                StringWriter sw = new StringWriter();
                XmlTextWriter tw = null;
                XmlSerializer serializer = new XmlSerializer(typeof(dum_ulozeni));
                tw = new XmlTextWriter(sw);
                using (StreamWriter swr = new StreamWriter("DOMY\\" + ukladany.popis + ".txt"))
                {
                    serializer.Serialize(tw, ukladany);
                    swr.Write(sw.ToString());
                }



                Console.WriteLine(sw.ToString());
                //  }

            }
            else
            {
                MessageBox.Show("Není načten žádný dům pro úpravu cen energií", "Žádný dům", MessageBoxButtons.OK);
            }
        }
        //zadavani novych hodnot
        private void zadatPočátečníHodnotyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zobrazovany != null)
            {
                if (zobrazovany.ceny_energii != null)
                {
                    if (!Directory.Exists("DOMY") || !File.Exists("DOMY//" + zobrazovany.popis + ".txt"))
                    {
                        MessageBox.Show("Nejprve dům uložte", "Uložit dům", MessageBoxButtons.OK);
                    }
                    else

                    {
                        zadavani_hodnot zadavani = new zadavani_hodnot();
                        zadavani.zobrazovany = zobrazovany;
                       // zadavani.prvni_hodnoty = true;
                        zadavani.ShowDialog();
                        zobrazovany.zobraz_dum();

                        //TODO jak se dum se zobrazuje po uloženi hodnot??
                    }
                }


                else
                {
                    MessageBox.Show("Nejsou zadány ceny energií,zadejte enrgie:ÚPRAVY- CENY ENERGIÍ", "CENY", MessageBoxButtons.OK);
                }
            }
            else
            { MessageBox.Show("Není načten žádný dům pro který by bylo možné zadat hodnoty", "ŽÁDNÝ DŮM", MessageBoxButtons.OK); }



        }
    }
}

