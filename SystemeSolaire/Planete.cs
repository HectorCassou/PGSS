﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class Planete
    {
        #region Attributs Planète
        public int id;
        public string nom = "Planète";
        public string zone = "";
        public string densiteAtmos = "";
        public List<Population> Populations = new List<Population>();
        public string type = "";
        public int taille = 0; // cette propriété ne peut prendre que les valeurs : /!\ rélaiser un type énumératif pour cet attribut /!\
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
        public string diametre = ""; // représenté par le nom de la catégorie + le diametre en km
        public string gravite = "";
        public string atmosCompo = "";
        public string pollution = "";
        public string geologie = "";
        public string volcanisme = "";
        public string hydrosphere = "";
        public int tauxHydro = 0;
        public string geographie;
        public string climat = "";
        public int tempPole = 0;
        public string densiteBio = "";
        public string complexiteBio = "";
        public bool artefactAncien = false;
        public int mixPopulation = 0; // cette propriété ne peut prendre que quatre valeurs : 0 si il n'y a pas de population du tout
        //                                                                                    1 si la population de ce monde est exclusivement native;
        //                                                                                    2 si la population de ce monde est exclusivement coloniale;
        //                                                                                    3 si la population de ce monde est un mélange natif/colonial.

        public List<Satellite> Satellites = new List<Satellite>();
        public int nbMoonlet = 0;
        public string commentaire = "";
        #endregion
    }
}
