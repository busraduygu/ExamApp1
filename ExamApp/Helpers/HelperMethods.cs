using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Helpers
{
    public class HelperMethods
    {
        public List<Data> GetQuestionTitleAndTextFromWired()
        {
            string link = "https://www.wired.com/";
            Uri url = new Uri(link);
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var SelectedHtml = "//*[@id=\"main-content\"]/div[1]/div[1]/section/div[3]/div/div/div/div"; //summary-list__items
            var SelectedHtmlList = htmlDocument.DocumentNode.SelectNodes(SelectedHtml);
            List<string> TitleList = new List<string>();
            List<string> HrefList = new List<string>();


            foreach (var items in SelectedHtmlList)
            {
                foreach (var innerItem1 in items.SelectNodes("div"))
                {
                    foreach (var item in innerItem1.SelectNodes("div"))
                    {

                        var a = item.SelectSingleNode("a");
                        var title = a.InnerText.ToString();
                        if (!string.IsNullOrEmpty(title))
                        {
                            var itemInnerHtmlText = item.InnerHtml.ToString();
                            int start = itemInnerHtmlText.IndexOf("href=\"") + 6;
                            var temp = itemInnerHtmlText.Substring(start, itemInnerHtmlText.Length - start);
                            int end = temp.IndexOf("\"");
                            var href = temp.Substring(0, end);
                            TitleList.Add(title);
                            HrefList.Add(href);
                        }
                    }
                }
            }
            List<string> TextList = new List<string>();
            foreach (var item in HrefList)
            {
                string link2 = $"https://www.wired.com{item}";
                Uri url2 = new Uri(link2);
                WebClient webClient2 = new WebClient();
                webClient2.Encoding = Encoding.UTF8;
                string html2 = webClient.DownloadString(url2);
                HtmlAgilityPack.HtmlDocument htmlDocument2 = new HtmlAgilityPack.HtmlDocument();
                htmlDocument2.LoadHtml(html2);

                var xpath = "//*[@id=\"main-content\"]/article/div[2]/div[1]/div[1]/div/div[1]/div";
                var SelectedHtmlList2 = htmlDocument2.DocumentNode.SelectNodes(xpath);
                if (SelectedHtmlList2 == null)
                {
                    xpath = "//*[@id=\"main-content\"]/article/div[2]/div[3]/div[1]/div[1]/div";
                    SelectedHtmlList2 = htmlDocument2.DocumentNode.SelectNodes(xpath);
                    foreach (var item2 in SelectedHtmlList2)
                    {

                        var text = item2.InnerText;
                        if (!string.IsNullOrEmpty(text))
                        {
                            TextList.Add(text);
                        }
                    }

                }
                else
                {
                    var text = "";
                    foreach (var item2 in SelectedHtmlList2)
                    {
                        if (!string.IsNullOrEmpty(item2.InnerText))
                        {
                            text += item2.InnerText;
                        }
                    }
                    TextList.Add(text);
                }

            }
            List<Data> dataList = new List<Data>();

            for (int i = 0; i < TitleList.Count; i++)
            {
                Data data = new Data();
                data.Id = i + 1;
                data.Title = TitleList[i];
                data.Text = TextList[i];
                data.Href = HrefList[i];
                dataList.Add(data);
            }
            return dataList;
        }
    }
}
