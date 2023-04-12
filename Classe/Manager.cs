using System.Collections.Generic;

namespace Classe
{
    public class Manager
    {
        public ListJeux ListeJeux = new ListJeux();

        public List<Source> ListeSource = new List<Source>();

        public int IndexJeuxChoisi;


        public int IndexSourceChoisi;
        
        public IPersistanceManager Persistance { get; set; }


        public void ChargerDonnees()
        {            
            var donnees = Persistance.ChargerDonnees();
            ListeJeux = donnees.Jeux;
            //ListeJeux = new ListJeux();
            ListeSource = donnees.Source;
        }

        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(ListeJeux,ListeSource);
        }

        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
            ChargerDonnees();
            SauvegardeDonnees();
        }

    }
}
