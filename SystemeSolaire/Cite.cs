using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class Cite
    {
        #region Attributs Cité
        public int id;
        public string nom = "Cité";
        public bool principale = false; // est-ce la plus grande ville de la population ?
        public int nbHabitant = 0;
        public string commentaire = "";
        #endregion
    }
}
