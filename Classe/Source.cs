using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Classe
{
    [DataContract]
    public class Source
    {
        public Source(string cheminDossier, string nomSource)
        {
            CheminDossier = cheminDossier;
            NomSource = nomSource;
        }

        [DataMember]
        public string CheminDossier { get; set; }
        private string cheminDossier;
        [DataMember]
        public string NomSource { get; set; }
        private string nomSource;

    }
}
