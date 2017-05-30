using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class CreateNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllNews();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void LoadAllNews()
        {
            DataTable dtNews = News_BL.ListAllNews();
            if (dtNews.Rows.Count > 0)
            {
                gvNews.DataSource = dtNews;
                gvNews.DataKeyNames = NewsDataKeys();
                gvNews.DataBind();
            }
            else
            {
                LoadEmptyNews();
            }
        }

        private void LoadEmptyNews()
        {
            DataTable dtNews = CreateNewsDataTable();
            for (int i = 0; i < 10; i++)
            {
                dtNews.Rows.Add(dtNews.NewRow());
            }
            gvNews.DataSource = dtNews;
            gvNews.DataKeyNames = NewsDataKeys();
            gvNews.DataBind();
        }

        private DataTable CreateNewsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NewsID", typeof(string));
            dt.Columns.Add("NewsHeadLine", typeof(string));
            dt.Columns.Add("NewsBody", typeof(string));
            dt.Columns.Add("CreatedBy", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));
            dt.Columns.Add("UpdateDate", typeof(string));
            return dt;
        }

        private string[] NewsDataKeys()
        {
            return new string[] { "NewsID", "NewsHeadLine", "NewsBody", "CreatedBy", "CreateDate", "Status", "UpdateBy", "UpdateDate" };
        }

        protected void btnEditNews_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int newsID = Convert.ToInt32(gvNews.DataKeys[rowindex]["NewsID"]);
            string newsHeadLine = Convert.ToString(gvNews.DataKeys[rowindex]["NewsHeadLine"]);
            string newsBody = Convert.ToString(gvNews.DataKeys[rowindex]["NewsBody"]);

            txtHeadLine.Text = newsHeadLine;
            txtNewsBody.Text = newsBody;
            ViewState["NewsID"] = newsID;
        }

        protected void btnDeleteNews_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
            int newsID = Convert.ToInt32(gvNews.DataKeys[rowindex]["NewsID"]);
            News_BL objNewsBL = new News_BL();
            objNewsBL.DeleteNews(newsID);
            LoadAllNews();
        }

        protected void btnSubmitNews_Click(object sender, EventArgs e)
        {
            if (txtNewsBody.Text != string.Empty && txtHeadLine.Text != string.Empty)
            {
                int newsID = 0;
                News_BO objNewsBO = LoadNewsInformation();
                News_BL objNewsBL = new News_BL();
                if (Convert.ToInt32(ViewState["NewsID"]) > 0)
                {
                    newsID = objNewsBL.UpdateNews(objNewsBO);
                }
                else
                {
                    newsID = objNewsBL.SaveNews(objNewsBO);
                }
                if (newsID > 0)
                {
                    LoadAllNews();
                    txtHeadLine.Text = string.Empty;
                    txtNewsBody.Text = string.Empty;
                    ViewState["NewsID"] = null;
                }
            }
        }

        private News_BO LoadNewsInformation()
        {
            News_BO objNewsBo = new News_BO();
            if (ViewState["NewsID"] != null)
            {
                objNewsBo.NewsID = Convert.ToInt32(ViewState["NewsID"]);
                objNewsBo.UpdateBy = "Admin";
            }
            objNewsBo.NewsHeadLine = txtHeadLine.Text.Trim();
            objNewsBo.NewsBody = txtNewsBody.Text.Trim();
            objNewsBo.Status = 1;
            objNewsBo.CreatedBy = "Admin";
            return objNewsBo;
        }

        protected void btnCancelNews_Click(object sender, EventArgs e)
        {
            txtHeadLine.Text = string.Empty;
            txtNewsBody.Text = string.Empty;
        }
    }
}