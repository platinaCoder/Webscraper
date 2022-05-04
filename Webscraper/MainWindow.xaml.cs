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
            AutoUpdater.Start("https://gist.githubusercontent.com/platinaCoder/dc02a911ddedb39a7ef3d64f4ee4c12b/raw/3f7becdcc16e808333d3be41a7c663fcf2a646a3/webscraper_update.xml");
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
            business_logic.ClearItems();
            string SearchQuery = ArtikelNummer_Text.Text;
            if (string.IsNullOrEmpty(SearchQuery))
            {
                business_logic.WarningDialogNoQuery();
            }
            else
            {
                if (PrehmBox.IsChecked ?? false)
                {

                    business_logic.SearchPrehm(SearchQuery);
                    DataCollection.ItemsSource = business_logic.LoadCollectionData;
                }
                else
                {
                    business_logic.WarningDialogNoWeb();
                }
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
