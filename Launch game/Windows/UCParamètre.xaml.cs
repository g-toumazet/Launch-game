using Classe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launch_game.Windows
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class UCParametre : System.Windows.Controls.UserControl
    {
        private string filename;
        public UCParametre()
        {
            InitializeComponent();
            ListeSourceVue.ItemsSource = (App.Current as App).LeManager.ListeSource;
        }
        private void ListeSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                String SourceChoisi = (e.AddedItems[0] as Source).NomSource;
                List<Source> ListeSource = (App.Current as App).LeManager.ListeSource;
                int d = 0;
                while (ListeSource[d].NomSource != SourceChoisi)
                {
                    d++;
                }
                (App.Current as App).LeManager.IndexSourceChoisi = d;
            }
        }

        private void AjouterSource_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).LeManager.ListeSource.Add(new Source(CheminSource_Textbox.Text, NomSource_Textbox.Text));
            if (NomSource_Textbox.Text != "" && NomSource_Textbox.Text != "Nom Source" && NomSource_Textbox.Text != "A remplir")
            {
                AjoutJeu(CheminSource_Textbox.Text);
            }
            else
            {
                NomSource_Textbox.Text = "A remplir";
                NomSource_Textbox.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
            }     
        }


        private void SupprimerSource_Click(object sender, RoutedEventArgs e)
        {
            List<Source> ListeSource = (App.Current as App).LeManager.ListeSource;
            ListeSource.Remove(ListeSource[(App.Current as App).LeManager.IndexSourceChoisi]);
            (App.Current as App).LeManager.ListeSource = ListeSource;
            ListeSourceVue.ItemsSource = null;
            ListeSourceVue.ItemsSource = (App.Current as App).LeManager.ListeSource;
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Source SourceChoisi = (App.Current as App).LeManager.ListeSource[(App.Current as App).LeManager.IndexSourceChoisi];
            AjoutJeu(SourceChoisi.CheminDossier);
        }
        private void AjoutJeu(string CheminDossier)
        {
            ListJeux ListeJeux = (App.Current as App).LeManager.ListeJeux;
            String Source = CheminDossier;

            if (Source == "")
            { }
            else
            {
                Source.Replace("\\", "");
                string[] files = Directory.GetFiles(CheminDossier, "*.exe", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    ListeJeux.AjoutJeux(file);
                }
                (App.Current as App).LeManager.ListeJeux = ListeJeux;
                (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;
            }
        }
        private void ChercherSource_Click(object sender, RoutedEventArgs e)
        {   
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                CheminSource_Textbox.Text = filename;
            }
        }
        private void ChercherJeux_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.FileName = "Folder Selection";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(folderBrowser.FileName);
                CheminSource_Textbox.Text = filename;
            }
        }

        private void AjouterJeux()
        {/*

            List<Jeux> ListeJeux = (App.Current as App).LeManager.ListeJeux;
            Jeux jeuxAdd = new Jeux()
            ListeJeux.Add(new Jeux(file, NomJeux));
                            }
                        }
                    }

                }
                (App.Current as App).LeManager.ListeJeux = ListeJeux;
                (App.Current as App).LeNavigateur.Etatactuel = Navigator.Etat.ACCUEIL;*/
        }
    }
}
