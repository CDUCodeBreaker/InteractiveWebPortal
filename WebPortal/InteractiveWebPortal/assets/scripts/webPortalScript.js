function CheckFormValidation() {
    var firstname = document.getElementById("txtFirstName").value;
    var lastname = document.getElementById("txtLastName").value;
    var email = document.getElementById("txtEmail").value;
    var dateofbirth = document.getElementById("txtDateOfBirth").value;
    var mobileno = document.getElementById("txtMobileNo").value;
    var address1 = document.getElementById("txtAddress1").value;
    var address2 = document.getElementById("txtAddress2").value;
    var postcode = document.getElementById("txtPostCode").value;
    var password = document.getElementById("txtPassword").value;
    var confirmpassword = document.getElementById("txtconfirmpassword").value;

    if (!document.getElementById("txtFirstName").value) {
        $('#txtFirstName').notify('Required!');
    }
    if (!document.getElementById("txtLastName").value) {
        $('#txtLastName').notify('Required!');
    }
    if (!document.getElementById("txtEmail").value) {
        $('#txtEmail').notify('Required!');
    }
    else {
        validate();
    }
    if (!document.getElementById("txtDateOfBirth").value) {
        $('#txtDateOfBirth').notify('Required!');
    }
    if (!document.getElementById("txtMobileNo").value) {
        $('#txtMobileNo').notify('Required!');
    }
    if (!document.getElementById("txtAddress1").value) {
        $('#txtAddress1').notify('Required!');
    }
    if (!document.getElementById("txtAddress2").value) {
        $('#txtAddress2').notify('Required!');
    }
    if (!document.getElementById("txtPostCode").value) {
        $('#txtPostCode').notify('Required!');
    }
    if (!document.getElementById("txtPassword").value) {
        $('#txtPassword').notify('Required!');
    }
    if (!document.getElementById("txtconfirmpassword").value) {
        $('#txtconfirmpassword').notify('Required!');
    }
    if (!firstname || !lastname || !dateofbirth || !email || !mobileno || !address1 || !address2 || !postcode || !password || !confirmpassword) {
        return false;
    }
    else
        return true;
}

function CheckEventValidation()
{
    alert("hi");
    //var firstname = document.getElementById("txtEventName").value;
    //var lastname = document.getElementById("txtEventDescription").value;
    //var email = document.getElementById("txtStartDate").value;
    //var dateofbirth = document.getElementById("txtStartTime").value;
    //var mobileno = document.getElementById("txtEndDate").value;
    //var address1 = document.getElementById("txtEndTime").value;
    //var address2 = document.getElementById("txtAddress2").value;
    //var postcode = document.getElementById("txtPostCode").value;
    //var password = document.getElementById("txtPassword").value;
    //var confirmpassword = document.getElementById("txtconfirmpassword").value;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validate() {
    var email = $("#txtEmail").val();
    if (validateEmail(email)) {
    } else {
        $('#txtEmail').notify('Invalid!');
    }
    return false;
}

function checkPass() {
    var pass1 = document.getElementById('txtPassword');
    var pass2 = document.getElementById('txtconfirmpassword');
    var goodColor = "#66cc66";
    var badColor = "#ff6666";
    if (pass1.value == pass2.value) {
        pass2.style.backgroundColor = goodColor;
        $(pass2).notify('Passwords Match!', 'success');
    } else {
        pass2.style.backgroundColor = badColor;
        $(pass2).notify('Passwords Do Not Match!');
    }

    function CheckLoginFormValidation()
    {
        var email = document.getElementById("txtEmail").value;
        var password = document.getElementById("txtPassword").value;
        if (!document.getElementById("txtEmail").value) {
            $('#txtEmail').notify('Required!');
        }
        if (!document.getElementById("txtPassword").value) {
            $('#txtPassword').notify('Required!');
        }

        if (!email || !password) {
            return false;
        }
        else
            return true;
    }

    
}  