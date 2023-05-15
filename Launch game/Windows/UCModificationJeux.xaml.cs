using Classe;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;
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
            Chargement_Page();
        }

        private void Chargement_Page()
        {
            Jeux JeuxChoisi = (App.Current as App).LeManager.ListeJeux.ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi];
            NomJeux.Text = JeuxChoisi.Nom;
            TextBlock_category.Text = JeuxChoisi.EcrireCategory();

            for (int i = 0; i < JeuxChoisi.ListCategory.Count; i++)
            {
                if (JeuxChoisi.ListCategory[i].Equals(Category.Multi))
                {
                    Button_Multi.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.Survival))
                {
                    Button_Survival.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.Solo))
                {
                    Button_Solo.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.Conduite))
                {
                    Button_Conduite.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.FPS))
                {
                    Button_FPS.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.Histoire))
                {
                    Button_Histoire.Background = Brushes.Blue;
                }
                else if (JeuxChoisi.ListCategory[i].Equals(Category.Fun))
                {
                    Button_Fun.Background = Brushes.Blue;
                }

            }
        }

        #region "Ajout category"

        private void Ajouter_multi_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Multi);
            Chargement_Page();
        }
        private void Ajouter_solo_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Solo);
            Chargement_Page();
        }

        private void Ajouter_fun_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Fun);
            Chargement_Page();
        }

        private void Ajouter_histoire_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Histoire);
            Chargement_Page();
        }

        private void Ajouter_fps_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.FPS);
            Chargement_Page();
        }

        private void Ajouter_conduite_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Conduite);
            Chargement_Page();
        }

        private void Ajouter_survival_Click(object sender, RoutedEventArgs e)
        {
            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux.ListeJeux;

            ListeJeux[(App.Current as App).LeManager.IndexJeuxChoisi].AjouterCategory(Category.Survival);
            Chargement_Page();
        }
        #endregion

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
