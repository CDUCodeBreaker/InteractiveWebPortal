using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class CreateAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllAnnouncement();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllAnnouncement()
        {
            DataTable dtAnnouncement = Announcement_BL.ListAllAnnouncements();
            if (dtAnnouncement.Rows.Count > 0)
            {
                gvAnnouncementList.DataSource = dtAnnouncement;
                gvAnnouncementList.DataKeyNames = AnnouncementDataKeys();
                gvAnnouncementList.DataBind();
            }
            else
            {
                LoadEmptyAnnouncement();
            }
        }

        private void LoadEmptyAnnouncement()
        {
            DataTable dtAnnouncement = CreateAnnouncementDataTable();
            for (int i = 0; i < 10; i++)
            {
                dtAnnouncement.Rows.Add(dtAnnouncement.NewRow());
            }
            gvAnnouncementList.DataSource = dtAnnouncement;
            gvAnnouncementList.DataKeyNames = AnnouncementDataKeys();
            gvAnnouncementList.DataBind();
        }

        private DataTable CreateAnnouncementDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AnnouncementID", typeof(int));
            dt.Columns.Add("Announcement", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            return dt;
        }

        private string[] AnnouncementDataKeys()
        {
            return new string[] { "AnnouncementID", "Announcement", "CreateDate", "CreatedBy", "Status" };
        }

        protected void btnSubmitAnnouncement_Click(object sender, EventArgs e)
        {
            if (txtAnnouncement.Text != string.Empty)
            {
                int announcementID = 0;
                Announcement_BO objAnnouncementBO = LoadAnnouncementInformation();
                Announcement_BL objAnnouncementBL = new Announcement_BL();
                if (Convert.ToInt32(ViewState["AnnouncementID"]) > 0)
                {
                    announcementID = objAnnouncementBL.UpdateAnnouncement(objAnnouncementBO);
                }
                else
                {
                    announcementID = objAnnouncementBL.SaveAnnouncement(objAnnouncementBO);
                }
                if (announcementID > 0)
                {
                    LoadAllAnnouncement();
                    txtAnnouncement.Text = string.Empty;
                    ViewState["AnnouncementID"] = null;
                }
            }
        }

        private Announcement_BO LoadAnnouncementInformation()
        {
            Announcement_BO objAnnouncementBO = new Announcement_BO();
            if (ViewState["AnnouncementID"] != null)
            {
                objAnnouncementBO.AnnouncementID = Convert.ToInt32(ViewState["AnnouncementID"]);
            }
            objAnnouncementBO.Announcement = txtAnnouncement.Text.Trim();
            objAnnouncementBO.Status = 1;
            objAnnouncementBO.CreatedBy = "Admin";
            return objAnnouncementBO;
        }

        protected void btnCancelAnnouncement_Click(object sender, EventArgs e)
        {
            txtAnnouncement.Text = string.Empty;
        }

        protected void btnEditAnnouncement_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int announcementID = Convert.ToInt32(gvAnnouncementList.DataKeys[rowindex]["AnnouncementID"]);
            string announcement = Convert.ToString(gvAnnouncementList.DataKeys[rowindex]["Announcement"]);
            txtAnnouncement.Text = announcement;
            ViewState["AnnouncementID"] = announcementID;
        }

        protected void btnDeleteAnnouncement_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int announcementID = Convert.ToInt32(gvAnnouncementList.DataKeys[rowindex]["AnnouncementID"]);
            Announcement_BL objAnnouncementBL = new Announcement_BL();
            objAnnouncementBL.DeleteAnnouncement(announcementID);
            LoadAllAnnouncement();
        }
    }
}