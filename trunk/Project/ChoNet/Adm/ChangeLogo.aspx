<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeLogo.aspx.cs" Inherits="ChangeLogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thay đổi logo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    Ảnh</td>
                <td style="width: 345px">
                    <asp:FileUpload ID="fileStore" runat="server" Width="337px" /></td>
            </tr>
            <tr>
                <td style="height: 89px">
                </td>
                <td style="height: 89px; width: 345px;">
                    <asp:Image ID="imgStore" runat="server" Height="73px" Width="110px" /></td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top: 10px; text-align: center; height: 35px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="short-button" 
                        Text="Lưu" OnClick="btnSave_Click" Width="62px" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
