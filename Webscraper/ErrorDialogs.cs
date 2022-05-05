using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Webscraper
{
    public class ErrorDialogs
    {
        public static void NoConnectionDialog()
        {
            string keyword = "Kan de website(s) niet bereiken. Check internetverbinding!";
            string caption = "Geen Verbinding";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(keyword, caption, button, icon, MessageBoxResult.Yes);
        }
        public static void WarningDialogNoQuery()
        {
            string keyword = "Tekstfield is leeg, gaarne een artikelnummer invoeren!";
            string caption = "Warning";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(keyword, caption, button, icon, MessageBoxResult.Yes);
        }
        public static void WarningDialogNoWeb()
        {
            string keyword = "Geen pagina geselecteerd!";
            string caption = "Warning";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(keyword, caption, button, icon, MessageBoxResult.Yes);
        }
        public static void WarningDialogNothingFound()
        {
            string keyword = "Niks kunnen vinden!";
            string caption = "Warning";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(keyword, caption, button, icon, MessageBoxResult.Yes);
        }

        // Variabele Testen
        public static void TestDialog(string urlprehm)
        {
            string keyword = urlprehm;
            string caption = "Info";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result;
            result = MessageBox.Show(keyword, caption, button, icon, MessageBoxResult.Yes);
        }
    }
}
