using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class SystemeStellaire
    {
        #region Attributs Système Solaire
        public int id { get; set; }
        public List<Etoile> Etoiles { get; set; }
        public List<Population> PopulationsNatives { get; set; }
        public Population populationColoniale { get; set; }
        public string nom { get; set; }
        public bool sombreCompagnon { get; set; }
        public bool debrisSpatiaux { get; set; }
        public bool nuageOort { get; set; }
        public int portail { get; set; }
        public bool comptoirMarchand { get; set; }
        public string gouvernance { get; set; }
        public bool repairePirate { get; set; }
        public int niveauMenace { get; set; }
        public int niveauSecurite { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur SystemeStellaire
        public SystemeStellaire()
        {
            Etoiles = new List<Etoile>();
            PopulationsNatives = new List<Population>();
            populationColoniale = new Population();
            nom = "Système Solaire";
            sombreCompagnon = false;
            debrisSpatiaux = false;
            nuageOort = false;
            portail = 0;
            comptoirMarchand = false;
            gouvernance = "";
            repairePirate = false;
            niveauMenace = 0;
            niveauSecurite = 0;
            commentaire = "";
        }
        #endregion
    }
}
