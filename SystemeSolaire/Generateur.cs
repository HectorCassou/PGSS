using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurSystemeStellaire
{
    public class Generateur
    {

        #region Attributs Générateur

        public List<string> listeParties = new List<string>();

        #endregion

        #region Etapes Génération Système Stellaire
        // Etape n°0 : déterminer le nombre d'étoiles
        public SystemeStellaire DeterminerNbEtoiles(SystemeStellaire sys)
        {
            if (sys.Etoiles.Count != 0)
            {
                sys.Etoiles.Clear();
            }
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(2, 10);
            int nbEtoile;
            if (jetDes < 18)
            {
                nbEtoile = 1;
            }
            else if (jetDes < 20 && jetDes > 17)
            {
                nbEtoile = 2;
            }
            else
            {
                nbEtoile = 3;
            }
            // on créer un nombre d'étoile égal à nbEtoile
            for (int i = 0; i < nbEtoile; i++)
            {
                sys.Etoiles.Add(new Etoile());
            }
            return sys;
        }
        // Etape n°1 : déterminer le type d'une étoile
        public Etoile DeterminerTypeEtoile(Etoile etoile)
        {
            //on détermine le type
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(2, 10);
            if (jetDes == 2)
            {
                etoile.type = "B";
            }
            else if (jetDes == 3)
            {
                etoile.type = "A";
            }
            else if (jetDes > 3 && jetDes < 9)
            {
                etoile.type = "F";
            }
            else if (jetDes > 8 && jetDes < 14)
            {
                etoile.type = "G";
            }
            else if (jetDes > 13 && jetDes < 17)
            {
                etoile.type = "K";
            }
            else if (jetDes > 16)
            {
                etoile.type = "M";
            }
                
            // on détermine la qualification du type
            etoile.qualificationType = jet.JeterD(1, 10, -1).ToString();
            return etoile;
        }
        // Etape n°2 : déterminer la taille d'une étoile
        public Etoile DeterminerTailleEtoile(Etoile etoile)
        {
            // on détermine la taille
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(2, 10);
            if (jetDes == 2)
            {
                etoile.taille = "IV";
            }
            else if (jetDes > 2 && jetDes < 17)
            {
                etoile.taille = "V";
            }
            else if (jetDes > 16)
            {
                etoile.taille = "VI";
            }
            return etoile;

        }
        // Etape n°3 : déterminer planète part1
        public int DeterminerNbPlanetes(Etoile etoile, int nbEtoile)
        {
            int nbElements = 0;
            // détermine le modificateur au jet de dé en fonction du type de l'étoile
            switch (etoile.type)
            {
                case "O":
                    nbElements = nbElements - 15;
                    break;
                case "B":
                    nbElements = nbElements - 12;
                    break;
                case "A":
                    nbElements = nbElements - 10;
                    break;
                case "F":
                    nbElements = nbElements - 4;
                    break;
                case "G":
                    nbElements = nbElements - 2;
                    break;
                case "K":
                    nbElements = nbElements - 6;
                    break;
                case "M":
                    nbElements = nbElements - 10;
                    break;
            }

            // détermine le modificateur au jet de dé en fonction du taille de l'étoile
            switch (etoile.taille)
            {
                case "Ia":
                    nbElements = nbElements - 8;
                    break;
                case "Ib":
                    nbElements = nbElements - 6;
                    break;
                case "II":
                    nbElements = nbElements - 4;
                    break;
                case "III":
                    nbElements = nbElements - 2;
                    break;
                case "IV":
                    nbElements = nbElements - 1;
                    break;
                case "VI":
                    nbElements = nbElements - 1;
                    break;
                case "VII":
                    nbElements = nbElements - 4;
                    break;
            }
            switch (nbEtoile)
            {
                case 2:
                    nbElements = nbElements - 2;
                    break;
                case 3:
                    nbElements = nbElements - 6;
                    break;
            }
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(3);
            nbElements = jetDes + nbElements;
            // si jetDes est égale à 18 et qu'il n'y a aucune planète après 
            //le système comportera au moins une étoile
            if (nbElements <= 0 && jetDes == 18)
            {
                nbElements = 1;
            }
            // dans le cas où le nombre de planète est négatif ou nul et que
            // jetDes est différent de 18 alors il y a  0 planete dans ce système solaire 
            else if (nbElements < 0 && jetDes != 18)
            {
                nbElements = 0;
            }

            return nbElements;
        }
        // Etape n°4 : retourne la position dans le système stellaire de l'élement rattaché à une étoile
        public string DeterminerPositionPlanete(Etoile etoile)
        {
            string position = "";
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);
            switch (etoile.type)
            {
                case "O":
                    if (jetDes < 13)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 15 && jetDes > 12)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 14)
                    {
                        position = "Froide";
                    }
                    break;
                case "B":
                    if (jetDes < 11)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 13 && jetDes > 10)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 12)
                    {
                        position = "Froide";
                    }
                    break;
                case "A":
                    if (jetDes < 9)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 11 && jetDes > 8)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 10)
                    {
                        position = "Froide";
                    }
                    break;
                case "F":
                    if (jetDes < 7)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 10 && jetDes > 6)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 9)
                    {
                        position = "Froide";
                    }
                    break;
                case "G":
                    if (jetDes < 6)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 10 && jetDes > 5)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 9)
                    {
                        position = "Froide";
                    }
                    break;
                case "K":
                    if (jetDes < 5)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes < 7 && jetDes > 4)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 6)
                    {
                        position = "Froide";
                    }
                    break;
                case "M":
                    if (jetDes < 3)
                    {
                        position = "Chaude";
                    }
                    else if (jetDes == 3)
                    {
                        position = "Habitable";
                    }
                    else if (jetDes > 3)
                    {
                        position = "Froide";
                    }
                    break;
            }
            return position;
        }
        // Etape n°5
        public Etoile DeterminerTypePlanete(Etoile etoile, string zone)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);
            string type = "";
            switch (zone)
            {
                case "Chaude":
                    if (jetDes < 3)
                    {
                        type = "Géante Gazeuse";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes < 20 && jetDes > 2)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes > 19)
                    {
                        type = "Ceinture d'Astéroide";
                        etoile.Ceintures.Add(new CeintureAsteroide(zone));
                    }
                    break;
                case "Habitable":
                    if (jetDes < 5)
                    {
                        type = "Géante Gazeuse";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes < 19 && jetDes > 4)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes == 19)
                    {
                        type = "Ceinture d'Astéroide";
                        etoile.Ceintures.Add(new CeintureAsteroide(zone));
                    }
                    else if (jetDes == 20)
                    {
                        type = "Glaciale";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    break;
                case "Froide":
                    if (jetDes < 9)
                    {
                        type = "Géante Gazeuse";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes < 12 && jetDes > 8)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    else if (jetDes < 14 && jetDes > 11)
                    {
                        type = "Ceinture d'Astéroide";
                        etoile.Ceintures.Add(new CeintureAsteroide(zone));
                    }
                    else if (jetDes > 13)
                    {
                        type = "Glaciale";
                        etoile.Planetes.Add(new Planete(zone, type));
                    }
                    break;
            }
            return etoile;
        }
        // Etape n°6
        public Planete DeterminerTaillePlanete(Planete planete)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);
            switch (planete.zone)
            {
                case "Chaude":
                    jetDes = jetDes - 1;
                    break;
                case "Froide":
                    jetDes = jetDes + 1;
                    break;
            }
            switch (planete.type)
            {
                case "Géante Gazeuse":
                    jetDes = jetDes + 20;
                    break;
                case "Glaciale":
                    jetDes = jetDes - 3;
                    break;
            }

            if (jetDes < -4)
            {
                planete.taille = 0;
            }
            else if (jetDes < 1 && jetDes > -4)
            {
                planete.taille = 1;
            }
            else if (jetDes < 6 && jetDes > 0)
            {
                planete.taille = 2;
            }
            else if (jetDes < 11 && jetDes > 5)
            {
                planete.taille = 3;
            }
            else if (jetDes < 16 && jetDes > 10)
            {
                planete.taille = 4;
            }
            else if (jetDes < 19 && jetDes > 15)
            {
                planete.taille = 5;
            }
            else if (jetDes < 21 && jetDes > 18)
            {
                if (planete.type == "Géante Gazeuse")
                {
                    planete.taille = 7;
                }
                else
                {
                    planete.taille = 6;
                }
            }
            else if (jetDes < 26 && jetDes > 20)
            {
                if (planete.type != "Géante Gazeuse")
                {
                    planete.taille = 6;
                }
                else
                {
                    planete.taille = 7;
                }
            }
            else if (jetDes < 36 && jetDes > 25)
            {
                planete.taille = 8;
            }
            else if (jetDes < 39 && jetDes > 35)
            {
                planete.taille = 9;
            }
            else if (jetDes > 38)
            {
                jetDes = jet.JeterD(1, 20); // regle optionnel sur les Naine brunes en cas de Géante Gazeuse Gargantuesque
                if (jetDes == 1)
                {
                    planete.taille = 11;
                }
                else
                {
                    planete.taille = 10;
                }
            }


            switch (planete.taille)
            {
                case 0:
                    planete.diametre = (jet.JeterD(5, 10, 50));
                    break;
                case 1:
                    planete.diametre = (jet.JeterD(1, 4) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 2:
                    planete.diametre = (jet.JeterD(2) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 3:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 4:
                    planete.diametre = (jet.JeterD(2, 4, 4) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 5:
                    planete.diametre = (jet.JeterD(5, 10, 50) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 6:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 7:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 8:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 9:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 10:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 11:
                    planete.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
            }
            return planete;
        }
        // Etape n°7
        public SystemeStellaire DeterminerSombreCompagnon(SystemeStellaire sys)
        {
            sys.sombreCompagnon = false;
            foreach(Etoile etoile in sys.Etoiles)
            {
                foreach (Planete planete in etoile.Planetes)
                {
                    if(planete.taille == 11 && planete.zone == "Froide")
                    {
                        sys.sombreCompagnon = true;
                    }
                }
            }
            return sys;
        }
        // Etape n°8
        public SystemeStellaire DeterminerDebris(SystemeStellaire sys)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 100);
            sys.debrisSpatiaux = false;
            if (jetDes < 9)
            {
                sys.debrisSpatiaux = true;
            }
            return sys;
        }
        // Etape n°9
        public SystemeStellaire DeterminerEtoileInstable(SystemeStellaire sys)
        {
            for (int i = 0; i < sys.Etoiles.Count; i++)
			{
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(1, 100);
                sys.Etoiles[i].instable = false;
                if (jetDes < 3)
                {
                    sys.Etoiles[i].instable = true;
                }
			} 
            return sys;
        }
        // Etape n°10
        public SystemeStellaire DeterminerNuageOort(SystemeStellaire sys)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 100);
            sys.nuageOort = false;
            if (jetDes < 11)
            {
                sys.nuageOort = true;
            }
            return sys;
        }
        // Etape n°11
        public SystemeStellaire DeterminerPortail(SystemeStellaire sys)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);
            sys.portail = 0;
            if (jetDes < 20 && jetDes > 5)
            {
                sys.portail = 1;
            }
            else if (jetDes > 19)
            {
                sys.portail = 2;
            }
            return sys;
        }
        // Etape n°12
        public SystemeStellaire DeterminerComptoirMarchand(SystemeStellaire sys)
        {
            sys.comptoirMarchand = false;
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 100);
            if(sys.portail == 1)
            {
                if (jetDes < 4)
                {
                    sys.comptoirMarchand = true;
                }
            }
            else if (sys.portail == 2)
            {
                if (jetDes < 9)
                {
                    sys.comptoirMarchand = true;
                }
            }
            return sys;
        }
        // Etape n°13
        public SystemeStellaire DeterminerColonisation(SystemeStellaire sys)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 100);
            bool systemColonise = false;
            // retirer la population coloniale dans le système  /!\ à améliorer peut être pour ajouter plus de race coloniale /!\
            for (int i = 0; i < sys.Populations.Count; i++)
            {
                if(sys.Populations[i].localisation == "SystemeStellaire" && sys.Populations[i].type == "Coloniale")
                {
                    sys.Populations.RemoveAt(i);
                }
            }

            switch (sys.portail)
            {
                case 0:
                    if (jetDes < 6)
                    {
                        systemColonise = true;
                    }
                    break;
                case 1:
                    if (jetDes < 16)
                    {
                        systemColonise = true;
                    }
                    break;
                case 2:
                    if (jetDes < 31)
                    {
                        systemColonise = true;
                    }
                    break;
            }
            if (systemColonise)
            {
                jetDes = (new JetDes()).JeterD(1, 4);
                switch (jetDes)
                {
                    case 1:
                        sys.Populations.Add(new Population("Humain", "SystemeStellaire", "Coloniale", 7, -3, 7, 4, 5, 8));
                        break;
                    case 2:
                        sys.Populations.Add(new Population("Narn", "SystemeStellaire", "Coloniale", 7, -2, 3, 6, 6, 5));
                        break;
                    case 3:
                        sys.Populations.Add(new Population("Centauri", "SystemeStellaire", "Coloniale", 8, 2, 2, 7, 7, 7));
                        break;
                    case 4:
                        sys.Populations.Add(new Population("Minbari", "SystemeStellaire", "Coloniale", 8, 4, 3, 1, 5, 8));
                        break;
                }
            }
            return sys;
        }
        // Etape n°14
        // Etape n°15
        // Etape n°16
        // Etape n°17
        // Etape n°18
        // Etape n°19
        // Etape n°20
        // Etape n°21
        // Etape n°22
        // Etape n°23
        // Etape n°24
        // Etape n°25
        // Etape n°26
        // Etape n°27
        // Etape n°28
        // Etape n°29
        // Etape n°30
        // Etape n°31
        // Etape n°32
        // Etape n°33
        // Etape n°34
        // Etape n°35
        // Etape n°36
        // Etape n°37
        // Etape n°38
        // Etape n°39
        // Etape n°40
        // Etape n°41
        // Etape n°42
        // Etape n°43
        // Etape n°44
        // Etape n°45
        // Etape n°46
        // Etape n°47
        // Etape n°48
        // Etape n°49
        // Etape n°50
        // Etape n°51
        // Etape n°52
        // Etape n°53
        // Etape n°54
        // Etape n°55
        // Etape n°56
        // Etape n°57
        // Etape n°58
        // Etape n°59
        // Etape n°60
        // Etape n°61
        // Etape n°62
        // Etape n°63
        // Etape n°64
        // Etape n°65
        // Etape n°66
        // Etape n°67
        // Etape n°68
        // Etape n°69
        // Etape n°70
        
        #endregion

        #region Parties Génération Système Stellaire
        // Partie n°0
        public SystemeStellaire partie0(SystemeStellaire sys)
        {
            sys = DeterminerNbEtoiles(sys);
            for (int i = 0; i < sys.Etoiles.Count ; i++)
            {
                sys.Etoiles[i] = DeterminerTypeEtoile(sys.Etoiles[i]);
                sys.Etoiles[i] = DeterminerTailleEtoile(sys.Etoiles[i]);
            }
            return sys;
        }
        // Partie n°1
        public SystemeStellaire partie1(SystemeStellaire sys)
        {
            int nbPlanete = 0;
            for (int i = 0; i < sys.Etoiles.Count ; i++)
            {
                nbPlanete = DeterminerNbPlanetes(sys.Etoiles[i], sys.Etoiles.Count);
                for (int j = 0; j < nbPlanete; j++)
                {
                    string zone = DeterminerPositionPlanete(sys.Etoiles[i]);
                    sys.Etoiles[i] = DeterminerTypePlanete(sys.Etoiles[i], zone);
                }

                for (int k = 0; k < sys.Etoiles[i].Planetes.Count; k++)
                {
                    sys.Etoiles[i].Planetes[k] = DeterminerTaillePlanete(sys.Etoiles[i].Planetes[k]);
                }
            }
            return sys;
        }
        // Partie n°2
        public SystemeStellaire partie2(SystemeStellaire sys)
        {
            sys = DeterminerSombreCompagnon(sys);
            sys = DeterminerDebris(sys);
            sys = DeterminerEtoileInstable(sys);
            sys = DeterminerNuageOort(sys);
            sys = DeterminerPortail(sys);
            sys = DeterminerComptoirMarchand(sys);
            sys = DeterminerColonisation(sys);
            return sys;
        }
        // Partie n°3
        public SystemeStellaire partie3(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°4
        public SystemeStellaire partie4(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°5
        public SystemeStellaire partie5(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°6
        public SystemeStellaire partie6(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°7
        public SystemeStellaire partie7(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°8
        public SystemeStellaire partie8(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°9
        public SystemeStellaire partie9(SystemeStellaire sys)
        {
            return sys;
        }
        // Partie n°10
        public SystemeStellaire partie10(SystemeStellaire sys)
        {
            return sys;
        }
        #endregion

        #region Méthodes Générateur
        public SystemeStellaire Generation()
        {
            SystemeStellaire systeme = new SystemeStellaire();
            systeme = ExecuterPartie(0, systeme);
            systeme = ExecuterPartie(1, systeme);
            systeme = ExecuterPartie(2, systeme);
            return systeme;
        }


        public SystemeStellaire ExecuterPartie(int numPartie, SystemeStellaire sys)
        {
            switch (numPartie)
            {
                case 0:
                    sys = partie0(sys);
                    break;
                case 1:
                    sys = partie1(sys);
                    break;
                case 2:
                    sys = partie2(sys);
                    break;
            }
            return sys;
        }
        #endregion
    }
}
