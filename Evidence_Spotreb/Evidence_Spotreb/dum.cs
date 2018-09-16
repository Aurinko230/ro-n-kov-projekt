using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;


namespace Evidence_Spotreb
{
    public class dum
    {
        public dum() { }
        public dum(dum_ulozeni ulozeny_dum, Panel zobrazovaci,Form formular)
        {
            this.byty = ulozeny_dum.byty;
            this.celkovy_elektrina = ulozeny_dum.celkovy_elektrina;
            this.celkovy_plyn = ulozeny_dum.celkovy_plyn;
            this.celkovy_voda = ulozeny_dum.celkovy_voda;
            this.ceny_energii = ulozeny_dum.ceny_energii;
            this.dalsi_vodomery = ulozeny_dum.dalsi_vodomery;
            this.popis = ulozeny_dum.popis;
            this.spolecne_prostory_elektrina = ulozeny_dum.spolecne_prostory_elektrina;
            this.spolecne_prostory_voda = ulozeny_dum.spolecne_prostory_voda;
            this.spolecne_prostory_plyn = ulozeny_dum.spolecne_prostory_plyn;
            this.panel_s_byty = zobrazovaci;
            this.id_pro_dum = ulozeny_dum.id_pro_dum;

        }

        public bool ulozeny;
        public ceny ceny_energii;
        public List<byt> Byty
        {
            get
            {
                return byty;
            }
            set
            {
                byty = value;
            }
        }

        //public List<meric> Dalsi_Vodomery
        //{
        //    get
        //    {
        //        return dalsi_vodomery;
        //    }
        //    set
        //    {
        //        dalsi_vodomery = value;
        //    }
        //}

        public meric Celkovy_Voda
        {
            get
            {
                return celkovy_voda;
            }
            set
            {
                celkovy_voda = value;
            }
        }

        public meric Celkovy_Elektrina
        {
            get
            {
                return celkovy_elektrina;
            }
            set
            {
                celkovy_elektrina = value;
            }
        }

        public meric Celkovy_Plyn
        {
            get
            {
                return celkovy_plyn;
            }
            set
            {
                celkovy_plyn = value;
            }
        }

        public meric Spolecny_Plyn
        {
            get
            {
                return spolecne_prostory_plyn;
            }
            set
            {
                spolecne_prostory_plyn = value;
            }
        }

        public meric Spolecny_Voda
        {
            get
            {
                return spolecne_prostory_voda;
            }
            set
            {
                spolecne_prostory_voda = value;
            }
        }

        public meric Spolecny_Elektrina
        {
            get
            {
                return spolecne_prostory_elektrina;
            }
            set
            {
                spolecne_prostory_elektrina = value;
            }
        }

        public Form formular;
        public Panel panel_s_byty;
        public GenerovaneID id_pro_dum;
        public string popis;
        public List<byt> byty;
        public meric celkovy_elektrina;
        public meric celkovy_voda;
        public meric celkovy_plyn;
        public meric spolecne_prostory_elektrina;
        public meric spolecne_prostory_plyn;
        public meric spolecne_prostory_voda;
        public List<meric> dalsi_vodomery;
        public List<meric> vsechny_vodomery_v_dome;
        public string cesta;


        public dum(Form formular, Panel panel_s_byty)
        {
            id_pro_dum = new GenerovaneID();
            this.formular = formular;
            this.panel_s_byty = panel_s_byty;
            this.vsechny_vodomery_v_dome = new List<meric>();
            this.byty = new List<byt>();

        }

