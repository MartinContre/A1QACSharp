using EuroNewsTest.Model;
using HtmlAgilityPack;
using System.Text;

namespace EuroNewsTest.Utils
{
    public class StringUtils
    {
        public static string ExtractRedirectUri(Message message)
        {
            string link = "";
            if (message != null && message.Payload != null && message.Payload.Parts != null)
            {
                foreach (var part in message.Payload.Parts)
                {
                    if (part.Body != null && part.Body.Data != null)
                    {
                        if (part.MimeType.Contains("html"))
                        {
                            link = GetLinkFromConfirmationEmail(part.Body.Data.ToString());
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
            }
            return link;
        }

        private static string GetLinkFromConfirmationEmail(string data)
        {
            data = data.Replace('-', '+').Replace('_', '/');

            byte[] s = Convert.FromBase64String(data);
            string html = Encoding.UTF8.GetString(s);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var link = doc.DocumentNode.SelectSingleNode("//a");
            return link.Attributes["href"].Value;
        }
    }
}

