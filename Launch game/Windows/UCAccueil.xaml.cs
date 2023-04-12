using Classe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
    /// Logique d'interaction pour UCAccueil.xaml
    /// </summary>
    public partial class UCAccueil : UserControl
    {
        public UCAccueil()
        {
            InitializeComponent();
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.ListeJeux;
            CompteurJeux.Text = (App.Current as App).LeManager.ListeJeux.Count().ToString();
 
        }
        private void Lol_Click(object sender, RoutedEventArgs e)
        {
            /*
            Process Lol = new Process();
            Lol.StartInfo.FileName = "C:/Riot Games/Riot Client/RiotClientServices.exe";
            Lol.StartInfo.Arguments = "--launch-product=league_of_legends"+"--launch-patchline=live";
            Lol.Start();
            */
            Process Proc = new Process();
            Proc.StartInfo.FileName = "C:/Program Files (x86)/Steam/steam.exe";
            Proc.StartInfo.Arguments = "steam://rungameid/361420";
            Proc.Start();

        }
        private void ListeJeux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                String JeuxChoisi = (e.AddedItems[0] as Jeux).Nom;
                List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;
                
                if (ListeJeux.Count != 0)
                {
                    int d = 0;
                    while (ListeJeux[d].Nom != JeuxChoisi)
                    {
                        d++;
                    }
                    (App.Current as App).LeManager.IndexJeuxChoisi = d;
                    BoutonLol.Text = ListeJeux[d].Chemin;
                    TextboxRename.Text = ListeJeux[d].Nom;
                    TextBlock_category.Text = ListeJeux[d].EcrireCategory();
                }               
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ListJeux ListeJeux = (App.Current as App).LeManager.ListeJeux;

            ListeJeux.SuppressionJeux((App.Current as App).LeManager.IndexJeuxChoisi);

            (App.Current as App).LeManager.ListeJeux = ListeJeux;

            ListeJeuxVue.ItemsSource = null;
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.ListeJeux;

        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            ListJeux ListeJeux = (App.Current as App).LeManager.ListeJeux;
            String NouveauNom = TextboxRename.Text;

            ListeJeux.RenameJeux(NouveauNom, (App.Current as App).LeManager.IndexJeuxChoisi);
            ListeJeuxVue.ItemsSource = null;
            ListeJeuxVue.ItemsSource = ListeJeux.ListeJeux;


        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].Launch();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeManager.SauvegardeDonnees();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeManager.ListeJeux.Clear();
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.PARAMETRE;
            (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
        }      

        private void TextBoxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.Recherche(TextBoxRecherche.Text);
        }

        #region "Ajout category"

        private void Ajouter_multi_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Multi);
        }
        private void Ajouter_solo_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Solo);
        }       

        private void Ajouter_fun_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Fun);
        }

        private void Ajouter_histoire_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Histoire);
        }

        private void Ajouter_fps_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.FPS);
        }

        private void Ajouter_conduite_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Conduite);
        }

        private void Ajouter_survival_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Survival);
        }
# endregion

        #region "Filtre"
        private void Filtre_all_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.ListeJeux;
        }

        private void Filtre_multi_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Multi);
        }
        private void Filtre_solo_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Solo);
        }

        private void Filtre_fun_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Fun);
        }

        private void Filtre_histoire_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Histoire);
        }

        private void Filtre_fps_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.FPS);
        }

        private void Filtre_conduite_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Conduite);
        }

        private void Filtre_survival_Click(object sender, RoutedEventArgs e)
        {
            ListeJeuxVue.ItemsSource = (App.Current as App).LeManager.ListeJeux.FiltreCategory(Category.Survival);
        }

        # endregion
    }
}
