using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
using wzorce;

namespace wzorce
{
    public class Program
    {
        static void Main(string[] args)
        {

            Meble prot = new Meble();
            prot.NazwaSklepu = "IKEA";
            Meble protcl = prot.Clone() as Meble;

            Historia h = new Historia();
            Magazyn magazyn = new Magazyn();
            Klient klient = new Klient("Klient nr 1", magazyn);
            while (true)
            {
                int action;
                Console.WriteLine("Witaj w sklepie : {0}", protcl.NazwaSklepu);
                Console.WriteLine("Wybierz co chcesz zrobic: ");
                Console.WriteLine("1. Pokaz co masz w koszyku i ile musisz za to zapłacić ");
                Console.WriteLine("2. Dodaj do koszyka");
                Console.WriteLine("3. Wyświetl produkty w magazynie");
                Console.WriteLine("4. Przejdź do kasy");


                if (!int.TryParse(Console.ReadLine(), out action))
                    return;
                switch (action)
                {
                    case 1:
                        klient.Koszyk();
                        klient.Koszty();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Wybierz ktory produkt chcesz kupic");
                        klient.Zakupy(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        magazyn.Stan();
                        Console.ReadKey();
                        break;
                    case 4:
                        klient.Koszty();
                        klient.zakonczZakupy(h);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
