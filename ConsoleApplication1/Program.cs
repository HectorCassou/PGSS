using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateurSystemeStellaire;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemeStellaire systeme = new SystemeStellaire();
            Console.WriteLine(systeme.debrisSpatiaux);

            Generateur gt = new Generateur();
            systeme = gt.DeterminerEtoile(systeme);
            Console.WriteLine(systeme.Etoiles.Count);

            foreach (Etoile etoile in systeme.Etoiles)
            {
                Console.WriteLine(etoile.type);
                Console.WriteLine(etoile.taille);
            }






            Console.ReadLine();

        }
    }
}
