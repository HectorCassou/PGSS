using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Population
    {
        #region Attributs Population
        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }
        public string categorieHabitant { get; set; }
        public int nbHabitant { get; set; }
        public string citePrincipale { get; set; }
        public string citeSecondaire { get; set; }
        public int tauxUrbanisation { get; set; }
        public int niveauTechno { get; set; } // /!\ en faire un type enumératif /!\
        public int modificateurColonie { get; set; }
        public int participation { get; set; }
        public int diversite { get; set; }
        public int control { get; set; }
        public int soutien { get; set; }
        public int nbColonieMajeure { get; set; }
        public int nbColonieMineure { get; set; }
        public int nbBaseMilitaire { get; set; }
        public int nbBaseScientifique { get; set; }
        public int nbBaseDefensive { get; set; }
        public int nbBaseCommerciale { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Methodes Population
        public int CalculerPopulationOrbital()
        {
            JetDes jet = new JetDes(); ;
            int jetDes = jet.JeterD(1, 100);

            return Convert.ToInt32(jetDes * 0.00001 * this.nbHabitant);
        }
        public int CalculerPopulationCitePrincipale()
        {
            return Convert.ToInt32(this.nbHabitant * tauxUrbanisation * 0.6);
        }
        public int CalculerPopulationCiteSecondaire()
        {
            return Convert.ToInt32(this.nbHabitant * tauxUrbanisation * 0.4);
        }
        #endregion

        #region Constructeur Population
        //constructeur par défaut
        public Population()
        {
            nom = "";
            type = "";
            categorieHabitant = "";
            nbHabitant = 0;
            citePrincipale = "citeP";
            citeSecondaire = "citeS";
            tauxUrbanisation = 5;
            niveauTechno = 0; // /!\ en faire un type enumératif /!\
            modificateurColonie = 0;
            participation = 0;
            diversite = 0;    
            control = 0;       
            soutien = 0;       
            nbColonieMajeure = 0;
            nbColonieMineure = 0;
            nbBaseMilitaire = 0;
            nbBaseScientifique = 0;
            nbBaseDefensive = 0;
            nbBaseCommerciale = 0;
            commentaire = "";
        }

        // constructeur pour les espèces coloniales du système stellaire (humain, centauri, minbari, narn, ...)
        public Population(string nomPC, string typePC, int nivotechPC, int modifPC, int p, int d, int c, int s)
        {
            nom = nomPC;
            type = typePC;
            categorieHabitant = "";
            nbHabitant = 0;
            citePrincipale = "citeP";
            citeSecondaire = "citeS";
            tauxUrbanisation = 5;
            niveauTechno = nivotechPC; // /!\ en faire un type enumératif /!\
            modificateurColonie = modifPC;
            participation = p;
            diversite = d;
            control = c;
            soutien = s;
            nbColonieMajeure = 0;
            nbColonieMineure = 0;
            nbBaseMilitaire = 0;
            nbBaseScientifique = 0;
            nbBaseDefensive = 0;
            nbBaseCommerciale = 0;
            commentaire = "";
        }

        //constructeur pour l'espèce native d'un corps célèste
        public Population(string typeP)
        {
            nom = "";
            type = typeP;
            categorieHabitant = "";
            nbHabitant = 0;
            citePrincipale = "citeP";
            citeSecondaire = "citeS";
            tauxUrbanisation = 5;
            niveauTechno = 0; // /!\ en faire un type enumératif /!\
            modificateurColonie = 0;
            participation = 0;
            diversite = 0;
            control = 0;
            soutien = 0;
            nbColonieMajeure = 0;
            nbColonieMineure = 0;
            nbBaseMilitaire = 0;
            nbBaseScientifique = 0;
            nbBaseDefensive = 0;
            nbBaseCommerciale = 0;
            commentaire = "";
        }

        //constructeur pour les espèces coloniales d'un corps célèste
        public Population(string nomP, string typeP, int modif, int p, int d, int c, int s)
        {
            nom = nomP;
            type = typeP;
            categorieHabitant = "";
            nbHabitant = 0;
            citePrincipale = "citeP";
            citeSecondaire = "citeS";
            tauxUrbanisation = 5;
            niveauTechno = 0; // /!\ en faire un type enumératif /!\
            modificateurColonie = modif;
            participation = p;
            diversite = d;
            control = c;
            soutien = s;
            nbColonieMajeure = 0;
            nbColonieMineure = 0;
            nbBaseMilitaire = 0;
            nbBaseScientifique = 0;
            nbBaseDefensive = 0;
            nbBaseCommerciale = 0;
            commentaire = "";
        }
        #endregion
    }
}
