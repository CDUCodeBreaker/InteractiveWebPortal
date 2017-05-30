using BL;
using BO;
using Common;
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
    public partial class CreateGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupSendMail.Style.Add("display", "none");
                ViewMemberPopup.Style.Add("display", "none");
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/admingroups.jpg); background-size:cover;");
                LoadAllGroups();
                LoadAllUsers();
            }
        }

        private void LoadAllUsers()
        {
            DataTable dtMember = User_BL.ListAllMembers();
            if (dtMember.Rows.Count > 0)
            {
                gvMemberList.DataSource = dtMember;
                gvMemberList.DataKeyNames = MemberDataKeys();
                gvMemberList.DataBind();
            }
            else
            {
                LoadEmptyMemberList();
            }
        }

        private void LoadEmptyMemberList()
        {
            DataTable dtMember = CreateMemberDataTable();
            for (int i = 0; i < 10; i++)
            {
                dtMember.Rows.Add(dtMember.NewRow());
            }
            gvMemberList.DataSource = dtMember;
            gvMemberList.DataKeyNames = MemberDataKeys();
            gvMemberList.DataBind();
        }

        private DataTable CreateMemberDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            return dt;
        }

        private string[] MemberDataKeys()
        {
            return new string[] { "UserID", "UserName" };
        }

        private void LoadAllGroups()
        {
            DataTable dtGroup = Group_BL.ListAllGroups();
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

        private void DeleteExistingGroupMemberByGroupID(int groupID)
        {
            GroupMember_BL objGroupMemberBL = new GroupMember_BL();
            DataTable dt = objGroupMemberBL.GroupMemberListByGroupID(groupID);
            if (dt.Rows.Count > 0)
            {
                objGroupMemberBL.DeleteGroupMemberByGroupID(groupID);
            }
        }

        private List<GroupMember_BO> LoadGroupMemberInformation(int GroupID)
        {
            List<GroupMember_BO> lstGroupMember = new List<GroupMember_BO>();
            foreach (GridViewRow row in gvMemberList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkMember") as CheckBox);
                    if (chkRow.Checked)
                    {
                        GridViewRow row1 = (GridViewRow)chkRow.NamingContainer;
                        int rowindex = row1.RowIndex;
                        int userid = Convert.ToInt32(gvMemberList.DataKeys[rowindex]["UserID"]);
                        string username = Convert.ToString(gvMemberList.DataKeys[rowindex]["UserName"]);
                        GroupMember_BO objGroupMemberBO = new GroupMember_BO();
                        objGroupMemberBO.GroupID = GroupID;
                        objGroupMemberBO.UserID = userid;
                        lstGroupMember.Add(objGroupMemberBO);
                    }
                }
            }
            return lstGroupMember;
        }

        private Group_BO LoadGroupInformation()
        {
            Group_BO objGroupBO = new Group_BO();
            if (Convert.ToInt32(ViewState["GroupID"]) > 0)
            {
                objGroupBO.GroupID = Convert.ToInt32(ViewState["GroupID"]);
            }
            objGroupBO.GroupName = txtGroupName.Text.Trim();
            objGroupBO.CreatedBy = Session["Name"].ToString();
            objGroupBO.Status = 1;
            return objGroupBO;
        }

        private bool AnyRowSelected()
        {
            bool result = false;
            foreach (GridViewRow row in gvMemberList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkMember") as CheckBox);
                    if (chkRow.Checked)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }



        protected void btnEditGroup_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
            LoadAllGroups();
            LoadAllUsers();
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int groupID = Convert.ToInt32(gvGroupList.DataKeys[rowindex]["GroupID"]);
            string groupName = Convert.ToString(gvGroupList.DataKeys[rowindex]["GroupName"]);

            txtGroupName.Text = groupName;
            ViewState["GroupID"] = groupID;


            GroupMember_BL objGroupMemberBL = new GroupMember_BL();
            DataTable dtGroupMemberList = objGroupMemberBL.GroupMemberListByGroupID(groupID);

            for (int i = 0; i < dtGroupMemberList.Rows.Count; i++)
            {
                foreach (GridViewRow row in gvMemberList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkMember") as CheckBox);
                        GridViewRow row1 = (GridViewRow)chkRow.NamingContainer;
                        int rowindex1 = row1.RowIndex;
                        int userid = Convert.ToInt32(gvMemberList.DataKeys[rowindex1]["UserID"]);
                        if (Convert.ToInt32(dtGroupMemberList.Rows[i]["UserID"]) == userid)
                        {
                            chkRow.Checked = true;
                        }
                    }
                }
            }
        }

        protected void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int groupID = Convert.ToInt32(gvGroupList.DataKeys[rowindex]["GroupID"]);
            if (ViewState["GroupID"] != null)
            {
                ViewState["GroupID"] = null;
            }
            ViewState["GroupID"] = groupID;
            PopupSendMail.Style.Add("display", "block");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
            DataTable dtEmail = GroupMember_BL.ListEmailAddressByGroupID(Convert.ToInt32(ViewState["GroupID"]));
            if (dtEmail.Rows.Count > 0)
            {
                for (int i = 0; i < dtEmail.Rows.Count; i++)
                {
                    string mail = dtEmail.Rows[i]["Email"].ToString();
                    EmailHelper objEmailHelper = new EmailHelper();
                    objEmailHelper.SendEmailWithAttachment("", mail, txtSubjectMail.Text.Trim(), txtBodyMail.Text.Trim());
                }
            }
        }

        protected void btnViewMember_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int groupID = Convert.ToInt32(gvGroupList.DataKeys[rowindex]["GroupID"]);
            string groupName = Convert.ToString(gvGroupList.DataKeys[rowindex]["GroupName"]);
            GroupMember_BL objGroupMemberBL = new GroupMember_BL();
            DataTable dtGroupMemberList = objGroupMemberBL.GroupMembersByGroupID(groupID);
            gvGroupMember.DataSource = dtGroupMemberList;
            gvGroupMember.DataBind();
            ViewMemberPopup.Style.Add("display", "block");
        }

        protected void btnSubmitGroup_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();

            if (txtGroupName.Text != string.Empty)
            {
                if (AnyRowSelected())
                {
                    int groupID = 0;
                    Group_BO objGroupBO = LoadGroupInformation();
                    Group_BL objGroupBL = new Group_BL();
                    if (Convert.ToInt32(ViewState["GroupID"]) > 0)
                    {
                        groupID = objGroupBL.UpdateGroup(objGroupBO);
                    }
                    else
                    {
                        groupID = objGroupBL.SaveGroup(objGroupBO);
                    }

                    if (groupID > 0)
                    {
                        DeleteExistingGroupMemberByGroupID(groupID);

                        List<GroupMember_BO> lstGroupMember = LoadGroupMemberInformation(groupID);
                        if (lstGroupMember.Count > 0)
                        {
                            foreach (var objGroupMember in lstGroupMember)
                            {
                                GroupMember_BL objGroupMemberBL = new GroupMember_BL();
                                objGroupMemberBL.SaveGroupMember(objGroupMember);
                            }
                        }
                        LoadAllGroups();
                        LoadAllUsers();
                    }
                }
            }

        }

        protected void btnCancelGroup_Click(object sender, EventArgs e)
        {
            PopUpDisplayNone();
            txtGroupName.Text = string.Empty;
            LoadAllUsers();
            LoadAllGroups();
        }

        public void PopUpDisplayNone()
        {
            PopupSendMail.Style.Add("display", "none");
            ViewMemberPopup.Style.Add("display", "none");
        }
    }
}