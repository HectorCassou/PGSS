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

            Generateur gt = new Generateur();
            for (int h = 0; h < 100; h++)
            {
                systeme = gt.Generation();
                bool Etoileinstable = false;
                foreach (Etoile etoile in systeme.Etoiles)
                {
                    if (etoile.instable)
                    {
                        Etoileinstable = true;
                    }
                }
                if (Etoileinstable)
                {
                    Console.WriteLine("\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n");

                
                    // Partie 0 , 1 et 2
                    Console.WriteLine("Nombre d'Etoile : {0}", systeme.Etoiles.Count);
                    Console.WriteLine("Sombre Compagnon : {0}", systeme.sombreCompagnon);
                    Console.WriteLine("Debris Spatiaux : {0}", systeme.debrisSpatiaux);
                    int compteurEtoileinstable = 0;
                    foreach (Etoile etoile in systeme.Etoiles)
                    {
                        if (etoile.instable)
                        {
                            compteurEtoileinstable++;
                        }
                    }
                    Console.WriteLine("Nombre d'Etoile instable : {0}", compteurEtoileinstable);
                    Console.WriteLine("Nuage Oort : {0}", systeme.nuageOort);
                    Console.WriteLine("Nombre de portail : {0}", systeme.portail);
                    Console.WriteLine("Comptoir Marchand : {0}", systeme.comptoirMarchand);
                    string populationColoniale = "";
                    for (int i = 0; i < systeme.Populations.Count; i++)
			        {
                        if (systeme.Populations[i].localisation == "SystemeStellaire" && systeme.Populations[i].type == "Coloniale")
                        {
                            populationColoniale = systeme.Populations[i].nom;
                        }
			        } 
                    {
                        
                    }
                    if (populationColoniale != "")
                    {
                        Console.WriteLine("Le système est colonisé par le peuple {0}\n", populationColoniale);
                    }
                    else
                    {
                        Console.WriteLine("Le système n'est pas colonisé\n");
                    }

                    for (int i = 0; i < systeme.Etoiles.Count; i++)
                    {
                        Console.WriteLine("Etoile n°{0} :", i + 1);
                        Console.WriteLine("Type de l'Etoile : {0}{1}", systeme.Etoiles[i].type, systeme.Etoiles[i].qualificationType);
                        Console.WriteLine("Taille de l'Etoile : {0}", systeme.Etoiles[i].taille);
                        Console.WriteLine("Etoile instable : {0}", systeme.Etoiles[i].instable);
                        Console.WriteLine("Nombre de Planetes : {0}", systeme.Etoiles[i].Planetes.Count);
                        Console.WriteLine("Nombre de Ceinture d'Astéroïdes : {0}\n", systeme.Etoiles[i].Ceintures.Count);

                        int compteurElements = 0;
                        for (int j = 0; j < systeme.Etoiles[i].Planetes.Count; j++)
                        {
                            Console.WriteLine("  Planete n°{0} :", j + 1);
                            Console.WriteLine("  Zone de la Planete : {0}", systeme.Etoiles[i].Planetes[j].zone);
                            Console.WriteLine("  Type de la Planete : {0}", systeme.Etoiles[i].Planetes[j].type);
                            Console.WriteLine("  Categorie de la taille de la Planete : {0}", systeme.Etoiles[i].Planetes[j].taille);
                            Console.WriteLine("  Diametre de la Planete : {0}", systeme.Etoiles[i].Planetes[j].diametre);
                            Console.WriteLine("  Gravité de la Planète : {0}\n", systeme.Etoiles[i].Planetes[j].gravite);
                            compteurElements = j + 1;
                        }
                        for (int j = 0; j < systeme.Etoiles[i].Ceintures.Count; j++)
                        {
                            Console.WriteLine("  Ceinture d'Astéroïdes n°{0}\n", j + compteurElements + 1);
                        }
                    }
                }
            }
            





            Console.ReadLine();

        }
    }
}
