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
using AutoUpdaterDotNET;

namespace Webscraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoUpdater.Start("https://github.com/platinaCoder/Webscraper/releases/download/update/update.xml");
        }
        private void ItemExport_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ItemInfo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ItemUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Zoeken_btn_Click(object sender, RoutedEventArgs e)
        {
            SearchPrehm.ClearItems();
            string SearchQuery = ArtikelNummer_Text.Text;
            if (string.IsNullOrEmpty(SearchQuery))
            {
                ErrorDialogs.WarningDialogNoQuery();
            }
            else
            {
                if (PrehmBox.IsChecked ?? false)
                {

                    SearchPrehm.searchPrehm(SearchQuery);
                    DataCollection.ItemsSource = SearchPrehm.LoadCollectionData;
                }
                else
                {
                    ErrorDialogs.WarningDialogNoWeb();
                }
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
