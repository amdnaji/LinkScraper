using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LinkScraper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //For sake of simplicity everything is on the controller
        public async Task<string> Scrape(string link)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(link);
                Stream contentStream = await response.Content.ReadAsStreamAsync();
                HtmlDocument document = new HtmlDocument();
                document.Load(contentStream);
                string imgSrc = string.Empty;
                var ogMeta = document.DocumentNode.SelectNodes("//meta[@property]");
                //Check if site contain Open graph element
                if (ogMeta != null)
                {
                    var ogImage = document.DocumentNode.SelectNodes("//meta[@property]").Where(x => x.Attributes["property"].Value == "og:image");
                    if (ogImage.Count() > 0) //check og:image found
                    {
                        StringBuilder images = new StringBuilder();
                        foreach (HtmlNode node in ogImage)
                        {
                            images.Append("<li>");
                            images.Append($"<img src='{node.Attributes["content"].Value}'/>");
                            images.Append("</li>");
                        }
                        return images.ToString();
                    }
                    else  //return some images
                        return GetNonOgImages(document.DocumentNode.SelectNodes("//img"));
                }
                else
                {

                    return GetNonOgImages(document.DocumentNode.SelectNodes("//img"));
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        private string GetNonOgImages(HtmlNodeCollection DOM)
        {
            StringBuilder Images = new StringBuilder();
            if (DOM != null)
            {
                foreach (var img in DOM)
                {
                    Images.AppendFormat("<li>");
                    Images.AppendFormat(img.OuterHtml);
                    Images.AppendFormat("</li>");

                }
            }
            return Images.ToString();
        }
    }
}