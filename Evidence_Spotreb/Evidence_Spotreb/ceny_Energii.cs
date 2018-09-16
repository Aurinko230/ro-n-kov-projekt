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
    public partial class ceny_Energii : Form
    {
        public ceny nastavovane_ceny;
        public ceny_Energii()
        {
            InitializeComponent();
        }
        public ceny_Energii(ceny ceny_za_energie)
        {
            InitializeComponent();
            
                if (ceny_za_energie != null)
                {
                    this.nastavovane_ceny = ceny_za_energie;
                }
                else
                {
                    nastavovane_ceny = new ceny();
                }
                textBox_voda.Text = nastavovane_ceny.cena_vody_za_m3.ToString();
                textBox_elektrina.Text = nastavovane_ceny.cena_elektriny_za_kwh.ToString();
                textBox_plyn.Text = nastavovane_ceny.cena_plynu_za_m3.ToString();
            }

        

        private void ceny_Energii_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// uložení cen energií
        /// </summary>

        private void button2_Click(object sender, EventArgs e)
        {
            double voda, elektrina, plyn;
            bool obsahuje_chybu = false;
            Double.TryParse(textBox_voda.Text, out voda);
            Double.TryParse(textBox_elektrina.Text, out elektrina);
            Double.TryParse(textBox_plyn.Text, out plyn);

            String chyba = "Chybně zadané hodnoty:";
            if (Double.TryParse(textBox_voda.Text, out voda) == false)
            {
                chyba = chyba + "voda";
                obsahuje_chybu = true;
            }
            if (Double.TryParse(textBox_elektrina.Text, out elektrina) == false)
            {
                chyba = chyba + "elektřina";
                obsahuje_chybu = true;
            }
            if (Double.TryParse(textBox_plyn.Text, out plyn) == false)
            {
                chyba = chyba + "plyn";
                obsahuje_chybu = true;
            }

            if (obsahuje_chybu == true)
            {
                MessageBox.Show(chyba, "CHYBA", MessageBoxButtons.OK);
            }
            else
            {
                nastavovane_ceny.cena_vody_za_m3 = voda;
                nastavovane_ceny.cena_elektriny_za_kwh = elektrina;
                nastavovane_ceny.cena_plynu_za_m3 = plyn;

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
