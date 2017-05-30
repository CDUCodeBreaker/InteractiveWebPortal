using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class ViewEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminevents.jpg);background-size:cover;");
                LoadAllEvents();
            }
        }

        private void LoadAllEvents()
        {
            DataTable dtEvents = Event_BL.ListAllEvents();
            if (dtEvents.Rows.Count > 0)
            {
                gvEventList.DataSource = dtEvents;
                gvEventList.DataKeyNames = EventDataKeys();
                gvEventList.DataBind();
            }
            else
            {
                LoadEmptyEvents();
            }
        }

        private void LoadEmptyEvents()
        {
            DataTable dtEvents = CreateEventDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtEvents.Rows.Add(dtEvents.NewRow());
            }
            gvEventList.DataSource = dtEvents;
            gvEventList.DataKeyNames = EventDataKeys();
            gvEventList.DataBind();
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

        protected void gvEventList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvEventList, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvEventList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "")
            {
                int selectedIndex = int.Parse(e.CommandArgument.ToString());
                string commandName = e.CommandName;

                if (commandName == "Select")
                {
                    lblHeader.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["EventName"]);
                    lblEventDescription.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["EventDescription"]);
                    lblStartDate.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["StartDate"]);
                    lblEndDate.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["EndDate"]);
                    lblStartTime.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["StartTime"]);
                    lblEndTime.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["EndTime"]);
                    lblLocation.Text = Convert.ToString(gvEventList.DataKeys[selectedIndex]["Location"]);
                    Image1.ImageUrl = Convert.ToString(gvEventList.DataKeys[selectedIndex]["FilePath"]);
                    vieweventpopup.Style.Add("display", "block");
                    vieweventpopup.Style.Add("display", "block");
                }
            }
        }
    }
}