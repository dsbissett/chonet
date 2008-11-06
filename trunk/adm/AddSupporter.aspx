<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSupporter.aspx.cs" Inherits="Admin_AddSupporter" %>

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
                 Hỗ trợ</td>
             <td>
                 <asp:TextBox ID="txtHoTro" runat="server" CssClass="textbox" Width="200px"></asp:TextBox></td>
         </tr>
        <tr>
             <td>
                 Họ và tên</td>
             <td>
                <asp:textbox id="txtHoVaTen" runat="server" CssClass="textbox" Width="200px"></asp:textbox></td>
        </tr>
         <tr>
             <td>
                 YM</td>
             <td>
                 <asp:TextBox ID="txtYM" runat="server" CssClass="textbox" Width="200px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtYM"
                    ErrorMessage="*">*</asp:RequiredFieldValidator></td>
         </tr>
        <tr>
            <td>
                Email</td>           
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
         <tr>
             <td>
                 Điện Thoại</td>
             <td>
                 <asp:TextBox ID="txtDienThoai" runat="server" CssClass="textbox" Width="200px"></asp:TextBox></td>
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
