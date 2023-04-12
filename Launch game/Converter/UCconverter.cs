using Launch_game.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using static Launch_game.Navigator;

namespace Launch_game
{
    /// <summary>
    /// permet d'afficher un UserControl à partir d'un état
    /// </summary>
    class UCconverter : IValueConverter
    {
        /// <summary>
        /// Associe un état à un UserControl et permet de l'ouvrir, n'ouvre rien dans le cas ou l'état n'est pas définit
        /// </summary>
        /// <returns>la fenêtre/UserControl à ouvrir</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Etat e = (Etat)value;

            switch (e)
            {
                case Navigator.Etat.ACCUEIL:
                    return new UCAccueil();
                case Navigator.Etat.PARAMETRE:
                    return new UCParametre();
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// Même fonction mais en sens contraire (n'est pas utilisée ici)
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
