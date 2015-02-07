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
//    public void TypeEtoile()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        if (jetDes == 2)
//        {
//            this.tailleE = "IV";
//        }
//        else if (jetDes > 2 && jetDes < 17)
//        {
//            this.tailleE = "V";
//        }
//        else if (jetDes > 16)
//        {
//            this.tailleE = "VI";
//        }
//    }
//    public void QualificationType()
//    {
//        this.qualificationType = (new JetDes()).JeterD(1, 10);
//    }
//    public void DeterminerTableElementSS()
//    {
//        int nbEtoile = this.systemSE.NbEtoile();
//        // détermine le modificateur au jet de dé en fonction du type de l'étoile
//        int modificateurs = 0;
//        switch (this.typeE)
//        {
//            case "O":
//                modificateurs = modificateurs - 15;
//                break;
//            case "B":
//                modificateurs = modificateurs - 12;
//                break;
//            case "A":
//                modificateurs = modificateurs - 10;
//                break;
//            case "F":
//                modificateurs = modificateurs - 4;
//                break;
//            case "G":
//                modificateurs = modificateurs - 2;
//                break;
//            case "K":
//                modificateurs = modificateurs - 6;
//                break;
//            case "M":
//                modificateurs = modificateurs - 10;
//                break;
//        }

//        // détermine le modificateur au jet de dé en fonction du taille de l'étoile
//        switch (this.tailleE)
//        {
//            case "Ia":
//                modificateurs = modificateurs - 8;
//                break;
//            case "Ib":
//                modificateurs = modificateurs - 6;
//                break;
//            case "II":
//                modificateurs = modificateurs - 4;
//                break;
//            case "III":
//                modificateurs = modificateurs - 2;
//                break;
//            case "IV":
//                modificateurs = modificateurs - 1;
//                break;
//            case "VI":
//                modificateurs = modificateurs - 1;
//                break;
//            case "VII":
//                modificateurs = modificateurs - 4;
//                break;
//        }
//        switch (nbEtoile)
//        {
//            case 2:
//                modificateurs = modificateurs - 2;
//                break;
//            case 3:
//                modificateurs = modificateurs - 6;
//                break;
//        }
//        int jetDes = (new JetDes()).JeterD(3);
//        int nbElementSS = jetDes + modificateurs;
//        // si jetDes est égale à 18 et qu'il n'y a aucune planète après 
//        // l'addition du jetDes et des modificateurs : le système comportera au moins une étoile
//        if (jetDes + modificateurs < 0 && jetDes == 18)
//        {
//            nbElementSS = 1;
//        }
//        // dans le cas où le nombre de planète est négatif ou nul et que
//        // jetDes est différent de 18 alors il n'y a pas de planete dans ce système solaire 
//        else if (jetDes + modificateurs < 0 && jetDes != 18)
//        {
//            nbElementSS = 0;
//        }
//        // dans le cas classique où le nombre de planète est strictement positif 
//        // on créé alors un nombre égale d'objet Planète reliés à l'objet Etoile
//        for (int j = 0; j < nbElementSS; j++)
//        {
//            // determiner la sous-classe : CorpsCeleste.Planete ou CeintureAsteroide
//            ElementSysteme nouvelElementSS = new ElementSysteme();
//            string zoneES;
//            string typeES;
//            zoneES = nouvelElementSS.Zone(this.typeE);
//            typeES = nouvelElementSS.DeterminerTypeES(zoneES);
//            if (typeES == "Géante Gazeuse" || typeES == "Terrestre" || typeES == "Glaciale")
//            {
//                this.tableElementSysteme.Add(new Planete(this, j.ToString() + this.id_E, zoneES, typeES));
//            }
//            else
//            {
//                this.tableElementSysteme.Add(new CeintureAsteroide(this, j.ToString() + this.id_E, zoneES));
//            }
//        }
//    }
//    public int NbElementSS()
//    {
//        return this.tableElementSysteme.Count;
//    }
//    #endregion

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