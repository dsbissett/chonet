<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendToFriend.aspx.cs" Inherits="SendToFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gửi cho bạn bè</title>
    <link type="text/css" href="Css/style.css" rel="Stylesheet" />
    <link type="text/css" href="Css/admin.css" rel="Stylesheet" />
    
    <script type="text/javascript" src="Scripts/WebForm.js"></script>

    <script type="text/javascript" src="Scripts/WebUIValidation.js"></script>

    <script type="text/javascript" src="Scripts/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:400px; height:180px">
        <table border="0" cellpadding="0" cellspacing="5" width="100%">
            <tr>
                <td  align="right">
                    Gửi tới</td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtNguoiNhan" runat="server" Width="95%"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNguoiNhan"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" valign="top" >
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Nội dung kèm theo" Width="120px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNoiDungKemTheo" runat="server" Height="100px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    </td>
                <td>
                    <asp:Button ID="btnGui" runat="server" CssClass="long-button" Text="Gửi" OnClick="btnGui_Click" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNguoiNhan"
                        ErrorMessage="Hãy nhập email hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
