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

namespace Evidence_Spotreb
{
    public partial class vysledky : Form
    {
        public dum zobrazovany;
        List<My_TextBox> textboxy;

        double minula_voda;
        double minula_elektrina;
        double minula_plyn;

        double vodaprebytek = 0;
        double elektrinaprebytek = 0;
        double plynprebytek = 0;

        double spolecny_plyn_cena = 0;
        double spolecna_voda_cena = 0;
        double spolecna_elektrina_cena = 0;

        double vodaSoucet = 0;
        double elektrinaSoucet = 0;
        double plynSoucet = 0;

        //vypoctene z prebytků
        double spolecny_cena = 0;
        //ze spolecných mericů pokud jsou
        double cena_spolecnych = 0;
        double suma=0;

        bool ulozene_vysledky;

        public vysledky(List<My_TextBox> boxy)
        {
            textboxy = boxy;
            InitializeComponent();
        }

        private void vysledky_Load(object sender, EventArgs e)
        {
            ulozene_vysledky = false;
            foreach (byt jeden_byt in zobrazovany.byty)
            {
                jeden_byt.spocti_spotrebu_bytu();
            }

            Point pozice_bytu = new Point(20, 20);
            if (zobrazovany.Spolecny_Elektrina != null || zobrazovany.Spolecny_Voda != null || zobrazovany.Spolecny_Plyn != null)
            {
                cena_spolecnych = this.zobrazovany.spocitej_spolecny();
                //vrací cenu na jeden byt za spotrebu ve spolecnych prostorach pokud pro to jsou merice
            }
            
            foreach (byt jeden_byt in zobrazovany.byty)
            {
                vodaSoucet = vodaSoucet + jeden_byt.mnozstvi_voda;
                elektrinaSoucet = elektrinaSoucet + jeden_byt.mnozstvi_elektrina;
                plynSoucet = plynSoucet + jeden_byt.mnozstvi_plyn;
            }

            vypocet_spolecnych();
            

            bool zapor = false;
            foreach (byt b in zobrazovany.Byty)
            {
                foreach (meric v in b.vodomery)
                {
                    if (v.rozdil_poslednich_hodnot < 0)
                    {
                        zapor = true;
                    }
                }
            }

            
            if (spolecna_voda_cena < 0 || spolecna_elektrina_cena < 0 || spolecny_plyn_cena < 0 || zapor)
            {
                MessageBox.Show("byly zadány divné hodnoty", "CHYBA", MessageBoxButtons.OK);
                this.button3.Enabled = false;
                this.button2.Enabled = false;
                //zobrazovat i pro nesmyslene hodnoty ale s upozornením a neukládat 

                GroupBox box = spolecne_prostory();
                box.Location = pozice_bytu;
                box.Parent=this.panel1;
                pozice_bytu.Y = pozice_bytu.Y + 200;


                foreach (byt jeden_byt in zobrazovany.byty)
                {

                    Byt_groupBox byt_box = new Byt_groupBox(jeden_byt, this.zobrazovany.ceny_energii, spolecny_cena);
                    byt_box.Parent = this.panel1;
                    byt_box.Location = pozice_bytu;
                    pozice_bytu.Y = pozice_bytu.Y + 210;
                    
                }

               
            }
            else
            {

                GroupBox box = spolecne_prostory();
                box.Location = pozice_bytu;
                box.Parent = this.panel1;
                pozice_bytu.Y = pozice_bytu.Y + 200;

                foreach (byt jeden_byt in zobrazovany.byty)
                {
                   
                    Byt_groupBox byt_box = new Byt_groupBox(jeden_byt, this.zobrazovany.ceny_energii, spolecny_cena);
                    byt_box.Parent = this.panel1;
                    byt_box.Location = pozice_bytu;
                    pozice_bytu.Y = pozice_bytu.Y + 210;
                   
                }
            }

          


        }
        //uložení hodnot
        //zapsání s chématu domu s novýma hodnotama

            //TODO enabled jen když nejsou divne hodnoty, nebo varovny msg box
        private void button2_Click(object sender, EventArgs e)
        {
            zobrazovany.pripsat_posledni_hodnoty();
            zobrazovany.pred_ulozenim();
            zobrazovany.ulozit_dum();
            ulozene_vysledky = true;
        }

