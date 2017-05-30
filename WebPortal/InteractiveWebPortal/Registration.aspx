<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="InteractiveWebPortal.Registration" %>

<%--<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Web Portal</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/todc-bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages/login.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/light.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="login">
    <!-- BEGIN LOGO -->
    <div class="logo">
        <img src="assets/img/com-logo.png" height="10px" width="130px" alt="" />
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <div class="content">
        <!-- BEGIN LOGIN FORM -->
        <form class="form-vertical login-form" autocomplete="off" runat="server">
            <h3 class="form-title">Create your account</h3>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">First Name</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-user" aria-hidden="true"></i>
                        <asp:TextBox ID="txtFirstName" class="m-wrap placeholder-no-fix" placeholder="First Name" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Last Name</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-user" aria-hidden="true"></i>
                        <asp:TextBox ID="txtLastName" class="m-wrap placeholder-no-fix" placeholder="Last Name" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Email</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-envelope" aria-hidden="true"></i>
                        <asp:TextBox ID="txtEmail" class="m-wrap placeholder-no-fix" placeholder="Email" onblur="return validate()" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Date Of Birth</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-calendar" aria-hidden="true"></i>
                        <asp:TextBox ID="txtDateOfBirth" class="m-wrap placeholder-no-fix" placeholder="Date Of Birth" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Mobile No</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-phone" aria-hidden="true"></i>
                        <asp:TextBox ID="txtMobileNo" class="m-wrap placeholder-no-fix" placeholder="Mobile No" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    Upload Picture
                    <asp:FileUpload ID="FileUploadControl"  runat="server" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Address1</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-location-arrow" aria-hidden="true"></i>
                        <asp:TextBox ID="txtAddress1" class="m-wrap placeholder-no-fix" placeholder="Address1" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Address2</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-location-arrow" aria-hidden="true"></i>
                        <asp:TextBox ID="txtAddress2" class="m-wrap placeholder-no-fix" placeholder="Address2" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Post Code</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-envelope" aria-hidden="true"></i>
                        <asp:TextBox ID="txtPostCode" class="m-wrap placeholder-no-fix" placeholder="Post Code" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <div class="dropdown">
                    Suburb
                    <asp:DropDownList ID="ddlSuburb" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <div class="dropdown">
                    State
                    <asp:DropDownList ID="ddlStates" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <div class="dropdown">
                    Country
                    <asp:DropDownList ID="ddlCountry" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Password</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-lock"></i>
                        <asp:TextBox ID="txtPassword" class="m-wrap placeholder-no-fix" TextMode="Password" placeholder="Password" onblur="checkPass(); return false;" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label visible-ie8 visible-ie9">Confirm Password</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-lock"></i>
                        <asp:TextBox ID="txtconfirmpassword" class="m-wrap placeholder-no-fix" TextMode="Password" placeholder="Confirm Password" onblur="checkPass(); return false;" runat="server"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="forget-password" style="text-align: center">
                <p>
                    <asp:Button ID="btnSignUp" class="btn btn-primary" OnClick="btnSignUp_Click" runat="server" OnClientClick="if ( ! CheckFormValidation()) return false;" Text="Sign Up" />
                    <asp:Button ID="btnBackToSignIn" class="btn btn-primary" OnClick="btnBackToSignIn_Click" runat="server" Text="Back" />
                </p>
            </div>
        </form>
        <!-- END LOGIN FORM -->
    </div>
    <!-- END LOGIN -->
    <!-- BEGIN JAVASCRIPTS -->
    <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <!-- END CORE PLUGINS -->
    <script src="assets/scripts/app.js"></script>
    <script src="assets/scripts/notify.js"></script>
    <script src="assets/scripts/notify.min.js"></script>
    <script src="assets/scripts/webPortalScript.js"></script>

    <script>
        jQuery(document).ready(function () {
            App.init();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#txtDateOfBirth').datepicker({
                format: 'dd/mm/yyyy'
            });
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>--%>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Registration </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/todc-bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages/login.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/light.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="favicon.ico" />
    <link href="css/regist.css" rel="stylesheet" type="text/css" media="all">
   
</head>


<body>
    <div class="agileheader">
        <br />
    </div>
    <div class="main-w3l">
        <div class="w3layouts-main">
            <h3>JOIN TODAY! </h3>
            <form id="registrationForm" autocomplete="off" runat="server">
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtFirstName"
                            placeholder="Enter your first name" type="fname" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtLastName" placeholder="Enter your last Name" type="lname" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtEmail" placeholder="Enter your email" type="email" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtDateOfBirth" placeholder="Enter your date of birth" type="dob" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtMobileNo" placeholder="Enter your mobile no" type="phone" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:FileUpload ID="FileUploadControl" CssClass="fileupload" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtAddress1" placeholder="Enter your address1" type="address" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtAddress2" placeholder="Enter your address2" type="address" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtPostCode" placeholder="Enter your postcode" type="postcode" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlSuburb" class="dropdown" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlStates" class="dropdown" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlCountry" class="dropdown" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtPassword" class="password" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:TextBox ID="txtconfirmpassword" class="password" TextMode="Password" placeholder="Confirm Password" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:Button ID="btnSignUp" class="btn btn-primary" OnClick="btnSignUp_Click" runat="server" OnClientClick="if ( ! CheckFormValidation()) return false;" Text="Sign Up" />
                        <asp:Button ID="btnBackToSignIn" class="btn btn-primary" OnClick="btnBackToSignIn_Click" runat="server" Text="Back" />
                    </div>
                </div>
            </form>
        </div>
    </div>

    <script src="assets/scripts/webPortalScript.js"></script>
    <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="//ajax.aspnetcdn.com/ajax/jQuery.validate/1.11.1/jquery.validate.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <!-- END CORE PLUGINS -->
    <script src="assets/scripts/app.js"></script>
    <script src="assets/scripts/notify.js"></script>
    <script src="assets/scripts/notify.min.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#txtDateOfBirth').datepicker({
                format: 'dd/mm/yyyy'
            });
        });
    </script>
</body>
</html>
