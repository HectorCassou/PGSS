using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class Etoile
    {
        #region Attributs Etoile
        public int id;
        public string nom = "Etoile";
        public string type = "";
        public string taille = "";
        public string qualificationType = "";
        public List<Planete> Planetes = new List<Planete>();
        public List<CeintureAsteroide> Ceintures = new List<CeintureAsteroide>();
        public bool instable = false;
        public string commentaire = "";
        #endregion
    }
}
