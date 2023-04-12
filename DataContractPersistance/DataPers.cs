using Classe;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataContractPersistance
{
    /// <summary>
    /// Définit un type qui permet de faire la gestion des données en utilisant un seul fichier
    /// </summary>
    [DataContract]
    class DataPers
    {
        /// <summary>
        /// Liste des regions
        /// </summary>
        [DataMember]
        public ListJeux Jeux { get; set; } = new ListJeux();

        [DataMember]
        public List<Source> Source { get; set; } = new List<Source>();

    }
}
