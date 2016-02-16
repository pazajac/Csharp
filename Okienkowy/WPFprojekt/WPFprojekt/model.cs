using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wzorce;

//Sklep z meblami
/*
    1. Prototyp
 *  2. Budowniczy
 *  3. Metoda Wytwórcza
 *  4. Multiton
 *  5. Singleton
 *  6. Dekorator
 *  7. MVC
 *  8. Iterator
 *  9. Obserwator
 *  10. Odwiedzający
 
*/

namespace wzorce
{
    public enum pokojowe { sofa = 1, szafa, komoda };
    public enum biurowe { biurko = 4, fotel, sejf };

    //1. Prototyp
    public abstract class ICloneable
    {
        public abstract ICloneable Clone();
    }

    public class Meble : ICloneable
    {
        pokojowe pok;
        biurowe biur;
        float cena;
        string objetosc;

        public void ZmienCene(float cen)
        {
            this.cena *= cen;
        }
        protected void ZmienNazwePok(pokojowe p)
        {
            this.pok = p;
        }
        protected void ZmienNazweBiur(biurowe b)
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

        private int ilosc;
        public int Ilosc
        {
            get { return ilosc; }
            set { ilosc = value; }
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
                    return new MeblePokojowe(pokojowe.szafa, 180, "1.7 m^3", 7);
                    break;

                case MebleRodzaj.Biurowe:
                    return new MebleBiurowe(biurowe.sejf, 300, "1.5 m^3", 7);
                    break;

                default:
                    break;
            }

            throw new NotSupportedException("Rodzaj Mebli " + mebleRodzaj + " nie jest rozpoznany");
        }

    }

    public class MeblePokojowe : Meble
    {
        public void InfoMeble()
        {
            Console.WriteLine("Nazwa: " + Pok + " " + Cena + " " + Objetosc);
        }
        public MeblePokojowe() { }
        public MeblePokojowe(pokojowe nazwa, float cena, string obj, int ilosc)
        {
            this.Pok = nazwa;
            this.Cena = cena;
            this.Objetosc = obj;
            this.Ilosc = ilosc;
        }


    }

    public class MebleBiurowe : Meble
    {
        public void InfoMeble()
        {
            Console.WriteLine("Nazwa: " + Biur + " " + Cena + " " + Objetosc);
        }
        public MebleBiurowe() { }
        public MebleBiurowe(biurowe nazwa, float cena, string obj, int ilosc)
        {
            this.Biur = nazwa;
            this.Cena = cena;
            this.Objetosc = obj;
            this.Ilosc = ilosc;
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
        public abstract void BuildIlosc(int ile);
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
        public override void BuildIlosc(int ile = 5)
        {
            meble.Ilosc = ile;
        }

        public BiuroweMebleBuilder() { }

        public MebleBiurowe biu { get { return (MebleBiurowe)meble; } }

        public BiuroweMebleBuilder(biurowe b, float c, string o, int i)
        {
            meble = new MebleBiurowe(b, c, o, i);
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

        public override void BuildIlosc(int ile = 5)
        {
            meble.Ilosc = ile;
        }

        public PokojoweMebleBuilder() { }

        public MeblePokojowe po { get { return (MeblePokojowe)meble; } }

        public PokojoweMebleBuilder(pokojowe b, float c, string o, int i)
        {
            meble = new MeblePokojowe(b, c, o, i);
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

        public void KonstruujMeble(int i)
        {
            mebleBuilder.StworzNoweMeble();
            mebleBuilder.BuildCena();
            mebleBuilder.BuildNazwa();
            mebleBuilder.BuildObjetosc();
            mebleBuilder.BuildIlosc(i);
        }
    }


    //Obserwator

    public class Wpis
    {
        DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        List<Meble> zakupione;

        public List<Meble> Zakupione
        {
            get { return zakupione; }
            set { zakupione = value; }
        }

        double suma;

        public double Suma
        {
            get { return suma; }
            set { suma = value; }
        }
        public Wpis(List<Meble> zak, double sum)
        {
            this.data = DateTime.Now;
            this.zakupione = zak;
            this.suma = sum;

        }
    }

    public class Historia
    {
        List<Wpis> archiwum;

        public List<Wpis> Archiwum
        {
            get { return archiwum; }
            set { archiwum = value; }
        }

        public Historia()
        {

            archiwum = new List<Wpis>();
        }

    }

}
