using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal.Forms
{
    public partial class ChangeYourPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            User objUserBO = new User();
            User_BL objUserBL = new User_BL();
            objUserBL.UpdateUserPasswordByUserID(UserID, txtNewPass.Text.Trim());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPass.Text = string.Empty;
            txtRepeatPass.Text = string.Empty;
            txtTempPass.Text = string.Empty;
        }
    }
}