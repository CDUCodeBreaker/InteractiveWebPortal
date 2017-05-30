using BL;
using BO;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class CreateAdvertisement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdvertisementList();
            }
        }

        private void LoadAdvertisementList()
        {
            DataTable dt = Advertisement_BL.ListAllAdvertisements();
            gvAdvertisements.DataSource = dt;
            gvAdvertisements.DataBind();
        }

        protected void btnSubmitResouce_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    int advertisementid = 0;
                    Advertisement_BO objAdvertisementBO = new Advertisement_BO();
                    Advertisement_BL objAdvertisementBL = new Advertisement_BL();
                    string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");

                    FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Advertisements/") + filename);
                    objAdvertisementBO = LoadAdvertisementInformation();
                    advertisementid = objAdvertisementBL.SaveResource(objAdvertisementBO);

                    if (advertisementid > 0)
                    {
                        LoadAdvertisementList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private Advertisement_BO LoadAdvertisementInformation()
        {
            Advertisement_BO objAdvertisementBO = new Advertisement_BO();
            string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");
            objAdvertisementBO.FileName = filename;
            objAdvertisementBO.CreatedBy = Session["Name"].ToString();
            objAdvertisementBO.FilePath = "~/Advertisements/" + filename;
            return objAdvertisementBO;
        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string advertisementid = (sender as LinkButton).CommandArgument;
            DataTable dtAdvertisement = Advertisement_BL.GetAdvertisementByAdvertisementID(Convert.ToInt32(advertisementid));

            if (dtAdvertisement.Rows.Count > 0)
            {
                Advertisement_BL objAdvertisementBL = new Advertisement_BL();
                objAdvertisementBL.DeleteAdvertisementByAdvertisementID(Convert.ToInt32(dtAdvertisement.Rows[0]["AdvertisementID"]));
                File.Delete(Server.MapPath(dtAdvertisement.Rows[0]["FilePath"].ToString()));
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}