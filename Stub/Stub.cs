using Classe;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Chemin du dossier qui va permettre de charger ou sauvegarder des données
        /// </summary>
        public string CheminFichier { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "XML");

        /// <summary>
        /// Nom du fichier où les données vont être sauvegardées
        /// </summary>
        public string NomFichier { get; set; } = "LaunchGames.xml";

        public (ListJeux,List<Source>) ChargerDonnees()
        {
            ListJeux Jeux = new ListJeux();
            Jeux.AjoutJeux("C:/Riot Games/Riot Client/");
              //  Add(new Jeux("C:/Riot Games/Riot Client/", "Riot Launcher"));

            List<Source> Source = new List<Source>();
            Source.Add(new Source("D:/SteamLibrary", "SteamLibrary"));
            return (Jeux,Source);
        }

        public void SauvegardeDonnees(ListJeux Jeux,List<Source> Source)
        {
            Console.WriteLine("Sauvegarde demandée");
        }
    }
}
