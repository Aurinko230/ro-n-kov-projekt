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

   
}
