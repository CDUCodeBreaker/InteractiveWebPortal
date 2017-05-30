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
    public partial class ViewGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/admingroups.jpg); background-size:cover;");
                LoadMyGroups();
            }
        }

        private void LoadMyGroups()
        {
            DataTable dtGroup = Group_BL.ListMyGroups(Convert.ToInt32(Session["UserID"]));
            if (dtGroup.Rows.Count > 0)
            {
                gvGroupList.DataSource = dtGroup;
                gvGroupList.DataKeyNames = GroupDataKeys();
                gvGroupList.DataBind();
            }
            else
            {
                LoadEmptyGroup();
            }
        }

        private void LoadEmptyGroup()
        {
            DataTable dtGroup = CreateGroupDataTable();
            for (int i = 0; i < 10; i++)
            {
                dtGroup.Rows.Add(dtGroup.NewRow());
            }
            gvGroupList.DataSource = dtGroup;
            gvGroupList.DataKeyNames = GroupDataKeys();
            gvGroupList.DataBind();
        }

        private DataTable CreateGroupDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GroupID", typeof(int));
            dt.Columns.Add("GroupName", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            return dt;
        }

        private string[] GroupDataKeys()
        {
            return new string[] { "GroupID", "GroupName", "CreatedBy", "CreateDate", "Status" };
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }





        protected void btnViewMember_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int groupID = Convert.ToInt32(gvGroupList.DataKeys[rowindex]["GroupID"]);
            string groupName = Convert.ToString(gvGroupList.DataKeys[rowindex]["GroupName"]);
            GroupMember_BL objGroupMemberBL = new GroupMember_BL();
            DataTable dtGroupMemberList = objGroupMemberBL.GroupMembersByGroupID(groupID);
            gvGroupMember.DataSource = dtGroupMemberList;
            gvGroupMember.DataBind();
            ViewMemberPopup.Style.Add("display", "block");
        }
    }
}