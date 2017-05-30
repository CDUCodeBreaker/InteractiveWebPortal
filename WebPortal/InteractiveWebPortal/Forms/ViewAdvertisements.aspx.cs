using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class ViewAdvertisements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }

        private new void Load()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Advertisements/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }

            for (int i = 0; i < files.Count; i++)
            {
                Image img = new Image();
                img.Width = 200;
                img.Height = 200;
                img.ImageUrl = "~/Advertisements/" + files[i].Text;
                img.CssClass = "img-responsive img-rounded";
                img.Attributes["OnClientClick"] = "return LoadDiv(this);";
                slideshow.Controls.Add(img);
            }
        }
    }
}