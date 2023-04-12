using System.Collections.Generic;

namespace Classe
{
    public interface IPersistanceManager
    {
        (ListJeux Jeux,List<Source> Source) ChargerDonnees();

        void SauvegardeDonnees(ListJeux Jeux, List<Source> Source);
    }
}