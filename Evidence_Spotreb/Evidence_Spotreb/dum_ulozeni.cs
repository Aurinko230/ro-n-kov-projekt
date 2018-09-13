using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_Spotreb
{
    public class dum_ulozeni

    {
        public dum_ulozeni() { }
        public dum_ulozeni(dum ukladany_dum)
        {
            this.popis = ukladany_dum.popis;
            this.byty = ukladany_dum.byty;
            this.celkovy_elektrina = ukladany_dum.celkovy_elektrina;
            this.celkovy_voda = ukladany_dum.celkovy_voda;
            this.celkovy_plyn = ukladany_dum.Celkovy_Plyn;
            this.spolecne_prostory_elektrina = ukladany_dum.spolecne_prostory_elektrina;
            this.spolecne_prostory_plyn = ukladany_dum.spolecne_prostory_plyn;
            this.spolecne_prostory_voda = ukladany_dum.spolecne_prostory_voda;
            this.dalsi_vodomery = ukladany_dum.dalsi_vodomery;
            this.cesta = ukladany_dum.cesta;
            //this.Byty = ukladany_dum.Byty;
            this.ceny_energii = ukladany_dum.ceny_energii;
            this.id_pro_dum = ukladany_dum.id_pro_dum;
        }

        public GenerovaneID id_pro_dum;
        public string popis;
        public List<byt> byty;
        public meric celkovy_elektrina;
        public meric celkovy_voda;
        public meric celkovy_plyn;
        public meric spolecne_prostory_elektrina;
        public meric spolecne_prostory_plyn;
        public meric spolecne_prostory_voda;
        public List<meric> dalsi_vodomery;
        public List<meric> vsechny_vodomery_v_dome;
        public string cesta;
        public ceny ceny_energii;
        

        //public List<meric> Dalsi_Vodomery
        //{
        //    get
        //    {
        //        return dalsi_vodomery;
        //    }
        //    set
        //    {
        //        dalsi_vodomery = value;
        //    }
        //}

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

       

    }
}
