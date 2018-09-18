using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Evidence_Spotreb
{
    public class byt
    { public byt()
        { upraveno = false; }
    
        private string popis;
        public string Popis
        {
            get
            {
                return popis;
            }
            set
            {
                popis = value;
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public bool upraveno;

        public List<meric> vodomery;
        public int zaloha;
        public meric plyn;// nemusí mít všichni
        public meric elektrina;
        public double cena_za_posledni_mesic;

        public double cena_voda;
        public double cena_elektrina;
        public double cena_plyn;

        public double mnozstvi_voda;
        public double mnozstvi_elektrina;
        public double mnozstvi_plyn;

        public void spocti_spotrebu_bytu()
        {
            mnozstvi_elektrina = elektrina.rozdil_poslednich_hodnot;
            if (plyn != null)
            {
                mnozstvi_plyn = plyn.rozdil_poslednich_hodnot;
            }

            double voda = 0;
            foreach (meric vodomer in vodomery)
            {
                voda = voda + vodomer.rozdil_poslednich_hodnot;
            }
            mnozstvi_voda = voda;



        }

        public void zobraz_byt(Point pozice, Panel kam_zobrazit, string cesta_domu)
        {

            GroupBox gr_byt = new GroupBox();

            gr_byt.Text = this.popis;
            gr_byt.Height = 135;
            gr_byt.Width = 800;
            gr_byt.Location = pozice;
            gr_byt.Parent = kam_zobrazit;
            kam_zobrazit.Refresh();

            Point zalohy_pozice = new Point(550, 60);
            Label zalohy = new Label();
            zalohy.Location = zalohy_pozice;
            zalohy.Height = 32;
            zalohy.Width = 240;
            zalohy.Text = "Zálohy:" + this.zaloha.ToString() + "Kč";

            zalohy.Font = new Font(zalohy.Font.FontFamily, 18);
            zalohy.ForeColor = Color.DarkGreen;
            zalohy.Parent = gr_byt;

            Button graf = new Button();
            Point graf_pozice = new Point(720, 10);
            graf.Text = "graf";
            graf.Location = graf_pozice;
            graf.Click += Zobraz_Graf;
            //graf.Tag = cesta_domu;
            graf.Parent = gr_byt;


            //TODO- vyřešit změny jinak

            //Button zalohy_zmena = new Button();
            //Point zalohy_zmena_pozice = new Point(720, 30);
            //zalohy_zmena.Text = "Zmenit zalohy";
            //zalohy_zmena.Location = zalohy_zmena_pozice;
            //zalohy_zmena.Click += zmena_zaloh;
            //zalohy_zmena.Parent = gr_byt;



            Point pozice_vodomeru = new Point(15, 15);
            Label nadpis_vodomery = new Label();
            nadpis_vodomery.Text = "Vodoměry";
            nadpis_vodomery.Location = pozice_vodomeru;

            pozice_vodomeru.Y = pozice_vodomeru.Y + 25;
            nadpis_vodomery.Parent = gr_byt;
            kam_zobrazit.Refresh();





            foreach (meric jedenvodomer in vodomery)
            {

                Label id_vodomeru = new Label();
                Label hodnota_vodomeru = new Label();
                Label popis_vodomeru = new Label();

                id_vodomeru.Text = "ID:" + jedenvodomer.Id.ToString();
                id_vodomeru.Location = pozice_vodomeru;
                id_vodomeru.Width = 45;
                pozice_vodomeru.X = pozice_vodomeru.X + 50;
                id_vodomeru.Parent = gr_byt;


                popis_vodomeru.Text = jedenvodomer.Popis;
                popis_vodomeru.Location = pozice_vodomeru;
                popis_vodomeru.Width = 120;
                popis_vodomeru.Parent = gr_byt;
                pozice_vodomeru.X = pozice_vodomeru.X + 130;





                hodnota_vodomeru.ForeColor = Color.Blue;
                if (jedenvodomer.dopocitavany == false)
                {
                    hodnota_vodomeru.Text = "Hodnota:" + jedenvodomer.posledni_hodnota.ToString(); // misto popisu posledni hodnotu
                }
                else
                {
                    hodnota_vodomeru.Text = "Hodnota: Dop.";
                }
                hodnota_vodomeru.Location = pozice_vodomeru;
                hodnota_vodomeru.Parent = gr_byt;
                pozice_vodomeru.X = pozice_vodomeru.X - 180;
                pozice_vodomeru.Y = pozice_vodomeru.Y + 25;




            }
            Label nadpis_elektromer = new Label();
            Point pozice_elektromeru = new Point(350, 15);
            nadpis_elektromer.Text = "Elektroměry";
            nadpis_elektromer.Location = pozice_elektromeru;
            nadpis_elektromer.Parent = gr_byt;


            pozice_elektromeru.Y = pozice_elektromeru.Y + 25;
            Label elektromer_id = new Label();
            elektromer_id.Text = "ID:" + this.elektrina.Id.ToString();
            elektromer_id.Location = pozice_elektromeru;
            elektromer_id.Width = 45;
            elektromer_id.Parent = gr_byt;

            pozice_elektromeru.X = pozice_elektromeru.X + 50;
            Label hodnota_elektromeru = new Label();
            hodnota_elektromeru.Text = "Hodnota:" + this.elektrina.posledni_hodnota.ToString();
            hodnota_elektromeru.ForeColor = Color.Blue;
            hodnota_elektromeru.Location = pozice_elektromeru;
            hodnota_elektromeru.Parent = gr_byt;


            if (this.plyn != null)
            {
                Label nadpis_plynomer = new Label();
                Point pozice_plynomeru = new Point(550, 15);
                nadpis_plynomer.Text = "Plynoměry";
                nadpis_plynomer.Location = pozice_plynomeru;
                nadpis_plynomer.Parent = gr_byt;


                pozice_plynomeru.Y = pozice_plynomeru.Y + 25;
                Label plynomer_id = new Label();
                plynomer_id.Text = "ID:" + this.plyn.Id.ToString();
                plynomer_id.Location = pozice_plynomeru;
                plynomer_id.Width = 45;
                plynomer_id.Parent = gr_byt;

                pozice_plynomeru.X = pozice_plynomeru.X + 50;
                Label hodnota_plynomer = new Label();
                hodnota_plynomer.Text = "Hodnota:" + this.plyn.posledni_hodnota.ToString();
                hodnota_plynomer.ForeColor = Color.Blue;
                hodnota_plynomer.Location = pozice_plynomeru;
                hodnota_plynomer.Parent = gr_byt;
            }



        }

        public void Zobraz_Graf(object sender, EventArgs e)
        {
            byt zobrazovany = this;
            Button b = (Button)sender;
            string cesta = (String)b.Tag;
            graf_spotreb graf = new graf_spotreb();
            graf.tento_byt = this;
            graf.ShowDialog();


        }

        public void zmena_zaloh(object sender, EventArgs e)
        {
            zmenit_zalohy z = new zmenit_zalohy();
            z.tento_byt = this;
            z.ShowDialog();
            //ikdyz uprava vlastne neprobehla
            upraveno = true;

            

        }

        public void zapis_byt_do_html(StreamWriter sw, ceny ceny_energii, double spolecne)
        {
            double celkem = 0;
            sw.WriteLine("<h3>" + popis + "<h3>");
          sw.WriteLine("<table>");
            sw.WriteLine("<th>typ</th><th>popis</th><th>mnozstvi</th><th>cena</th>");
            foreach (meric vodomer in vodomery)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>"+"voda"+"</td>");
                sw.WriteLine("<td>" + vodomer.Popis + "</td>");
                sw.WriteLine("<td>" + vodomer.rozdil_poslednich_hodnot + "</td>");
                sw.WriteLine("<td>" + (vodomer.rozdil_poslednich_hodnot*ceny_energii.cena_vody_za_m3).ToString() + " Kč</td>");
                sw.WriteLine("</tr>");
                celkem = celkem + (vodomer.rozdil_poslednich_hodnot * ceny_energii.cena_vody_za_m3);

            }
            //elektrina
            sw.WriteLine("<tr>");
            sw.WriteLine("<td>" + "elektrina" + "</td>");
            sw.WriteLine("<td>" + elektrina.Popis + "</td>");
            sw.WriteLine("<td>" + elektrina.rozdil_poslednich_hodnot + "</td>");
            sw.WriteLine("<td>" + (elektrina.rozdil_poslednich_hodnot * ceny_energii.cena_elektriny_za_kwh).ToString() + " Kč</td>");
            sw.WriteLine("</tr>");
            celkem = celkem + (elektrina.rozdil_poslednich_hodnot * ceny_energii.cena_elektriny_za_kwh);

            //plyn
            if (plyn != null)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>" + "plyn" + "</td>");
                sw.WriteLine("<td>" + plyn.Popis + "</td>");
                sw.WriteLine("<td>" + plyn.rozdil_poslednich_hodnot + "</td>");
                sw.WriteLine("<td>" + (plyn.rozdil_poslednich_hodnot * ceny_energii.cena_plynu_za_m3).ToString() + " Kč</td>");
                sw.WriteLine("</tr>");
                celkem = celkem + (plyn.rozdil_poslednich_hodnot * ceny_energii.cena_plynu_za_m3);
            }

            sw.WriteLine("<tr>");
            sw.WriteLine("<td>" + "spolecne" + "</td>");
            sw.WriteLine("<td>" + "" + "</td>");
            sw.WriteLine("<td>" + ""+ "</td>");
            sw.WriteLine("<td>" + spolecne.ToString()+ " Kč</td>");
            sw.WriteLine("</tr>");

          

            sw.WriteLine("<tr>");
            sw.WriteLine("<td>" + "celkem" + "</td>");
            sw.WriteLine("<td>" + "" + "</td>");
            sw.WriteLine("<td>" + "" + "</td>");
            sw.WriteLine("<td>" + celkem.ToString() + " Kč</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("</table>");

        }

        public void pripsat_hodnoty_v_byte()
        {
            foreach (meric vodomer in vodomery)
            {
                vodomer.pripsat_posledni_hodnotu();
            }
            elektrina.pripsat_posledni_hodnotu();

            if (plyn != null)
            {
                plyn.pripsat_posledni_hodnotu();
            }
        }
    }
}
