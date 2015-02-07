using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Planete
    {
        #region Attributs Planète
        public int id { get; set; }
        public string nom { get; set; }
        public string zone { get; set; }
        public string densiteAtmos { get; set; }
        public List<Population> Populations { get; set; }
        public string type { get; set; }
        public int taille { get; set; } // cette propriété ne peut prendre que les valeurs : /!\ rélaiser un type énumératif pour cet attribut /!\
        // 0 correspondant à la catégorie Minuscule
        // 1 correspondant à la catégorie Fine
        // 2 correspondant à la catégorie Toute Petite
        // 3 correspondant à la catégorie Petite
        // 4 correspondant à la catégorie Moyenne
        // 5 correspondant à la catégorie Grande
        // 6 correspondant à la catégorie Enorme
        // 7 correspondant à la catégorie Petite Géante Gazeuse
        // 8 correspondant à la catégorie Géante Gazeuse Moyenne
        // 9 correspondant à la catégorie Enorme Géante Gazeuse
        // 10 correspondant à la catégorie Gargantuesque Géante Gazeuse
        public string diametre { get; set; } // représenté par le nom de la catégorie + le diametre en km
        public string gravite { get; set; }
        public string atmosCompo { get; set; }
        public string pollution { get; set; }
        public string geologie { get; set; }
        public string volcanisme { get; set; }
        public string hydrosphere { get; set; }
        public int tauxHydro { get; set; }
        public string geographie { get; set; }
        public string climat { get; set; }
        public int tempPole { get; set; }
        public string densiteBio { get; set; }
        public string complexiteBio { get; set; }
        public bool artefactAncien { get; set; }
        public int mixPopulation { get; set; } // cette propriété ne peut prendre que quatre valeurs : 0 si il n'y a pas de population du tout
        //                                                                                    1 si la population de ce monde est exclusivement native;
        //                                                                                    2 si la population de ce monde est exclusivement coloniale;
        //                                                                                    3 si la population de ce monde est un mélange natif/colonial.

        public List<Satellite> Satellites { get; set; }
        public int nbMoonlet { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur Planete
        public Planete()
        {
            nom = "Planète";
            zone = "";
            densiteAtmos = "";
            Populations = new List<Population>();
            type = "";
            taille = 0;
            diametre = "";
            gravite = "";
            atmosCompo = "";
            pollution = "";
            geologie = "";
            volcanisme = "";
            hydrosphere = "";
            tauxHydro = 0;
            geographie = "";
            climat = "";
            tempPole = 0;
            densiteBio = "";
            complexiteBio = "";
            artefactAncien = false;
            mixPopulation = 0;
            Satellites = new List<Satellite>();
            nbMoonlet = 0;
            commentaire = "";
        }
        #endregion
    }
}
