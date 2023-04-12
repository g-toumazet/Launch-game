using Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Classe
{

    [DataContract]
    public class ListJeux
    {
        public ListJeux()
        {
            ListeJeux = new List<Jeux>();
        }

        [DataMember]

        public List<Jeux> ListeJeux { get; set; }
        private List<Jeux> listeJeux;


        public void AjoutJeux(string file)
        {
            string NomJeux = file;
            Jeux preJeux = new Jeux(file, NomJeux);
            if (preJeux.JeuxValide())
            {
                preJeux.MiseEnFormeNom();
                if (this.ListeJeux.Count == 0  || !this.JeuxDansListe(preJeux))
                {
                    this.ListeJeux.Add(preJeux);
                }
            }
        }

        private bool JeuxDansListe(Jeux NvJeux)
        {
            for ( int i =0; i < this.ListeJeux.Count; i++)
            {
                if (NvJeux.Chemin == this.ListeJeux[i].Chemin)           // si Nom et Chemin identique  NvJeux.Nom == this.ListeJeux[i].Nom &&
                {
                    return true;
                }
                else if (NvJeux.Nom == this.ListeJeux[i].Nom && NvJeux.Chemin != this.ListeJeux[i].Chemin)      // si Nom identique mais Chemin différent
                {
                    NvJeux.Nom += "(1)";
                }
            }
            return false;

        }

        public void Clear()
        {
            this.ListeJeux = new List<Jeux>();
        }

        public void RenameJeux(string NouveauNom,int indexJeux)
        {
            if (NouveauNom != "")
            {
                Jeux jeuxAModif = this.ListeJeux[indexJeux];
                jeuxAModif.Nom = NouveauNom;
                this.ListeJeux[indexJeux] = jeuxAModif;
            }
        }

        public void SuppressionJeux(int index)
        {
            this.ListeJeux.Remove(ListeJeux[index]);
        }
        
        public int Count()
        {
            return ListeJeux.Count();
        }

        public List<Jeux> Recherche(string nom)
        {
            List<Jeux> newListeRecherche = new List<Jeux>();
            for (int i = 0; i < ListeJeux.Count; i++)
            {
                if (ListeJeux[i].Nom.ToLower().Contains(nom.ToLower()))
                {
                    newListeRecherche.Add(ListeJeux[i]);
                }
            }
            return newListeRecherche;

        }

        public List<Jeux> FiltreCategory(Category category)
        {
            List<Jeux> newListeFiltre = new List<Jeux>();
            for (int i = 0; i < ListeJeux.Count; i++)
            {
                if (!(ListeJeux[i].ListCategory == null) && ListeJeux[i].ListCategory.Contains(category) )
                {
                    newListeFiltre.Add(ListeJeux[i]);
                }
            }
            return newListeFiltre;
        }

    }
}
