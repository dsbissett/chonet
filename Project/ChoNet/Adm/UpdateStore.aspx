<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateStore.aspx.cs" Inherits="Adm_UpdateStore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Update Store</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />  
</head>
<body>
    <form id="form1" runat="server">
        <table width="550px" border="0" cellspacing="4" cellpadding="0">
            <tr>
                <td style="width:150px">
                    Tên cửa hàng</td>
                <td style="width:400px">
                    <asp:TextBox ID="txtTen" runat="server" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Địa chỉ</td>
                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 19px">
                    Điện thoại cố định</td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtCoDinh" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Điện thoại di động</td>
                <td>
                    <asp:TextBox ID="txtDiDong" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Fax</td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Website</td>
                <td>
                    <asp:TextBox ID="txtWebSite" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Nick Yahoo</td>
                <td>
                    <asp:TextBox ID="txtYahoo" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Liên hệ</td>
                <td>
                    <asp:TextBox ID="txtLienHe" runat="server" Rows="6" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Giới thiệu</td>
                <td>
                    <asp:TextBox ID="txtGioiThieu" runat="server" Width="400px" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Ảnh</td>
                <td>
                    <asp:FileUpload ID="fileStore" runat="server" Width="400px" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Image ID="imgStore" runat="server" Height="73px" Width="110px" /></td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top: 10px; text-align: center">
                    <asp:Button ID="btnSave" runat="server" CssClass="short-button" OnClick="btnSave_Click"
                        Text="Lưu" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
