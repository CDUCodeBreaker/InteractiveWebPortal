using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtEmail.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User objUserBO = new User();
            User_BL objUserBL = new User_BL();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();


            if (email != string.Empty || password != string.Empty)
            {
                if (chkRememberMe.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtEmail.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();

                DataTable dtUser = new DataTable();
                objUserBO.Email = email;
                objUserBO.Password = password;
                dtUser = objUserBL.CheckLogin(objUserBO);
                if (dtUser.Rows.Count > 0)
                {
                    var UserID = dtUser.Rows[0]["UserID"].ToString();
                    var Email = dtUser.Rows[0]["Email"].ToString();
                    var Password = dtUser.Rows[0]["Password"].ToString();
                    var Name = dtUser.Rows[0]["FirstName"].ToString() + ' ' + dtUser.Rows[0]["LastName"].ToString();
                    var UserType = dtUser.Rows[0]["UserType"].ToString();
                    Session["UserID"] = UserID;
                    Session["Email"] = Email;
                    Session["Password"] = Password;
                    Session["Name"] = Name;
                    Session["UserType"] = UserType;
                    if (Convert.ToInt32(UserType) == 1)
                    {
                        Response.Redirect("Forms/MemberRequestList.aspx");
                    }
                    else
                    {
                        Response.Redirect("Forms/ViewPosts.aspx");
                    }
                }
            }
        }
    }
}