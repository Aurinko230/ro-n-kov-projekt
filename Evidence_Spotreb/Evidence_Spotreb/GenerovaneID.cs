using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_Spotreb
{
   public class GenerovaneID
    {
        static int posledniID;

        public GenerovaneID()
        {
            posledniID = 0;
        }
        public GenerovaneID(int maximalni)
        {
            posledniID = maximalni;
        }
        public int noveID()
        {
            posledniID++;
            return posledniID;
        }
        public void zruseni_merice()
        {
            posledniID--;
        }
    }

    public class pridat
    {
        public bool ano;
    }
}
