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
    public partial class zadavani_hodnot : Form
    {
        //public bool prvni_hodnoty;
        public dum zobrazovany;
        List<My_TextBox> textboxy;
        List<My_TextBox> textboxy_dopocitavane ;  // nebudou se zobrazovat

        public zadavani_hodnot()
        {
            textboxy_dopocitavane = new List<My_TextBox>();
            InitializeComponent();
        }
        
        

        void Pridej_do_listu(My_TextBox box)
        {
            if (textboxy == null)
            {
                textboxy = new List<My_TextBox>();
            }
            textboxy.Add(box);
        }

        public bool vsude_platne_hodnoty()
        {
            int pocet_platnych=0;
            foreach (My_TextBox box in textboxy)
            {
                if (box.platna_hodnota == true)
                {
                    pocet_platnych++;
                }

            }
            if (pocet_platnych == textboxy.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       

        private void zadavani_hodnot_Load(object sender, EventArgs e)
        {


            label1.Text = zobrazovany.ceny_energii.cena_vody_za_m3.ToString();
            label2.Text = zobrazovany.ceny_energii.cena_elektriny_za_kwh.ToString();
            label3.Text = zobrazovany.ceny_energii.cena_plynu_za_m3.ToString();


            Label popis = new Label();
            popis.Width = 300;
            popis.Text = zobrazovany.popis;
            popis.Location = new Point(25, 25);
            popis.Font=new Font("Microsoft Sans Serif",20);
            popis.Height = 30;
            popis.Parent = this;
            
            
            Panel zobrazovaci_panel = new Panel();
            zobrazovaci_panel.Location = new Point(25, 70);
            zobrazovaci_panel.Width = 650;
            zobrazovaci_panel.Height = 400;
            zobrazovaci_panel.BackColor = Color.LightGray;
            zobrazovaci_panel.Parent = this;
            zobrazovaci_panel.AutoScroll = true;

            Point ID_pozice = new Point(25, 25);
            Point POPIS_pozice = new Point(80, 25);
            Point ZADAVANI_pozice = new Point(480, 25);


            Label id_label = new Label();
            id_label.Text = "ID";
            id_label.Location = ID_pozice;
            id_label.Width = 40;
            //id_label.BackColor = Color.Yellow;
            id_label.Parent = zobrazovaci_panel;

            Label popis_label = new Label();
            popis_label.Text = "POPIS";

            popis_label.Location = POPIS_pozice;
            popis_label.Parent = zobrazovaci_panel;

            Label zadvani_label = new Label();
            zadvani_label.Text = "ZADÁVÁNÍ";
            zadvani_label.Location = ZADAVANI_pozice;
            zadvani_label.Parent = zobrazovaci_panel;

            ID_pozice.Y = ID_pozice.Y + 25;
            POPIS_pozice.Y = POPIS_pozice.Y + 25;
            ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;

            
            foreach (byt jeden_byt in zobrazovany.Byty)
            {
                foreach (meric jeden_vodomer in jeden_byt.vodomery)
                {
                    if (jeden_vodomer.dopocitavany == false)
                    {
                        Label id_vodomeru = new Label();
                        id_vodomeru.Text = jeden_vodomer.Id.ToString();
                        id_vodomeru.Location = ID_pozice;
                        id_vodomeru.Width = 40;
                        id_vodomeru.Parent = zobrazovaci_panel;

                        Label popis_vodomeru = new Label();
                        popis_vodomeru.Text = jeden_vodomer.Popis;
                        popis_vodomeru.Location = POPIS_pozice;
                        popis_vodomeru.BackColor = Color.LightBlue;
                        popis_vodomeru.Width = 350;
                        popis_vodomeru.Parent = zobrazovaci_panel;

                        My_TextBox zadavani = new My_TextBox();
                        zadavani.Location = ZADAVANI_pozice;
                        zadavani.Parent = zobrazovaci_panel;
                        zadavani.zadavany_meric = jeden_vodomer;
                        Pridej_do_listu(zadavani);
                        // zadavani.Text = zadavani.voda.posledni_hodnota.ToString();
                        // to tam neni potřeba
                        //--------------------
                        ID_pozice.Y = ID_pozice.Y + 25;
                        POPIS_pozice.Y = POPIS_pozice.Y + 25;
                        ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;

                        // zadavani.Text = "350";
                    }
                    else// dopociatavany vodomer
                    {
                        My_TextBox dopocitavany = new My_TextBox();
                        if (textboxy_dopocitavane == null)
                        {
                            textboxy_dopocitavane = new List<My_TextBox>();
                        }
                        dopocitavany.zadavany_meric = jeden_vodomer;
                        textboxy_dopocitavane.Add(dopocitavany);


                    }
                }

                Label id_elektromeru = new Label();
                id_elektromeru.Text = jeden_byt.elektrina.Id.ToString();
                id_elektromeru.Location = ID_pozice;
                id_elektromeru.Width = 40;
                id_elektromeru.Parent = zobrazovaci_panel;

                Label popis_elektromeru = new Label();
                popis_elektromeru.Text = jeden_byt.elektrina.Popis;
                popis_elektromeru.Location = POPIS_pozice;
                popis_elektromeru.BackColor = Color.Yellow;
                popis_elektromeru.Width = 350;
                popis_elektromeru.Parent = zobrazovaci_panel;

                My_TextBox zadavani_elektromeru = new My_TextBox();
                zadavani_elektromeru.Location = ZADAVANI_pozice;
                zadavani_elektromeru.Parent = zobrazovaci_panel;
                zadavani_elektromeru.zadavany_meric = jeden_byt.elektrina;
                Pridej_do_listu(zadavani_elektromeru);

                ID_pozice.Y = ID_pozice.Y + 25;
                POPIS_pozice.Y = POPIS_pozice.Y + 25;
                ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;



                if (jeden_byt.plyn != null)
                {
                    Label id_plynu = new Label();
                    id_plynu.Text = jeden_byt.plyn.Id.ToString();
                    id_plynu.Location = ID_pozice;
                    id_plynu.Width = 40;
                    id_plynu.Parent = zobrazovaci_panel;

                    Label popis_plynu = new Label();
                    popis_plynu.Text = jeden_byt.plyn.Popis;
                    popis_plynu.Location = POPIS_pozice;
                    popis_plynu.BackColor = Color.Red;
                    popis_plynu.Width = 350;
                    popis_plynu.Parent = zobrazovaci_panel;

                    My_TextBox zadavani_plynu = new My_TextBox();
                    zadavani_plynu.Location = ZADAVANI_pozice;
                    zadavani_plynu.Parent = zobrazovaci_panel;
                    zadavani_plynu.zadavany_meric = jeden_byt.plyn;
                    Pridej_do_listu(zadavani_plynu);

                    ID_pozice.Y = ID_pozice.Y + 25;
                    POPIS_pozice.Y = POPIS_pozice.Y + 25;
                    ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
                }

            }


            if (zobrazovany.dalsi_vodomery != null)
            {
                foreach (meric jeden_vodomer in zobrazovany.dalsi_vodomery)
                {
                    Label id_vodomeru = new Label();
                    id_vodomeru.Text = jeden_vodomer.Id.ToString();
                    id_vodomeru.Location = ID_pozice;
                    id_vodomeru.Width = 40;
                    id_vodomeru.Parent = zobrazovaci_panel;

                    Label popis_vodomeru = new Label();
                    popis_vodomeru.Text = jeden_vodomer.Popis;
                    popis_vodomeru.Location = POPIS_pozice;
                    popis_vodomeru.BackColor = Color.LightBlue;
                    popis_vodomeru.Width = 350;
                    popis_vodomeru.Parent = zobrazovaci_panel;

                    My_TextBox zadavani = new My_TextBox();
                    zadavani.Location = ZADAVANI_pozice;
                    zadavani.Parent = zobrazovaci_panel;
                    zadavani.zadavany_meric = jeden_vodomer;
                    Pridej_do_listu(zadavani);

                    ID_pozice.Y = ID_pozice.Y + 25;
                    POPIS_pozice.Y = POPIS_pozice.Y + 25;
                    ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;

                }
            }


            Label id_celkovyVoda = new Label();
            id_celkovyVoda.Text = zobrazovany.Celkovy_Voda.Id.ToString();
            id_celkovyVoda.Location = ID_pozice;
            id_celkovyVoda.Width = 40;
            id_celkovyVoda.Parent = zobrazovaci_panel;

            Label popis_celkovy_vodomer = new Label();
            popis_celkovy_vodomer.Text = zobrazovany.Celkovy_Voda.Popis;
            popis_celkovy_vodomer.Location = POPIS_pozice;
            popis_celkovy_vodomer.BackColor = Color.Olive;
            popis_celkovy_vodomer.Width = 350;
            popis_celkovy_vodomer.Parent = zobrazovaci_panel;

            My_TextBox zadavani_celkovy_vodomer = new My_TextBox();
            zadavani_celkovy_vodomer.Location = ZADAVANI_pozice;
            zadavani_celkovy_vodomer.Parent = zobrazovaci_panel;
            zadavani_celkovy_vodomer.zadavany_meric = zobrazovany.Celkovy_Voda;
            Pridej_do_listu(zadavani_celkovy_vodomer);

            ID_pozice.Y = ID_pozice.Y + 25;
            POPIS_pozice.Y = POPIS_pozice.Y + 25;
            ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
            //-------------------------------------------------------------------------------

            Label id_celkovyElektrina = new Label();
            id_celkovyElektrina.Text = zobrazovany.Celkovy_Elektrina.Id.ToString();
            id_celkovyElektrina.Location = ID_pozice;
            id_celkovyElektrina.Width = 40;
            id_celkovyElektrina.Parent = zobrazovaci_panel;

            Label popis_celkovy_elektrina = new Label();
            popis_celkovy_elektrina.Text = zobrazovany.Celkovy_Elektrina.Popis;
            popis_celkovy_elektrina.Location = POPIS_pozice;
            popis_celkovy_elektrina.BackColor = Color.Olive;
            popis_celkovy_elektrina.Width = 350;
            popis_celkovy_elektrina.Parent = zobrazovaci_panel;

            My_TextBox zadavani_celkovy_elektrina = new My_TextBox();
            zadavani_celkovy_elektrina.Location = ZADAVANI_pozice;
            zadavani_celkovy_elektrina.Parent = zobrazovaci_panel;
            zadavani_celkovy_elektrina.zadavany_meric = zobrazovany.Celkovy_Elektrina;
            Pridej_do_listu(zadavani_celkovy_elektrina);

            ID_pozice.Y = ID_pozice.Y + 25;
            POPIS_pozice.Y = POPIS_pozice.Y + 25;
            ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;

            //---------------------------------------------------------------------------------------
            if (zobrazovany.Celkovy_Plyn != null)
            {
                Label id_celkovyPlyn = new Label();
                id_celkovyPlyn.Text = zobrazovany.Celkovy_Plyn.Id.ToString();
                id_celkovyPlyn.Location = ID_pozice;
                id_celkovyPlyn.Width = 40;
                id_celkovyPlyn.Parent = zobrazovaci_panel;

                Label popis_celkovy_Plyn = new Label();
                popis_celkovy_Plyn.Text = zobrazovany.Celkovy_Plyn.Popis;
                popis_celkovy_Plyn.Location = POPIS_pozice;
                popis_celkovy_Plyn.BackColor = Color.Olive;
                popis_celkovy_Plyn.Width = 350;
                popis_celkovy_Plyn.Parent = zobrazovaci_panel;

                My_TextBox zadavani_celkovy_Plyn = new My_TextBox();
                zadavani_celkovy_Plyn.Location = ZADAVANI_pozice;
                zadavani_celkovy_Plyn.Parent = zobrazovaci_panel;
                zadavani_celkovy_Plyn.zadavany_meric = zobrazovany.Celkovy_Plyn;
                Pridej_do_listu(zadavani_celkovy_Plyn);

                ID_pozice.Y = ID_pozice.Y + 25;
                POPIS_pozice.Y = POPIS_pozice.Y + 25;
                ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
            }


            //***********************************************************************
            //spolecne prostory
            //*******************************************************************************

            if (zobrazovany.Spolecny_Voda != null)
            {
                Label id_spolecnaVoda = new Label();
                id_spolecnaVoda.Text = zobrazovany.Spolecny_Voda.Id.ToString();
                id_spolecnaVoda.Location = ID_pozice;
                id_spolecnaVoda.Width = 40;
                id_spolecnaVoda.Parent = zobrazovaci_panel;

                Label popis_spolecny_vodomer = new Label();
                popis_spolecny_vodomer.Text = zobrazovany.Spolecny_Voda.Popis;
                popis_spolecny_vodomer.Location = POPIS_pozice;
                popis_spolecny_vodomer.BackColor = Color.Orange;
                popis_spolecny_vodomer.Width = 350;
                popis_spolecny_vodomer.Parent = zobrazovaci_panel;

                My_TextBox zadavani_spolecny_vodomer = new My_TextBox();
                zadavani_spolecny_vodomer.Location = ZADAVANI_pozice;
                zadavani_spolecny_vodomer.Parent = zobrazovaci_panel;
                zadavani_spolecny_vodomer.zadavany_meric = zobrazovany.Spolecny_Voda;
                Pridej_do_listu(zadavani_spolecny_vodomer);

                ID_pozice.Y = ID_pozice.Y + 25;
                POPIS_pozice.Y = POPIS_pozice.Y + 25;
                ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
            }
            //-------------------------------------------------------------------------------
            if (zobrazovany.Spolecny_Elektrina != null)
            {
                Label id_spolecny_Elektrina = new Label();
                id_spolecny_Elektrina.Text = zobrazovany.Spolecny_Elektrina.Id.ToString();
                id_spolecny_Elektrina.Location = ID_pozice;
                id_spolecny_Elektrina.Width = 40;
                id_spolecny_Elektrina.Parent = zobrazovaci_panel;

                Label popis_spolecny_elektrina = new Label();
                popis_spolecny_elektrina.Text = zobrazovany.Spolecny_Elektrina.Popis;
                popis_spolecny_elektrina.Location = POPIS_pozice;
                popis_spolecny_elektrina.BackColor = Color.Yellow;
                popis_spolecny_elektrina.Width = 350;
                popis_spolecny_elektrina.Parent = zobrazovaci_panel;

                My_TextBox zadavani_spolecny_elektrina = new My_TextBox();
                zadavani_spolecny_elektrina.Location = ZADAVANI_pozice;
                zadavani_spolecny_elektrina.Parent = zobrazovaci_panel;
                zadavani_spolecny_elektrina.zadavany_meric = zobrazovany.Spolecny_Elektrina;
                Pridej_do_listu(zadavani_spolecny_elektrina);

                ID_pozice.Y = ID_pozice.Y + 25;
                POPIS_pozice.Y = POPIS_pozice.Y + 25;
                ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
            }

            //---------------------------------------------------------------------------------------
            if (zobrazovany.Spolecny_Plyn != null)
            {

                Label id_spolecny_Plyn = new Label();
                id_spolecny_Plyn.Text = zobrazovany.Celkovy_Elektrina.Id.ToString();
                id_spolecny_Plyn.Location = ID_pozice;
                id_spolecny_Plyn.Width = 40;
                id_spolecny_Plyn.Parent = zobrazovaci_panel;

                Label popis_spolecny_Plyn = new Label();
                popis_spolecny_Plyn.Text = zobrazovany.Spolecny_Plyn.Popis;
                popis_spolecny_Plyn.Location = POPIS_pozice;
                popis_spolecny_Plyn.BackColor = Color.Yellow;
                popis_spolecny_Plyn.Width = 350;
                popis_spolecny_Plyn.Parent = zobrazovaci_panel;

                My_TextBox zadavani_spolecny_Plyn = new My_TextBox();
                zadavani_spolecny_Plyn.Location = ZADAVANI_pozice;
                zadavani_spolecny_Plyn.Parent = zobrazovaci_panel;
                zadavani_spolecny_Plyn.zadavany_meric = zobrazovany.Spolecny_Plyn;
                Pridej_do_listu(zadavani_spolecny_Plyn);

                ID_pozice.Y = ID_pozice.Y + 25;
                POPIS_pozice.Y = POPIS_pozice.Y + 25;
                ZADAVANI_pozice.Y = ZADAVANI_pozice.Y + 25;
            }


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!vsude_platne_hodnoty())
            {
                MessageBox.Show("Některá z hodnot není platná( je označena červeně,nebo není vyplněná)", "Neplatné hodnoty", MessageBoxButtons.OK);
            }
            else
            {
                    spocti_rozdily();
                    zapis_rozdily_do_domu();
                    vysledky vysledne_hodnoty = new vysledky(textboxy);
                    vysledne_hodnoty.zobrazovany = zobrazovany;
                    vysledne_hodnoty.ShowDialog();
                    
                    
                    //zobrazovany.ulozit_dum();
                    // ukladat az po potvrzeni
                
                
                this.Close();
            }
        }

        private void spocti_rozdily()
        {//nejdrive nedopočítávané
            foreach (My_TextBox jedenmeric in textboxy)
            {
                if (jedenmeric.zadavany_meric.dopocitavany == false)//tohle nebude potřeba tay budou jen nedopocitavane
                {
                    double rozdil = Double.Parse(jedenmeric.Text) - jedenmeric.zadavany_meric.posledni_hodnota;
                    jedenmeric.zadavany_meric.rozdil_poslednich_hodnot = rozdil;
                    jedenmeric.zadavany_meric.nova_hodnota = Double.Parse(jedenmeric.Text);
                }
            }
            //dopocitavane až kdyz mame rozdily dopocitavanych
            //jiny seznam aby se neprochazely vsechny
            foreach (My_TextBox jedenmeric in textboxy_dopocitavane)
            {
                double spolecny_rozdil = 0;
                double suma_odecitanych = 0;
                double rozdil;
                //najde meric od ktereho se odecítá a rozdíl jeho hodnot

                foreach (My_TextBox jedenmeric_odecitany in textboxy)
                {
                    if (jedenmeric_odecitany.zadavany_meric.Id == jedenmeric.zadavany_meric.spolecnyID)
                    {
                        spolecny_rozdil = jedenmeric_odecitany.zadavany_meric.rozdil_poslednich_hodnot;
                    }
                }
                //najde ty ktere se budou odecitat
                foreach (My_TextBox odecitany in textboxy)
                {
                    if (jedenmeric.zadavany_meric.odecitane.Contains(odecitany.zadavany_meric.Id))
                    {
                        suma_odecitanych = suma_odecitanych + odecitany.zadavany_meric.rozdil_poslednich_hodnot;
                    }
                }

                rozdil = spolecny_rozdil - suma_odecitanych;
                
                    jedenmeric.zadavany_meric.rozdil_poslednich_hodnot = rozdil;
               
            }
        }


        private void zapis_rozdily_do_domu()
        { foreach (byt jeden_byt in zobrazovany.byty)
            {
                foreach (meric jedenvodomer in jeden_byt.vodomery)
                {
                    jedenvodomer.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(jedenvodomer.Id, jedenvodomer.dopocitavany);
                    jedenvodomer.nova_hodnota = najdi_odpovidajici_nove_hodnoty(jedenvodomer.Id, jedenvodomer.dopocitavany);
                }
                jeden_byt.elektrina.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(jeden_byt.elektrina.Id, false);
                jeden_byt.elektrina.nova_hodnota = najdi_odpovidajici_nove_hodnoty(jeden_byt.elektrina.Id, false);
                if (jeden_byt.plyn!=null)
                {
                    jeden_byt.plyn.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(jeden_byt.plyn.Id, false);
                    jeden_byt.plyn.nova_hodnota = najdi_odpovidajici_nove_hodnoty(jeden_byt.plyn.Id, false);
                }

            }

            zobrazovany.celkovy_voda.rozdil_poslednich_hodnot= najdi_odpovidajici_rozdil_hodnot(zobrazovany.celkovy_voda.Id, false);
            zobrazovany.celkovy_voda.nova_hodnota = najdi_odpovidajici_nove_hodnoty(zobrazovany.celkovy_voda.Id, false);

            zobrazovany.celkovy_elektrina.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(zobrazovany.celkovy_elektrina.Id, false);
            zobrazovany.celkovy_elektrina.nova_hodnota = najdi_odpovidajici_nove_hodnoty(zobrazovany.celkovy_elektrina.Id, false);

            if (zobrazovany.celkovy_plyn != null)
            {
                zobrazovany.celkovy_plyn.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(zobrazovany.celkovy_plyn.Id, false);
                zobrazovany.celkovy_plyn.nova_hodnota = najdi_odpovidajici_nove_hodnoty(zobrazovany.celkovy_plyn.Id, false);
            }
            if (zobrazovany.dalsi_vodomery != null)
            {
                foreach (meric jeden_vodomer in zobrazovany.dalsi_vodomery)
                {
                    jeden_vodomer.rozdil_poslednich_hodnot = najdi_odpovidajici_rozdil_hodnot(jeden_vodomer.Id, false);
                    jeden_vodomer.nova_hodnota= najdi_odpovidajici_nove_hodnoty(jeden_vodomer.Id, false);
                }
            }

        }



         private double najdi_odpovidajici_rozdil_hodnot(int ID, bool dopocitavany)
        {
            if (dopocitavany == false)
            {
                foreach (My_TextBox box in textboxy)
                {
                    if (box.zadavany_meric.Id == ID)
                    {
                        return box.zadavany_meric.rozdil_poslednich_hodnot;
                    }
                   
                }
                return 0;
            }
            else
            {
                foreach (My_TextBox box in textboxy_dopocitavane)
                {
                    if (box.zadavany_meric.Id == ID)
                    {
                        return box.zadavany_meric.rozdil_poslednich_hodnot;
                    }
                    
                }
                return 0;
            }

        }

        private double najdi_odpovidajici_nove_hodnoty(int ID, bool dopocitavany)
        {
            if (dopocitavany == false)
            {
                foreach (My_TextBox box in textboxy)
                {
                    if (box.zadavany_meric.Id == ID)
                    {
                        return box.zadavany_meric.nova_hodnota;
                    }

                }
                return 0;
                
            }
            else
            {// je dopocítávany a hodnota nova hodnota merice neni zadaná a spočítá se az pri zápisu do seznamu hodnot 
                return 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
