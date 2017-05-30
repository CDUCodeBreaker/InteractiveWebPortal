using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class ViewAnnouncements : System.Web.UI.Page
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
                gvAnnouncements.DataSource = dtAnnouncement;
                gvAnnouncements.DataKeyNames = AnnouncementDataKeys();
                gvAnnouncements.DataBind();
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
            gvAnnouncements.DataSource = dtAnnouncement;
            gvAnnouncements.DataKeyNames = AnnouncementDataKeys();
            gvAnnouncements.DataBind();
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
    }
}