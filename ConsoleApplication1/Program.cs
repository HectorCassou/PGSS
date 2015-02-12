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
            for (int h = 0; h < 1000; h++)
            {
                systeme = gt.Generation();

                bool test = false;
                foreach (Etoile etoile in systeme.Etoiles)
                {
                    foreach (Planete planete in etoile.Planetes)
                    {
                        if (planete.complexiteBio == "Intelligence Native")
                        {
                            test = true;
                        }
                    }
                }
                if (test)
                {
                    Console.WriteLine("\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n");

                
                    // Partie 0 , 1 et 2
                    Console.WriteLine("Nombre d'Etoile : {0}", systeme.Etoiles.Count);
                    //Console.WriteLine("Sombre Compagnon : {0}", systeme.sombreCompagnon);
                    //Console.WriteLine("Debris Spatiaux : {0}", systeme.debrisSpatiaux);
                    //int compteurEtoileinstable = 0;
                    //foreach (Etoile etoile in systeme.Etoiles)
                    //{
                    //    if (etoile.instable)
                    //    {
                    //        compteurEtoileinstable++;
                    //    }
                    //}
                    //Console.WriteLine("Nombre d'Etoile instable : {0}", compteurEtoileinstable);
                    //Console.WriteLine("Nuage Oort : {0}", systeme.nuageOort);
                    //Console.WriteLine("Nombre de portail : {0}", systeme.portail);
                    //Console.WriteLine("Comptoir Marchand : {0}", systeme.comptoirMarchand);
                    if (systeme.populationColoniale.type != "")
                    {
                        Console.WriteLine("Le système est colonisé par le peuple {0}\n", systeme.populationColoniale.nom);
                    }
                    else
                    {
                        Console.WriteLine("Le système n'est pas colonisé\n");
                    }
                    int compteurEtoile = 0;
                    foreach (Etoile etoile in systeme.Etoiles)
                    {
                        Console.WriteLine("Etoile n°{0} :", compteurEtoile + 1);
                        //Console.WriteLine("Type de l'Etoile : {0}{1}", systeme.Etoiles[i].type, systeme.Etoiles[i].qualificationType);
                        //Console.WriteLine("Taille de l'Etoile : {0}", systeme.Etoiles[i].taille);
                        //Console.WriteLine("Etoile instable : {0}", systeme.Etoiles[i].instable);
                        Console.WriteLine("Nombre de Planetes : {0}", etoile.Planetes.Count);
                        Console.WriteLine("Nombre de Ceinture d'Astéroïdes : {0}\n", etoile.Ceintures.Count);

                        int compteurElements = 0;
                        foreach (Planete planete in etoile.Planetes)
                        {
                            Console.WriteLine("  Planete n°{0} :", compteurElements + 1);
                            Console.WriteLine("  Zone de la Planete : {0}", planete.zone);
                            Console.WriteLine("  Type de la Planete : {0}", planete.type);
                            //Console.WriteLine("  Categorie de la taille de la Planete : {0}", systeme.Etoiles[i].Planetes[j].taille);
                            //Console.WriteLine("  Diametre de la Planete : {0} miles", systeme.Etoiles[i].Planetes[j].diametre);
                            //Console.WriteLine("  Gravité de la Planète : {0}", systeme.Etoiles[i].Planetes[j].gravite);
                            //Console.WriteLine("  Densité Atmosphérique de la Planète : {0}", systeme.Etoiles[i].Planetes[j].densiteAtmos);
                            //if (systeme.Etoiles[i].Planetes[j].densiteAtmos != "Vide")
                            //{
                            //    Console.WriteLine("  Composition Atmosphérique de la Planète : {0}", systeme.Etoiles[i].Planetes[j].atmosCompo);
                            //    if (systeme.Etoiles[i].Planetes[j].type != "Géante Gazeuse")
                            //    {
                            //        Console.WriteLine("  Pollution de la Planète : {0}", systeme.Etoiles[i].Planetes[j].pollution);
                            //    }
                            //}
                            if (planete.type != "Géante Gazeuse")
                            {
                                //Console.WriteLine("  Géologie de la Planète : {0}", systeme.Etoiles[i].Planetes[j].geologie);
                                //Console.WriteLine("  Volcanisme de la Planète : {0}", systeme.Etoiles[i].Planetes[j].volcanisme);
                                //Console.WriteLine("  Hydropshère de la Planète : {0}({1}%)", systeme.Etoiles[i].Planetes[j].hydrosphere, systeme.Etoiles[i].Planetes[j].tauxHydro);

                                if (planete.climat == "Vide" || planete.climat == "Froid Extrème" || planete.climat == "Chaleur Extrème")
                                {
                                    Console.WriteLine("  Climat : {0}", planete.climat);

                                }
                                else
                                {
                                    Console.WriteLine("  Climat : {0}(+-{1})", planete.climat, planete.tempPole);
                                    Console.WriteLine("  Densité de la Biospshère : {0}", planete.densiteBio);
                                    Console.WriteLine("  Complexité de la Biosphère : {0}", planete.complexiteBio);
                                    switch (planete.mixPopulation)
                                    {
                                        case 0:
                                            Console.WriteLine("  Population : Aucune");
                                            break;
                                        case 1:
                                            Console.WriteLine("  Population : Native");
                                            break;
                                        case 2:
                                            Console.WriteLine("  Population : Coloniale");
                                            break;
                                        case 3:
                                            Console.WriteLine("  Population : Native et Coloniale");
                                            break;
                                    }
                                    
                                }

                                if (planete.artefactAncien)
                                {
                                    Console.WriteLine("  Artefact : Présent");
                                }
                                else
                                {
                                    Console.WriteLine("  Artefact : Aucun");
                                }
                                
                            }
                            Console.WriteLine("  Nombre de Lunes : {0}\n", planete.Satellites.Count);
                            int compteurLunes = 0;
                            //Console.WriteLine("  Nombre de petits satellites : {0}", systeme.Etoiles[i].Planetes[j].nbMoonlets);
                            foreach (Planete satellite in planete.Satellites)
                            {

                                Console.WriteLine("     Lunes n°{0}", compteurLunes + 1);
                                Console.WriteLine("     Type : {0}", satellite.type);
                                if (satellite.climat == "Vide" || satellite.climat == "Froid Extrème" || satellite.climat == "Chaleur Extrème")
                                {
                                    Console.WriteLine("     Climat : {0}", satellite.climat);

                                }
                                else
                                {
                                    Console.WriteLine("     Climat : {0}(+-{1})", satellite.climat, satellite.tempPole);
                                    Console.WriteLine("     Densité de la Biospshère : {0}", satellite.densiteBio);
                                    Console.WriteLine("     Complexité de la Biosphère : {0}", satellite.complexiteBio);
                                    switch (satellite.mixPopulation)
                                    {
                                        case 0:
                                            Console.WriteLine("     Population : Aucune");
                                            break;
                                        case 1:
                                            Console.WriteLine("     Population : Native");
                                            break;
                                        case 2:
                                            Console.WriteLine("     Population : Coloniale");
                                            break;
                                        case 3:
                                            Console.WriteLine("     Population : Native et Coloniale");
                                            break;
                                    }

                                }

                                if (satellite.artefactAncien)
                                {
                                    Console.WriteLine("     Artefact : Présent\n");
                                }
                                else
                                {
                                    Console.WriteLine("     Artefact : Aucun\n");
                                }
                                compteurLunes = compteurLunes + 1;
                            }
                            compteurElements = compteurElements + 1;
                        }
                        foreach (CeintureAsteroide ceinture in etoile.Ceintures)
                        {
                            Console.WriteLine("  Ceinture d'Astéroïdes n°{0}\n", compteurElements + 1);
                            compteurElements = compteurElements + 1;
                        }
                        compteurEtoile = compteurEtoile + 1;
                    }
                }
            }
            





            Console.ReadLine();

        }
    }
}
