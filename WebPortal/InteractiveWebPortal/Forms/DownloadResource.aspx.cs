using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class DownloadResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminresources.jpg);background-size:cover;");
                LoadAudioList();
                LoadVideoList();
                LoadDocumentList();
            }
        }

        private void LoadAudioList()
        {
            DataTable dt = Resources_BL.ListAllResourcesByFileType(1);
            gvAudios.DataSource = dt;
            gvAudios.DataBind();
        }

        private void LoadVideoList()
        {
            DataTable dt = Resources_BL.ListAllResourcesByFileType(2);
            gvVideos.DataSource = dt;
            gvVideos.DataBind();
        }

        private void LoadDocumentList()
        {
            DataTable dt = Resources_BL.ListAllResourcesByFileType(3);
            gvDocuments.DataSource = dt;
            gvDocuments.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            string resourceID = (sender as LinkButton).CommandArgument;
            DataTable dtResource = Resources_BL.GetResourceByResourceID(Convert.ToInt32(resourceID));
            if (dtResource.Rows.Count > 0)
            {
                string filepath = Server.MapPath(dtResource.Rows[0]["FilePath"].ToString());
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filepath));
                Response.WriteFile(filepath);
                Response.End();
            }
        }
    }
}