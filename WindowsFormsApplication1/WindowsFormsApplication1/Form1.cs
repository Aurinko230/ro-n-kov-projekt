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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dum zobrazovany = new dum();
            zobrazovany.cesta = "sdfsffg";
            zobrazovany.popis = "neco";
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;


            XmlSerializer serializer2 = new XmlSerializer(typeof(dum));
            tw = new XmlTextWriter(sw);
            serializer2.Serialize(tw, zobrazovany);
            Console.WriteLine(sw.ToString());
            Console.WriteLine(typeof(dum));
        }
    }

    public class dum
    {
        public dum() { }

        public bool ulozeny;
        //public ceny ceny_energii;
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

       // public Form formular;
       //  public Panel panel_s_byty;
         //public GenerovaneID id_pro_dum;
        public string popis;
        public List<byt> byty;
        public meric celkovy_elektrina;
        public meric celkovy_voda;
        public meric celkovy_plyn;
        public meric spolecne_prostory_elektrina;
        public meric spolecne_prostory_plyn;
        public meric spolecne_prostory_voda;
        public List<meric> dalsi_vodomery;
        // List<meric> dalsi_elektromery;
        // List<meric> dalsi_plynomery;
        public List<meric> vsechny_vodomery_v_dome;
        public string cesta;


       // public dum(Form formular, Panel panel_s_byty)
        //{
        //    //id_pro_dum = new GenerovaneID();
        //    this.formular = formular;
        //   this.panel_s_byty = panel_s_byty;
        //    this.vsechny_vodomery_v_dome = new List<meric>();
        //    this.byty = new List<byt>();

        //}
    }
    public class byt
    {
        public byt()
        { }

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

    }
    public class meric
    {
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

        public double posledni_hodnota;
        public double nova_hodnota;
        public List<double> hodnoty_vodomeru;
        public bool dopocitavany;

        public int spolecnyID;//ten od kterého se odečítá
        public List<int> odecitane; //ty které jsou pod ním a odečítají se od společného
        public Typ_merice typ;

        public meric(Typ_merice typ)
        { }
        public meric()
        { }
    }
    public enum Typ_merice { Elektromer, Vodomer, Plynomer };




}
