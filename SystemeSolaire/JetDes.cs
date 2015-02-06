using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    class JetDes
    {
        // méthode pour jeter n'importe quel jet de dés
        // par défaut elle lance 1d6+0
        public int JeterD(int nbD = 1, int typeD = 6, int modifD = 0)
        {
            Random hazard = new Random();
            return hazard.Next(nbD + modifD, modifD + nbD * typeD + 1);
        }
    }
}
