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

        public List<string> listeEtapes = new List<string>();

        #endregion

        #region Etapes Génération
        // Etape n°1 : déterminer les étoiles
        public SystemeStellaire DeterminerEtoile(SystemeStellaire sys)
        {
            if (sys.Etoiles.Count != 0)
            {
                sys.Etoiles.Clear();
            }
            int jetDes = (new JetDes()).JeterD(2, 10);
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


            foreach(Etoile etoile in sys.Etoiles)
            {
                //on détermine le type
                jetDes = (new JetDes()).JeterD(1, 100);
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
                // on détermine la taille
                jetDes = (new JetDes()).JeterD(1, 100);
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
                // on détermine la qualification du type
                etoile.qualificationType = new JetDes().JeterD(1, 10).ToString();
            }
            return sys;
        }
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        // Etape n°0
        #endregion

        #region Méthodes Générateur
        public void Generation()
        {

        }


        public void executerEtape(int numEtape)
        {
            switch (numEtape)
            {
                case 0:
                    break;
            }
        }
        #endregion
    }
}
