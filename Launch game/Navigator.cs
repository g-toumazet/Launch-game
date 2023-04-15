using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Launch_game
{
    /// <summary>
    /// Permet de naviguer entre les differents UC
    /// </summary>
    public class Navigator : INotifyPropertyChanged
    {
        /// <summary>
        /// Etat qu'on va associer à chaque UC
        /// </summary>
        public enum Etat
        {
            ACCUEIL,
            PARAMETRE,
            MODIFICATIONJEUX
        }

        /// <summary>
        /// Nom de la fenetre choisie
        /// </summary>
        public String FenetreChoisi { get; set; }


        /// <summary>
        /// Fixe l'état prédeterminé comme ACCEUIL, qui correspond à UCVide
        /// </summary>
        private Etat EtatActuel = Etat.ACCUEIL;

        /// <summary>
        /// Permet de changer l'état actuel
        /// </summary>
        public Etat Etatactuel
        {
            get => EtatActuel;
            set
            {
                if (value != EtatActuel)
                {
                    EtatActuel = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Permet de changer la propriété
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Change la propriété
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
