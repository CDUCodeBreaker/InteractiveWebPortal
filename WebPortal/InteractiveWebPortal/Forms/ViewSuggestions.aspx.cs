using BL;
using BO;
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
    public partial class ViewSuggestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminsuggestion.jpg); background-size:cover;");
                LoadAllSuggestions();
                popupreply.Style.Add("display", "none");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllSuggestions()
        {
            DataTable dtSuggestions = Suggestion_BL.ListAllSuggestions();
            if (dtSuggestions.Rows.Count > 0)
            {
                gvSuggestionList.DataSource = dtSuggestions;
                gvSuggestionList.DataKeyNames = SuggestionDataKeys();
                gvSuggestionList.DataBind();
            }
            else
            {
                LoadEmptySuggestions();
            }
        }

        private string[] SuggestionDataKeys()
        {
            return new string[] { "SuggestionID", "Suggestions", "CreatedBy", "CreateDate", "UserID" };
        }

        private void LoadEmptySuggestions()
        {
            DataTable dtSuggestion = CreateSuggestionDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtSuggestion.Rows.Add(dtSuggestion.NewRow());
            }
            gvSuggestionList.DataSource = dtSuggestion;
            gvSuggestionList.DataKeyNames = SuggestionDataKeys();
            gvSuggestionList.DataBind();
        }

        private DataTable CreateSuggestionDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SuggestionID", typeof(int));
            dt.Columns.Add("Suggestions", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("UserID", typeof(int));
            return dt;
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            popupreply.Style.Add("display", "block");
            txtReply.Text = string.Empty;
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int SuggestionID = Convert.ToInt32(gvSuggestionList.DataKeys[rowindex]["SuggestionID"]);
            ViewState["SuggestionID"] = SuggestionID;
            LoadAllReplyBySuggestionID();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtReply.Text != string.Empty)
            {
                int replyID = 0;

                Suggestion_Reply_BO objSuggestionReplyBO = LoadReplyInformation();
                Suggestion_Reply_BL objSuggestionReplyBL = new Suggestion_Reply_BL();
                replyID = objSuggestionReplyBL.SaveSuggestionReply(objSuggestionReplyBO);
                LoadAllReplyBySuggestionID();
            }
        }

        private Suggestion_Reply_BO LoadReplyInformation()
        {
            Suggestion_Reply_BO objSuggestionReplyBO = new Suggestion_Reply_BO();
            objSuggestionReplyBO.Reply = txtReply.Text.Trim();
            objSuggestionReplyBO.SuggestionID = Convert.ToInt32(ViewState["SuggestionID"]);
            objSuggestionReplyBO.RepliedBy = Session["Name"].ToString();
            return objSuggestionReplyBO;
        }

        private void LoadAllReplyBySuggestionID()
        {
            DataTable dtReply = Suggestion_Reply_BL.ListAllReplyBySuggestionID(Convert.ToInt32(ViewState["SuggestionID"]));
            if (dtReply.Rows.Count > 0)
            {
                gvReplySuggestion.DataSource = dtReply;
                gvReplySuggestion.DataKeyNames = SuggestionReplyDataKeys();
                gvReplySuggestion.DataBind();
            }
            else
            {
                LoadEmptyReply();
            }
        }

        private void LoadEmptyReply()
        {
            DataTable dtEmptyReply = CreateReplyDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtEmptyReply.Rows.Add(dtEmptyReply.NewRow());
            }
            gvReplySuggestion.DataSource = dtEmptyReply;
            gvReplySuggestion.DataKeyNames = SuggestionReplyDataKeys();
            gvReplySuggestion.DataBind();
        }

        private DataTable CreateReplyDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ReplyID", typeof(string));
            dt.Columns.Add("SuggestionID", typeof(string));
            dt.Columns.Add("Reply", typeof(string));
            dt.Columns.Add("RepliedBy", typeof(string));
            dt.Columns.Add("ReplyDate", typeof(string));
            return dt;
        }

        private string[] SuggestionReplyDataKeys()
        {
            return new string[] { "ReplyID", "SuggestionID", "Reply", "RepliedBy", "ReplyDate" };
        }
    }
}