using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class CeintureAsteroide
    {
        #region Attributs CeintureAstéroïde
        public int id;
        public string nom = "Ceinture d'Astéroïde";
        public string zone = "";
        public string densiteAtmos = "Vide";
        public string densite = "";
        public List<AsteroideMajeur> Asteroides = new List<AsteroideMajeur>();
        public Population population = new Population();
        public string commentaire = "";
        #endregion
    }
}
