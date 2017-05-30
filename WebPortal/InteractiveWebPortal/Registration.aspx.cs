using BL;
using BO;
using Common;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveWebPortal
{
    public partial class Registration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSuburb();
                LoadState();
                LoadCountry();
                txtEmail.AutoCompleteType = AutoCompleteType.Disabled;
            }
        }

        private void LoadSuburb()
        {
            DataTable dtSuburbs = Suburb_BL.ListSuburbs();
            ddlSuburb.DataSource = dtSuburbs;
            ddlSuburb.DataTextField = "Name";
            ddlSuburb.DataValueField = "ID";
            ddlSuburb.DataBind();
        }

        private void LoadState()
        {
            DataTable dtStates = States_BL.ListStates();
            ddlStates.DataSource = dtStates;
            ddlStates.DataTextField = "Name";
            ddlStates.DataValueField = "ID";
            ddlStates.DataBind();
        }

        private void LoadCountry()
        {
            DataTable dtCountry = Country_BL.ListCountry();
            ddlCountry.DataSource = dtCountry;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string filename = Convert.ToString(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()).Replace(" ", "_");
            User objuser = LoadUserInformation();
            User_BL objUserBL = new User_BL();
            int uid = objUserBL.SaveUser(objuser);
            if (uid > 0)
            {
                FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/MemberPhotos/") + filename + ".jpg");
                Response.Redirect("Login.aspx");
                // EmailHelper objEmailHelper = new EmailHelper();
                // objEmailHelper.SendMail(txtEmail.Text.Trim());
            }
        }

        private User LoadUserInformation()
        {
            User objuser = new User();
            objuser.FirstName = txtFirstName.Text.Trim().ToString();
            objuser.LastName = txtLastName.Text.Trim().ToString();
            objuser.UserType = 2;
            objuser.Email = txtEmail.Text.Trim().ToString();
            objuser.Password = txtPassword.Text.Trim().ToString();
            objuser.MobileNo = txtMobileNo.Text.Trim().ToString();
            if (txtDateOfBirth.Text == string.Empty)
            {
                objuser.DateOfBirth = DateTime.Now;
            }
            else
            {
                objuser.DateOfBirth = DateTime.ParseExact(txtDateOfBirth.Text.Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            objuser.Address1 = txtAddress1.Text.Trim().ToString();
            objuser.Address2 = txtAddress2.Text.Trim().ToString();
            objuser.PostalCode = txtPostCode.Text.Trim().ToString();
            objuser.Suburb = ddlSuburb.SelectedItem.Text.ToString();
            objuser.State = ddlStates.SelectedItem.Text.ToString();
            objuser.Country = ddlCountry.SelectedItem.Text.ToString();
            objuser.Status = 1;
            objuser.IsActive = false;
            objuser.CreateDate = DateTime.Now;
            objuser.FileName = Convert.ToString(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()).Replace(" ", "_") + ".jpg";
            objuser.FilePath = "~/MemberPhotos/" + Convert.ToString(txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()).Replace(" ", "_") + ".jpg";

            return objuser;
        }

        protected void btnBackToSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}