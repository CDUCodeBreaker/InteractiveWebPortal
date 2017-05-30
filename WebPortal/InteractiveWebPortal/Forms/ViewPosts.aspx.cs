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
    public partial class ViewPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminpost.jpg);background-size:cover;");
                LoadAllPosts();
            }
        }

        private void LoadAllPosts()
        {
            DataTable dtPost = Post_BL.ListAllPosts();
            if (dtPost.Rows.Count > 0)
            {
                gvPost.DataSource = dtPost;
                gvPost.DataKeyNames = PostDataKeys();
                gvPost.DataBind();
            }
            else
            {
                LoadEmptyPost();
            }
        }

        private void LoadEmptyPost()
        {
            DataTable dtPost = new DataTable();
            for (int i = 0; i < 5; i++)
            {
                dtPost.Rows.Add(dtPost.NewRow());
            }
            gvPost.DataSource = dtPost;
            gvPost.DataKeyNames = PostDataKeys();
            gvPost.DataBind();
        }

        private string[] PostDataKeys()
        {
            return new string[] { "PostID", "PostSubject", "PostBody" };
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {

        }

        private void LoadComments(int PostID)
        {
            DataTable dtComment = Comment_BL.ListAllCommentsByPostID(PostID);
            if (dtComment.Rows.Count > 0)
            {
                gvComment.DataSource = dtComment;
                gvComment.DataKeyNames = CommentDataKeys();
                gvComment.DataBind();
            }
            else
            {
                LoadEmptyComment();
            }
        }

        private void LoadEmptyComment()
        {
            DataTable dtComment = CreateCommentTable();
            for (int i = 0; i < 10; i++)
            {
                dtComment.Rows.Add(dtComment.NewRow());
            }
            gvComment.DataSource = dtComment;
            gvComment.DataKeyNames = CommentDataKeys();
            gvComment.DataBind();
        }

        private DataTable CreateCommentTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CommentID", typeof(string));
            dt.Columns.Add("Comment", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            return dt;
        }

        private string[] CommentDataKeys()
        {
            return new string[] { "CommentID", "Comment", "CreateDate", "CreatedBy" };
        }

        protected void btnViewComment_Click(object sender, EventArgs e)
        {
            addcommentpopup.Style.Add("display", "none");
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int postID = Convert.ToInt32(gvPost.DataKeys[rowindex]["PostID"]);
            string PostBody = Convert.ToString(gvPost.DataKeys[rowindex]["PostBody"]);
            lblHeader.Text = PostBody;
            LoadComments(postID);
            viewcommentpopup.Style.Add("display", "block");
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "";
            viewcommentpopup.Style.Add("display", "none");
            addcommentpopup.Style.Add("display", "block");
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int postID = Convert.ToInt32(gvPost.DataKeys[rowindex]["PostID"]);
            ViewState["PostID"] = postID;
            txtComment.Enabled = true;
            btnSaveComment.Enabled = true;
            btnCancelComment.Enabled = true;

        }

        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (txtComment.Text != string.Empty)
            {
                int commentID = 0;
                Comment_BO objCommentBO = LoadCommentInformation();
                Comment_BL objCommentBL = new Comment_BL();
                commentID = objCommentBL.InsertComment(objCommentBO, Convert.ToInt32(ViewState["PostID"]));
                if (commentID > 0)
                {
                    txtComment.Text = string.Empty;
                    ViewState["PostID"] = null;
                    addcommentpopup.Style.Add("display", "none");
                }
            }
        }

        private Comment_BO LoadCommentInformation()
        {
            Comment_BO objCommentBO = new Comment_BO();
            objCommentBO.Comment = txtComment.Text.Trim();
            objCommentBO.CommentType = 1;
            objCommentBO.CreatedBy = Session["Name"].ToString();
            objCommentBO.Status = 1;
            return objCommentBO;
        }

        protected void btnCancelComment_Click(object sender, EventArgs e)
        {
            addcommentpopup.Style.Add("display", "none");
            viewcommentpopup.Style.Add("display", "none");
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {

        }
    }
}