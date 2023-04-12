using Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace Launch_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager LeManager => (App.Current as App).LeManager;

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = (App.Current as App).LeNavigateur;
        }

        private void Param_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.PARAMETRE;
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
        }
        private void RefreshAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < (App.Current as App).LeManager.ListeSource.Count(); i++)
            {
                ListJeux ListeJeux = (App.Current as App).LeManager.ListeJeux;

                String Source = (App.Current as App).LeManager.ListeSource[i].CheminDossier;

                if (!(Source == ""))
                {
                    Source.Replace("\\", "");
                    string[] files = Directory.GetFiles((App.Current as App).LeManager.ListeSource[i].CheminDossier, "*.exe", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        ListeJeux.AjoutJeux(file);
                    }
                    (App.Current as App).LeManager.ListeJeux = ListeJeux;
                    (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.PARAMETRE;
                    (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
                }
            }
            
        }
    }
}
