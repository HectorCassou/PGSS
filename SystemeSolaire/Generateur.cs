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
        public Etoile Determinertypetoile(Etoile etoile)
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
        public Etoile Determinertailletoile(Etoile etoile)
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
        // Etape n°3 : déterminer planète 
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
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    else if (jetDes < 20 && jetDes > 2)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type, false));
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
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    else if (jetDes < 19 && jetDes > 4)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    else if (jetDes == 19)
                    {
                        type = "Ceinture d'Astéroide";
                        etoile.Ceintures.Add(new CeintureAsteroide(zone));
                    }
                    else if (jetDes == 20)
                    {
                        type = "Glaciale";
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    break;
                case "Froide":
                    if (jetDes < 9)
                    {
                        type = "Géante Gazeuse";
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    else if (jetDes < 12 && jetDes > 8)
                    {
                        type = "Terrestre";
                        etoile.Planetes.Add(new Planete(zone, type, false));
                    }
                    else if (jetDes < 14 && jetDes > 11)
                    {
                        type = "Ceinture d'Astéroide";
                        etoile.Ceintures.Add(new CeintureAsteroide(zone));
                    }
                    else if (jetDes > 13)
                    {
                        type = "Glaciale";
                        etoile.Planetes.Add(new Planete(zone, type, false));
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

            if (jetDes < -3)
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

            sys.populationColoniale = new Population(); 

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
                        sys.populationColoniale = new Population("Humain", "Coloniale", 7, -3, 7, 4, 5, 8);
                        break;
                    case 2:
                        sys.populationColoniale = new Population("Narn", "Coloniale", 7, -2, 3, 6, 6, 5);
                        break;
                    case 3:
                        sys.populationColoniale = new Population("Centauri", "Coloniale", 8, 2, 2, 7, 7, 7);
                        break;
                    case 4:
                        sys.populationColoniale = new Population("Minbari", "Coloniale", 8, 4, 3, 1, 5, 8);
                        break;
                }
            }
            return sys;
        }
        // Etape n°14
        public Planete DeterminerGravitePlanete(Planete planete)
        {
            // correspond à un 1d20
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);

            // règle additionnelle : si la planète est glaciale alors il faut soustraire 4 au jet de dé
            if (planete.type == "Glaciale")
            {
                jetDes = jetDes - 4;
            }

            // compare la chaine de caractère correspondant à la catégorie de taille de la planète pour déterminer la gravité
            switch (planete.taille)
            {
                case 0:
                    if (jetDes < 20)
                    {
                        planete.gravite = "Microgravité";
                    }
                    else
                    {
                        planete.gravite = "Très Basse";
                    }
                    break;
                case 1:
                    if (jetDes < 16)
                    {
                        planete.gravite = "Microgravité";
                    }
                    else
                    {
                        planete.gravite = "Très Basse";
                    }
                    break;
                case 2:
                    if (jetDes < 11)
                    {
                        planete.gravite = "Microgravité";
                    }
                    else
                    {
                        planete.gravite = "Très Basse";
                    }
                    break;
                case 3:
                    if (jetDes < 11)
                    {
                        planete.gravite = "Très Basse";
                    }
                    else if (jetDes < 20 && jetDes > 10)
                    {
                        planete.gravite = "Basse";
                    }
                    else
                    {
                        planete.gravite = "Moyenne";
                    }
                    break;
                case 4:
                    if (jetDes < 3)
                    {
                        planete.gravite = "Très Basse";
                    }
                    else if (jetDes < 8 && jetDes > 2)
                    {
                        planete.gravite = "Basse";
                    }
                    else if (jetDes < 16 && jetDes > 7)
                    {
                        planete.gravite = "Moyenne";
                    }
                    else
                    {
                        planete.gravite = "Forte";
                    }
                    break;
                case 5:
                    if (jetDes < 3)
                    {
                        planete.gravite = "Basse";
                    }
                    else if (jetDes < 6 && jetDes > 2)
                    {
                        planete.gravite = "Moyenne";
                    }
                    else if (jetDes < 13 && jetDes > 7)
                    {
                        planete.gravite = "Forte";
                    }
                    else if (jetDes < 19 && jetDes > 12)
                    {
                        planete.gravite = "Très Forte";
                    }
                    else
                    {
                        planete.gravite = "Extrème";
                    }
                    break;
                case 6:
                    if (jetDes < 2)
                    {
                        planete.gravite = "Basse";
                    }
                    else if (jetDes < 4 && jetDes > 1)
                    {
                        planete.gravite = "Moyenne";
                    }
                    else if (jetDes < 11 && jetDes > 3)
                    {
                        planete.gravite = "Forte";
                    }
                    else if (jetDes < 17 && jetDes > 10)
                    {
                        planete.gravite = "Très Forte";
                    }
                    else
                    {
                        planete.gravite = "Extrème";
                    }
                    break;
                default:
                    // la gravité pour les géantes gazeuses suit des règles spéciales
                    planete.gravite = "Extrème";
                    break;
            }
            return planete;
        }
        // Etape n°15
        public Planete DeterminerDensiteAtmospheriquePlanete(Planete planete)
        {

            // correspond à un 1d20
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);

            // si la planète est un satellite d'une autre planète
            if (planete.estSatellite)
            {
                jetDes = jetDes - 2;
            }

            // règle additionnelle : si la planète est glaciale alors il faut soustraire 4 au jet de dé
            if (planete.zone == "Chaude" || planete.zone == "Froide")
            {
                jetDes = jetDes - 4;
            }

            if (planete.type != "Géante Gazeuse")
            {
                switch (planete.gravite)
                {
                    case "Microgravité":
                        if (jetDes < 20)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        break;
                    case "Très Basse":
                        if (jetDes < 10)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes < 19 && jetDes > 9)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        break;
                    case "Basse":
                        if (jetDes < 6)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes < 11 && jetDes > 5)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else if (jetDes < 16 && jetDes > 10)
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        else
                        {
                            planete.densiteAtmos = "Moyenne";
                        }
                        break;
                    case "Moyenne":
                        if (jetDes < 3)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes < 4 && jetDes > 2)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else if (jetDes < 7 && jetDes > 3)
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        else if (jetDes < 11 && jetDes > 6)
                        {
                            planete.densiteAtmos = "Moyenne";
                        }
                        else if (jetDes < 16 && jetDes > 10)
                        {
                            planete.densiteAtmos = "Dense";
                        }
                        else
                        {
                            planete.densiteAtmos = "Très Dense";
                        }
                        break;
                    case "Forte":
                        if (jetDes < 2)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes < 4 && jetDes > 1)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else if (jetDes < 8 && jetDes > 3)
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        else if (jetDes < 12 && jetDes > 7)
                        {
                            planete.densiteAtmos = "Moyenne";
                        }
                        else if (jetDes < 17 && jetDes > 11)
                        {
                            planete.densiteAtmos = "Dense";
                        }
                        else
                        {
                            planete.densiteAtmos = "Très Dense";
                        }
                        break;
                    case "Très Forte":
                        if (jetDes < 2)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes == 2)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else if (jetDes < 5 && jetDes > 2)
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        else if (jetDes < 7 && jetDes > 4)
                        {
                            planete.densiteAtmos = "Moyenne";
                        }
                        else if (jetDes < 14 && jetDes > 6)
                        {
                            planete.densiteAtmos = "Dense";
                        }
                        else
                        {
                            planete.densiteAtmos = "Très Dense";
                        }
                        break;
                    case "Extrème":
                        if (jetDes < 2)
                        {
                            planete.densiteAtmos = "Vide";
                        }
                        else if (jetDes == 2)
                        {
                            planete.densiteAtmos = "Très Faible";
                        }
                        else if (jetDes == 3)
                        {
                            planete.densiteAtmos = "Faible";
                        }
                        else if (jetDes == 4)
                        {
                            planete.densiteAtmos = "Moyenne";
                        }
                        else if (jetDes < 9 && jetDes > 4)
                        {
                            planete.densiteAtmos = "Dense";
                        }
                        else if (jetDes < 19 && jetDes > 8)
                        {
                            planete.densiteAtmos = "Très Dense";
                        }
                        else
                        {
                            planete.densiteAtmos = "Extrèmement Dense";
                        }
                        break;
                }
            }
            else
            {
                planete.densiteAtmos = "Extrèmement Dense"; // cas où la planète est de type Géante gazeuse
            }
            return planete;
        }
        // Etape n°16
        public Planete DeterminerCompositionAtmospherePlanete(Planete planete)
        {

            if (planete.densiteAtmos != "Vide")
            {
                if (planete.type == "Géante Gazeuse")
                {
                    // détermine la composition de l'atmospshère pour les géantes gazeuses
                    planete.atmosCompo = "Corrosive";
                    planete.pollution = "Aucune";
                }
                else
                {
                    // correspond à un 1d20
                    int jetDes = (new JetDes()).JeterD(1, 20);

                    switch (planete.zone)
                    {
                        case "Chaude":
                            if (jetDes < 6)
                            {
                                planete.atmosCompo = "Corrosive";
                                planete.pollution = "Aucune";
                            }
                            else if (jetDes < 11 && jetDes > 5)
                            {
                                planete.atmosCompo = "Toxique";
                                planete.pollution = "Aucune";
                            }
                            else
                            {
                                planete.atmosCompo = "Inerte";
                                planete.pollution = "Aucune";
                            }
                            break;
                        case "Habitable":
                            if (jetDes < 4)
                            {
                                planete.atmosCompo = "Toxique";
                                planete.pollution = "Aucune";
                            }
                            else if (jetDes < 6 && jetDes > 3)
                            {
                                planete.atmosCompo = "Inerte";
                                planete.pollution = "Aucune";
                            }
                            else if (jetDes < 13 && jetDes > 5)
                            {
                                planete.atmosCompo = "Respirable";
                                planete.pollution = "Aucune";
                            }
                            else
                            {
                                planete.atmosCompo = "Respirable";
                                planete.pollution = "Polluée";
                                
                            }
                            break;
                        case "Froide":
                            if (jetDes < 4)
                            {
                                planete.atmosCompo = "Inerte";
                                planete.pollution = "Aucune";
                            }
                            else if (jetDes < 6 && jetDes > 3)
                            {
                                planete.atmosCompo = "Toxique";
                                planete.pollution = "Aucune";
                            }
                            else if (jetDes < 13 && jetDes > 5)
                            {
                                planete.atmosCompo = "Corrosive";
                                planete.pollution = "Aucune";
                            }
                            else
                            {
                                planete.atmosCompo = "Variable";
                                planete.pollution = "Aucune";
                            }
                            break;
                    }
                }

            }
            else
            {
                planete.atmosCompo = "Aucune";
            }
            return planete;
        }
        // Etape n°17
        public Planete DeterminerPollutionPlanete(Planete planete)
        {   
            if(planete.pollution == "Polluée")
            {
                // on jete 1d6
                JetDes jet = new JetDes();
                int jetDes = (new JetDes()).JeterD();
                switch (jetDes)
                {
                    case 1:
                        planete.pollution = "Polluée";
                        break;
                    case 2:
                        planete.pollution = "Peu d'Oxygène";
                        break;
                    case 3:
                        planete.pollution = "Radioactive";
                        break;
                    case 4:
                        planete.pollution = "Nocive";
                        break;
                    case 5:
                        planete.pollution = "Allergique";
                        break;
                    case 6:
                        planete.pollution = "Contagieuse";
                        break;
                }
            }
            return planete;
        }
        // Etape n°18
        public Planete DeterminerGeologiePlanete(Planete planete)
        {

            if (planete.type == "Géante Gazeuse")
            {
                // détermine la géologie pour les géantes gazeuses
                planete.geologie = "Aucune";
            }
            else
            {
                // correspond à un 1d20
                int jetDes = (new JetDes()).JeterD(1, 20);

                // modificateur apporter au jet pour déterminer la géologie de la planète selon la gravité
                switch (planete.gravite)
                {
                    case "Microgravité":
                        jetDes = jetDes - 4;
                        break;
                    case "Très Basse":
                        jetDes = jetDes - 2;
                        break;
                    case "Basse":
                        jetDes = jetDes - 1;
                        break;
                    case "Forte":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Forte":
                        jetDes = jetDes + 2;
                        break;
                    case "Extrème":
                        jetDes = jetDes + 4;
                        break;
                }

                // modificateur apporter au jet pour déterminer la géologie de la planète selon la densité atmosphérique
                switch (planete.densiteAtmos)
                {
                    case "Vide":
                        jetDes = jetDes + 3;
                        break;
                    case "Très Faible":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Dense":
                        jetDes = jetDes - 2;
                        break;
                    case "Extrèmement Dense":
                        jetDes = jetDes - 4;
                        break;
                }

                // résultat du jet pour déterminer la géologie de la planète
                if (jetDes < 4)
                {
                    planete.geologie = "Très Plate";
                }
                else if (jetDes < 8 && jetDes > 3)
                {
                    planete.geologie = "Plate";
                }
                else if (jetDes < 14 && jetDes > 7)
                {
                    planete.geologie = "Moyenne";
                }
                else if (jetDes < 18 && jetDes > 13)
                {
                    planete.geologie = "Rocailleuse";
                }
                else
                {
                    planete.geologie = "Très Rocailleuse";
                }
            }
            return planete;
        }
        // Etape n°19
        public Planete DeterminerVolcanismePlanete(Planete planete)
        {
            if (planete.type == "Géante Gazeuse" || planete.type == "Glaciale")
            {
                // détermine le volcanisme pour les géantes gazeuses et planètes n'ayant pas de coeur en fusion (Glaciale)
                planete.volcanisme = "Aucun";
            }
            else
            {
                // correspond à un 1d10
                int jetDes = (new JetDes()).JeterD(1, 10);

                // si la planète est un satellite d'une autre planète
                if (planete.estSatellite)
                {
                    jetDes = jetDes - 2;
                }

                // modificateur apporter au jet pour déterminer le volcanisme de la planète selon la gravité
                switch (planete.gravite)
                {
                    case "Microgravité":
                        jetDes = jetDes - 4;
                        break;
                    case "Très Basse":
                        jetDes = jetDes - 2;
                        break;
                    case "Basse":
                        jetDes = jetDes - 1;
                        break;
                    case "Forte":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Forte":
                        jetDes = jetDes + 2;
                        break;
                    case "Extrème":
                        jetDes = jetDes + 4;
                        break;
                }

                // modificateur apporter au jet pour déterminer le volcanisme de la planète selon la géologie
                switch (planete.geologie)
                {
                    case "Très Plate":
                        jetDes = jetDes - 5;
                        break;
                    case "Plate":
                        jetDes = jetDes - 3;
                        break;
                    case "Rocailleuse":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Rocailleuse":
                        jetDes = jetDes + 3;
                        break;
                }


                // résultat du jet pour déterminer le volcanisme de la planète
                if (jetDes < 5)
                {
                    planete.volcanisme = "Mort";
                }
                else if (jetDes < 7 && jetDes > 4)
                {
                    planete.volcanisme = "Stable";
                }
                else if (jetDes < 10 && jetDes > 6)
                {
                    planete.volcanisme = "Actif";
                }
                else if (jetDes < 12 && jetDes > 9)
                {
                    planete.volcanisme = "Très Actif";
                }
                else
                {
                    planete.volcanisme = "Extrème";
                }
            }
            return planete;
        }
        // Etape n°20
        public Planete DeterminerHydrospherePlanete(Planete planete)
        {

            if (planete.type == "Géante Gazeuse")
            {
                // détermine l'hydrosphère pour les géantes gazeuses
                planete.hydrosphere = "Aucune";
            }
            else
            {
                // correspond à un 1d20
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(1, 20);

                // si la planète est un satellite d'une autre planète
                if (planete.estSatellite)
                {
                    jetDes = jetDes - 2;
                }

                // modificateur apporter au jet pour déterminer l'hydrosphère de la planète selon la densité atmosphérique
                switch (planete.densiteAtmos)
                {
                    case "Vide":
                        jetDes = jetDes - 8;
                        break;
                    case "Très Faible":
                        jetDes = jetDes - 4;
                        break;
                    case "Faible":
                        jetDes = jetDes - 2;
                        break;
                    case "Dense":
                        jetDes = jetDes + 2;
                        break;
                    case "Très Dense":
                        jetDes = jetDes + 4;
                        break;
                    case "Extrèmement Dense":
                        jetDes = jetDes + 6;
                        break;
                }

                // modificateur apporter au jet pour déterminer l'hydrosphère de la planète selon la zone
                switch (planete.zone)
                {
                    case "Chaude":
                        jetDes = jetDes - 4;
                        break;
                    case "Habitable":
                        jetDes = jetDes + 2;
                        break;
                    case "Froide":
                        jetDes = jetDes - 2;
                        break;
                }


                // résultat du jet pour déterminer l'hydrosphère de la planète
                if (jetDes < 7)
                {
                    planete.hydrosphere = "Aucune";
                }
                else if (jetDes < 11 && jetDes > 6)
                {
                    planete.hydrosphere = "Très Sèche";
                    planete.tauxHydro = jet.JeterD(1, 20);
                }
                else if (jetDes < 14 && jetDes > 10)
                {
                    planete.hydrosphere = "Sèche";
                    planete.tauxHydro = 20 + jet.JeterD(1, 10);
                }
                else if (jetDes < 16 && jetDes > 13)
                {
                    planete.hydrosphere = "Equilibrée";
                    planete.tauxHydro = 30 + jet.JeterD(1, 20);
                }
                else if (jetDes < 18 && jetDes > 15)
                {
                    planete.hydrosphere = "Moite";
                    planete.tauxHydro = 50 + jet.JeterD(1, 20);
                }
                else if (jetDes < 20 && jetDes > 17)
                {
                    planete.hydrosphere = "Humide";
                    planete.tauxHydro = 70 + jet.JeterD(1, 20);
                }
                else if (jetDes > 19)
                {
                    planete.hydrosphere = "Très Humide";
                    planete.tauxHydro = 90 + jet.JeterD(1, 10);
                }
            }
            return planete;
        }
        // Etape n°21
        public Planete DeterminerGeographiePlanete(Planete planete)
        {

            if (planete.type == "Géante Gazeuse")
            {
                // détermine la géologie pour les géantes gazeuses
                planete.geographie = "Aucune";
            }
            else
            {
                if (planete.tauxHydro < 50)
                {

                    // définie par les oceans et mers
                    // correspond à un 1d10
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(1, 10);

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la gravité
                    switch (planete.volcanisme)
                    {
                        case "Mort":
                            jetDes = jetDes - 4;
                            break;
                        case "Stable":
                            jetDes = jetDes - 2;
                            break;
                        case "Très Actif":
                            jetDes = jetDes + 2;
                            break;
                        case "Extrème":
                            jetDes = jetDes + 4;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                    switch (planete.geologie)
                    {
                        case "Très Plate":
                            jetDes = jetDes - 4;
                            break;
                        case "Plate":
                            jetDes = jetDes - 1;
                            break;
                        case "Rocailleuse":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Rocailleuse":
                            jetDes = jetDes + 2;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                    if (planete.tauxHydro > 0 && planete.tauxHydro < 31)
                    {
                        jetDes = jetDes + 4;
                    }
                    else if (planete.tauxHydro > 40 && planete.tauxHydro < 50)
                    {
                        jetDes = jetDes - 4;
                    }

                    // resultat
                    if (jetDes < 6)
                    {
                        planete.geographie = "Grand océan";
                    }
                    else if (jetDes < 11 && jetDes > 5)
                    {
                        planete.geographie = jet.JeterD(1, 4, 1) + " océans";
                    }
                    else if (jetDes < 16 && jetDes > 10)
                    {
                        planete.geographie = jet.JeterD(1, 2) + " océans et " + jet.JeterD(1, 4, 1) + " mers";
                    }
                    else if (jetDes > 15)
                    {
                        planete.geographie = "Grands lacs";
                    }
                }
                else
                {
                    // défine par les continents
                    // correspond à un 1d20
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(1, 10);

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la gravité
                    switch (planete.volcanisme)
                    {
                        case "Mort":
                            jetDes = jetDes - 4;
                            break;
                        case "Stable":
                            jetDes = jetDes - 2;
                            break;
                        case "Très Actif":
                            jetDes = jetDes + 2;
                            break;
                        case "Extrème":
                            jetDes = jetDes + 6;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                    switch (planete.geologie)
                    {
                        case "Très Plate":
                            jetDes = jetDes - 2;
                            break;
                        case "Plate":
                            jetDes = jetDes - 1;
                            break;
                        case "Rocailleuse":
                            jetDes = jetDes + 2;
                            break;
                        case "Très Rocailleuse":
                            jetDes = jetDes + 4;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                    if (planete.tauxHydro > 59 && planete.tauxHydro < 76)
                    {
                        jetDes = jetDes + 4;
                    }
                    else if (planete.tauxHydro > 75 && planete.tauxHydro < 101)
                    {
                        jetDes = jetDes + 8;
                    }

                    // resultat
                    if (jetDes < 6)
                    {
                        planete.geographie = "Supercontinent";
                    }
                    else if (jetDes < 11 && jetDes > 5)
                    {
                        planete.geographie = jet.JeterD(1, 4, 1) + " grands continents";
                    }
                    else if (jetDes < 16 && jetDes > 10)
                    {
                        planete.geographie = jet.JeterD(1, 2) + " grands continents et " + jet.JeterD(1, 4, 1) + " petits continents";
                    }
                    else if (jetDes > 15)
                    {
                        planete.geographie = "Grandes îles et archipelles";
                    }
                }
            }
            return planete;
        }
        // Etape n°22
        public Planete DeterminerClimatPlanete(Planete planete, Etoile etoile)
        {
            if (planete.type == "Géante Gazeuse" || planete.densiteAtmos == "Vide")
            {
                // détermine le climat pour les géantes gazeuses et les planètes sans atmosphère
                planete.climat = "Vide";
            }
            else if (planete.zone == "Chaude")
            {
                planete.climat = "Chaleur Extrème";
            }
            else if (planete.zone == "Froide")
            {
                planete.climat = "Froid Extrème";
            }
            else
            {
                // correspond à un 2d10
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(2, 10);

                // modificateur apporter au jet pour déterminer le climat de la planète selon le volcanisme
                switch (planete.volcanisme)
                {
                    case "Actif":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Actif":
                        jetDes = jetDes + 2;
                        break;
                    case "Extrème":
                        jetDes = jetDes + 4;
                        break;
                }

                // modificateur apporter au jet pour déterminer le climat de la planète selon le type d'Etoile
                switch (etoile.type)
                {
                    case "O":
                        jetDes = jetDes + 7;
                        break;
                    case "B":
                        jetDes = jetDes + 5;
                        break;
                    case "A":
                        jetDes = jetDes + 3;
                        break;
                    case "F":
                        jetDes = jetDes + 1;
                        break;
                    case "K":
                        jetDes = jetDes - 2;
                        break;
                    case "M":
                        jetDes = jetDes - 5;
                        break;
                }

                // modificateur apporter au jet pour déterminer le climat de la planète selon la taille de l'Etoile
                switch (etoile.taille)
                {
                    case "Ia":
                        jetDes = jetDes + 7;
                        break;
                    case "Ib":
                        jetDes = jetDes + 6;
                        break;
                    case "II":
                        jetDes = jetDes + 5;
                        break;
                    case "III":
                        jetDes = jetDes + 3;
                        break;
                    case "IV":
                        jetDes = jetDes + 2;
                        break;
                    case "VI":
                        jetDes = jetDes - 4;
                        break;
                    case "VII":
                        jetDes = jetDes - 8;
                        break;
                }

                // modificateur apporter au jet pour déterminer le climat de la planète selon la densité atmosphérique
                switch (planete.densiteAtmos)
                {
                    case "Très Fine":
                        jetDes = jetDes - 6;
                        break;
                    case "Fine":
                        jetDes = jetDes - 2;
                        break;
                    case "Dense":
                        jetDes = jetDes + 2;
                        break;
                    case "Très Dense":
                        jetDes = jetDes + 4;
                        break;
                    case "Extrèmement Dense":
                        jetDes = jetDes + 8;
                        break;
                }

                //résultat

                if (jetDes < 1)
                {
                    planete.climat = "-10 F°";
                }
                else if (jetDes < 3 && jetDes > 0)
                {
                    planete.climat = "0 F°";
                }
                else if (jetDes < 5 && jetDes > 2)
                {
                    planete.climat = "20 F°";
                }
                else if (jetDes < 7 && jetDes > 4)
                {
                    planete.climat = "30 F°";
                }
                else if (jetDes < 9 && jetDes > 6)
                {
                    planete.climat = "40 F°";
                }
                else if (jetDes < 13 && jetDes > 8)
                {
                    planete.climat = "50 F°";
                }
                else if (jetDes < 15 && jetDes > 12)
                {
                    planete.climat = "60 F°";
                }
                else if (jetDes < 17 && jetDes > 14)
                {
                    planete.climat = "70 F°";
                }
                else if (jetDes < 19 && jetDes > 16)
                {
                    planete.climat = "80 F°";
                }
                else if (jetDes < 21 && jetDes > 18)
                {
                    planete.climat = "90 F°";
                }
                else if (jetDes == 21)
                {
                    planete.climat = "100 F°";
                }
                else if (jetDes > 21)
                {
                    planete.climat = "110 F°";
                }
            }
            return planete;
        }
        // Etape n°23
        public Planete DeterminerTempPolePlanete(Planete planete)
        {

            if (planete.climat == "Vide" || planete.climat == "Chaleur Extrème" || planete.climat == "Froid Extrème")
            {
                // détermine la variation température aux pôles pour les planètes au climat extrème
                planete.tempPole = 0;
            }
            else
            {
                // correspond à un 2d10
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(2, 10);

                // modificateur apporter au jet pour déterminer la variance de la température de la planète selon la taille de planète
                switch (planete.taille)
                {
                    case 0:
                        jetDes = jetDes - 4;
                        break;
                    case 1:
                        jetDes = jetDes - 4;
                        break;
                    case 2:
                        jetDes = jetDes - 4;
                        break;
                    case 3:
                        jetDes = jetDes - 4;
                        break;
                    case 5:
                        jetDes = jetDes + 4;
                        break;
                    case 6:
                        jetDes = jetDes + 8;
                        break;
                }

                // modificateur apporter au jet pour déterminer la variance de la température de la planète selon l'hydrosphère
                if (planete.tauxHydro < 21)
                {
                    jetDes = jetDes - 2;
                }
                if (planete.tauxHydro < 81 && planete.tauxHydro > 20)
                {
                    jetDes = jetDes + 2;
                }
                if (planete.tauxHydro > 80)
                {
                    jetDes = jetDes + 4;
                }

                // résultat
                planete.tempPole = jetDes * 3;
            }
            return planete;
        }
        // Etape n°24
        public Planete DeterminerBiospherePlanete(Planete planete)
        {

            planete.complexiteBio = "Aucune";

            if (planete.type == "Géante Gazeuse")
            {
                planete.densiteBio = "Aucune";
            }
            else
            {
                // correspond à un 2d10
                JetDes jet = new JetDes();
                int modificateur = 0;
                
                // modificateur apporter au jet pour déterminer la biopshère de la planète selon la densité atmosphérique
                switch (planete.densiteAtmos)
                {
                    case "Vide":
                        modificateur = modificateur - 8;
                        break;
                    case "Très Fine":
                        modificateur = modificateur - 4;
                        break;
                    case "Fine":
                        modificateur = modificateur - 2;
                        break;
                    case "Dense":
                        modificateur = modificateur - 2;
                        break;
                    case "Très Dense":
                        modificateur = modificateur - 4;
                        break;
                    case "Extrèmement Dense":
                        modificateur = modificateur - 8;
                        break;
                }

                // modificateur apporter au jet pour déterminer la biopshère de la planète selon l'hydropshère
                switch (planete.hydrosphere)
                {
                    case "Aucune":
                        modificateur = modificateur - 8;
                        break;
                    case "Très Sèche":
                        modificateur = modificateur - 4;
                        break;
                    case "Humide":
                        modificateur = modificateur + 4;
                        break;
                    case "Très Humide":
                        modificateur = modificateur + 8;
                        break;
                }

                // modificateur apporter au jet pour déterminer la biopshère de la planète selon la zone
                switch (planete.zone)
                {
                    case "Habitable":
                        modificateur = modificateur + 2;
                        break;
                    case "Froide":
                        modificateur = modificateur - 6;
                        break;
                    case "Chaude":
                        modificateur = modificateur - 8;
                        break;
                }
                // modificateur apporter au jet pour déterminer la biopshère de la planète selon la composition de l'atmosphère
                switch (planete.atmosCompo)
                {
                    case "Corrosive":
                        modificateur = modificateur - 6;
                        break;
                    case "Toxique":
                        modificateur = modificateur - 4;
                        break;
                    case "Respirable":
                        modificateur = modificateur + 2;
                        break;
                    case "Inerte":
                        modificateur = modificateur - 6;
                        break;
                }
                // modificateur apporter au jet pour déterminer la biopshère de la planète selon le volcanisme
                if (planete.volcanisme == "Extrème")
                {
                    modificateur = modificateur - 6;
                }

                // un jet pour la densite de la biosphère
                int jetDesDB = jet.JeterD(2, 10, modificateur); 

                //resultat densité biopshère
                if (jetDesDB < 6)
                {
                    planete.densiteBio = "Aucune";
                }
                else if (jetDesDB < 11 && jetDesDB > 5)
                {
                    planete.densiteBio = "Très Rare";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                    modificateur = modificateur -10;
                }
                else if (jetDesDB < 16 && jetDesDB > 10)
                {
                    planete.densiteBio = "Rare";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                    modificateur = modificateur -5;
                }
                else if (jetDesDB < 19 && jetDesDB > 15)
                {
                    planete.densiteBio = "Peu Fréquente";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                }
                else if (jetDesDB < 22 && jetDesDB > 18)
                {
                    planete.densiteBio = "Moyenne";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                }
                else if (jetDesDB < 26 && jetDesDB > 21)
                {
                    planete.densiteBio = "Abondante";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                    modificateur = modificateur + 3;
                }
                else if (jetDesDB > 25)
                {
                    planete.densiteBio = "Très Abondante";
                    // on rejète un nouveau jet pour déterminer la complexité de la biosphère
                    modificateur = modificateur + 5;
                }


                
                // resultat complexité biosphère
                if (planete.densiteBio != "Aucune")
                {
                    // un jet pour la densite de la biosphère
                    int jetDesCB = jet.JeterD(2, 10, modificateur); 

                    if (jetDesCB < 6)
                    {
                        planete.complexiteBio = "Très Simple";
                    }
                    else if (jetDesCB < 11 && jetDesCB > 5)
                    {
                        planete.complexiteBio = "Simple";
                    }
                    else if (jetDesCB < 16 && jetDesCB > 10)
                    {
                        planete.complexiteBio = "Basique";

                    }
                    else if (jetDesCB < 19 && jetDesCB > 15)
                    {
                        planete.complexiteBio = "Modérée";
                    }
                    else if (jetDesCB < 22 && jetDesCB > 18)
                    {
                        planete.complexiteBio = "Avancée";
                    }
                    else if (jetDesCB < 26 && jetDesCB > 21)
                    {
                        planete.complexiteBio = "Très Avancée";
                    }
                    else if (jetDesCB > 25)
                    {
                        planete.complexiteBio = "Intelligence Native";
                    }
                }
            }
            return planete;
        }
        // Etape n°25
        public Planete DeterminerArtefactPlanete(Planete planete)
        {
            JetDes jet = new JetDes();
            planete.artefactAncien = false;

            int jetDes = jet.JeterD(1, 100);
            if (jetDes == 1)
            {
                planete.artefactAncien = true;
            }
            return planete;
        }
        // Etape n°26
        public Planete DeterminerPopulations(Planete planete, SystemeStellaire systeme)
        {
            if (planete.type == "Géante Gazeuse") // pas de population si le  corps celeste est une géante gazeuse
            {
                planete.Populations.Clear();
                planete.mixPopulation = 0;
            }
            else
            {
                bool systemColonise = false;
                if(systeme.populationColoniale.type == "Coloniale")
                {
                    systemColonise = true;
                }
                
                if (systemColonise == false) // si le systeme solaire n'est pas colonisé
                {
                    if (planete.complexiteBio == "Très Avancée" || planete.complexiteBio == "Intelligence Native") // et si il y a une forme de vie assez avancée
                    {
                        foreach (Population pop in planete.Populations)
                        {
                            if (pop.type == "Native" || pop.nom == systeme.populationColoniale.nom)
                            {
                                planete.Populations.Remove(pop);
                            }
                        }
                        planete.Populations.Add(new Population("Native"));
                        planete.mixPopulation = 1;
                    }
                    else // sinon pas de population
                    {
                        foreach (Population pop in planete.Populations)
                        {
                            if (pop.type == "Native" || pop.nom == systeme.populationColoniale.nom)
                            {
                                planete.Populations.Remove(pop);
                            }
                        }
                        planete.mixPopulation = 0;
                    }
                }
                else // si le systeme solaire est colonisé
                {
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(1, 10);
                    // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                    jetDes = jetDes + systeme.populationColoniale.modificateurColonie;

                    switch (planete.complexiteBio) // quelle est la complexité de la biosphère
                    {
                        case "Très Simple":
                            jetDes = jetDes - 2;
                            break;
                        case "Simple":
                            jetDes = jetDes - 1;
                            break;
                        case "Modérée":
                            jetDes = jetDes + 1;
                            break;
                        case "Avancée":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Avancée":
                            jetDes = jetDes + 2;
                            break;
                        case "Intelligence Native":
                            jetDes = jetDes - 1;
                            break;
                    }
                    if (planete.volcanisme == "Extrème") // le volcanisme est il supportable
                    {
                        jetDes = jetDes - 2;
                    }
                    switch (planete.atmosCompo) // quelles sont les conditions atmosphériques
                    {
                        case "Respirable":
                            jetDes = jetDes + 1;
                            break;
                        default:
                            jetDes = jetDes - 1;
                            break;
                    }
                    if (planete.artefactAncien) // y a t'il un artefact des anciens
                    {
                        jetDes = jetDes + 6;
                    }

                    // resultat
                    if (jetDes < 8) // pas suffisament intéressant pour être colonisé
                    {
                        if (planete.complexiteBio == "Très Avancée" || planete.complexiteBio == "Intelligence Native")  // il y a quand même une forme de vie suffisamment avancée
                        {
                            foreach (Population pop in planete.Populations)
                            {
                                if (pop.type == "Native" || pop.nom == systeme.populationColoniale.nom)
                                {
                                    planete.Populations.Remove(pop);
                                }
                            }
                            planete.Populations.Add(new Population("Native"));
                            planete.mixPopulation = 1;
                        }
                        else // pas de population
                        {
                            planete.Populations.Clear();
                            planete.mixPopulation = 0;
                        }
                    }
                    else // suffisamment interessant pour être colonisé
                    {
                        if (planete.complexiteBio == "Très Avancée" || planete.complexiteBio == "Intelligence Native")
                        {
                            foreach (Population pop in planete.Populations)
                            {
                                if (pop.type == "Native" || pop.nom == systeme.populationColoniale.nom)
                                {
                                    planete.Populations.Remove(pop);
                                }
                            }
                            planete.Populations.Add(new Population("Native"));
                            planete.Populations.Add(new Population(systeme.populationColoniale.nom, "Coloniale", systeme.populationColoniale.modificateurColonie, systeme.populationColoniale.participation,
                                                                                                                                                                  systeme.populationColoniale.diversite,
                                                                                                                                                                  systeme.populationColoniale.control,
                                                                                                                                                                  systeme.populationColoniale.soutien));
                            planete.mixPopulation = 3; // il y a une forme de vie originaire du corps celeste et une population coloniale
                        }
                        else
                        {
                            foreach (Population pop in planete.Populations)
                            {
                                if (pop.type == "Native" || pop.nom == systeme.populationColoniale.nom)
                                {
                                    planete.Populations.Remove(pop);
                                }
                            }
                            planete.Populations.Add(new Population(systeme.populationColoniale.nom, "Coloniale", systeme.populationColoniale.modificateurColonie, systeme.populationColoniale.participation,
                                                                                                                                                                  systeme.populationColoniale.diversite,
                                                                                                                                                                  systeme.populationColoniale.control,
                                                                                                                                                                  systeme.populationColoniale.soutien));
                            planete.mixPopulation = 2; // il n'y a qu'une population coloniale
                        }
                    }

                }
            }
            return planete;
        }
        // Etape n°27
        public Planete DeterminerNbLunes(Planete planete)
        {
            if(planete.Satellites.Count != 0)
            {
                planete.Satellites.Clear();
            }
            int nbLunes = 0;

            JetDes jet = new JetDes();

            if (planete.taille == 7 || planete.taille == 8) // petite ou moyenne géante gazeuse
            {
                nbLunes = jet.JeterD(2, 6);
            }
            else if (planete.taille == 9 || planete.taille == 10 || planete.taille == 11) // énorme ou gargantuesque géante gazeuse + les naines brunes
            {
                nbLunes = jet.JeterD(3, 6);
            }
            else if (planete.taille == 5 || planete.taille == 6) // grande terrestre ou glaciale+ les planète de taille énorme ceci n'est pas mentionné dans le livre de règles
            {
                nbLunes = jet.JeterD(1, 6, -2);
            }
            else if (planete.taille == 3 || planete.taille == 4) // petite ou moyenne  terrestre ou glaciale
            {
                nbLunes = jet.JeterD(1, 6, -4);
            }

            if(nbLunes < 0)
            {
                nbLunes = 0;
            }

            for (int i = 0; i < nbLunes; i++)
            {
                planete.Satellites.Add(new Planete(planete.zone, true));
            }

            return planete;
        }
        // Etape n°28
        public Planete DeterminerNbMoonlets(Planete planete)
        {
            JetDes jet = new JetDes();
            int nbMoonlets = 0;

            if (planete.taille == 7 || planete.taille == 8) // petite ou moyenne géante gazeuse
            {
                nbMoonlets = jet.JeterD(3, 6);
            }
            else if (planete.taille == 9 || planete.taille == 10 || planete.taille == 11) // énorme ou gargantuesque géante gazeuse + les naines brunes
            {
                nbMoonlets = jet.JeterD(4, 6);
            }
            else if (planete.taille == 5 || planete.taille == 6) // grande terrestre ou glaciale + les planète de taille énorme ceci n'est pas mentionné dans le livre de règles
            {
                nbMoonlets = jet.JeterD(1, 6, -3);
            }
            else if (planete.taille == 3 || planete.taille == 4) // petite ou moyenne  terrestre ou glaciale
            {
                nbMoonlets = jet.JeterD(1, 6, -3);
            }

            if (nbMoonlets < 0)
            {
                nbMoonlets = 0;
            }

            planete.nbMoonlets = nbMoonlets;

            return planete;
        }
        // Etape n°29
        public Planete DeterminerTypeSatellite(Planete satellite)
        {
            // on jette 1d20
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);

            switch (satellite.zone)
            {
                case "Chaude":
                    satellite.type = "Terrestre";
                    break;
                case "Habitable":
                    if (jetDes < 16)
                    {
                        satellite.type = "Terrestre";
                    }
                    else
                    {
                        satellite.type = "Glaciale";
                    }
                    break;
                case "Froide":
                    if (jetDes < 11)
                    {
                        satellite.type = "Terrestre";
                    }
                    else
                    {
                        satellite.type = "Glaciale";
                    }
                    break;
            }
            return satellite;
        }
        // Etape n°30
        public Planete DeterminerTailleSatellite(Planete planete, Planete satellite)
        {
            // on tire 1d20 avec un modificateur de -5 qui correspond à celui applicable à un satellite
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20, -5);

            switch (satellite.zone)
            {
                case "Chaude":
                    jetDes = jetDes - 1;
                    break;
                case "Froide":
                    jetDes = jetDes + 1;
                    break;
            }
            switch (satellite.type)
            {
                case "Glaciale":
                    jetDes = jetDes - 3;
                    break;
            }


            if (jetDes < -3)
            {
                satellite.taille = 0;
            }
            if (jetDes < 1 && jetDes > -4)
            {
                satellite.taille = 1;
            }
            if (jetDes < 6 && jetDes > 0)
            {
                satellite.taille = 2;
            }
            if (jetDes < 11 && jetDes > 5)
            {
                satellite.taille = 3;
            }
            if (jetDes < 16 && jetDes > 10)
            {
                satellite.taille = 4;
            }
            if (jetDes < 19 && jetDes > 15)
            {
                satellite.taille = 5;
            }
            if (jetDes > 18)
            {
                satellite.taille = 6;
            }


            if (planete.taille <= satellite.taille)
            {
                satellite.taille = planete.taille - 1;
            }


            switch (satellite.taille)
            {
                case 0:
                    satellite.diametre = (jet.JeterD(5, 10, 50));
                    break;
                case 1:
                    satellite.diametre = (jet.JeterD(1, 4) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 2:
                    satellite.diametre = (jet.JeterD(2) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 3:
                    satellite.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 4:
                    satellite.diametre = (jet.JeterD(2, 4, 4) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 5:
                    satellite.diametre = (jet.JeterD(5, 10, 50) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
                case 6:
                    satellite.diametre = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1));
                    break;
            }
            return satellite;
        }
        // Etape n°31
        public Population DeterminerNbHabitants(Population pop, Planete planete)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(2, 10);
            // modificateurs aux jets du nombre d'habitant de la population
            switch (planete.densiteBio)
            {
                case "Aucune":
                    jetDes = jetDes - 8;
                    break;
                case "Très Rare":
                    jetDes = jetDes - 6;
                    break;
                case "Rare":
                    jetDes = jetDes - 2;
                    break;
                case "Abondante":
                    jetDes = jetDes + 4;
                    break;
            }

            switch (planete.complexiteBio)
            {
                case "Simple":
                    jetDes = jetDes - 6;
                    break;
                case "Basique":
                    jetDes = jetDes - 3;
                    break;
                case "Avancée":
                    jetDes = jetDes + 2;
                    break;
                case "Très Avancée":
                    jetDes = jetDes + 4;
                    break;
                case "Intelligence Native":
                    jetDes = jetDes + 6;
                    break;
            }

            switch (planete.atmosCompo)
            {
                case "Corrosive":
                    jetDes = jetDes - 4;
                    break;
                case "Toxique":
                    jetDes = jetDes - 3;
                    break;
                case "Inerte":
                    jetDes = jetDes - 2;
                    break;
                case "Respirable":
                    if (planete.pollution == "Aucune")
                    {
                        jetDes = jetDes + 2;
                    }
                    else
                    {
                        jetDes = jetDes - 1;
                    }
                    break;
            }

            switch (planete.zone)
            {
                case "Chaude":
                    jetDes = jetDes - 4;
                    break;
                case "Habitable":
                    jetDes = jetDes + 2;
                    break;
                case "Froide":
                    jetDes = jetDes - 2;
                    break;
            }

            if (planete.hydrosphere == "Très Humide" || planete.hydrosphere == "Humide")
            {
                jetDes = jetDes + 2;
            }
            else if (planete.hydrosphere == "Aucune" || planete.hydrosphere == "Très Sèche")
            {
                jetDes = jetDes - 2;
            }

            if (planete.volcanisme == "Extrème")
            {
                jetDes = jetDes - 4;
            }
            if (pop.type == "Coloniale")
            {
                jetDes = jetDes - pop.modificateurColonie;
            }

            if (planete.mixPopulation == 3)
            {
                jetDes = jetDes - 4;
            }

            // résultat
            if (jetDes < 6)
            {
                pop.categorieHabitant = "Très Basse";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 4) * 100;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 100) * 1000;
                }
            }
            else if (jetDes < 10 && jetDes > 5)
            {
                pop.categorieHabitant = "Basse";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 1000;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 1000000;
                }
            }
            else if (jetDes < 16 && jetDes > 9)
            {
                pop.categorieHabitant = "Moyenne";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 10000;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 100) * 1000000;
                }
            }
            else if (jetDes < 20 && jetDes > 15)
            {
                pop.categorieHabitant = "Forte";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 100000;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 100000000;
                }
            }
            else if (jetDes < 25 && jetDes > 19)
            {
                pop.categorieHabitant = "Très Forte";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 1000000;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 1000000000;
                }
            }
            else if (jetDes > 24)
            {
                pop.categorieHabitant = "Extrèmement Forte";
                if (pop.type == "Coloniale")
                {
                    pop.nbHabitant = jet.JeterD(1, 10) * 100000000;
                }
                else
                {
                    pop.nbHabitant = jet.JeterD(1, 10, 4) * 1000000000;
                }
            }

            //enfin on détermine le taux d'urbanisation de la population
            pop.tauxUrbanisation = jet.JeterD(1, 6, 4);

            return pop;
        }
        // Etape n°32
        public Population DeterminerNiveauTechnologique(Population pop, Planete planete, SystemeStellaire sys)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);

            switch (pop.categorieHabitant)
            {
                case "Très Basse":
                    jetDes = jetDes - 2;
                    break;
                case "Basse":
                    jetDes = jetDes - 1;
                    break;
                case "Forte":
                    jetDes = jetDes + 2;
                    break;
                case "Très Forte":
                    jetDes = jetDes + 4;
                    break;
                case "Extrèmement Forte":
                    jetDes = jetDes + 5;
                    break;
            }

            if (pop.type == "Coloniale")
            {
                jetDes = jetDes + 3;
            }

            if (planete.gravite == "Extrème" ||
                planete.volcanisme == "Extrème" ||
                planete.atmosCompo == "Corrosive" ||
                planete.densiteAtmos == "Vide" ||
                planete.densiteAtmos == "Extrèmement Dense" ||
                planete.densiteBio == "Aucune" ||
                planete.climat == "Chaleur Extrème" ||
                planete.climat == "Froid Extrème")
            {
                jetDes = jetDes + 4;
            }

            // résultat
            if (jetDes == 1)
            {
                pop.niveauTechno = 0;
            }
            else if (jetDes < 4 && jetDes > 1)
            {
                pop.niveauTechno = 1;
            }
            else if (jetDes < 6 && jetDes > 3)
            {
                pop.niveauTechno = 2;
            }
            else if (jetDes < 8 && jetDes > 5)
            {
                pop.niveauTechno = 3;
            }
            else if (jetDes < 10 && jetDes > 7)
            {
                pop.niveauTechno = 4;
            }
            else if (jetDes < 13 && jetDes > 9)
            {
                pop.niveauTechno = 5;
            }
            else if (jetDes < 16 && jetDes > 12)
            {
                pop.niveauTechno = 6;
            }
            else if (jetDes < 20 && jetDes > 15)
            {
                pop.niveauTechno = 7;
            }
            else if (jetDes > 19)
            {
                pop.niveauTechno = 8;
            }


            if (pop.type == "Coloniale") 
            {
                foreach (Population popNativeSysteme in sys.PopulationsNatives)
                {
                    if (pop.nom == popNativeSysteme.nom && pop.niveauTechno > sys.populationColoniale.niveauTechno)
                    {
                        pop.niveauTechno = popNativeSysteme.niveauTechno;
                    }
                }
                if (pop.nom == sys.populationColoniale.nom && pop.niveauTechno > sys.populationColoniale.niveauTechno)
                {
                    pop.niveauTechno = sys.populationColoniale.niveauTechno;
                }
            }

            return pop;
        }
        // Etape n°33
        public Population DeterminerModificateurColonie(Population pop)
        {
            switch (pop.niveauTechno)
            {
                case 7:
                    pop.modificateurColonie = -4;
                    break;
                case 8:
                    pop.modificateurColonie = -3;
                    break;
            }
            return pop;
        }
        // Etape n°34
        public Population DeterminerGouvernement(Population pop, SystemeStellaire sys)
        {
            if (pop.type == "Coloniale")
            {
                foreach (Population popNativeSysteme in sys.PopulationsNatives)
                {
                    if (pop.nom == popNativeSysteme.nom)
                    {
                        pop.participation = popNativeSysteme.participation;
                        pop.diversite = popNativeSysteme.diversite;
                        pop.control = popNativeSysteme.control;
                        pop.soutien = popNativeSysteme.soutien;
                    }
                }
                if (pop.nom == sys.populationColoniale.nom)
                {
                    pop.participation = sys.populationColoniale.participation;
                    pop.diversite = sys.populationColoniale.diversite;
                    pop.control = sys.populationColoniale.control;
                    pop.soutien = sys.populationColoniale.soutien;
                }
            }
            else
            {
                JetDes jet = new JetDes();

                pop.participation = jet.JeterD(1, 10);
                pop.diversite = jet.JeterD(1, 10);
                pop.control = jet.JeterD(1, 10);
                pop.soutien = jet.JeterD(1, 10);
            }
            return pop;
        }
        // Etape n°35
        public Population DeterminerPopulationOrbital(Population pop, Planete planete)
        {
            if (pop.niveauTechno > 5)
            {
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(2, 10);

                // modificateurs au jet de la population orbitale
                switch (pop.niveauTechno)
                {
                    case 6:
                        jetDes = jetDes - 2;
                        break;
                    case 8:
                        jetDes = jetDes + 2;
                        break;
                }

                // résultat pour le colonies majeure et mineure
                if (jetDes < 5)
                {
                    pop.nbColonieMajeure = 0;
                    pop.nbColonieMineure = 0;
                }
                else if (jetDes < 11 && jetDes > 4)
                {
                    pop.nbColonieMajeure = 1;
                    pop.nbColonieMineure = 0;
                    jetDes = jetDes - 1; // on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de base présentes
                }
                else if (jetDes < 18 && jetDes > 10)
                {
                    pop.nbColonieMajeure = jet.JeterD(1, 3);
                    pop.nbColonieMineure = jet.JeterD(2, 3);
                    jetDes = jetDes - 3;// on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de base présentes
                }
                else if (jetDes > 17)
                {
                    pop.nbColonieMajeure = jet.JeterD(1, 4);
                    pop.nbColonieMineure = jet.JeterD(3, 4);
                    jetDes = jetDes - 4;// on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de bases présentes
                }

                // résultat pour les bases à partir du score restant
                int typeBase;
                // on initialise les nombres de bases présentes
                pop.nbBaseMilitaire = 0;
                pop.nbBaseScientifique = 0;
                pop.nbBaseDefensive = 0;
                pop.nbBaseCommerciale = 0;
                for (int i = jetDes; i == 0; i--)//chaque point du score restant représente une base (règle arbitraire car non explicité dans le supplément)
                {
                    typeBase = jet.JeterD(1, 4); // on détermine le type de la base au hazard
                    switch (typeBase)
                    {
                        case 1:
                            pop.nbBaseMilitaire = pop.nbBaseMilitaire + 1;
                            break;
                        case 2:
                            pop.nbBaseScientifique = pop.nbBaseScientifique + 1;
                            break;
                        case 3:
                            pop.nbBaseDefensive = pop.nbBaseDefensive + 1;
                            break;
                        case 4:
                            pop.nbBaseCommerciale = pop.nbBaseCommerciale + 1;
                            break;
                    }
                }

            }
            else // résultat où le niveau technologique de la population est insuffisant pour pouvoir avoir un population orbitale
            {
                pop.nbColonieMajeure = 0;
                pop.nbColonieMineure = 0;
                pop.nbBaseMilitaire = 0;
                pop.nbBaseScientifique = 0;
                pop.nbBaseDefensive = 0;
                pop.nbBaseCommerciale = 0;
            }
            return pop;
        }
        // Etape n°36
        public CeintureAsteroide DeterminerDensiteCeinture(CeintureAsteroide ceinture, Etoile etoile, SystemeStellaire systeme)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);
            int compteurGeanteGazeuse = 0;

            foreach (Etoile star in systeme.Etoiles)
            {
                foreach (Planete planete in star.Planetes)
                {
                    if(planete.type == "Géante Gazeuse")
                    {
                        compteurGeanteGazeuse = compteurGeanteGazeuse + 1;
                    }
                }
            }
            if (compteurGeanteGazeuse > 2)
            {
                jetDes = jetDes - 4;
            }
            else if (compteurGeanteGazeuse < 2)
            {
                jetDes = jetDes + 2;
            }

            //resultat
            if (jetDes < 6)
            {
                ceinture.densite = "Légère";
            }
            else if (jetDes < 16 && jetDes > 5)
            {
                ceinture.densite = "Moyenne";
            }
            else if (jetDes < 19 && jetDes > 15)
            {
                ceinture.densite = "Dense";
            }
            else if (jetDes > 18)
            {
                ceinture.densite = "Très Dense";
            }

            return ceinture;
        }
        // Etape n°37
        public CeintureAsteroide DeterminerNbAsteroidesMajeurs(CeintureAsteroide ceinture)
        {
            JetDes jet = new JetDes();
            int nbAsteroid = jet.JeterD();

            switch (ceinture.densite)
            {
                case "Légère":
                    nbAsteroid = nbAsteroid - 3;
                    break;
                case "Moyenne":
                    nbAsteroid = nbAsteroid - 1;
                    break;
                case "Dense":
                    nbAsteroid = nbAsteroid + 2;
                    break;
                case "Très Dense":
                    nbAsteroid = nbAsteroid + 6;
                    break;
            }
            for (int i = 0; i < nbAsteroid; i++)
            {
                ceinture.Asteroides.Add(new AsteroideMajeur());
            }
            return ceinture;
        }
        // Etape n°38
        public AsteroideMajeur DeterminerTailleAsteroide(AsteroideMajeur asteroide, CeintureAsteroide ceinture)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1, 20);

            // modificateurs au jet de la taille de l'asteroid Majeur
            switch (ceinture.densite)
            {
                case "Légère":
                    jetDes = jetDes - 2;
                    break;
                case "Dense":
                    jetDes = jetDes + 1;
                    break;
                case "Très Dense":
                    jetDes = jetDes + 2;
                    break;
            }

            //résultat
            if (jetDes < 11)
            {
                asteroide.taille = 20 + jet.JeterD(2, 10);
            }
            else if (jetDes < 19 && jetDes > 10)
            {
                asteroide.taille = 100 + (jet.JeterD(1, 10) * 10);
            }
            else if (jetDes > 18)
            {
                asteroide.taille = jet.JeterD(2, 4) * 100;
            }

            return asteroide;
        }
        // Etape n°39
        public SystemeStellaire DeterminerNomsPopulationsNatives(SystemeStellaire systeme)
        {
            int compteurNomPopulation = 0;
            for (int i = 0; i < systeme.Etoiles.Count; i++)
            {
                for (int j = 0; j < systeme.Etoiles[i].Planetes.Count; j++)
                {
                    for (int k = 0; k < systeme.Etoiles[i].Planetes[j].Populations.Count; k++)
                    {
                        if (systeme.Etoiles[i].Planetes[j].Populations[k].type != "Coloniale")
                        {
                            systeme.Etoiles[i].Planetes[j].Populations[k].nom = "Population n°" + compteurNomPopulation + 1;
                        }
                    }
                    for (int k = 0; k < systeme.Etoiles[i].Planetes[j].Satellites.Count; k++)
                    {
                        for (int l = 0; l < systeme.Etoiles[i].Planetes[j].Satellites[k].Populations.Count; l++)
                        {
                            if (systeme.Etoiles[i].Planetes[j].Satellites[k].Populations[l].type != "Coloniale")
                            {
                                systeme.Etoiles[i].Planetes[j].Satellites[k].Populations[l].nom = "Population n°" + compteurNomPopulation + 1;
                            }
                        }
                    }
                }
            }
            return systeme;
        }
        // Etape n°40
        public SystemeStellaire DeterminerColonisationCeintureAsteroide(SystemeStellaire systeme)
        {
            foreach (Etoile etoile in systeme.Etoiles)
            {
                foreach (CeintureAsteroide ceinture in etoile.Ceintures)
                {
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(1, 10);
                    // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                    jetDes = jetDes + systeme.populationColoniale.modificateurColonie;

                    // resultat
                    if (jetDes > 6) // suffisament intéressant pour être colonisé
                    {
                        ceinture.population = new Population(systeme.populationColoniale.nom, "Coloniale", systeme.populationColoniale.niveauTechno, 1,
                                                                                                           systeme.populationColoniale.participation,
                                                                                                           systeme.populationColoniale.diversite,
                                                                                                           systeme.populationColoniale.control,
                                                                                                           systeme.populationColoniale.soutien);
                    }
                }
            }
            return systeme;
        }
        // Etape n°40
        public SystemeStellaire DeterminerConquete(SystemeStellaire systeme)
        {
            JetDes jet = new JetDes();

            // nettoyage des espèce ayant réalisé une colonisation intra-système
            if (systeme.PopulationsNatives.Count != 0)
            {
                systeme.PopulationsNatives.Clear();
            }

            foreach (Etoile etoile in systeme.Etoiles)
            {
                foreach (Planete planete in etoile.Planetes)
                {
                    foreach (Population pop in planete.Populations)
                    {
                        if (pop.type == "Coloniale" && pop.nom != systeme.populationColoniale.nom)
                        {
                            planete.Populations.Remove(pop);
                        }
                        foreach (Planete satellite in planete.Satellites)
                        {
                            if (pop.type == "Coloniale" && pop.nom != systeme.populationColoniale.nom)
                            {
                                planete.Populations.Remove(pop);
                            }
                        }
                    }
                }
            }

            // ajout de population native intelligente dans la course à la colonisation du système
            foreach (Etoile etoile in systeme.Etoiles)
            {
                foreach (Planete planete in etoile.Planetes)
                {
                    foreach (Population pop in planete.Populations)
                    {
                        if (pop.niveauTechno == 6 || pop.niveauTechno == 7 || pop.niveauTechno == 8)
                        {
                            systeme.PopulationsNatives.Add(pop);
                        }
                        foreach (Planete satellite in planete.Satellites)
                        {
                            if (pop.niveauTechno == 6 || pop.niveauTechno == 7 || pop.niveauTechno == 8)
                            {
                                systeme.PopulationsNatives.Add(pop);
                            }
                        }
                    }
                }
            }

            //répartition dans le système des différentes espèces coloniales intra-système
            foreach (Population pop in systeme.PopulationsNatives)
            {
                int nbColonie = 0;
                switch (pop.niveauTechno)
                {
                    case 6:
                        nbColonie = jet.JeterD(1, 2, -1);
                        break;
                    case 7:
                        nbColonie = jet.JeterD(1, 3, -1);
                        break;
                    case 8:
                        nbColonie = jet.JeterD(1, 4, -1);
                        break;
                }

                foreach (Etoile etoile in systeme.Etoiles)
                {
                    if (nbColonie != 0)
                    {
                        foreach (CeintureAsteroide ceinture in etoile.Ceintures)
                        {
                            if (nbColonie != 0 && ceinture.population.type == "")
                            {
                                int jetDes = jet.JeterD(1, 10);
                                // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                                jetDes = jetDes + pop.modificateurColonie;

                                // resultat
                                if (jetDes > 5) // suffisament intéressant pour être colonisé
                                {
                                    ceinture.population = new Population(pop.nom, "Coloniale", pop.niveauTechno, 2,
                                                                                                pop.participation,
                                                                                                pop.diversite,
                                                                                                pop.control,
                                                                                                pop.soutien);
                                    nbColonie = nbColonie - 1;
                                }
                            }
                        }
                    }

                    if (nbColonie != 0)
                    {
                        foreach (Planete planete in etoile.Planetes)
                        {
                            if (nbColonie != 0)
                            {
                                int jetDes = jet.JeterD(1, 10);
                                // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                                jetDes = jetDes + pop.modificateurColonie;

                                switch (planete.complexiteBio) // quelle est la complexité de la biosphère
                                {
                                    case "Très Simple":
                                        jetDes = jetDes - 2;
                                        break;
                                    case "Simple":
                                        jetDes = jetDes - 1;
                                        break;
                                    case "Modérée":
                                        jetDes = jetDes + 1;
                                        break;
                                    case "Avancée":
                                        jetDes = jetDes + 1;
                                        break;
                                    case "Très Avancée":
                                        jetDes = jetDes + 2;
                                        break;
                                    case "Intelligence Native":
                                        jetDes = jetDes - 1;
                                        break;
                                }
                                if (planete.volcanisme == "Extrème") // le volcanisme est il supportable
                                {
                                    jetDes = jetDes - 2;
                                }
                                switch (planete.atmosCompo) // quelles sont les conditions atmosphériques
                                {
                                    case "Respirable":
                                        jetDes = jetDes + 1;
                                        break;
                                    default:
                                        jetDes = jetDes - 1;
                                        break;
                                }
                                if (planete.artefactAncien) // y a t'il un artefact des anciens
                                {
                                    jetDes = jetDes + 6;
                                }

                                // resultat
                                if (jetDes > 7) // suffisament intéressant pour être colonisé
                                {
                                    if (planete.mixPopulation == 0)  // il n'y a pas de forme de vie suffisamment avancée présente
                                    {
                                        planete.Populations.Add(new Population(pop.nom, "Coloniale", pop.niveauTechno,
                                                                                                      pop.modificateurColonie,
                                                                                                      pop.participation,
                                                                                                      pop.diversite,
                                                                                                      pop.control,
                                                                                                      pop.soutien));
                                        planete.mixPopulation = 2;
                                        nbColonie = nbColonie - 1;
                                    }
                                    else if (planete.mixPopulation == 1) // il y a quand même une forme de vie suffisamment avancée présente
                                    {
                                        planete.Populations.Add(new Population(pop.nom, "Coloniale", pop.niveauTechno,
                                                                                                       pop.modificateurColonie,
                                                                                                       pop.participation,
                                                                                                       pop.diversite,
                                                                                                       pop.control,
                                                                                                       pop.soutien));
                                        planete.mixPopulation = 3;
                                        nbColonie = nbColonie - 1;
                                    }
                                }
                            }

                            if (nbColonie != 0)
                            {
                                foreach (Planete satellite in planete.Satellites)
                                {
                                    if (nbColonie != 0)
                                    {
                                        int jetDes = jet.JeterD(1, 10);
                                        // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                                        jetDes = jetDes + pop.modificateurColonie;

                                        switch (satellite.complexiteBio) // quelle est la complexité de la biosphère
                                        {
                                            case "Très Simple":
                                                jetDes = jetDes - 2;
                                                break;
                                            case "Simple":
                                                jetDes = jetDes - 1;
                                                break;
                                            case "Modérée":
                                                jetDes = jetDes + 1;
                                                break;
                                            case "Avancée":
                                                jetDes = jetDes + 1;
                                                break;
                                            case "Très Avancée":
                                                jetDes = jetDes + 2;
                                                break;
                                            case "Intelligence Native":
                                                jetDes = jetDes - 1;
                                                break;
                                        }
                                        if (satellite.volcanisme == "Extrème") // le volcanisme est il supportable
                                        {
                                            jetDes = jetDes - 2;
                                        }
                                        switch (satellite.atmosCompo) // quelles sont les conditions atmosphériques
                                        {
                                            case "Respirable":
                                                jetDes = jetDes + 1;
                                                break;
                                            default:
                                                jetDes = jetDes - 1;
                                                break;
                                        }
                                        if (satellite.artefactAncien) // y a t'il un artefact des anciens
                                        {
                                            jetDes = jetDes + 6;
                                        }

                                        // resultat
                                        if (jetDes > 7) // pas suffisament intéressant pour être colonisé
                                        {
                                            if (satellite.mixPopulation == 0)  // il n'y a pas de forme de vie suffisamment avancée présente
                                            {
                                                satellite.Populations.Add(new Population(pop.nom, "Coloniale", pop.niveauTechno,
                                                                                                      pop.modificateurColonie,
                                                                                                      pop.participation,
                                                                                                      pop.diversite,
                                                                                                      pop.control,
                                                                                                      pop.soutien));
                                                satellite.mixPopulation = 2;
                                                nbColonie = nbColonie - 1;
                                            }
                                            else if (satellite.mixPopulation == 1)// il y a quand même une forme de vie suffisamment avancée présente
                                            {
                                                satellite.Populations.Add(new Population(pop.nom, "Coloniale", pop.niveauTechno,
                                                                                                      pop.modificateurColonie,
                                                                                                      pop.participation,
                                                                                                      pop.diversite,
                                                                                                      pop.control,
                                                                                                      pop.soutien));
                                                satellite.mixPopulation = 3;
                                                nbColonie = nbColonie - 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return systeme;
        }
        // Etape n°41
        public CeintureAsteroide DeterminerRegressionTechnologique(CeintureAsteroide ceinture)
        {
            JetDes jet = new JetDes();
            switch(ceinture.population.niveauTechno)
            {
                case 6:
                    ceinture.population.niveauTechno = ceinture.population.niveauTechno - jet.JeterD(1, 2, -1);
                    break;
                case 7:
                    ceinture.population.niveauTechno = ceinture.population.niveauTechno - jet.JeterD(1, 3, -1);
                    break;
                case 8:
                    ceinture.population.niveauTechno = ceinture.population.niveauTechno - jet.JeterD(1, 4, -1);
                    break;
            }
            return ceinture;
        }
        // Etape n°42
        public CeintureAsteroide DeterminerPopulationCeintureAsteroides(CeintureAsteroide ceinture)
        {
            JetDes jet = new JetDes();
            int jetDes = jet.JeterD(1,20);

            //modificateur selon la densité de la ceinture d'astéroïdes
            switch(ceinture.densite)
            {
                case "Légère":
                    jetDes = jetDes - 3;
                    break;
                case "Dense":
                    jetDes = jetDes + 1;
                    break;
                case "Très Dense":
                    jetDes = jetDes + 2;
                    break;
            }
            //modificateur selon le niveau technologique de la population de la ceinture d'astéroïdes
            switch(ceinture.population.niveauTechno)
            {
                case 5:
                    jetDes = jetDes - 5;
                    break;
                case 6:
                    jetDes = jetDes - 1;
                    break;
                case 7:
                    jetDes = jetDes + 1;
                    break;
                case 8:
                    jetDes = jetDes + 3;
                    break;
            }
            //modification selon l'origine de la population de la ceinture d'astéroïde
            jetDes = jetDes + ceinture.population.modificateurColonie;

            //résultat
            if(jetDes < 1)
            {
                ceinture.population.nbHabitant = 0;
            }
            else if (jetDes < 6 && jetDes > 0)
            {
                ceinture.population.nbHabitant = jet.JeterD(1,4) * 100;
            }
            else if (jetDes < 11 && jetDes > 5)
            {
                ceinture.population.nbHabitant = jet.JeterD(1, 4) * 1000;
            }
            else if (jetDes < 16 && jetDes > 10)
            {
                ceinture.population.nbHabitant = jet.JeterD(1, 10, 10) * 1000;
            }
            else if (jetDes < 20 && jetDes > 15)
            {
                ceinture.population.nbHabitant = jet.JeterD(1, 20, 50) * 1000;
            }
            else if (jetDes > 19)
            {
                ceinture.population.nbHabitant = jet.JeterD(1, 10) * 10000 ;
            }

            jetDes = jet.JeterD(1, 100);
            if (jetDes < 31 && ceinture.population.modificateurColonie == 2)
            {
                ceinture.population.nbHabitant = ceinture.population.nbHabitant * 10;
            }
             
            return ceinture;
        }
        // Etape n°43
        // Etape n°44
        // Etape n°45
        // Etape n°46
        
        #endregion

        #region Parties Génération Système Stellaire
        // Partie n°0
        public SystemeStellaire partie0(SystemeStellaire sys)
        {
            sys = DeterminerNbEtoiles(sys);
            for (int i = 0; i < sys.Etoiles.Count ; i++)
            {
                sys.Etoiles[i] = Determinertypetoile(sys.Etoiles[i]);
                sys.Etoiles[i] = Determinertailletoile(sys.Etoiles[i]);
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
            for (int i = 0; i < sys.Etoiles.Count; i++)
			{
			    for (int j = 0; j < sys.Etoiles[i].Planetes.Count; j++)
			    {
                    sys.Etoiles[i].Planetes[j] = DeterminerGravitePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerDensiteAtmospheriquePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerCompositionAtmospherePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerPollutionPlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerGeologiePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerVolcanismePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerHydrospherePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerGeographiePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerClimatPlanete(sys.Etoiles[i].Planetes[j], sys.Etoiles[i]);
                    sys.Etoiles[i].Planetes[j] = DeterminerTempPolePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerBiospherePlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerArtefactPlanete(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerPopulations(sys.Etoiles[i].Planetes[j], sys);
                    sys.Etoiles[i].Planetes[j] = DeterminerNbLunes(sys.Etoiles[i].Planetes[j]);
                    sys.Etoiles[i].Planetes[j] = DeterminerNbMoonlets(sys.Etoiles[i].Planetes[j]);
			    }
			}
            return sys;
        }
        // Partie n°4
        public SystemeStellaire partie4(SystemeStellaire sys)
        {
            for (int i = 0; i < sys.Etoiles.Count; i++)
            {
                for (int j = 0; j < sys.Etoiles[i].Planetes.Count; j++)
                {
                    for (int k = 0; k < sys.Etoiles[i].Planetes[j].Satellites.Count; k++)
                    {
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerTypeSatellite(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerTailleSatellite(sys.Etoiles[i].Planetes[j], sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerGravitePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerDensiteAtmospheriquePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerCompositionAtmospherePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerPollutionPlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerGeologiePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerVolcanismePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerHydrospherePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerGeographiePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerClimatPlanete(sys.Etoiles[i].Planetes[j].Satellites[k], sys.Etoiles[i]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerTempPolePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerBiospherePlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerArtefactPlanete(sys.Etoiles[i].Planetes[j].Satellites[k]);
                        sys.Etoiles[i].Planetes[j].Satellites[k] = DeterminerPopulations(sys.Etoiles[i].Planetes[j].Satellites[k], sys);
                    }
                }
            }
            return sys;
        }
        // Partie n°5
        public SystemeStellaire partie5(SystemeStellaire sys)
        {
            for (int i = 0; i < sys.Etoiles.Count; i++)
            {
                for (int j = 0; j < sys.Etoiles[i].Planetes.Count; j++)
                {
                    for (int k = 0; k < sys.Etoiles[i].Planetes[j].Populations.Count; k++)
                    {
                        sys.Etoiles[i].Planetes[j].Populations[k] = DeterminerNbHabitants(sys.Etoiles[i].Planetes[j].Populations[k], sys.Etoiles[i].Planetes[j]);
                        sys.Etoiles[i].Planetes[j].Populations[k] = DeterminerNiveauTechnologique(sys.Etoiles[i].Planetes[j].Populations[k], sys.Etoiles[i].Planetes[j], sys);
                        sys.Etoiles[i].Planetes[j].Populations[k] = DeterminerGouvernement(sys.Etoiles[i].Planetes[j].Populations[k], sys);
                        sys.Etoiles[i].Planetes[j].Populations[k] = DeterminerPopulationOrbital(sys.Etoiles[i].Planetes[j].Populations[k], sys.Etoiles[i].Planetes[j]);
                    }
                    for (int k = 0; k < sys.Etoiles[i].Planetes[j].Satellites.Count; k++)
                    {
                        for (int l = 0; l < sys.Etoiles[i].Planetes[j].Satellites[k].Populations.Count; l++)
                        {
                            sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l] = DeterminerNbHabitants(sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l], sys.Etoiles[i].Planetes[j].Satellites[k]);
                            sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l] = DeterminerNiveauTechnologique(sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l], sys.Etoiles[i].Planetes[j].Satellites[k], sys);
                            sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l] = DeterminerGouvernement(sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l], sys);
                            sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l] = DeterminerPopulationOrbital(sys.Etoiles[i].Planetes[j].Satellites[k].Populations[l], sys.Etoiles[i].Planetes[j].Satellites[k]);
                        }
                    }
                }
            }
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
        #endregion

        #region Méthodes Générateur
        public SystemeStellaire Generation()
        {
            SystemeStellaire systeme = new SystemeStellaire();
            systeme = ExecuterPartie(0, systeme);
            systeme = ExecuterPartie(1, systeme);
            systeme = ExecuterPartie(2, systeme);
            systeme = ExecuterPartie(3, systeme);
            systeme = ExecuterPartie(4, systeme);
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
                case 3:
                    sys = partie3(sys);
                    break;
                case 4:
                    sys = partie4(sys);
                    break;
                case 5:
                    sys = partie5(sys);
                    break;
                case 6:
                    sys = partie6(sys);
                    break;
                case 7:
                    sys = partie7(sys);
                    break;
                case 8:
                    sys = partie8(sys);
                    break;
            }
            return sys;
        }
        #endregion
    }
}
