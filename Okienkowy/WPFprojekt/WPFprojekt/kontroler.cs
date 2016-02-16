using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wzorce;

namespace wzorce
{
    public class ProduktContainer
    {
        
        //Multiton
        public Dictionary<string, Meble> lista_prod = new Dictionary<string, Meble>();

        public List<Meble> getLista
        {
            get { return lista_prod.Values.ToList(); }
        }

        //Singleton
        static object _lock = new object();
        public void DodajMebel(string klucz, Meble m)
        {
            lock (_lock)
                if(!lista_prod.ContainsKey(klucz))
                    lista_prod.Add(klucz, m);
        }

        //Iterator
        int i = 0;
        public bool hasNext()
        {
            if (i > getLista.Count - 1)
            {
                i = 0;
                return false;
            }
            return true;
        }

        public Meble getNext()
        {
            return getLista.ElementAt(i++);
        }

        public List<T> getCat<T>()
        {
            List<T> addin = new List<T>();
            foreach (Meble prod in getLista)
            {
                if (typeof(T) == prod.GetType() || typeof(T) == prod.GetType().BaseType || typeof(T) == prod.GetType().BaseType.BaseType)
                {
                    addin.Add((T)(object)prod);
                }
            }
            return addin;
        }

    }

    public class Klient : ProduktContainer
    {
        string nazwa;
        float koszt = 0;
        Magazyn obj;
        public string Nazwa
        {
            get { return nazwa; }
        }

        public Klient(string nazwa, Magazyn obj)
        {
            this.nazwa = nazwa;
            this.obj = obj;
        }

        public bool Zakupy(Magazyn m, int i, int ile)
        {
            if (i < m.getLista.Count && ile <= m.getLista[i].Ilosc)
            {
                Meble temp = (Meble)m.getLista[i].Clone();
                if (!lista_prod.ContainsKey(Convert.ToString(m.getLista[i].Pok)))
                {
                    //Meble temp = (Meble)m.getLista[i].Clone();
                    temp.Ilosc = ile;
                    m.getLista[i].Ilosc -= ile;
                    lista_prod.Add(temp.Pok.ToString(), temp);
                    koszt += ile * m.getLista[i].Cena;
                }
                else if(lista_prod.ContainsKey(Convert.ToString(m.getLista[i].Pok)))
                {
                    lista_prod[m.getLista[i].Pok.ToString()].Ilosc += ile;
                    m.getLista[i].Ilosc -= ile;
                    koszt += ile * m.getLista[i].Cena;
                }

                else if (!lista_prod.ContainsKey(Convert.ToString(m.getLista[i].Biur)))
                {
                    //Meble temp = (Meble)m.getLista[i].Clone();
                    temp.Ilosc = ile;
                    m.getLista[i].Ilosc -= ile;
                    lista_prod.Add(temp.Biur.ToString(), temp);
                    koszt += ile * m.getLista[i].Cena;
                }
                else if(lista_prod.ContainsKey(Convert.ToString(m.getLista[i].Biur)))
                {
                    lista_prod[m.getLista[i].Biur.ToString()].Ilosc += ile;
                    m.getLista[i].Ilosc -= ile;
                    koszt += ile * m.getLista[i].Cena;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ZapiszZakup(Historia h)
        {
            Wpis w = new Wpis(getLista, koszt);
            h.Archiwum.Add(w);
        }

        public string Koszty()
        {
            string k = "Trzeba zapłacić: " + this.koszt + " zł";
            return k;
        }
    }

    public class Magazyn : ProduktContainer
    {
        //Singleton
        private static Magazyn instance;

        public static Magazyn Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Magazyn();
                }
                return instance;
            }
        }

        public void DodajP(Meble ob, int ilosc)
        {
            for (int i = 0; i < ilosc; i++)
                getLista.Add(ob);
        }

        public Meble Usun(int i)
        {
            if (lista_prod.Count() > 0)
            {
                Meble obj = getLista[i];
                getLista.RemoveAt(i);
                return obj;
            }
            else return null;
        }



        public Magazyn()
        {

            Waiter waiter = new Waiter();


            waiter.MebleBuilder = new PokojoweMebleBuilder();
            waiter.KonstruujMeble(10);
            DodajMebel("1", waiter.Meble);

            waiter.MebleBuilder = new BiuroweMebleBuilder();
            waiter.KonstruujMeble(5);
            DodajMebel("2", waiter.Meble);

            DodajMebel("3", new MebleBiurowe(biurowe.sejf, 200, "1.4 m^3", 20));
            DodajMebel("4", new MeblePokojowe(pokojowe.komoda, 300, "1.22 m^3", 4));



            //Metoda Wytwórcza
            DodajMebel("5", Meble.MebleFactory(Meble.MebleRodzaj.Pokojowe));
            DodajMebel("6", Meble.MebleFactory(Meble.MebleRodzaj.Biurowe));




        }

        public void Stan()
        {
            int i = 0;

            Console.WriteLine("W magazynie mamy: ");
            foreach (Meble obj in getLista)
            {
                if (obj.Pok != 0)
                    Console.WriteLine(" " + i + " , " + obj.Pok + " , " + obj.Cena + " zł");
                if (obj.Biur != 0)
                    Console.WriteLine(" " + i + " , " + obj.Biur + " , " + obj.Cena + " zł");
                i++;
            }
        }


        //Odwiedzajacy
        public void ZmianaCeny<T>(float temp)
        {
            foreach (Meble p in getLista)
                if (p.GetType() == typeof(T))
                {
                    p.ZmienCene(temp);
                }
        }

    }
}