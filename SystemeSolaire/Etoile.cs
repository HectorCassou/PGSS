using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Etoile
    {
        #region Attributs Etoile
        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }
        public string taille { get; set; }
        public string qualificationType { get; set; }
        public List<Planete> Planetes { get; set; }
        public List<CeintureAsteroide> Ceintures { get; set; }
        public bool instable { get; set; }
        public string commentaire { get; set; }
        #endregion

        #region Constructeur Etoile
        public Etoile()
        {
            nom = "Etoile";
            type = "";
            taille = "";
            qualificationType = "";
            Planetes = new List<Planete>();
            Ceintures = new List<CeintureAsteroide>();
            instable = false;
            commentaire = "";
        }
        #endregion
    }
}

//public class Etoile
//{
//    #region Attributs Etoile
//    public SystemeSolaire systemSE;
//    public ArrayList tableElementSysteme;
//    public string id_E = "";
//    public string nomE = "";
//    public string typeE = "";
//    public string tailleE = "";
//    public int qualificationType = 0;
//    public string commentaireE = "";
//    #endregion

//    #region Méthodes Etoile
//
// 
//    public void DeterminerTableElementSS()
//    {
//
//    #region Constructeurs Etoile
//    public Etoile(SystemeSolaire system, int rang)
//    {
//        this.systemSE = system;
//        this.id_E = "E" + rang;
//        this.nomE = "Etoile n°" + rang;
//        this.TypeEtoile();
//        this.TailleEtoile();
//    }
//    #endregion
//}