using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wzorce;

namespace wzorce
{
    public partial class Magazyn
    {
        List<Meble> lista_prod;
        int i = 0;
        public Magazyn()
        {
            lista_prod = new List<Meble>();

            Waiter waiter = new Waiter();

            waiter.MebleBuilder = new BiuroweMebleBuilder();
            waiter.KonstruujMeble();
            DodajMebel(waiter.Meble, 2);

            waiter.MebleBuilder = new PokojoweMebleBuilder();
            waiter.KonstruujMeble();
            DodajMebel(waiter.Meble, 2);

            //Metoda Wytwórcza
            DodajMebel(Meble.MebleFactory(Meble.MebleRodzaj.Biurowe), 2);
            DodajMebel(Meble.MebleFactory(Meble.MebleRodzaj.Pokojowe), 2);


            /*Historia h = new Historia();
            h.Archiwum.Add(new Wpis(lista_prod));
            Console.WriteLine(h);*/


            PokojoweMebleBuilder F1 = new PokojoweMebleBuilder();
            PokojoweMebleBuilder F2 = new PokojoweMebleBuilder();

            listaD.Add("klucz1", F1);
            listaD.Add("klucz2", F1);
        }

        //4. Multiton
        Dictionary<string, Meble> listaD = new Dictionary<string, Meble>();

        List<Meble> LISTAD
        {
            get { return listaD.Values.ToList(); }
        }

        //Iterator
        public bool hasNext()
        {
            if (i > lista_prod.Count-1)
            {
                i = 0;
                return false;
            }
            return true;
        }

        public Meble getNext()
        {
            return lista_prod.ElementAt(i++);
        }

    }
}
