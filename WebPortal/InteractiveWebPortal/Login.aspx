<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InteractiveWebPortal.Login" %>

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
            <h3 style="font-family: 'Times New Roman'; font-size: 20px">Log in to your account</h3>
            <form autocomplete="off" runat="server">
                <asp:TextBox name="Email" ID="txtEmail" runat="server" type="email" required="" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '';}"></asp:TextBox>
                <asp:TextBox name="Password" ID="txtPassword" runat="server" type="password" required="" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = ' ;}"></asp:TextBox>
                <span style="font-family: 'Times New Roman'; font-size: 18px">
                    <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" /></span>
                <h6 style="font-family: 'Times New Roman'; font-size: 18px"><a href="ResetPassword.aspx">Forgot Password?</a></h6>
                <div class="clear">
                    <asp:Button ID="btnLogin" class="btn btn-primary pull-right" runat="server" OnClientClick="if ( ! CheckLoginFormValidation()) return false;" OnClick="btnLogin_Click" Text="Login" />
                </div>
            </form>
            <p style="font-family: 'Times New Roman'; font-size: 18px">Create Account.&nbsp<a href="Registration.aspx">Register Now</a></p>
            <br />

            <p style="font-family: 'Times New Roman'; font-size: 18px"><a href="Homepage.aspx">Homepage</a></p>
        </div>
    </div>
</body>
</html>
