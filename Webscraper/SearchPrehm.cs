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
                string ZoekOpdracht = SearchQuery.Replace(" ", "+");
                HtmlDocument doc = web.Load("https://www.prehmshop.de/advanced_search_result.php?keywords=" + ZoekOpdracht);
                var title = doc.DocumentNode.CssSelect("div.header_cell > a").ToList();
                var links = doc.DocumentNode.CssSelect("a.product_link");
                var productLink = new List<string>();
                var productTitle = new List<string>();

                foreach (var item in title)
                {
                    if (item.Attributes["href"].Value.Contains(".html"))
                    {
                        productLink.Add(item.Attributes["href"].Value);
                        productTitle.Add(item.InnerText);
                    }
                }

                var TitleAndLink = productLink.Zip(productTitle, (l, t) => new { productLink = l, productTitle = t });
                foreach (var nw in TitleAndLink)
                {
                    var product = new List<EntryModel>();
                    var adDetails = new EntryModel
                    {
                        Title = nw.productTitle,
                        Link = nw.productLink
                    };

                    Debug.Print(adDetails.ToString());
                    var ZoekOpdrachtInTitle = adDetails.Title.ToLower().Contains(ZoekOpdracht.ToLower());
                    if (ZoekOpdrachtInTitle)
                    {
                        _entries.Add(adDetails);
                    }
                }
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
