<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditComment.aspx.cs" Inherits="Adm_EditComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Css/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" style="width:100%; height:100%; text-align:center;vertical-align:middle;">
        <tr>
            <td> 
    <table style="text-align:left;">
        <tr>
            <td>
                Nội dung</td>
            <td rowspan="2">
                <asp:textbox id="txtNoiDung" runat="server" Width="400px" CssClass="textbox" Height="200px" TextMode="MultiLine"></asp:textbox></td>
        </tr>
        <tr>
            <td>
                </td>
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
    </div>
    </form>
</body>
</html>
