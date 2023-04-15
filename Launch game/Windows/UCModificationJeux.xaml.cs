using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launch_game.Windows
{
    /// <summary>
    /// Logique d'interaction pour UCModificationJeux.xaml
    /// </summary>
    public partial class UCModificationJeux : UserControl
    {
        public UCModificationJeux()
        {
            InitializeComponent();
            NomJeux.Text = (App.Current as App).LeManager.ListeJeux.ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].Nom;
        }

        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
        }
    }
}
