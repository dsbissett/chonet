<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Admin_AddUser" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm người dùng</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
// <!CDATA[
 


// ]]>
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="500px">
                <tr>
                    <td align="right" style="width: 20%">
                        Tên đầy đủ
                    </td>
                    <td style="width: 30%">
                        <input id="txtHoVaTen" maxlength="50" style="width: 90%" type="text" runat="server" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHoVaTen" ErrorMessage="Hãy nhập tên đầy đủ"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
                    <td align="right" style="width: 20%">
                        Ngày sinh</td>
                    <td style="width: 30%">
                        <igsch:WebDateChooser ID="wdcNgaySinh" runat="server" Width="95%" Value="1980-06-05">
                            <CalendarLayout Culture="Vietnamese (Vietnam)" DropDownYearsNumber="200">
                            </CalendarLayout>
                        </igsch:WebDateChooser>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 40px">
                        Tên truy cập</td>
                    <td>
                        <input id="txtTaiKhoan" maxlength="50" style="width: 90%" type="text" runat="server" /><asp:RequiredFieldValidator
                            ID="rfvTaiKhoan" runat="server" ControlToValidate="txtTaiKhoan" ErrorMessage="Hãy nhập tên truy cập">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblTonTaiTenTruyCap" runat="server" ForeColor="Red"></asp:Label></td>
                    <td align="right">
                        Mật khẩu</td>
                    <td>
                        <input id="txtMatKhau" runat="server" maxlength="50" style="width: 90%" type="text" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="Hãy nhập mật khẩu">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        Email
                    </td>
                    <td>
                        <input id="txtEmail" maxlength="50" style="width: 90%" type="text" runat="server" />
                    </td>
                    <td align="right">
                        Giới tính</td>
                    <td>
                        <asp:RadioButton ID="rbtNam" runat="server" Text="Nam" GroupName="GioiTinh" /><asp:RadioButton
                            ID="rbtNu" runat="server" Text="Nữ" GroupName="GioiTinh" /></td>
                </tr>
                <tr>
                    <td align="right">
                        ĐTDĐ
                    </td>
                    <td>
                        <input id="txtDienThoaiDiDong" maxlength="50" style="width: 90%" type="text" runat="server" /></td>
                    <td align="right">
                        ĐTCĐ</td>
                    <td>
                        <input id="txtDienThoaiCoDinh" maxlength="50" style="width: 90%" type="text" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">
                        YM</td>
                    <td>
                        <input id="txtYM" maxlength="50" style="width: 90%" type="text" runat="server" /></td>
                    <td align="right">
                        Kích hoạt</td>
                    <td>
                        <input id="chkKichHoat" type="checkbox" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">
                        Thuộc nhóm
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlLoaiNguoiDung" runat="server" Width="98%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Địa chỉ</td>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox1" runat="server" Height="75px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 15px" align="right">
                        <input id="hidmatkhau" runat="server" type="hidden" />
                        <input id="hidActiveCode" runat="server" type="hidden" /></td>
                </tr>
                <tr>
                    <td id="ValidateText" align="right" colspan="2" valign="middle">
                        <div id="rfvMessageThongBao" style="color: red"><input id="btnReset" runat="server" class="middle-button" type="button" value="Đặt lại mật khẩu"
                            onserverclick="btnReset_ServerClick" style="width: 84px" />
                            <input id="btnSendMail" runat="server" class="middle-button" type="button" value="Gửi thư kích hoạt"
                            onserverclick="btnSendMail_ServerClick" style="width: 92px" />&nbsp;</div>
                    </td>
                    <td align="right" colspan="2" valign="top">
                        <input id="btnLuu" runat="server" class="middle-button" type="button" value="Đồng ý"
                            onserverclick="btnLuu_ServerClick" />
                        &nbsp;<input id="btnThoat" runat="server" class="middle-button" size="20" type="button"
                            value="Huỷ bỏ" onclick='window.parent.CloseDialogWindow();' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
