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
    public partial class MemberBlockList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/dashboardadmin.jpg)");
                LoadBlockList();
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


        private void LoadBlockList()
        {
            DataTable dtBlockedMember = User_BL.UserListByStatus(3);
            if (dtBlockedMember.Rows.Count > 0)
            {
                DataTable dtNewBlockedList = CreateDataTable();
                dtNewBlockedList = LoadData(dtBlockedMember);
                if (dtNewBlockedList.Rows.Count > 0)
                {
                    gvBlockedMember.DataSource = dtNewBlockedList;
                    gvBlockedMember.DataKeyNames = BlockedMemberDataKeys();
                    gvBlockedMember.DataBind();
                }
            }
            else
            {
                LoadEmptyBlockedMember();
            }
        }

        private void LoadEmptyBlockedMember()
        {
            DataTable dtBlockedMember = CreateDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtBlockedMember.Rows.Add(dtBlockedMember.NewRow());
            }
            gvBlockedMember.DataSource = dtBlockedMember;
            gvBlockedMember.DataKeyNames = BlockedMemberDataKeys();
            gvBlockedMember.DataBind();
        }

        private string[] BlockedMemberDataKeys()
        {
            return new string[] { "UserID", "Name", "MemberShipNo", "Email", "Mobile", "DateOfBirth", "Address", "Suburb", "FilePath" };
        }

        
        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void btnUnblock_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvBlockedMember.DataKeys[rowindex]["UserID"]);

            User_BL objUserBL = new User_BL();
            objUserBL.UnBlockUser(userid);
            LoadBlockList();
        }

        protected void btnRemoveFromBlock_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int userid = Convert.ToInt32(gvBlockedMember.DataKeys[rowindex]["UserID"]);

            User_BL objUserBL = new User_BL();
            objUserBL.BlockUser(userid);
            LoadBlockList();
        }
    }
}