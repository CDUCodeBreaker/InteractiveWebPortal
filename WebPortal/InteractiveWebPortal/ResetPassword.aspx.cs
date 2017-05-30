using BL;
using BO;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendPassword_Click(object sender, EventArgs e)
        {

            User objUserBO = new User();
            User_BL objUserBL = new User_BL();
            DataTable dt = objUserBL.GetUserByEmail(txtEmail.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                string tempPass = RandomPasswordGenerator.CreateRandomPassword();
                objUserBL.UpdateUserPasswordByUserID(Convert.ToInt32(dt.Rows[0]["UserID"]), tempPass);
                EmailHelper objEmailHelper = new EmailHelper();
                objEmailHelper.SendEmailWithAttachment("", txtEmail.Text.Trim(), "Temporary Password", "Your temporary password is " + tempPass + "\n" + "Thank You." + "\n" + "WebPortal Team.");
            }
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}