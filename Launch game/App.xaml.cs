using Classe;
using DataContractPersistance;
using System.Windows;

namespace Launch_game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager LeManager { get; set; } = new Manager(new DataContractP());

        public Navigator LeNavigateur { get; set; } = new Navigator();

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            LeManager.SauvegardeDonnees();
        }
    }
}
