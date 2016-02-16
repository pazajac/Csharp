using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wzorce;

namespace wzorce
{
    public enum pokojowe { sofa = 1, szafa, komoda };
    public enum biurowe { biurko = 1, fotel, sejf };

    //1. Prototyp
    public abstract class ICloneable
    {
        public abstract ICloneable Clone();
        protected string nazwaSklepu;
        public string NazwaSklepu
        {
            get { return nazwaSklepu; }
            set { nazwaSklepu = value; }
        }
    }
    //Dekorator
    public class Meble : ICloneable
    {

        pokojowe pok;
        biurowe biur;
        float cena;
        string objetosc;
        int i = 0;
       

        public void ZmienCene(float cen)
        {
            this.cena = cen;
        }
        public void ZmienNazwePok(pokojowe p)
        {
            this.pok = p;
        }
        public void ZmienNazweBiur(biurowe b)
        {
            this.biur = b;
        }
        protected void ZmienObjetosc(string obj)
        {
            this.objetosc = obj;
        }

        public float Cena
        {
            get { return cena; }
            set { cena = value; }
        }
        public pokojowe Pok
        {
            get { return pok; }
            set { pok = value; }
        }
        public biurowe Biur
        {
            get { return biur; }
            set { biur = value; }
        }
        public string Objetosc
        {
            get { return objetosc; }
            set { objetosc = value; }
        }

        //Prototyp
        public override ICloneable Clone()
        {
            return (ICloneable)this.MemberwiseClone();
        }

        public enum MebleRodzaj
        {
            Pokojowe, Biurowe
        }

        //2.Metoda Wytwórcza
        public static Meble MebleFactory(MebleRodzaj mebleRodzaj)
        {
            switch (mebleRodzaj)
            {
                case MebleRodzaj.Pokojowe:
                    return new PokojoweMebleBuilder(pokojowe.szafa, 180, "1.7 m^3");
                    break;

                case MebleRodzaj.Biurowe:
                    return new BiuroweMebleBuilder(biurowe.sejf, 300, "1.5 m^3");
                    break;

                default:
                    break;
            }

            throw new NotSupportedException("Rodzaj Mebli " + mebleRodzaj + " nie jest rozpoznany");
        }

    }


    //3.Budowniczy
    //Abstrakcyjny budowniczy
    public abstract class MebleBuilder : Meble
    {
        protected Meble meble;
        public Meble Meble
        {
            get { return meble; }
        }
        public void StworzNoweMeble() { meble = new Meble(); }

        public abstract void BuildNazwa();
        public abstract void BuildCena();
        public abstract void BuildObjetosc();
    }

    //Konkretny budowniczy
    public class BiuroweMebleBuilder : MebleBuilder
    {
        public override void BuildNazwa()
        {
            meble.Biur = biurowe.biurko;
        }
        public override void BuildCena()
        {
            meble.Cena = 150;
        }
        public override void BuildObjetosc()
        {
            meble.Objetosc = "0.9 m^3";
        }
        public BiuroweMebleBuilder() { }

        public BiuroweMebleBuilder(biurowe b, float c, string o)
        {
            ZmienCene(c);
            ZmienNazweBiur(b);
            ZmienObjetosc(o);
        }
    }

    public class PokojoweMebleBuilder : MebleBuilder
    {
        public override void BuildNazwa()
        {
            meble.Pok = pokojowe.sofa;
        }
        public override void BuildCena()
        {
            meble.Cena = 200;
        }
        public override void BuildObjetosc()
        {
            meble.Objetosc = "1.2 m^3";
        }

        public PokojoweMebleBuilder() { }

        public PokojoweMebleBuilder(pokojowe p, float c, string o)
        {
            ZmienCene(c);
            ZmienNazwePok(p);
            ZmienObjetosc(o);
        }

    }

    //Nadzorca
    public class Waiter
    {
        private MebleBuilder mebleBuilder;
        public MebleBuilder MebleBuilder
        {
            get { return mebleBuilder; }
            set { mebleBuilder = value; }
        }

        public Meble Meble
        {
            get { return mebleBuilder.Meble; }
        }

        public void KonstruujMeble()
        {
            mebleBuilder.StworzNoweMeble();
            mebleBuilder.BuildCena();
            mebleBuilder.BuildNazwa();
            mebleBuilder.BuildObjetosc();
        }
    }


    //Obserwator
    public class Historia
    {
        public List<Wpis> Archiwum;

        public Historia()
        {
            Archiwum = new List<Wpis>();
        }

    }

    public class Wpis
    {
        DateTime data;
        List<Meble> Zakupione;

        public Wpis(List<Meble> lista_pr)
        {
            this.Zakupione = lista_pr;
            data = DateTime.Now;
        }

    }

    
    public partial class Magazyn
    {
		//6. Singleton
        private static Magazyn instance;
		
		public static Magazyn Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new Magazyn();
				}
                return instance;
			}
		}

        public List<T> getCat<T>()
        {
            List<T> addin = new List<T>();
            foreach (Meble prod in lista_prod)
            {
                if (typeof(T) == prod.GetType() || typeof(T) == prod.GetType().BaseType || typeof(T) == prod.GetType().BaseType.BaseType)
                {
                    addin.Add((T)Convert.ChangeType(prod, typeof(T)));
                }
            }
            return addin;
        }

        
        //Odwiedzajacy
        public void ZmianaCeny1<T>(float temp)
        {
            foreach(Meble p in lista_prod)
                if(p.GetType() == typeof(T))
                {
                    p.ZmienCene(temp);
                }
        }

        public void ZmianaCeny2<T>(float temp)
        {
            List<T> doZmian = getCat<T>();
            foreach (Meble p in lista_prod)
                if (doZmian.Equals(p))
                {
                    p.ZmienCene(temp);
                }
        }
			
        void DodajMebel(Meble ob, int ilosc)
        {
            for (int i = 0; i < ilosc; i++)
                lista_prod.Add(ob);
        }


        public Meble Usun(int i)
        {
            if (lista_prod.Count() > 0 && i < lista_prod.Count())
            {
                Meble obj = lista_prod[i];
                lista_prod.RemoveAt(i);
                return obj;
            }
            else return null;
        }
    }
}
