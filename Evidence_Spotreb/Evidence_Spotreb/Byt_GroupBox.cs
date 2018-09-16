using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Evidence_Spotreb
{
    public class Byt_groupBox : GroupBox
    {
        Label hodnota_voda;
        Label hodnota_elektrina;
        Label hodnota_plyn;

        Label cena_voda;
        Label cena_elektrina;
        Label cena_plyn;
        Label cena_spolecne;

        Label zalohy;
        Label cena_celkem;
        byt tento_byt;




        public Byt_groupBox(byt tehle_byt, ceny ceny_energii, double spolecne_prostory)
        {
            tento_byt = tehle_byt;
            this.Width = 600;
            this.Height = 200;
            this.Text = tehle_byt.Popis;
            Label nadpis1 = new Label();
            nadpis1.Text = "co";
            nadpis1.Location = new Point(40, 20);
            nadpis1.Width = 50;
            nadpis1.ForeColor = Color.Brown;
            nadpis1.Parent = this;

            Label nadpis2 = new Label();
            nadpis2.Text = "hodnota";
            nadpis2.Location = new Point(120, 20);
            nadpis2.Width = 80;
            nadpis2.ForeColor = Color.Brown;
            nadpis2.Parent = this;

            Label nadpis3 = new Label();
            nadpis3.Text = "cena";
            nadpis3.Location = new Point(240, 20);
            nadpis3.Width = 80;
            nadpis3.ForeColor = Color.Brown;
            nadpis3.Parent = this;

            //------------------------------------------------------

            Label voda = new Label();
            voda.Text = "voda";
            voda.Location = new Point(40, 45);
            voda.Width = 50;
            voda.Parent = this;

            Label elektrina = new Label();
            elektrina.Text = "elektrina";
            elektrina.Location = new Point(40, 70);
            elektrina.Width = 50;
            elektrina.Parent = this;

            Label plyn = new Label();
            plyn.Text = "plyn";
            plyn.Location = new Point(40, 95);
            plyn.Width = 50;
            plyn.Parent = this;

            Label spolecne = new Label();
            spolecne.Text = "společné";
            spolecne.Location = new Point(40, 120);
            spolecne.Width = 50;
            spolecne.Parent = this;

            //-----------------------------------------------------------------------
            //Hodnoty měřičů


            Label voda_hodnota = new Label();
            voda_hodnota.Text = tehle_byt.mnozstvi_voda.ToString();
            voda_hodnota.Location = new Point(120, 45);
            voda_hodnota.Width = 50;
            voda_hodnota.Parent = this;

            Label elektrina_hodnota = new Label();
            elektrina_hodnota.Text = tehle_byt.mnozstvi_elektrina.ToString();
            elektrina_hodnota.Location = new Point(120, 70);
            elektrina_hodnota.Width = 50;
            elektrina_hodnota.Parent = this;

            //nemusí mít!!!!

            if (tehle_byt.plyn != null)
            {
                Label plyn_hodnota = new Label();
                plyn_hodnota.Text = tehle_byt.mnozstvi_plyn.ToString();
                plyn_hodnota.Location = new Point(120, 95);
                plyn_hodnota.Width = 50;
                plyn_hodnota.Parent = this;
            }
            else
            {
                Label plyn_hodnota = new Label();
                plyn_hodnota.Text = "X";
                plyn_hodnota.Location = new Point(120, 95);
                plyn_hodnota.Width = 50;
                plyn_hodnota.Parent = this;

            }


            //-----------------------------------------------------------------------------
            // CENY
            double cena_voda = tehle_byt.mnozstvi_voda * ceny_energii.cena_vody_za_m3;
            Label voda_cena = new Label();
            voda_cena.Text = cena_voda.ToString() + "Kč";
            voda_cena.Location = new Point(240, 45);
            voda_cena.Width = 50;
            voda_cena.Parent = this;

            double cena_ele = tehle_byt.mnozstvi_elektrina * ceny_energii.cena_elektriny_za_kwh;
            Label elektrina_cena = new Label();
            elektrina_cena.Text = cena_ele.ToString() + "Kč";
            elektrina_cena.Location = new Point(240, 70);
            elektrina_cena.Width = 50;
            elektrina_cena.Parent = this;


            double cena_plyn = 0;
            if (tehle_byt.plyn != null)
            {
                cena_plyn = tehle_byt.mnozstvi_plyn * ceny_energii.cena_plynu_za_m3;
                Label plyn_cena = new Label();
                plyn_cena.Text = cena_plyn.ToString() + "Kč";
                plyn_cena.Location = new Point(240, 95);
                plyn_cena.Width = 50;
                plyn_cena.Parent = this;
            }
            else
            {
                Label plyn_cena = new Label();
                plyn_cena.Text = "X";
                plyn_cena.Location = new Point(240, 95);
                plyn_cena.Width = 50;
                plyn_cena.Parent = this;

            }

            Label spolecne_cena = new Label();
            spolecne_cena.Text = spolecne_prostory.ToString() + "Kč";
            spolecne_cena.Location = new Point(240, 120);
            spolecne_cena.Width = 50;
            spolecne_cena.Parent = this;



            //------------------------------------------------------------------------------



            Label zalohy = new Label();
            zalohy.Location = new Point(350, 80);
            zalohy.Text = tehle_byt.zaloha.ToString() + "Kč";
            zalohy.Width = 180;
            zalohy.Height = 30;
            zalohy.ForeColor = Color.DarkBlue;
            zalohy.Font = new Font("Tahoma", 18, FontStyle.Bold);
            zalohy.Parent = this;

            tehle_byt.cena_voda = cena_voda;
            tehle_byt.cena_elektrina = cena_ele;

            double cena = cena_voda + cena_ele + spolecne_prostory;
            if (plyn != null)
            {
                tehle_byt.cena_plyn = cena_plyn;
                cena = cena + cena_plyn;
            }

            Label celkovacena = new Label();
            celkovacena.Location = new Point(350, 30);
            celkovacena.Text = cena.ToString() + "Kč";
            celkovacena.Width = 180;
            celkovacena.Height = 45;
            celkovacena.Font = new Font("Tahoma", 25, FontStyle.Bold);
            if (cena <= tehle_byt.zaloha)
            {
                celkovacena.BackColor = Color.Green;
            }
            else
            {
                celkovacena.BackColor = Color.Red;
            }
            celkovacena.Parent = this;


        }
    }
}
