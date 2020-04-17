<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='https://www.google.com/recaptcha/api.js' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" style="width:100%;" id="tb_captcha" runat="server"> 
                <tr>
                    <td>
                        <div class="g-recaptcha" data-sitekey="CHAVE_SITE"></div>                
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnIncluir" runat="server" Text="TESTAR" ClientIDMode="Static" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
