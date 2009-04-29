<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LostPassword.aspx.cs" Inherits="LostPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Quên mật khẩu</title>
    <link rel="Stylesheet" href="../Css/admin.css" />
    <link rel="Stylesheet" href="../Css/style.css" />
    <script type="text/javascript" src="../Scripts/Common.js"></script>    
    <script type="text/javascript" src="../Scripts/WebForm.js"></script>
    <script type="text/javascript" src="../Scripts/WebUIValidation.js"></script>    
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:300px; padding-left:15px">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td style="height: 40px; text-align: center" colspan="2">
                Điền email để lấy lại mật khẩu</td>
            </tr>
            <tr>
                <td style="width: 100px">Email của bạn:</td>
                <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*"
                    SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
              <tr>
                <td style="height: 20px"></td>
                <td>
                 <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email không hợp lệ" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
               <tr>
                <td></td>
                <td style="text-align: center">
                    <asp:Button ID="btnGui" runat="server" Text="Gửi" CssClass="long-button" OnClick="btnGui_Click" Width="81px" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
