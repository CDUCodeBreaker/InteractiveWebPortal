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
    public partial class MemberApproveList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/dashboardadmin.jpg)");
                LoadApproveList();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        

        private DataTable LoadData(DataTable dtRequestedMember)
        {
            DataTable dt = CreateDataTable();
            for (int i = 0; i < dtRequestedMember.Rows.Count; i++)
            {
                dt.Rows.Add(
                    dtRequestedMember.Rows[i]["UserID"],
                    dtRequestedMember.Rows[i]["FirstName"] + " " + dtRequestedMember.Rows[i]["LastName"],
                    dtRequestedMember.Rows[i]["MemberShipNo"],
                    dtRequestedMember.Rows[i]["Email"],
                    dtRequestedMember.Rows[i]["MobileNo"],
                    dtRequestedMember.Rows[i]["DateOfBirth"],
                    dtRequestedMember.Rows[i]["Address1"] + " " + dtRequestedMember.Rows[i]["Address2"],
                    dtRequestedMember.Rows[i]["Suburb"],
                    dtRequestedMember.Rows[i]["FilePath"]
                    );
            }
            return dt;
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("MembershipNo", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Mobile", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Suburb", typeof(string));
            dt.Columns.Add("FilePath", typeof(string));
            return dt;
        }

        private string[] RequestMemberDataKeys()
        {
            return new string[] { "UserID", "Name", "MemberShipNo", "Email", "Mobile", "DateOfBirth", "Address", "Suburb", "FilePath" };
        }

        private void LoadApproveList()
        {
            DataTable dtApprovedMember = User_BL.UserListByStatus(2);
            if (dtApprovedMember.Rows.Count > 0)
            {
                DataTable dtNewApprovedList = CreateDataTable();
                dtNewApprovedList = LoadData(dtApprovedMember);
                if (dtNewApprovedList.Rows.Count > 0)
                {
                    gvApprovedMember.DataSource = dtNewApprovedList;
                    gvApprovedMember.DataKeyNames = ApprovedMemberDataKeys();
                    gvApprovedMember.DataBind();
                }
            }
            else
            {
                LoadEmptyApprovedMember();
            }
        }

        private string[] ApprovedMemberDataKeys()
        {
            return new string[] { "UserID", "Name", "MemberShipNo", "Email", "Mobile", "DateOfBirth", "Address", "Suburb", "FilePath" };
        }

        private void LoadEmptyApprovedMember()
        {
            DataTable dtApprovedMember = CreateDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtApprovedMember.Rows.Add(dtApprovedMember.NewRow());
            }
            gvApprovedMember.DataSource = dtApprovedMember;
            gvApprovedMember.DataKeyNames = ApprovedMemberDataKeys();
            gvApprovedMember.DataBind();
        }

        private string[] BlockedMemberDataKeys()
        {
            return new string[] { "UserID", "Name", "MemberShipNo", "Email", "Mobile", "DateOfBirth", "Address", "Suburb", "FilePath" };
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvApprovedMember.DataKeys[rowindex]["UserID"]);
            string username = Convert.ToString(gvApprovedMember.DataKeys[rowindex]["Name"]);
            string membershipno = Convert.ToString(gvApprovedMember.DataKeys[rowindex]["MemberShipNo"]);
            string filePath = Convert.ToString(gvApprovedMember.DataKeys[rowindex]["FilePath"]);
            string email = Convert.ToString(gvApprovedMember.DataKeys[rowindex]["Email"]);
            string url = "E-Card.aspx?UserID=" + userid + "&UserName=" + username + "&MemberShipNo=" + membershipno + "&FilePath=" + filePath + "&Email=" + email;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "window.open('" + url + "');", true);
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void btnBlock_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvApprovedMember.DataKeys[rowindex]["UserID"]);

            User_BL objUserBL = new User_BL();
            objUserBL.BlockUser(userid);
            LoadApproveList();
        }

        protected void btnRemoveFromApprove_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvApprovedMember.DataKeys[rowindex]["UserID"]);

            User_BL objUserBL = new User_BL();
            objUserBL.BlockUser(userid);
            LoadApproveList();
        }
    }
}