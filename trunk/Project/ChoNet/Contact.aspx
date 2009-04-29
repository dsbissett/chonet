<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EstoreMaster.master" CodeFile="Contact.aspx.cs"
    Inherits="Contact" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphEstore">
    <table class="box2" cellspacing="0" cellpadding="0" width="100%" border="0" style="width: 402px;">
        <tbody>
            <tr>
                <td class="title">
                    Liên hệ</td>
            </tr>
            <tr>
                <td class="box2_bor" style="height: 280px; padding-left:20px">
                    <div runat="server" id="divGianHang" style="padding-left:20">
                        
                    </div>
                    <hr />
              <div style="width: 402px; height: 180px" class="box2">
                            <table border="0" cellpadding="0" cellspacing="5" width="100%">
                                <tr>
                                    <td align="right">
                                        Từ: &nbsp;</td>
                                    <td style="width: 70%">
                                        <asp:TextBox ID="txtNguoiGui" runat="server" Width="95%"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNguoiGui" ErrorMessage="*"
                                            Width="1px"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Tiêu đề: &nbsp;
                                    </td>
                                    <td style="width: 70%">
                                        <asp:TextBox ID="txtTieuDe" runat="server" Width="95%"></asp:TextBox></td>
                                </tr>
                                <tr style="color: #666666">
                                    <td align="right" valign="top">
                                        Nội dung: &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtNoiDungKemTheo" runat="server" Height="100px" TextMode="MultiLine"
                                            Width="95%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGui" runat="server" CssClass="long-button" OnClick="btnGui_Click"
                                            Text="Gửi" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNguoiGui"
                                            ErrorMessage="Hãy nhập email hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                </tr>
                            </table>
                        </div></td></tr>
        </tbody>
    </table>
    <br />
</asp:Content>
