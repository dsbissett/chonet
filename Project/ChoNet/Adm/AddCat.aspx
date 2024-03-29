﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCat.aspx.cs" Inherits="Admin_AddCat" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Category</title>    
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtTenNhomSanPham">
        <table cellpadding="0" cellspacing="0" style="width:100%; height:100%; text-align:center;vertical-align:middle;">
        <tr>
            <td> 
    <table style="text-align:left;">
        <tr>
            <td>
                <asp:label id="Label1" runat="server" text="Tên danh mục cha"></asp:label></td>
            <td>
                <asp:textbox id="txtTenNhomSanPham" runat="server" Width="200px" CssClass="textbox"></asp:textbox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenNhomSanPham"
                    ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:label id="Label2" runat="server" text="Thứ tự"></asp:label></td>
            <td>
                <igtxt:WebNumericEdit ID="txtThuTu" runat="server" Width="50px" DataMode="Int" HorizontalAlign="Left" MinValue="0" Nullable="False" NullText="0">
                </igtxt:WebNumericEdit></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr><td></td><td><asp:button id="btnLuu" runat="server" text="Lưu" OnClick="btnLuu_Click" Width="77px" CssClass="short-button" /></td></tr>
</table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
