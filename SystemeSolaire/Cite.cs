using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Cite
    {
        #region Attributs Cité
        public int id { get; set; }
        public string nom { get; set; }
        public bool principale { get; set; } // est-ce la plus grande ville de la population ?
        public int nbHabitant { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur Cite
        public Cite()
        {
            nom = "Cité";
            principale = false;
            nbHabitant = 0;
            commentaire = "";
        }
        #endregion
    }
}
