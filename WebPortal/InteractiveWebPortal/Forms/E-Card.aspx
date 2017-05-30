<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E-Card.aspx.cs" Inherits="InteractiveWebPortal.Forms.E_Card" %>


<script type="text/javascript" src="../assets/plugins/jquery-1.10.1.min.js"></script>
<script type="text/javascript" src="../assets/scripts/html2canvas.min.js"></script>

<script type="text/javascript">
    function ConvertToImage(btnExport) {
        html2canvas($("#ECard")[0]).then(function (canvas) {
            var base64 = canvas.toDataURL();
            $("[id*=hfImageData]").val(base64);
            __doPostBack(btnExport.name, "");
        });
        return false;
    }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


        <div id="ECard" style="width: 340px; background-color: White; padding: 5px">
            <table border="1" style="border-collapse: collapse; background-color: maroon">
                <tr>
                    <td style="width: 177px; border-color: maroon">
                        <img src="NewFolder1/trump.jpg" id="userimage" runat="server" alt="Avatar" style="height: 80px; width: 120px" /></td>
                    <td style="width: 177px; text-align: right; border-color: maroon">
                        <asp:Label ID="lblName" runat="server" Font-Bold="true" Style="color: white; font-family: Cambria" Text=""></asp:Label><br />
                        <asp:Label ID="lblMemberShipNo" runat="server" Font-Bold="true" Style="color: white; font-family: Cambria" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 177px; border-color: maroon"></td>
                    <td style="width: 177px; text-align: right; border-color: maroon">
                        <asp:Image ID="imgQRCode" runat="server" Height="112px" Width="132px" /></td>
                </tr>


            </table>
        </div>
        <asp:HiddenField ID="hfImageData" runat="server" />
        <asp:Button ID="btnExport" Text="Export & Send" runat="server" UseSubmitBehavior="false"
            OnClick="ExportToImage" OnClientClick="return ConvertToImage(this)" />
    </form>
</body>
</html>
