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
        public string localisation { get; set; }
        public string type { get; set; }
        public string categorieHabitant { get; set; }
        public int nbHabitant { get; set; }
        public List<Cite> Cites { get; set; }
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

        #region Constructeur Population
        public Population()
        {
            nom = "Population";
            localisation = "";
            type = "";
            categorieHabitant = "";
            nbHabitant = 0;
            Cites = new List<Cite>();
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
        #endregion
    }
}
