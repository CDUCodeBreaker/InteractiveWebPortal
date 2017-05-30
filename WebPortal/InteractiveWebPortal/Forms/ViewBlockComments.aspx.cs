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
    public partial class ViewBlockComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/blockadmin.jpg); background-size:cover;");
                LoadAllBlockedComments();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllBlockedComments()
        {
            DataTable dtBlockedComments = Comment_BL.ListAllBlockedComments();
            if (dtBlockedComments.Rows.Count > 0)
            {
                gvBlockComment.DataSource = dtBlockedComments;
                gvBlockComment.DataKeyNames = BlockCommentDataKeys();
                gvBlockComment.DataBind();
            }
            else
            {

                LoadEmptyBlockComments();
            }
        }
        private DataTable CreateCommentTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommentID", typeof(string));
            dt.Columns.Add("Comment", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("PostID", typeof(string));
            return dt;
        }
        private string[] BlockCommentDataKeys()
        {
            return new string[] { "CommentID", "Comment", "CreateDate", "CreatedBy", "PostID" };
        }

        private void LoadEmptyBlockComments()
        {
            DataTable dtComment = CreateCommentTable();
            for (int i = 0; i < 10; i++)
            {
                dtComment.Rows.Add(dtComment.NewRow());
            }
            gvBlockComment.DataSource = dtComment;
            gvBlockComment.DataKeyNames = BlockCommentDataKeys();
            gvBlockComment.DataBind();
        }
    }
}