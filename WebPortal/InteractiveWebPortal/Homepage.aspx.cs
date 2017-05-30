using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using System.Net;
            //using System.IO;
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("username", "hasanmukit009");
            client.QueryString.Add("password", "#Bangladesh1971#");
            client.QueryString.Add("to", "0451719939");
            client.QueryString.Add("from", "0420207627");
            client.QueryString.Add("message", "Hello World!");
            client.QueryString.Add("ref", "123");
            client.QueryString.Add("maxsplit", "1");
            string baseurl = "http://www.smsbroadcast.com.au/api-adv.php";
            //string baseurl = "https://api.smsbroadcast.com.au/api-adv.php?username=hasanmukit009&password=#Bangladesh1971#&to=0451719939&from=0420207627&message=Hello%20World&ref=112233&maxsplit=1&delay=1";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            //return (s);
        }
    }
}