using BL;
using BO;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class CreatePost : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
                body.Attributes.Add("style", "background:url(/Images/adminpost.jpg);background-size:cover;");
                id01.Style.Add("display", "none");
                LoadAllPost();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllPost()
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
            for (int i = 0; i < 10; i++)
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

        protected void btnSubmitPost_Click(object sender, EventArgs e)
        {
            if (txtPostBody.Text != string.Empty && txtPostSubject.Text != string.Empty)
            {
                int postID = 0;
                Post_BO objPostBO = LoadPostInformation();
                Post_BL objPostBL = new Post_BL();
                if (Convert.ToInt32(ViewState["PostID"]) > 0)
                {
                    postID = objPostBL.UpdatePost(objPostBO);
                }
                else
                {
                    postID = objPostBL.SavePost(objPostBO);
                }
                if (postID > 0)
                {
                    LoadAllPost();
                    txtPostBody.Text = string.Empty;
                    txtPostSubject.Text = string.Empty;
                    ViewState["PostID"] = null;
                }
            }
        }

        private Post_BO LoadPostInformation()
        {
            Post_BO objPost = new Post_BO();
            if (ViewState["PostID"] != null)
            {
                objPost.PostID = Convert.ToInt32(ViewState["PostID"]);
                objPost.UpdateBy = Session["Name"].ToString();
            }
            objPost.PostSubject = txtPostSubject.Text.Trim();
            objPost.PostBody = txtPostBody.Text.Trim();
            objPost.Status = 1;
            objPost.CreatedBy = Session["Name"].ToString();
            return objPost;
        }

        protected void btnCancelPost_Click(object sender, EventArgs e)
        {
            txtPostBody.Text = string.Empty;
            txtPostSubject.Text = string.Empty;
            ViewState["PostID"] = null;
        }

        protected void btnEditPost_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int postID = Convert.ToInt32(gvPost.DataKeys[rowindex]["PostID"]);
            string postsubject = Convert.ToString(gvPost.DataKeys[rowindex]["PostSubject"]);
            string postBody = Convert.ToString(gvPost.DataKeys[rowindex]["PostBody"]);

            txtPostBody.Text = postBody;
            txtPostSubject.Text = postsubject;
            ViewState["PostID"] = postID;
            id01.Style.Add("display", "none");
        }

        protected void btnDeletePost_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int postID = Convert.ToInt32(gvPost.DataKeys[rowindex]["PostID"]);
            Post_BL objPostBL = new Post_BL();
            objPostBL.DeletePost(postID);
            LoadAllPost();
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int postID = Convert.ToInt32(gvPost.DataKeys[rowindex]["PostID"]);
            lblHeader.Text = Convert.ToString(gvPost.DataKeys[rowindex]["PostBody"]);
            LoadComments(postID);
            id01.Style.Add("display", "block");
            // mp1.Show();
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
            dt.Columns.Add("PostID", typeof(string));
            return dt;
        }

        private string[] CommentDataKeys()
        {
            return new string[] { "CommentID", "Comment", "CreateDate", "CreatedBy", "PostID" };
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            id01.Style.Add("display", "none");
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int commentID = Convert.ToInt32(gvComment.DataKeys[rowindex]["CommentID"]);
            int postID = Convert.ToInt32(gvComment.DataKeys[rowindex]["PostID"]);
            Comment_BL objCommentBL = new Comment_BL();
            objCommentBL.DeleteComment(commentID);
            LoadComments(postID);
        }

        protected void btnBlockComment_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int commentID = Convert.ToInt32(gvComment.DataKeys[rowindex]["CommentID"]);
            int postID = Convert.ToInt32(gvComment.DataKeys[rowindex]["PostID"]);
            Comment_BL objCommentBL = new Comment_BL();
            objCommentBL.BlockComment(commentID);
            LoadComments(postID);
        }

        protected void gvComment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "")
                {
                    e.Row.Enabled = false;
                }
            }
        }
    }

}