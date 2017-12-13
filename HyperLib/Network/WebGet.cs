using System.Net;
using System.IO;

namespace HyperLib.Network
{
    class WebGet
    {
        public static string GetWebContent(string url){
            WebClient client = new WebClient();
            Stream str = client.OpenRead(url);
            StreamReader strr = new StreamReader(str, Encoding.UTF8);
            return strr.ReadToEnd();
        }
    }
}