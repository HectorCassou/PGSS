using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Satellite
    {
        #region Attributs Satellite
        public int id { get; set; }
        public string nom { get; set; }
        public string zone { get; set; }
        public string densiteAtmos { get; set; }
        public List<Population> Populations { get; set; }
        public string type { get; set; }
        public string categorieTaille { get; set; } // cette propriété ne peut prendre que les valeurs : 
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
        public int diametre { get; set; } //le diametre en miles
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
        public int distance { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur Satellite
        public Satellite()
        {
            nom = "Satellite";
            zone = "";
            densiteAtmos = "";
            Populations = new List<Population>();
            type = "";
            categorieTaille = "";
            diametre = 0;
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
            distance = 0;
            commentaire = "";
        }
        #endregion
    }
}
