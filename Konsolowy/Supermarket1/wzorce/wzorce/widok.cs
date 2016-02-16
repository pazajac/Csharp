using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wzorce;

//Prezentacja danych w obrębie graficznego interfejsu

namespace wzorce
{
    public class Klient
    {
        string nazwa;
        float koszt = 0;
        int i = 0;
        List<Meble> lista_zakupow;
        Magazyn obj;
        public string Nazwa
        {
            get { return nazwa; }
        }

        public Klient(string nazwa, Magazyn obj)
        {
            this.nazwa = nazwa;
            lista_zakupow = new List<Meble>();
            this.obj = obj;
        }

        public void Zakupy(int i)
        {
            try
            {
                lista_zakupow.Add(obj.Usun(i));
                this.koszt += lista_zakupow[lista_zakupow.Count - 1].Cena;
            }
            catch { }
                
        }

        public void Koszty()
        {
            Console.WriteLine("Trzeba zapłacić: " + this.koszt + " zł");
        }


        //Iterator
        public bool hasNext()
        {
            if (i > lista_zakupow.Count - 1)
            {
                i = 0;
                return false;
            }
            return true;
        }

        public Meble getNext()
        {
            return lista_zakupow.ElementAt(i++);
        }

        public void Koszyk()
        {
            int i = 0;
            Console.WriteLine("Obecnie mam w koszyku: ");
            try
            {
                while (hasNext())
                {
                    var obj = getNext();
                    if (obj.Biur != 0)
                        Console.WriteLine(" " + i + " , " + obj.Biur + " , " + obj.Cena);
                    if (obj.Pok != 0)
                        Console.WriteLine(" " + i + " , " + obj.Pok + " , " + obj.Cena);

                    i++;
                }
            }
            catch { }
        }

        public void zakonczZakupy(Historia h)
        {
            Console.WriteLine("Dziekujemy za zakupy");
            Wpis w = new Wpis(lista_zakupow);
            h.Archiwum.Add(w);
        }
    }

    public partial class Magazyn
    {

        public void Stan()
        {
            int i = 0;

            Console.WriteLine("W magazynie mamy: ");
            foreach (Meble obj in lista_prod)
            {
                if (obj.Pok != 0)
                    Console.WriteLine(" " + i + " , " + obj.Pok + " , " + obj.Cena + " zł");
                if (obj.Biur != 0)
                    Console.WriteLine(" " + i + " , " + obj.Biur + " , " + obj.Cena + " zł");
                i++;

            }
        }

    }
}
