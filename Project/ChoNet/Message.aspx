<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Message</title>
    <link type="text/css" rel="Stylesheet" href="App_Themes/Default/Default.css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="100%">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: center">
                    </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
