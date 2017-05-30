<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="InteractiveWebPortal.ResetPassword" %>

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
        <form class="form-vertical login-form" autocomplete="off" runat="server">
            <h3 class="">Forget Password ?</h3>
            <p>Enter your e-mail address below to reset your password.</p>
            <div class="control-group">
                <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                <label class="control-label visible-ie8 visible-ie9">Email</label>
                <div class="controls">
                    <div class="input-icon left">
                        <i class="icon-user"></i>
                        <asp:TextBox ID="txtEmail" class="m-wrap placeholder-no-fix" placeholder="Email" name="email" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="text-align: center">
                <p>
                    <asp:Button ID="btnSendPassword" class="btn btn-primary" runat="server" OnClick="btnSendPassword_Click" Text="Sign Up" />
                    <asp:Button ID="btnBackToLogin" class="btn btn-primary" runat="server" OnClick="btnBackToLogin_Click" Text="Back" />
                </p>
            </div>
        </form>
        <!-- END FORGOT PASSWORD FORM -->
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
    <!-- END CORE PLUGINS -->
    <script src="assets/scripts/app.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>--%>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login</title>
    <link href="css/index.css" rel="stylesheet" type="text/css" media="all">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <div class="agileheader">
        <br />
    </div>
    <div class="main-w3l">
        <div class="w3layouts-main">
            <h3>Forget Password ?</h3>
            <form autocomplete="off" runat="server">
                <asp:TextBox ID="txtEmail"  placeholder="Email" type="email" runat="server"></asp:TextBox>
                <div class="clear">
                    <asp:Button ID="btnSendPassword" class="btn btn-primary" runat="server" OnClick="btnSendPassword_Click" Text="Send" />
                    <asp:Button ID="btnBackToLogin" class="btn btn-primary" runat="server" OnClick="btnBackToLogin_Click" Text="Back" />
                </div>
            </form>
            <p><a href="Homepage.aspx">Homepage</a></p>
        </div>
    </div>
</body>
</html>