        public void ulozit_dum()
        {
            //if (kontrola_pred_ulozenim())
           // {

                

                dum_ulozeni ukladany = new dum_ulozeni(this);

                StringWriter sw = new StringWriter();
                XmlTextWriter tw = null;
                XmlSerializer serializer = new XmlSerializer(typeof(dum_ulozeni));
                tw = new XmlTextWriter(sw);
                using (StreamWriter swr = new StreamWriter("DOMY\\" + ukladany.popis + ".xml"))
                {
                    serializer.Serialize(tw, ukladany);
                    swr.Write(sw.ToString());
                }



                
           // }
        }
        /// <summary>
        /// dům musí splňovat:
        /// </summary>
        /// <returns>
        /// True pokud splňuje podmínky,False pokud ne.
        /// Pokud nesplňuje vyhodí messagebox se seznamem nesplňěných parametrů
        /// </returns>
        public bool kontrola_pred_ulozenim()
        {
            List<String> seznam_chyb = new List<String>();
            if (this.byty.Count == 0)
            {
                seznam_chyb.Add("Dům neobsahuje žádný byt");
            }
            if (this.Celkovy_Voda == null)
            {
                seznam_chyb.Add("Není zadaný celkový vodoměr");
            }
            if (this.Celkovy_Elektrina == null)
            {
                seznam_chyb.Add("Není zadaný celkový elektroměr");
            }

            if (seznam_chyb.Count > 0)
            {
                String celkovej_text = "";
                foreach (String text in seznam_chyb)
                {
                    celkovej_text = celkovej_text + text + "\n";

                }
                MessageBox.Show(celkovej_text, "Chyby", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }


        }

        public void zobraz_dum()
        {


            int pocet = panel_s_byty.Controls.Count;

            for (int i = 0; i < pocet; i++)
            {
                panel_s_byty.Controls.RemoveAt(0);
            }
            
            panel_s_byty.Refresh();

            Label popis_domu = new Label();
            popis_domu.Text = this.popis;
            popis_domu.Font = new Font(popis_domu.Font.FontFamily, 20);
            popis_domu.Location = new Point(25, 25);
            popis_domu.Width = 550;
            popis_domu.Height = 35;
            popis_domu.Parent = panel_s_byty;


            Point pozice = new Point(25, 80);

            if (spolecne_prostory_plyn != null || spolecne_prostory_elektrina != null || spolecne_prostory_voda != null)
            {
                zobraz_spolecne_prostory(pozice, panel_s_byty);
                pozice.Y = pozice.Y + 180;
            }

            if (Celkovy_Plyn != null || Celkovy_Voda != null || Celkovy_Elektrina != null)
            {
                zobraz_celkove(pozice, panel_s_byty);
                pozice.Y = pozice.Y + 180;
            }

            if (dalsi_vodomery != null && dalsi_vodomery.Count > 0)
            {
                zobraz_ostatni_vodomery(pozice, panel_s_byty);
                pozice.Y = pozice.Y + 180;

            }

            foreach (byt jedenbyt in byty)
            {
                jedenbyt.zobraz_byt(pozice, panel_s_byty, this.cesta);
                pozice.Y = pozice.Y + 150;
            }

            if (ceny_energii != null)
            {
                zobraz_ceny(new Point(550,80), panel_s_byty);
            }
            panel_s_byty.Refresh();

        }

        private void zobraz_ceny(Point pozice, Panel panel)
        {
            GroupBox box= new GroupBox();
            box.Text = "Ceny Energií";
            box.Width = 260;
            box.Height = 120;
            Point sloupec1 = new Point(30, 25);
            Point sloupec2 = new Point(100, 25);
            Point sloupec3 = new Point(150, 25);

            Label voda = new Label();
            voda.Text = "Voda";
            voda.Location = sloupec1;
            voda.Width = 60;
            sloupec1.Y = sloupec1.Y + 30;

            Label elektrina = new Label();
            elektrina.Text = "Elektrina";
            elektrina.Location = sloupec1;
            elektrina.Width= 60;
            sloupec1.Y = sloupec1.Y + 30;

            Label plyn = new Label();
            plyn.Text = "Plyn";
            plyn.Width = 60;
            plyn.Location = sloupec1;

            voda.Parent = box;
            elektrina.Parent = box;
            plyn.Parent = box;
            //-------------------------------------------------------------------------

            Label voda_cena = new Label();
            voda_cena.Text = ceny_energii.cena_vody_za_m3.ToString();
            voda_cena.Location = sloupec2;
            sloupec2.Y = sloupec2.Y + 30;
            voda_cena.Width = 40;
            voda_cena.Parent = box;

            Label elektrina_cena = new Label();
            elektrina_cena.Text = ceny_energii.cena_elektriny_za_kwh.ToString();
            elektrina_cena.Location = sloupec2;
            sloupec2.Y = sloupec2.Y + 30;
            elektrina_cena.Width = 40;
            elektrina_cena.Parent = box;

            Label plyn_cena = new Label();
            plyn_cena.Text = ceny_energii.cena_plynu_za_m3.ToString();
            plyn_cena.Location = sloupec2;
            plyn_cena.Width = 40;
            plyn_cena.Parent = box;

            //---------------------------------------------------------------------------------

            Label voda_jednotky = new Label();
            voda_jednotky.Text = "kč/m3";
            voda_jednotky.Location = sloupec3;
            sloupec3.Y= sloupec3.Y + 30;
            voda_jednotky.Parent = box;

            Label elektrina_jednotky = new Label();
            elektrina_jednotky.Text = "kč/kwh";
            elektrina_jednotky.Location = sloupec3;
            sloupec3.Y = sloupec3.Y + 30;
            elektrina_jednotky.Parent = box;

            Label plyn_jednotky = new Label();
            plyn_jednotky.Text = "kč/m3";
            plyn_jednotky.Location = sloupec3;
            plyn_jednotky.Parent = box;

            box.Location = pozice;
            box.Parent = panel;
            

        }

        public void zobraz_spolecne_prostory(Point pozice, Panel kam_zobrazit)
        {// možná zobrazovat i id vodomerru, ale asi to neni nutný
            GroupBox box = new GroupBox();
            box.Location = pozice;
            box.Width = 500;
            box.Height = 120;
            box.Text = "Společné prostory";
            box.Parent = kam_zobrazit;

            if (this.spolecne_prostory_voda != null)
            {
                Point pozice_vodomeru = new Point(15, 15);
                Label nadpis_vodomery = new Label();
                nadpis_vodomery.Text = "vodoměr";
                nadpis_vodomery.Location = pozice_vodomeru;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;
                nadpis_vodomery.Parent = box;


                Label spolecny_vodomer_id = new Label();
                spolecny_vodomer_id.Text = "ID: " + this.spolecne_prostory_voda.Id.ToString();// bude tam posledni hodnota
                spolecny_vodomer_id.Location = pozice_vodomeru;
                spolecny_vodomer_id.Parent = box;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;


                Label spolecny_vodomer = new Label();
                spolecny_vodomer.Text = this.spolecne_prostory_voda.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_vodomer.Location = pozice_vodomeru;
                spolecny_vodomer.Parent = box;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;
            }


            if (this.spolecne_prostory_elektrina != null)
            {
                Point pozice_elektromeru = new Point(150, 15);
                Label nadpis_elektromer = new Label();
                nadpis_elektromer.Text = "elektroměr";
                nadpis_elektromer.Location = pozice_elektromeru;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;
                nadpis_elektromer.Parent = box;

                Label spolecny_elektromer_id = new Label();
                spolecny_elektromer_id.Text = "ID: " + this.spolecne_prostory_elektrina.Id.ToString();// bude tam posledni hodnota
                spolecny_elektromer_id.Location = pozice_elektromeru;
                spolecny_elektromer_id.Parent = box;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;

                Label spolecny_elektromer = new Label();
                spolecny_elektromer.Text = this.spolecne_prostory_elektrina.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_elektromer.Location = pozice_elektromeru;
                spolecny_elektromer.Parent = box;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;
            }

            if (this.spolecne_prostory_plyn != null)
            {
                Point pozice_plynomeru = new Point(285, 15);
                Label nadpis_plynomer = new Label();
                nadpis_plynomer.Text = "plynoměr";
                nadpis_plynomer.Location = pozice_plynomeru;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;
                nadpis_plynomer.Parent = box;

                Label spolecny_plynomer_id = new Label();
                spolecny_plynomer_id.Text = "ID: " + this.spolecne_prostory_plyn.Id.ToString();// bude tam posledni hodnota
                spolecny_plynomer_id.Location = pozice_plynomeru;
                spolecny_plynomer_id.Parent = box;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;

                Label spolecny_plynomer = new Label();
                spolecny_plynomer.Text = this.spolecne_prostory_plyn.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_plynomer.Location = pozice_plynomeru;
                spolecny_plynomer.Parent = box;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;

            }

            

        }

       

        public void zobraz_celkove(Point pozice, Panel kam_zobrazit)
        {// možná zobrazovat i id vodomerru, ale asi to neni nutný
            GroupBox box = new GroupBox();
            box.Location = pozice;
            box.Width = 500;
            box.Height = 120;
            box.Text = "Celkové";
            box.Parent = kam_zobrazit;

            if (this.Celkovy_Voda != null)
            {
                Point pozice_vodomeru = new Point(15, 15);
                Label nadpis_vodomery = new Label();
                nadpis_vodomery.Text = "vodoměr";
                nadpis_vodomery.Location = pozice_vodomeru;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;
                nadpis_vodomery.Parent = box;

                Label spolecny_vodomer_id = new Label();
                spolecny_vodomer_id.Text = "ID: " + this.Celkovy_Voda.Id.ToString();// bude tam posledni hodnota
                spolecny_vodomer_id.Location = pozice_vodomeru;
                spolecny_vodomer_id.Parent = box;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;

                Label spolecny_vodomer = new Label();
                spolecny_vodomer.Text = this.Celkovy_Voda.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_vodomer.Location = pozice_vodomeru;
                spolecny_vodomer.Parent = box;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;
            }


            if (this.Celkovy_Elektrina != null)
            {
                Point pozice_elektromeru = new Point(150, 15);
                Label nadpis_elektromer = new Label();
                nadpis_elektromer.Text = "elektroměr";
                nadpis_elektromer.Location = pozice_elektromeru;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;
                nadpis_elektromer.Parent = box;

                Label spolecny_elektromer_id = new Label();
                spolecny_elektromer_id.Text = "ID: " + this.Celkovy_Elektrina.Id.ToString();// bude tam posledni hodnota
                spolecny_elektromer_id.Location = pozice_elektromeru;
                spolecny_elektromer_id.Parent = box;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;

                Label spolecny_elektromer = new Label();
                spolecny_elektromer.Text = this.Celkovy_Elektrina.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_elektromer.Location = pozice_elektromeru;
                spolecny_elektromer.Parent = box;
                pozice_elektromeru.Y = pozice_elektromeru.Y + 25;
            }

            if (this.Celkovy_Plyn != null)
            {
                Point pozice_plynomeru = new Point(285, 15);
                Label nadpis_plynomer = new Label();
                nadpis_plynomer.Text = "plynoměr";
                nadpis_plynomer.Location = pozice_plynomeru;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;
                nadpis_plynomer.Parent = box;

                Label spolecny_plynomer_id = new Label();
                spolecny_plynomer_id.Text = "ID: " + this.Celkovy_Plyn.Id.ToString();// bude tam posledni hodnota
                spolecny_plynomer_id.Location = pozice_plynomeru;
                spolecny_plynomer_id.Parent = box;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;

                Label spolecny_plynomer = new Label();
                spolecny_plynomer.Text = this.Celkovy_Plyn.posledni_hodnota.ToString();// bude tam posledni hodnota
                spolecny_plynomer.Location = pozice_plynomeru;
                spolecny_plynomer.Parent = box;
                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;

            }

        }

        public void zobraz_ostatni_vodomery(Point pozice, Panel kam_zobrazit)
        {
            GroupBox box = new GroupBox();
            box.Location = pozice;
            box.Width = 500;
            box.Height = 130;
            box.Text = "Ostatní vodoměry";
            box.Parent = kam_zobrazit;


            Point pozice_vodomeru = new Point(15, 15);
            foreach (meric jedenvodomer in this.dalsi_vodomery)
            {

                Label id_vodomeru = new Label();
                Label hodnota_vodomeru = new Label();
                Label popis_vodomeru = new Label();

                id_vodomeru.Text = "ID:" + jedenvodomer.Id.ToString();
                id_vodomeru.Location = pozice_vodomeru;
                id_vodomeru.Width = 45;
                pozice_vodomeru.X = pozice_vodomeru.X + 50;
                id_vodomeru.Parent = box;


                popis_vodomeru.Text = jedenvodomer.Popis;
                popis_vodomeru.Location = pozice_vodomeru;
                popis_vodomeru.Width = 120;
                popis_vodomeru.Parent = box;
                pozice_vodomeru.X = pozice_vodomeru.X + 130;


                hodnota_vodomeru.ForeColor = Color.Blue;
                if (jedenvodomer.dopocitavany == false)
                {
                    hodnota_vodomeru.Text = "Hodnota:" + jedenvodomer.posledni_hodnota.ToString(); // misto popisu posledni hodnotu
                }
                else
                {
                    hodnota_vodomeru.Text = "Hodnota: X";
                }
                hodnota_vodomeru.Location = pozice_vodomeru;
                hodnota_vodomeru.Parent = box;
                pozice_vodomeru.X = pozice_vodomeru.X - 180;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;


            }


        }

        public double  spocitej_spolecny()
        {

            double voda_cena = 0, elektrina_cena = 0, plyn_cena = 0;

            if (this.Spolecny_Voda != null)
            {
                double voda_mnozstvi = this.spolecne_prostory_voda.nova_hodnota - this.spolecne_prostory_voda.posledni_hodnota;
                voda_cena = voda_mnozstvi * this.ceny_energii.cena_vody_za_m3;
            }

            if (this.Spolecny_Elektrina != null)
            {
                double elektrina_mnozstvi = this.spolecne_prostory_elektrina.nova_hodnota - this.spolecne_prostory_elektrina.posledni_hodnota;
                elektrina_cena = elektrina_mnozstvi * this.ceny_energii.cena_elektriny_za_kwh;
            }

            if (this.Spolecny_Plyn != null)
            {
                double plyn_mnozstvi = this.spolecne_prostory_plyn.nova_hodnota - this.spolecne_prostory_plyn.posledni_hodnota;
                plyn_cena = plyn_mnozstvi * this.ceny_energii.cena_plynu_za_m3;
            }

            double suma_spolecny = voda_cena + elektrina_cena + plyn_cena;
            double na_jeden_byt = suma_spolecny / this.byty.Count();
            return na_jeden_byt;
        }


        //private void uloz_dum()
        //{ if (!Directory.Exists("DOMY"))
        //    {
        //        Directory.CreateDirectory("DOMY");

        //    }
        //    dum_ulozeni ukladany = new dum_ulozeni(this);

        //    StringWriter sw = new StringWriter();
        //    XmlTextWriter tw = null;
        //    XmlSerializer serializer = new XmlSerializer(typeof(dum_ulozeni));
        //    tw = new XmlTextWriter(sw);
        //    using (StreamWriter swr = new StreamWriter("DOMY\\" + ukladany.popis + ".txt"))
        //    {
        //        serializer.Serialize(tw, ukladany);
        //        swr.Write(sw.ToString());
        //    }


        //}
        public void oznac_pouzity_vodomer(int id, bool oznacovani)
        {
            foreach (byt jedenbyt in byty)
            {
                foreach (meric vodomer in jedenbyt.vodomery)
                {
                    if (vodomer.Id == id)
                    {
                        vodomer.pouzit_v_dopocitavanem = oznacovani;
                    }

                }
            }
            if (dalsi_vodomery != null)
            {
                foreach (meric vodomer in dalsi_vodomery)
                {
                    if (vodomer.Id == id)
                    {
                        vodomer.pouzit_v_dopocitavanem = oznacovani;
                    }

                }
            }
            if (celkovy_voda != null)
            {
                if (celkovy_voda.Id == id)
                {
                    celkovy_voda.pouzit_v_dopocitavanem = oznacovani;
                }

            }

            //TODO-- společný by se neměl používat pro výpočty

            

        }

        public void pripsat_posledni_hodnoty()
        {
            foreach (byt jeden_byt in byty)
            {
                jeden_byt.pripsat_hodnoty_v_byte();
            }
            celkovy_voda.pripsat_posledni_hodnotu();
            celkovy_elektrina.pripsat_posledni_hodnotu();
            if (celkovy_plyn != null)
            {
                celkovy_plyn.pripsat_posledni_hodnotu();
            }


            if (spolecne_prostory_voda != null)
            {
                spolecne_prostory_voda.pripsat_posledni_hodnotu();
            }
            if (spolecne_prostory_elektrina != null)
            {
                spolecne_prostory_elektrina.pripsat_posledni_hodnotu();
            }
            if (spolecne_prostory_plyn != null)
            {
                spolecne_prostory_plyn.pripsat_posledni_hodnotu();
            }

            foreach (meric vodomer in dalsi_vodomery)
            {
                vodomer.pripsat_posledni_hodnotu();
            }



        }
        public void pred_ulozenim()
        {// z nove hodnoty do posledni hodnoty novou nechat nulovou
            foreach (byt jeden_byt in byty)
            {
                foreach(meric jedenvodomer in jeden_byt.vodomery)
                {
                    jedenvodomer.nova_do_posledni();
                }
                jeden_byt.elektrina.nova_do_posledni();
                if (jeden_byt.plyn != null)
                {
                    jeden_byt.plyn.nova_do_posledni();
                }
            }

            celkovy_voda.nova_do_posledni();
            celkovy_elektrina.nova_do_posledni();
            if (celkovy_plyn != null)
            {
                celkovy_plyn.nova_do_posledni();
            }


            if (spolecne_prostory_voda != null)
            {
                spolecne_prostory_voda.nova_do_posledni();
            }
            if (spolecne_prostory_elektrina != null)
            {
                spolecne_prostory_elektrina.nova_do_posledni();
            }
            if (spolecne_prostory_plyn != null)
            {
                spolecne_prostory_plyn.nova_do_posledni();
            }

            foreach (meric vodomer in dalsi_vodomery)
            {
                vodomer.nova_do_posledni();
            }



        }
        /// <summary>
        /// Ověří zda dům obsahuje vše co musí( celkové měřiče, alespoň jeden byt)
        /// </summary>
        /// <returns>
        /// true- splnuje- může být uložen
        /// false - nesplňuje, nesmí být v takovém stavu uložen
        /// </returns>
        
    }
}
