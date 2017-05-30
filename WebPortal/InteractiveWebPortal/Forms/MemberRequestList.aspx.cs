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
    public partial class MemberRequestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/dashboardadmin.jpg)");
                LoadRequestList();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void LoadRequestList()
        {
            DataTable dtRequestedMember = User_BL.UserListByStatus(1);
            if (dtRequestedMember.Rows.Count > 0)
            {
                DataTable dtNewRequestList = CreateDataTable();
                dtNewRequestList = LoadData(dtRequestedMember);
                if (dtNewRequestList.Rows.Count > 0)
                {
                    gvMemberRequest.DataSource = dtNewRequestList;
                    gvMemberRequest.DataKeyNames = RequestMemberDataKeys();
                    gvMemberRequest.DataBind();
                }
            }
            else
            {
                LoadEmptyRequestedMember();
            }
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

        private void LoadEmptyRequestedMember()
        {
            DataTable dtRequestedMember = CreateDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtRequestedMember.Rows.Add(dtRequestedMember.NewRow());
            }
            gvMemberRequest.DataSource = dtRequestedMember;
            gvMemberRequest.DataKeyNames = RequestMemberDataKeys();
            gvMemberRequest.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvMemberRequest.DataKeys[rowindex]["UserID"]);
            string membershipno = string.Format("ALN{0}{1}", DateTime.Now.ToString("dd/MM/yyyy").Replace("/", ""), userid.ToString().PadLeft(5, '0'));
            User_BL objUserBL = new User_BL();
            objUserBL.ApproveUser(userid, membershipno);
            LoadRequestList();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvMemberRequest.DataKeys[rowindex]["UserID"]);

            User_BL objUserBL = new User_BL();
            objUserBL.RejectUser(userid);
            LoadRequestList();
        }

















    }
}