        GroupBox spolecne_prostory()
        { 
            
            GroupBox box = new GroupBox();
            box.Text = "Ceny energií za společné prostory";
            box.Width = 500;
            box.Height = 180;
            Point sloupec1 = new Point(25, 25);
            Point sloupec2 = new Point(200, 25);
            Point sloupec3 = new Point(375, 25);

            Label voda = new Label();
            voda.Text = "Voda";
            voda.Location = sloupec1;
            voda.Width = 60;
            sloupec1.Y = sloupec1.Y + 25;

            Label elektrina = new Label();
            elektrina.Text = "Elektrina";
            elektrina.Location = sloupec1;
            elektrina.Width = 60;
            sloupec1.Y = sloupec1.Y + 25;

            Label plyn = new Label();
            plyn.Text = "Plyn";
            plyn.Width = 60;
            plyn.Location = sloupec1;

            sloupec1.Y = sloupec1.Y + 40;

            voda.Parent = box;
            elektrina.Parent = box;
            plyn.Parent = box;
            //----------------------------------------------
            Label voda_mnozstvi= new Label();
            Label elektrina_mnozstvi = new Label();
            Label plyn_mnozstvi = new Label();

            voda_mnozstvi.Text = vodaprebytek.ToString();
            elektrina_mnozstvi.Text = elektrinaprebytek.ToString();
            plyn_mnozstvi.Text = plynprebytek.ToString();

            voda_mnozstvi.Location = sloupec2;
            sloupec2.Y = sloupec2.Y + 25;
            elektrina_mnozstvi.Location = sloupec2;
            sloupec2.Y = sloupec2.Y + 25;
            plyn_mnozstvi.Location = sloupec2;

            voda_mnozstvi.Parent = box;
            elektrina_mnozstvi.Parent = box;
            plyn_mnozstvi.Parent = box;
            //---------------------------------------------------------
            Label voda_cena = new Label();
            Label elektrina_cena = new Label();
            Label plyn_cena = new Label();

            voda_cena.Text = spolecna_voda_cena.ToString();
            elektrina_cena.Text = spolecna_elektrina_cena.ToString();
            plyn_cena.Text = spolecny_plyn_cena.ToString();

            voda_cena.Location = sloupec3;
            sloupec3.Y = sloupec3.Y + 25;
            elektrina_cena.Location = sloupec3;
            sloupec3.Y = sloupec3.Y + 25;
            plyn_cena.Location = sloupec3;

            sloupec3.Y = sloupec3.Y + 40;

            voda_cena.Parent = box;
            elektrina_cena.Parent = box;
            plyn_cena.Parent = box;
            //--------------------------------------------------
            Label celkem_cena = new Label();
            celkem_cena.Text = "Cena celkem";
            celkem_cena.Location = sloupec1;
            celkem_cena.Parent = box;
            sloupec1.Y = sloupec1.Y + 25;

            Label cena = new Label();
            cena.Text = suma.ToString()+"Kč"; 
            cena.Location = sloupec3;
            sloupec3.Y = sloupec3.Y + 25;
            cena.Parent = box;


            Label jeden = new Label();
            jeden.Text = "Cena na jeden byt";
            jeden.Location = sloupec1;
            jeden.Parent = box;
            sloupec1.Y = sloupec1.Y + 25;

            Label jeden_cena = new Label();
            jeden_cena.Text = spolecny_cena.ToString() + "Kč";
            jeden_cena.Location = sloupec3;
            sloupec3.Y = sloupec3.Y + 25;
            jeden_cena.Parent = box;

            
            return box;
        }

