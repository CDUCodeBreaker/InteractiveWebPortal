using System;
using System.Web.UI;

namespace InteractiveWebPortal.Forms
{
    public partial class WebPortal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            //body.Attributes.Add("background-color", "red");
            if (!IsPostBack)
            {
                if (Session["Name"] != null)
                {
                    lblName.Text = Session["Name"].ToString();
                    if (Convert.ToInt32(Session["UserType"]) == 1)
                    {
                        lblUserType.Text = "Admin";
                    }
                    else
                    {
                        lblUserType.Text = "Member";
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}