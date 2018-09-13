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
    public partial class Existuje : Form
    { /// <summary>
      /// informuje o znovupřidání existujícího měřiče, který smí být pouze jeden
      /// </summary>
      /// 
        public dum zobrazovany;
        public meric vod;
        public meric pl;
        public meric ele;
        char typ;
        public Existuje(String text, char co_to_je, meric vod, meric ele, meric pl)
        {
            InitializeComponent();
            this.label1.Text = text;
            this.vod = vod;
            this.ele = ele;
            this.pl = pl;
            this.typ = co_to_je;
            this.ControlBox = false;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            ele = null;
            vod = null;
            pl = null;

            Close();
        }

        private void button1_Click(object sender, EventArgs e)// vytvořit nový
        {
            bool jsou_vsechny_null = true;
            int id = zobrazovany.id_pro_dum.noveID();
            novy_Elektromer_nebo_Plynomer novy_meric = new novy_Elektromer_nebo_Plynomer(vod, ele, pl, typ, id);
            if (typ == 'V')
            {
                novy_meric.Text = "Nový Vodoměr";
            }
            if (typ == 'E')
            {
                novy_meric.Text = "Nový Elektroměr";
            }
            if (typ == 'P')
            {
                novy_meric.Text = "Nový Plynoměr";
            }
            novy_meric.ShowDialog();


            if (typ == 'V' && novy_meric.vod != null)
            {
                vod = novy_meric.vod;
                jsou_vsechny_null = false;

            }
            if (typ == 'E' && novy_meric.ele != null)
            {
                ele = novy_meric.ele;
                jsou_vsechny_null = false;
            }
            if (typ == 'P' && novy_meric.pl != null)
            {
                pl = novy_meric.pl;
                jsou_vsechny_null = false;
            }

            if (jsou_vsechny_null == true)// nechci žádnej z nich měnit
            {
                vod = null;
                pl = null;
                ele = null;
            }


            this.Close();
            Console.WriteLine("ulozenej meric");

        }

        private void Existuje_Load(object sender, EventArgs e)
        {

        }
    }
}
