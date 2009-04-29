<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="SendActiveMail.aspx.cs" Inherits="SendActiveMail" Title="Gửi lại thư kích hoạt" %>
<asp:Content ContentPlaceHolderID="cphMain" ID="contentSendMail" runat="server">

    <div>
    <table border="0" width="100%"><tr><td style="text-align: center">
        <span style="font-size: 16pt"><span style="font-size: 12pt">
            <br />
            <span style="font-size: 11pt">Hãy nhập email của bạn chúng tôi sẽ gửi lại thư
            kích hoạt!<br />
            </span></span>
            <br />
        </span></td></tr>
        <tr>
            <td align="center">
                <table border="0" width="50%"><tr>
                    <td align="center">
                        Email</td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Nhập email  không đúng!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSend" runat="server" CssClass="button" Text="Gửi thư kích hoạt" OnClick="btnSend_Click" Width="117px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>