using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class CeintureAsteroide
    {
        #region Attributs CeintureAstéroïde
        public int id { get; set; }
        public string nom { get; set; }
        public string zone { get; set; }
        public string densiteAtmos { get; set; }
        public string densite { get; set; }
        public List<AsteroideMajeur> Asteroides { get; set; }
        public Population population { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur CeintureAsteroide
        public CeintureAsteroide()
        {
            nom = "Ceinture d'Astéroïde";
            zone = "";
            densiteAtmos = "Vide";
            densite = "";
            Asteroides = new List<AsteroideMajeur>();
            population = new Population();
            commentaire = "";
        }
        #endregion
    }
}
