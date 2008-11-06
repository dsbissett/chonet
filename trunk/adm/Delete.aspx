<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Admin_Delete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Delete</title>
    <link href="/ChoNet/Css/admin.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%; height:100%; vertical-align:middle;text-align:center;">
        <tr>
            <td>
                    <table style="width:100%;height:100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td rowspan="2">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/QuestionIcon1.jpg" /></td>
            <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
        <asp:Label ID="lblMessage" runat="server" Text="Bạn có muốn xóa?" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
        <asp:Button ID="btnXoa" runat="server" Text="Xóa" Width="57px" OnClick="btnXoa_Click" CssClass="short-button" />
        <input id="Button1" type="button" value="Hủy" onclick="window.parent.CloseDialogWindow();" class="short-button" /></td>
        </tr>
    </table>
            </td>
        </tr>
    </table>

    </form>
</body>
</html>
