<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdv.aspx.cs" Inherits="Admin_AddAdv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Adv</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript"> 
        
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="5">
<tr>
    <td>
        <table width="100%" border="0" cellspacing="1" cellpadding="0">
            <tr>
                <td>
                    URL</td>
                <td>
                    <asp:TextBox ID="txtDuongDan" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Nội dung quảng cáo</td>
                <td>
                    <asp:TextBox ID="txtNoiDung" runat="server" Rows="3" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Ảnh/Flash (<300KB)</td>
                <td>
                    <asp:FileUpload ID="fileQuangCao" runat="server" Width="300px" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RadioButton ID="rbtImage" runat="server" Checked="True" GroupName="MediaType"
                        Text="Ảnh" />
                    <asp:RadioButton ID="rbtFlash" runat="server" GroupName="MediaType" Text="Flash" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <img id="imgAnhQuangCao" runat="server" alt="Anh/Flash quang cao" height="200" src="" width="300" visible="false" />
                    <span id="flashQuangCao" runat="server" visible="false"></span>
                    </td>
            </tr>
            <tr>
                <td>
                    Ghi chú</td>
                <td>
                    <asp:TextBox ID="txtGhiChu" runat="server" Rows="3" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top: 10px; text-align: center">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Lưu (Ctrl + S)" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
        </td>
</tr>
</table>
    </form>
</body>
</html>
