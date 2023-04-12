using Classe;


namespace Test_DataContract
{
    /// <summary>
    /// Teste le bon fonctionnement de la persistance
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Manager unManager = new Manager(new Stub.Stub());
            unManager.ChargerDonnees();
            unManager.Persistance = new DataContractPersistance.DataContractP();
            unManager.SauvegardeDonnees();
        }
    }
}

