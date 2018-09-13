using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_Spotreb
{
   public enum Typ_merice{Elektromer, Vodomer, Plynomer};

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

        public double rozdil_poslednich_hodnot;
        public double cena_za_posledi_spotrebovane;

        public double posledni_hodnota;
        public double nova_hodnota;
        public List<double> hodnoty;
        public bool dopocitavany;
        public int spolecnyID;//ten od kterého se odečítá
        public List<int> odecitane; //ty které jsou pod ním a odečítají se od společného
        public Typ_merice typ;
        public bool pouzit_v_dopocitavanem;

        public meric(Typ_merice typ)
        { }
        public meric()
        { }

        public void pripsat_posledni_hodnotu()
        {
            if (dopocitavany == false)
            {
                if (hodnoty == null)
                {
                    hodnoty = new List<double>();
                }
                hodnoty.Add(nova_hodnota);
            }
            else
            {
                if (hodnoty == null)
                {
                    hodnoty = new List<double>();
                }
                if (hodnoty.Count() > 0)
                {
                    hodnoty.Add(hodnoty.Last() + rozdil_poslednich_hodnot);
                }
                else
                {
                    hodnoty.Add(rozdil_poslednich_hodnot);
                }
            }

        }

        public void nova_do_posledni()
        {
            posledni_hodnota = nova_hodnota;
            nova_hodnota = 0;

        }
    }

   
}
