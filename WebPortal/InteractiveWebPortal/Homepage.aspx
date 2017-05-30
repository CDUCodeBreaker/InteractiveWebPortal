<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="InteractiveWebPortal.Homepage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Welcome to the webportal</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/home.css" rel="stylesheet">
   
</head>
<body>
    <div class="banner">
        <nav class="navbar navbar-default my-navbar">
            <div class="container">
                <!-- Brand and toggle get grouped for better mobile display -->
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="Registration.aspx"><span class="glyphicon glyphicon-user"></span>Register</a></li>
                    <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>
                </ul>
            </div>
        </nav>
        <div class="container">

            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <%-- <li data-target="#myCarousel" data-slide-to="3"></li>
                    <li data-target="#myCarousel" data-slide-to="4"></li>--%>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item active">
                        <img src="Images/homeImage/h2.jpg" alt="Los Angeles" style="width: 100%;">
                    </div>
                    <div class="item">
                        <img src="Images/homeImage/h3.jpg" alt="New york" style="width: 100%;">
                    </div>
                     <div class="item">
                        <img src="Images/homeImage/h1.jpg" alt="Chicago" style="width: 100%;">
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>
     <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>

