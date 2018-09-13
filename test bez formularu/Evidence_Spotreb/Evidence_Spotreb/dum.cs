using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Linq;
using System.Text;


namespace Evidence_Spotreb
{
    public class dum
    {
        public dum() { }

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

        public List<meric> Dalsi_Vodomery
        {
            get
            {
                return dalsi_vodomery;
            }
            set
            {
                dalsi_vodomery = value;
            }
        }

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

            if (Dalsi_Vodomery != null && Dalsi_Vodomery.Count > 0)
            {
                zobraz_ostatni_vodomery(pozice, panel_s_byty);
                pozice.Y = pozice.Y + 180;

            }

            foreach (byt jedenbyt in byty)
            {
                jedenbyt.zobraz_byt(pozice, panel_s_byty, this.cesta);
                pozice.Y = pozice.Y + 150;
            }
            panel_s_byty.Refresh();

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
            foreach (meric jedenvodomer in this.Dalsi_Vodomery)
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
    }
}
