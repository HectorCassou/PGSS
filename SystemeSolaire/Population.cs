using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class Population
    {
        #region Attributs Population
        public int id;
        public string nom = "Population";
        public string localisation = ""; // Systeme Solaire
                                         // Planete
                                         // Satellite
                                         // Asteroide
        public string type = "";  // population native
                                  // population coloniale
        public string categorieHabitant = "";
        public int nbHabitant = 0;
        public List<Cite> Cites = new List<Cite>();
        public int niveauTechno = 0; // /!\ en faire un type enumératif /!\
        public int modificateurColonie = 0;
        public int participation = 0; // score qui détermine la politique de la population
        public int diversite = 0;     // score qui détermine la politique de la population
        public int control = 0;       // score qui détermine la politique de la population
        public int soutien = 0;       // score qui détermine la politique de la population
        public int nbColonieMajeure = 0;
        public int nbColonieMineure = 0;
        public int nbBaseMilitaire = 0;
        public int nbBaseScientifique = 0;
        public int nbBaseDefensive = 0;
        public int nbBaseCommerciale = 0;
        public string commentaire = "";
        #endregion
    }
}
