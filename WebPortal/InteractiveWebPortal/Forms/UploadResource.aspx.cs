using BL;
using BO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class UploadResource : System.Web.UI.Page
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

        protected void btnSubmitResouce_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    int resourceid = 0;
                    Resources_BO objResourcesBO = new Resources_BO();
                    Resources_BL objResourcesBL = new Resources_BL();
                    string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");
                    if (ddlFileType.SelectedItem.Text == "Audio")
                    {
                        FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Files/") + filename);
                        objResourcesBO = LoadResourceInformation();
                        resourceid = objResourcesBL.SaveResource(objResourcesBO);
                    }
                    else if (ddlFileType.SelectedItem.Text == "Video")
                    {
                        FileUploadControl.SaveAs(Server.MapPath("~/Files/") + filename);
                        objResourcesBO = LoadResourceInformation();
                        resourceid = objResourcesBL.SaveResource(objResourcesBO);
                    }
                    else if (ddlFileType.SelectedItem.Text == "Document")
                    {
                        FileUploadControl.SaveAs(Server.MapPath("~/Files/") + filename);
                        objResourcesBO = LoadResourceInformation();
                        resourceid = objResourcesBL.SaveResource(objResourcesBO);
                    }
                    if (resourceid > 0)
                    {
                        LoadAudioList();
                        LoadVideoList();
                        LoadDocumentList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private Resources_BO LoadResourceInformation()
        {
            Resources_BO objResourcesBO = new Resources_BO();
            string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");
            objResourcesBO.FileName = filename;
            objResourcesBO.CreatedBy = Session["Name"].ToString();

            if (ddlFileType.SelectedItem.Text == "Audio")
            {
                objResourcesBO.FileType = 1;
                objResourcesBO.FilePath = "~/Files/" + filename;
            }
            else if (ddlFileType.SelectedItem.Text == "Video")
            {
                objResourcesBO.FileType = 2;
                objResourcesBO.FilePath = "~/Files/" + filename;

            }
            else if (ddlFileType.SelectedItem.Text == "Document")
            {
                objResourcesBO.FileType = 3;
                objResourcesBO.FilePath = "~/Files/" + filename;

            }
            return objResourcesBO;
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

        protected void DeleteFile(object sender, EventArgs e)
        {
            string resourceID = (sender as LinkButton).CommandArgument;
            DataTable dtResource = Resources_BL.GetResourceByResourceID(Convert.ToInt32(resourceID));

            if (dtResource.Rows.Count > 0)
            {
                Resources_BL objResourcesBL = new Resources_BL();
                objResourcesBL.DeleteResourceByResourceID(Convert.ToInt32(dtResource.Rows[0]["ResourceID"]));
                File.Delete(Server.MapPath(dtResource.Rows[0]["FilePath"].ToString()));
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}