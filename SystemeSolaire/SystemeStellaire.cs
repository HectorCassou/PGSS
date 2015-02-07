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
        public List<Population> Populations { get; set; }
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
            Populations = new List<Population>();
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

//public class SystemeSolaire
//{


//    #region Méthodes Système Solaire
//    public void NbPortail()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        if (jetDes < 6)
//        {
//            this.portail = 0;
//        }
//        else if (jetDes < 20 && jetDes > 5)
//        {
//            this.portail = 1;
//        }
//        else
//        {
//            this.portail = 2;
//        }
//    }
//    public void colonisationSS()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        this.systemColonise = false;
//        switch (this.portail)
//        {
//            case 0:
//                if (jetDes < 6)
//                {
//                    this.systemColonise = true;
//                }
//                break;
//            case 1:
//                if (jetDes < 16)
//                {
//                    this.systemColonise = true;
//                }
//                break;
//            case 2:
//                if (jetDes < 31)
//                {
//                    this.systemColonise = true;
//                }
//                break;
//        }
//        if (this.systemColonise)
//        {
//            jetDes = (new JetDes()).JeterD(1, 4);
//            switch (jetDes)
//            {
//                case 1:
//                    this.raceColonie = "Humain";
//                    break;
//                case 2:
//                    this.raceColonie = "Narn";
//                    break;
//                case 3:
//                    this.raceColonie = "Centauri";
//                    break;
//                case 4:
//                    this.raceColonie = "Minbari";
//                    break;
//            }
//        }
//    }
//    public void NbDebrisSpatiaux()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        if (jetDes < 9)
//        {
//            this.debrisSpatiaux = true;
//        }
//        else
//        {
//            this.debrisSpatiaux = false;
//        }
//    }
//    public void EtoileInstable()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        if (jetDes < 3)
//        {
//            this.etoileInstable = true;
//        }
//        else
//        {
//            this.etoileInstable = false;
//        }
//    }
//    public void NuageOort()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        if (jetDes < 11)
//        {
//            this.nuageOort = 1;
//        }
//        else if (jetDes == 11)
//        {
//            this.nuageOort = 2;
//        }
//        else
//        {
//            this.nuageOort = 0;
//        }
//    }
//    public void RepairePirate()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        this.repairePirate = false;
//        if (this.tablePopNativeSS.Count() != 0)
//        {
//            if (jetDes < 16)
//            {
//                this.repairePirate = true;
//            }
//        }
//        else
//        {
//            if (jetDes < 6)
//            {
//                this.repairePirate = true;
//            }
//        }
//    }
//    public void ComptoirMarchand()
//    {
//        int jetDes = (new JetDes()).JeterD(1, 100);
//        this.comptoirMarchand = false;
//        if (this.tablePopNativeSS.Count() != 0)
//        {
//            if (jetDes < 9)
//            {
//                this.comptoirMarchand = true;
//            }
//        }
//        else
//        {
//            if (jetDes < 3)
//            {
//                this.comptoirMarchand = true;
//            }
//        }
//    }
//    public void Gouvernance()
//    {

//    }
//    public void NiveauMenace()
//    {

//    }
//    public void NiveauSecurite()
//    {

//    }
//    public void DeterminerTableEtoile()
//    {
//        int jetDes = (new JetDes()).JeterD(2, 10);
//        int nbEtoile;
//        if (jetDes < 18)
//        {
//            nbEtoile = 1;
//        }
//        else if (jetDes < 20 && jetDes > 17)
//        {
//            nbEtoile = 2;
//        }
//        else
//        {
//            nbEtoile = 3;
//        }
//        // on créer un nombre d'étoile égal à nbEtoile
//        for (int i = 0; i < nbEtoile; i++)
//        {
//            this.tableEtoile.Add(new Etoile(this, i));
//        }
//    }

//    public int NombreGeanteGazeuse()
//    {
//        int nbGG = 0;
//        foreach (Etoile etoile in this.tableEtoile)
//        {
//            foreach (Planete plnt in etoile.tableElementSysteme)
//            {
//                if (plnt.typeCC == "Géante Gazeuse")
//                {
//                    nbGG = nbGG + 1;
//                }
//            }
//        }
//        return nbGG;
//    }
//    public void ColonisationDuSS()
//    {

//        foreach (Population pop in tablePopNativeSS)
//        {
//            int nbColonie = 0;
//            JetDes jet = new JetDes();
//            int jetDes;
//            Queue<CeintureAsteroide> listeCASS = new Queue<CeintureAsteroide>();
//            Queue<Planete> listePSS = new Queue<Planete>();
//            Queue<Satellite> listeSSS = new Queue<Satellite>();


//            switch (pop.niveauTechnoPo)
//            {
//                case 6:
//                    nbColonie = jet.JeterD(1, 2, -1);
//                    break;
//                case 7:
//                    nbColonie = jet.JeterD(1, 3, -1);
//                    break;
//                case 8:
//                    nbColonie = jet.JeterD(1, 4, -1);
//                    break;
//            }
//            // on rassemble tous les éléments du système solaire dans deux files : une pour les corpscelestes et l'autre pour les astéroïdes
//            foreach (Etoile etoile in this.tableEtoile)
//            {
//                foreach (Planete plnt in etoile.tableElementSysteme)
//                {
//                    if (plnt.typeCC != "Géante Gazeuse")
//                    {
//                        listePSS.Enqueue(plnt);
//                    }
//                    foreach (Satellite satellite in plnt.tableSatellite)
//                    {
//                        listeSSS.Enqueue(satellite);
//                    }
//                }
//                foreach (CeintureAsteroide ca in etoile.tableElementSysteme)
//                {
//                    listeCASS.Enqueue(ca);
//                }
//            }
//            // trier les objet en fonction de la zone d'origine de la population
//            // on parcours ensuite tous les éléments de ces deux queues pour savoir si la population de la ceinture d'astéroïdes possède une autre planètes dans le systéme solaire
//            while (nbColonie != 0)
//            {
//                int choix = jet.JeterD(1, 3);
//                if (choix == 1 && listeCASS.Count != 0)
//                {
//                    choix = jet.JeterD(1, listeCASS.Count, -1);

//                }
//                else if (choix == 2 && listePSS.Count != 0)
//                {
//                    choix = jet.JeterD(1, listePSS.Count, -1);
//                }
//                else if (choix == 3 && listeSSS.Count != 0)
//                {
//                    choix = jet.JeterD(1, listeSSS.Count, -1);
//                }
//            }
//        }
//    }
//    #endregion
//}
