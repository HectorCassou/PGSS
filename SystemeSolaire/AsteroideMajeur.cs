using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class AsteroideMajeur
    {
        #region Attributs AstéroïdeMajeur
        public int id { get; set; }
        public string nom { get; set; }
        public int taille { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur AsteroideMajeur
        public AsteroideMajeur()
        {
            nom = "Astéroïde Majeur";
            taille = 0;
            commentaire = "";
        }
        #endregion
    }
}
