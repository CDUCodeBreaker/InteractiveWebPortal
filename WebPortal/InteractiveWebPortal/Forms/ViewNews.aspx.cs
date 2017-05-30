using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class ViewNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllNews();
            }
        }

        private void LoadAllNews()
        {
            DataTable dtNews = News_BL.ListAllNews();
            if (dtNews.Rows.Count > 0)
            {
                gvNewsList.DataSource = dtNews;
                gvNewsList.DataKeyNames = NewsDataKeys();
                gvNewsList.DataBind();
            }
            else
            {
                LoadEmptyNews();
            }
        }

        private void LoadEmptyNews()
        {
            DataTable dtNews = CreateNewsDataTable();
            for (int i = 0; i < 5; i++)
            {
                dtNews.Rows.Add(dtNews.NewRow());
            }
            gvNewsList.DataSource = dtNews;
            gvNewsList.DataKeyNames = NewsDataKeys();
            gvNewsList.DataBind();
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
    }
}