        private void vypocet_spolecnych()
        {
            if (zobrazovany.Spolecny_Voda == null)
            {
                if (zobrazovany.Celkovy_Voda.hodnoty != null)
                {

                    if (zobrazovany.Celkovy_Voda.hodnoty.Count > 0)
                    {
                        minula_voda = zobrazovany.Celkovy_Voda.hodnoty.Last();
                    }
                    else
                    {
                        minula_voda = 0;
                    }
                    vodaprebytek = (zobrazovany.Celkovy_Voda.rozdil_poslednich_hodnot) - vodaSoucet;
                    spolecna_voda_cena = vodaprebytek * zobrazovany.ceny_energii.cena_vody_za_m3;
                }
                else //tohle by nemělo nastat hodnoty by neměly být null
                {
                    minula_voda = 0;
                }
            }
            //else //existuje vodomer pro spolecne prostory -- musi se odeccist pro přebytek nejen byty ale i spolecne prostory
            //{ //TODO - prepsat jinak aby se to cele zbytečně neopakovalo , obdobně u elektriny a plynu
            //    if (zobrazovany.Celkovy_Voda.hodnoty != null)
            //    {

            //        if (zobrazovany.Celkovy_Voda.hodnoty.Count > 0)
            //        {
            //            minula_voda = zobrazovany.Celkovy_Voda.hodnoty.Last();
            //        }
            //        else
            //        {
            //            minula_voda = 0;
            //        }
            //        vodaprebytek = (zobrazovany.Celkovy_Voda.rozdil_poslednich_hodnot) - (vodaSoucet + zobrazovany.Spolecny_Voda.rozdil_poslednich_hodnot);
            //        spolecna_voda_cena = vodaprebytek * zobrazovany.ceny_energii.cena_vody_za_m3;
            //    }
            //    else //tohle by nemělo nastat hodnoty by neměly být null
            //    {
            //        minula_voda = 0;
            //    }


            //}

            if (zobrazovany.Spolecny_Elektrina == null)
            {
                if (zobrazovany.Celkovy_Elektrina.hodnoty != null)
                {
                    if (zobrazovany.Celkovy_Elektrina.hodnoty.Count > 0)
                    {
                        minula_elektrina = zobrazovany.Celkovy_Elektrina.hodnoty.Last();
                    }
                    else
                    {
                        minula_elektrina = 0;
                    }

                }
                else
                {
                    minula_elektrina = 0;
                }
                elektrinaprebytek = (zobrazovany.Celkovy_Elektrina.rozdil_poslednich_hodnot) - elektrinaSoucet;
                spolecna_elektrina_cena = elektrinaprebytek * zobrazovany.ceny_energii.cena_elektriny_za_kwh;
            }
            //else// spolecny i prebytky
            //{
            //    if (zobrazovany.Celkovy_Elektrina.hodnoty != null)
            //    {
            //        if (zobrazovany.Celkovy_Elektrina.hodnoty.Count > 0)
            //        {
            //            minula_elektrina = zobrazovany.Celkovy_Elektrina.hodnoty.Last();
            //        }
            //        else
            //        {
            //            minula_elektrina = 0;
            //        }

            //    }
            //    else
            //    {
            //        minula_elektrina = 0;
            //    }
            //    elektrinaprebytek = (zobrazovany.Celkovy_Elektrina.rozdil_poslednich_hodnot) - (elektrinaSoucet + zobrazovany.Spolecny_Elektrina.rozdil_poslednich_hodnot);
            //    spolecna_elektrina_cena = elektrinaprebytek * zobrazovany.ceny_energii.cena_elektriny_za_kwh;

            //}

            if ( zobrazovany.Celkovy_Plyn != null)
            {
                if (zobrazovany.Celkovy_Plyn != null && zobrazovany.Celkovy_Plyn.hodnoty != null)
                {
                    if (zobrazovany.Celkovy_Plyn.hodnoty.Count > 0)
                    {
                        minula_plyn = zobrazovany.Celkovy_Plyn.hodnoty.Last();
                    }
                    else
                    {
                        minula_plyn = 0;
                    }
                }
                else
                {
                    minula_plyn = 0;
                }
                plynprebytek = (zobrazovany.Celkovy_Plyn.rozdil_poslednich_hodnot) - plynSoucet;
                spolecny_plyn_cena = plynprebytek * zobrazovany.ceny_energii.cena_plynu_za_m3;
                //if (zobrazovany.Spolecny_Plyn != null)
                //{
                //    plynprebytek = plynprebytek - zobrazovany.Spolecny_Plyn.rozdil_poslednich_hodnot;
                //}
            }
            
           
            //variant je vic- prebytky, spolecny merice, obojí !!!!!
            suma = spolecna_voda_cena + spolecna_elektrina_cena + spolecny_plyn_cena;
            double prebytky_cena = 0;
            prebytky_cena = suma / zobrazovany.Byty.Count();
            spolecny_cena = prebytky_cena + cena_spolecnych;
            spolecny_cena = Math.Ceiling(spolecny_cena);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ulozene_vysledky == false)
            {
                DialogResult dialogResult = MessageBox.Show("Neuloženo", "opravdu chcete zavřít bez uložení hodnot?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //nic
                }


            }
            else
            {
                this.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //rozumné zobrazení cen pro aktualne zadane období
            //nerozdělovat uložení hodnot a souboru s vysledky? uložit je automaticly taky, nebo msgbox s dotazem?
            // do tabulky a ulozit jako html
            // TODO - zapisovat jen jednou jen jako html
            //TODO - přidat nastavení nazvu obdobi při ukládání

            string nazev_souboru=textBox1.Text;
            if (nazev_souboru == "")
            {
                nazev_souboru = "posledni_obdobi";
            }

            //------------------------------
            var folderBrowserDialog1 = new FolderBrowserDialog();
            
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string cesta = folderBrowserDialog1.SelectedPath;
  

            //------------------------------


            using (StreamWriter sw = new StreamWriter(cesta + "\\"+nazev_souboru + ".html"))
            {
                zobrazovany.pripsat_posledni_hodnoty();
                zobrazovany.pred_ulozenim();

                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<style type=\"text/css\">");

                sw.WriteLine("table { border: 1px solid black;");
                sw.WriteLine("border-collapse: collapse;}");



                sw.WriteLine("</style>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");

                zapis_ceny(sw);

                foreach (byt jedenbyt in zobrazovany.byty)
                {
                    jedenbyt.zapis_byt_do_html(sw, this.zobrazovany.ceny_energii, spolecny_cena);

                }
                sw.WriteLine("<br><br>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");

            }
           }

            //ulozeni hodnot domu

            // TODO - odkomentovat (pro testovani se to neukládá )

            //zobrazovany.pripsat_posledni_hodnoty();
            //zobrazovany.pred_ulozenim();
            //zobrazovany.ulozit_dum();
            //ulozene_vysledky = true;


        }

        void zapis_ceny(StreamWriter sw)
        {
            sw.WriteLine("<h3>Ceny energií</h3>");
            sw.WriteLine("<p>voda:"+zobrazovany.ceny_energii.cena_vody_za_m3.ToString()+"kč/m3</p>");
            sw.WriteLine("<p>elektřina:"+ zobrazovany.ceny_energii.cena_elektriny_za_kwh.ToString()+ "kč/kwh</p>");
            sw.WriteLine("<p>plyn"+ zobrazovany.ceny_energii.cena_plynu_za_m3.ToString()+ "kč/m3</p>");

        }
    }
}
