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
    public class SearchPrehm
    {
        private static ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();
        public static ObservableCollection<EntryModel> LoadCollectionData
        {
            get { return _entries; }
            set { _entries = value; }
        }
        public static void PrehmSearchResults(string SearchQuery)
        {
            HtmlWeb web = new HtmlWeb();

            try
            {
                HtmlDocument doc = web.Load("https://www.prehmshop.de/advanced_search_result.php?keywords=" + SearchQuery);
                var title = doc.DocumentNode.CssSelect("div.header_cell > a").Single().InnerText;
                var links = doc.DocumentNode.CssSelect("a.product_link");
                var productLink = new List<string>();
                var productTitle = new List<string>();

                foreach (var link in links)
                {
                    if (link.Attributes["href"].Value.Contains(".html"))
                    {
                        productLink.Add(link.Attributes["href"].Value);
                    }
                }

                Debug.Print($"Title: {title} \n Link: {productLink[0]}");
                _entries.Add(new EntryModel { Title = title, Link = productLink[0] });
            }
            catch (WebException)
            {
                ErrorDialogs.NoConnectionDialog();
            }
            catch (InvalidOperationException)
            {
                ErrorDialogs.WarningDialogNothingFound();
            }

        }
        public static void ClearItems()
        {
            _entries.Clear();
        }
    }
}
