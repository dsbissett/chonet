<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStoreSubCat.aspx.cs" Inherits="Admin_AddStoreSubCat" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add SubCat</title>
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
                 <asp:Label ID="Label3" runat="server" Text="Tên danh mục con"></asp:Label></td>
             <td>
                 <asp:TextBox ID="txtTenNhomSanPham" runat="server" BackColor="WhiteSmoke" ReadOnly="True" CssClass="textbox" Width="200px"></asp:TextBox></td>
         </tr>
        <tr>
             <td>
                <asp:label id="Label1" runat="server" text="Tên nhóm con"></asp:label></td>
             <td>
                <asp:textbox id="txtTenNhomCon" runat="server" CssClass="textbox" Width="200px"></asp:textbox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenNhomCon"
                    ErrorMessage="H?y nh?p tên nhóm con">*</asp:RequiredFieldValidator></td>
        </tr>
         <tr>
             <td>
                 <asp:Label ID="Label4" runat="server" Text="Nhóm sản phẩm chợ nét"></asp:Label></td>
             <td>
                 <asp:DropDownList ID="ddlNhomSanPham" runat="server" Width="205px">
                 </asp:DropDownList></td>
         </tr>
        <tr>
            <td>
                <asp:label id="Label2" runat="server" text="Thứ tự"></asp:label></td>           
            <td>
                <igtxt:webnumericedit id="txtThuTu" runat="server" datamode="Int" horizontalalign="Left"
                    minvalue="0" nullable="False" nulltext="0" width="50px" MaxLength="5"></igtxt:webnumericedit></td>
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
