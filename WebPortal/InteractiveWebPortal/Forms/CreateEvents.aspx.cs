using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class CreateEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminevents.jpg);background-size:cover;");
                LoadAllEvents();
                id01.Style.Add("display", "none");
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllEvents()
        {
            DataTable dtEvents = Event_BL.ListAllEvents();
            if (dtEvents.Rows.Count > 0)
            {
                gvEvents.DataSource = dtEvents;
                gvEvents.DataKeyNames = EventDataKeys();
                gvEvents.DataBind();
            }
            else
            {
                LoadEmptyEvents();
            }
        }

        private void LoadEmptyEvents()
        {
            DataTable dtEvents = CreateEventDataTable();
            for (int i = 0; i < 10; i++)
            {
                dtEvents.Rows.Add(dtEvents.NewRow());
            }
            gvEvents.DataSource = dtEvents;
            gvEvents.DataKeyNames = EventDataKeys();
            gvEvents.DataBind();
        }

        private DataTable CreateEventDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EventID", typeof(string));
            dt.Columns.Add("EventName", typeof(string));
            dt.Columns.Add("EventDescription", typeof(string));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("EndDate", typeof(string));
            dt.Columns.Add("StartTime", typeof(string));
            dt.Columns.Add("EndTime", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("UpdatedBy", typeof(string));
            dt.Columns.Add("FilePath", typeof(string));
            return dt;
        }

        private string[] EventDataKeys()
        {
            return new string[] { "EventID", "EventName", "EventDescription", "StartDate", "EndDate", "StartTime", "EndTime", "Location", "CreatedBy", "UpdatedBy", "FilePath" };
        }

        protected void btnSubmitEvents_Click(object sender, EventArgs e)
        {
            id01.Style.Add("display", "none");
            if (txtEventName.Text != string.Empty && txtEventDescription.Text != string.Empty && txtEndDate.Text != string.Empty && txtStartDate.Text != string.Empty && txtStartTime.Text != string.Empty && txtEndTime.Text != string.Empty && txtLocation.Text != string.Empty)
            {

                int eventID = 0;
                Event_BO objEventBO = LoadEventInformation();
                Event_BL objEventBL = new Event_BL();
                if (Convert.ToInt32(ViewState["EventID"]) > 0)
                {
                    eventID = objEventBL.UpdateEvent(objEventBO);
                }
                else
                {
                    eventID = objEventBL.SaveEvent(objEventBO);
                }
                if (eventID > 0)
                {
                    FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/EventFiles/") + Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_"));
                    LoadAllEvents();
                    txtEndDate.Text = string.Empty;
                    txtEndTime.Text = string.Empty;
                    txtEventDescription.Text = string.Empty;
                    txtEventName.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                    txtStartDate.Text = string.Empty;
                    txtStartTime.Text = string.Empty;
                    ViewState["EventID"] = null;
                }
            }
        }

        private Event_BO LoadEventInformation()
        {
            Event_BO objEventBO = new Event_BO();
            if (ViewState["EventID"] != null)
            {
                objEventBO.EventID = Convert.ToInt32(ViewState["EventID"]);
                objEventBO.UpdatedBy = Session["Name"].ToString();
                if (FileUploadControl.HasFile)
                {
                    objEventBO.FilePath = "~/EventFiles/" + Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");
                }
            }
            else
            {
                if (FileUploadControl.HasFile)
                {
                    objEventBO.FilePath = "~/EventFiles/" + Path.GetFileName(FileUploadControl.PostedFile.FileName).Replace(" ", "_");
                }
            }
            objEventBO.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objEventBO.StartTime = txtStartTime.Text.Trim();
            objEventBO.EndDate = DateTime.ParseExact(txtEndDate.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objEventBO.EndTime = txtEndTime.Text.Trim();
            objEventBO.EventDescription = txtEventDescription.Text.Trim();
            objEventBO.EventName = txtEventName.Text.Trim();
            objEventBO.Location = txtLocation.Text.Trim();
            objEventBO.Status = 1;
            objEventBO.CreatedBy = Session["Name"].ToString();
            return objEventBO;
        }

        protected void btnEditEvent_Click(object sender, EventArgs e)
        {
            id01.Style.Add("display", "none");
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int eventID = Convert.ToInt32(gvEvents.DataKeys[rowindex]["EventID"]);
            string eventName = Convert.ToString(gvEvents.DataKeys[rowindex]["EventName"]);
            string eventDescription = Convert.ToString(gvEvents.DataKeys[rowindex]["EventDescription"]);
            string startDate = Convert.ToString(gvEvents.DataKeys[rowindex]["StartDate"]);
            string endDate = Convert.ToString(gvEvents.DataKeys[rowindex]["EndDate"]);
            string startTime = Convert.ToString(gvEvents.DataKeys[rowindex]["StartTime"]);
            string endTime = Convert.ToString(gvEvents.DataKeys[rowindex]["EndTime"]);
            string location = Convert.ToString(gvEvents.DataKeys[rowindex]["Location"]);
            txtEventName.Text = eventName;
            txtEventDescription.Text = eventDescription;
            txtStartDate.Text = startDate;
            txtStartTime.Text = startTime;
            txtEndDate.Text = endDate;
            txtEndTime.Text = endTime;
            txtLocation.Text = location;
            ViewState["EventID"] = eventID;

            hdnEndTime.Value = endTime;
            hdnStartTime.Value = startTime;
        }

        protected void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            id01.Style.Add("display", "none");
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int eventID = Convert.ToInt32(gvEvents.DataKeys[rowindex]["EventID"]);
            Event_BL objEventBL = new Event_BL();
            objEventBL.DeleteEvent(eventID);
            LoadAllEvents();
        }

        protected void btnCancelEvents_Click(object sender, EventArgs e)
        {
            txtEndDate.Text = string.Empty;
            txtEndTime.Text = string.Empty;
            txtEventDescription.Text = string.Empty;
            txtEventName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtStartTime.Text = string.Empty;
        }

        protected void gvEvents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvEvents, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "")
            {
                int selectedIndex = int.Parse(e.CommandArgument.ToString());
                string commandName = e.CommandName;

                if (commandName == "Select")
                {
                    lblHeader.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["EventName"]);
                    lblEventDescription.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["EventDescription"]);
                    lblStartDate.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["StartDate"]);
                    lblEndDate.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["EndDate"]);
                    lblStartTime.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["StartTime"]);
                    lblEndTime.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["EndTime"]);
                    lblLocation.Text = Convert.ToString(gvEvents.DataKeys[selectedIndex]["Location"]);
                    Image1.ImageUrl = Convert.ToString(gvEvents.DataKeys[selectedIndex]["FilePath"]);
                    id01.Style.Add("display", "block");
                }
            }
        }
    }
}