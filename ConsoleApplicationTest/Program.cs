using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateurSystemeStellaire;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemeStellaire systeme = Generateur.DeterminerEtoile(new SystemeStellaire());
            Console.WriteLine("le nombe d'étoile : {0}", systeme.Etoiles);
            Console.ReadLine();
        }
    }
}
