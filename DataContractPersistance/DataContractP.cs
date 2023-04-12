using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Classe;

namespace DataContractPersistance
{
    public class DataContractP : IPersistanceManager
    {
        public string CheminFichier { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "XML");

        public string NomFichier { get; set; } = "LaunchGames.xml";

        public (ListJeux, List<Source>) ChargerDonnees()
        {
            
            if (!File.Exists(Path.Combine(CheminFichier, NomFichier)))
            {
                throw new FileNotFoundException("The persistance file is missing.");
            }
            var serializer = new DataContractSerializer(typeof(DataPers),
                new DataContractSerializerSettings()
                {
                    PreserveObjectReferences = true
                });

            DataPers data;
            using (Stream stream = File.OpenRead(Path.Combine(CheminFichier, NomFichier)))
            {
                data = serializer.ReadObject(stream) as DataPers;
            }

            return (data.Jeux, data.Source) ;
            /*
            List<Jeux> Jeux = new List<Jeux>();
            Jeux.Add(new Jeux("C:/Riot Games/Riot Client/", "Riot Launcher"));
            return Jeux;*/
        }

        public void SauvegardeDonnees(ListJeux jeux,List<Source> sources)
        {
            var serializer = new DataContractSerializer(typeof(DataPers),
                new DataContractSerializerSettings()
                {
                    PreserveObjectReferences = true
                });

            if (!Directory.Exists(CheminFichier))
            {
                Directory.CreateDirectory(CheminFichier);
            }

            DataPers data = new DataPers();
            data.Jeux = jeux;
            data.Source = sources;

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter textWriter = File.CreateText(Path.Combine(CheminFichier, NomFichier)))
            {
                using (XmlWriter writer = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(writer, data);
                }
            }

        }
    }
}
