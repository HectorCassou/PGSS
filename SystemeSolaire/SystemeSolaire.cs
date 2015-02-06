using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeSolaire
{
    public class SystemeSolaire
    {
        #region Attributs Système Solaire
        public int id;
        public List<Etoile> Etoiles = new List<Etoile>();
        public List<Population> Populations = new List<Population>();
        public string nom = "Système Solaire";
        public bool sombreCompagnon = false;
        public bool debrisSpatiaux = false;
        public bool nuageOort = false;
        public int portail = 0;
        public bool comptoirMarchand = false;
        public string gouvernance = "";
        public bool repairePirate = false;
        public int niveauMenace = 0;
        public int niveauSecurite = 0;
        public string commentaire = "";
        #endregion
    }
}
