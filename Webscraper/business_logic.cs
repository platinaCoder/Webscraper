using System;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web;
using System.Net;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace Webscraper
{
    public class business_logic
    {
        private static ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();
        public static ObservableCollection<EntryModel> LoadCollectionData
        {
            get { return _entries; }
            set { _entries = value; }
        }
        public static void SearchPrehm(string SearchQuery)
        {
            HtmlWeb web = new HtmlWeb();

            try
            {
                HtmlDocument doc = web.Load("https://www.prehmshop.de/advanced_search_result.php?keywords=" + SearchQuery);
                string title = doc.DocumentNode.CssSelect("div.header_cell > a").Single().InnerText;
                var links = doc.DocumentNode.CssSelect("a.product_link");
                var productLink = new List<string>();

                foreach (var link in links)
                {
                    if (link.Attributes["href"].Value.Contains(".html"))
                    {
                        productLink.Add(link.Attributes["href"].Value);
                    }
                }

                string filteredProductLink = productLink[0];
                int index = filteredProductLink.IndexOf("&");
                if (index >= 0)
                    filteredProductLink = filteredProductLink.Substring(0, index);

                Debug.Print($"Title: {title} \n Link: {filteredProductLink}");
                _entries.Add(new EntryModel { Title = title, Link = filteredProductLink });
            }
            catch (WebException)
            {
                NoConnectionDialog();
            }
            catch (InvalidOperationException)
            {
                WarningDialogNothingFound();
            }

        }
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
        public static void ClearItems()
        {
            _entries.Clear();
        }
    }
}
