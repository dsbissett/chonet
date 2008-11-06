<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpgradeStore.aspx.cs" Inherits="Admin_UpgradeStore" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nâng cấp gian hàng</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" style="width:100%; height:100%; text-align:center;vertical-align:middle;">
        <tr>
            <td> 
     <table style="text-align:left;">
        <tr>
             <td>
                 Gian Hàng</td>
             <td>
                 <asp:TextBox ID="txtTenCuaHang" runat="server" BackColor="WhiteSmoke" ReadOnly="True" CssClass="textbox" Width="200px"></asp:TextBox></td>
         </tr>
        <tr>
             <td>
                 Loại gian hàng</td>
             <td>
                 <asp:DropDownList ID="ddlLoaiGianHang" runat="server" Width="205px">
                     <asp:ListItem Value="3">Th&#244;ng thường</asp:ListItem>
                     <asp:ListItem Value="2">Chuy&#234;n nghiệp</asp:ListItem>
                     <asp:ListItem Value="1">VIP</asp:ListItem>
                 </asp:DropDownList></td>
        </tr>
         <tr>
             <td>
                 Bảo đảm</td>
             <td>
                 <asp:DropDownList ID="ddlBaoDam" runat="server" Width="64px">
                     <asp:ListItem>0</asp:ListItem>
                     <asp:ListItem Value="1">1</asp:ListItem>
                     <asp:ListItem Value="2">2</asp:ListItem>
                     <asp:ListItem Value="3">3</asp:ListItem>
                     <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>5</asp:ListItem>
                 </asp:DropDownList></td>
         </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:button id="btnLuu" runat="server" text="Lưu" OnClick="btnLuu_Click" Width="77px" CssClass="short-button" /></td></tr>
        </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
