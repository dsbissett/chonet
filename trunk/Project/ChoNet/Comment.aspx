<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Comment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhận xét</title>
    <link rel="Stylesheet" href="Css/admin.css" />
    <link rel="Stylesheet" href="Css/style.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnGuiNhanXet" defaultfocus="txtNguoiNhanXet">
    <div style="width:400px">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td style="width: 30%" align="right">
        Người nhận xét :</td> 
    <td>
        <asp:TextBox ID="txtNguoiNhanXet" runat="server" Width="95%"></asp:TextBox></td> 
       </tr>
       <tr>
    <td align="right">
        Nội dung :</td> 
    <td>
        <asp:TextBox ID="txtNoiDung" runat="server" Height="100px" TextMode="MultiLine" Width="95%"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoiDung" ErrorMessage="*"></asp:RequiredFieldValidator></td> 
       </tr>
       <tr>
    <td style="height: 20px" align="right"></td> 
    <td></td> 
       </tr>
       <tr>
    <td align="right"></td> 
    <td>
        <asp:Button ID="btnGuiNhanXet" runat="server" CssClass="button" Text="Gửi nhận xét" OnClick="btnGuiNhanXet_Click" /></td> 
       </tr>
    </table>
    </div>
    </form>
</body>
</html>
