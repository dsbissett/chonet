<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateStore.aspx.cs" Inherits="RateStore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đánh giá</title>
    <link type="text/css" href="Css/style.css" rel="Stylesheet" />
    <link type="text/css" href="Css/admin.css" rel="Stylesheet" />

    <script type="text/javascript" src="Scripts/WebForm.js"></script>

    <script type="text/javascript" src="Scripts/WebUIValidation.js"></script>

    <script type="text/javascript" src="Scripts/common.js"></script>

    <script type="text/javascript" id="igClientScript">
    function resetdanhgia()
    {        
        rbtgiaca = document.getElementById('<%=rbtGiaCa.ClientID %>');
        rbtphucvu = document.getElementById('<%=rbtPhucVu.ClientID %>');
        rbtbaohanh = document.getElementById('<%=rbtBaoHanh.ClientID %>');
        rbtchatluong = document.getElementById('<%=rbtChatLuong.ClientID %>');
        rbtchung = document.getElementById('<%=rbtChung.ClientID %>');
        txttieude = document.getElementById('<%=txtTieuDe.ClientID %>');
        txtnoidung = document.getElementById('<%=txtNoiDung.ClientID %>');        
        rbtgiaca.checked = true;
        rbtphucvu.checked = true;
        rbtbaohanh.checked = true;
        rbtchatluong.checked = true;
        rbtchung.checked = true;
        
        txttieude.value='';
        txtnoidung.value='';
        
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px;
                    padding-top: 10px; padding-right: 10px; padding-bottom: 10px; padding-left: 10px;">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 512px">
                        <tbody>
                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                <td style="padding-top: 10px; padding-right: 10px; padding-bottom: 10px; padding-left: 10px;
                                    border-top-color: rgb(204, 204, 204); border-right-color: rgb(204, 204, 204);
                                    border-bottom-color: rgb(204, 204, 204); border-left-color: rgb(204, 204, 204);
                                    border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px;
                                    border-top-style: solid; border-right-style: solid; border-bottom-style: solid;
                                    border-left-style: solid; font-family: Verdana, Arial, Helvetica, sans-serif;
                                    font-size: 11px; color: rgb(102, 102, 102);">
                                    <table bgcolor="#E9E9E9" border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                <td  style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: rgb(102, 102, 102); height: 206px;">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="1">
                                                        <tbody>
                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                <td width="74%" colspan="2" align="left" valign="top" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 198px;">
                                                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                                        <tbody>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td height="20" align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <b>Tiêu chí đánh giá</b></td>
                                                                                <td height="20" colspan="3" align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <strong>Kém</strong></td>
                                                                                <td height="20" colspan="3" align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <strong>Bình thường</strong></td>
                                                                                <td height="20" colspan="2" align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <strong>Tốt</strong></td>
                                                                                <td height="20" colspan="2" align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <strong>Suất sắc</strong></td>
                                                                                <td width="64" height="20" align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td width="85" align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                </td>
                                                                                <td width="37" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    1</td>
                                                                                <td width="20" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    2</td>
                                                                                <td height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    3</td>
                                                                                <td height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px;">
                                                                                    4</td>
                                                                                <td width="29" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    5</td>
                                                                                <td width="22" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    6</td>
                                                                                <td height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    7</td>
                                                                                <td height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px;">
                                                                                    8</td>
                                                                                <td width="33" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    9</td>
                                                                                <td width="25" height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    10</td>
                                                                                <td height="10" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    Không chọn</td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    Giá cả</td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa1" runat="server" GroupName="GiaCa"  />
                                                                                </td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa2" runat="server" GroupName="GiaCa"  />
                                                                                </td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px; height: 30px;">
                                                                                    &nbsp;<asp:RadioButton ID="rbtGiaCa3" runat="server" GroupName="GiaCa"  /></td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px; height: 30px;">
                                                                                    &nbsp;<asp:RadioButton ID="rbtGiaCa4" runat="server" GroupName="GiaCa"  /></td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    &nbsp;<asp:RadioButton ID="rbtGiaCa5" runat="server" GroupName="GiaCa"  /></td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    &nbsp;<asp:RadioButton ID="rbtGiaCa6" runat="server" GroupName="GiaCa"  /></td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px; height: 30px;">
                                                                                    &nbsp;<asp:RadioButton ID="rbtGiaCa7" runat="server" GroupName="GiaCa"  /></td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px; height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa8" runat="server" GroupName="GiaCa"  />
                                                                                </td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa9" runat="server" GroupName="GiaCa"  />
                                                                                </td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa10" runat="server" GroupName="GiaCa"  />
                                                                                </td>
                                                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); height: 30px;">
                                                                                    <asp:RadioButton ID="rbtGiaCa" runat="server" Checked="True" GroupName="GiaCa"  /></td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    Thái độ phục vụ</td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu1" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu2" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtPhucVu3" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px;">
                                                                                    <asp:RadioButton ID="rbtPhucVu4" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu5" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu6" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtPhucVu7" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px;">
                                                                                    <asp:RadioButton ID="rbtPhucVu8" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu9" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu10" runat="server" GroupName="PhucVu"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtPhucVu" runat="server" Checked="True" GroupName="PhucVu"
                                                                                         /></td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    Chế độ bảo hành</td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh1" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh2" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtBaoHanh3" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px;">
                                                                                    <asp:RadioButton ID="rbtBaoHanh4" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh5" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh6" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtBaoHanh7" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px;">
                                                                                    <asp:RadioButton ID="rbtBaoHanh8" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh9" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh10" runat="server" GroupName="BaoHanh"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtBaoHanh" runat="server" Checked="True" GroupName="BaoHanh"
                                                                                         /></td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td align="left" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    Chất lượng sản phẩm</td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong1" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong2" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtChatLuong3" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px;">
                                                                                    <asp:RadioButton ID="rbtChatLuong4" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong5" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong6" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtChatLuong7" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px;">
                                                                                    <asp:RadioButton ID="rbtChatLuong8" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong9" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong10" runat="server" GroupName="ChatLuong"  /></td>
                                                                                <td height="30" align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChatLuong" runat="server" Checked="True" GroupName="ChatLuong"
                                                                                         /></td>
                                                                            </tr>
                                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                                <td align="left" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <b>Nhận xét chung</b></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung1" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung2" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtChung3" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 28px;">
                                                                                    <asp:RadioButton ID="rbtChung4" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung5" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung6" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 26px;">
                                                                                    <asp:RadioButton ID="rbtChung7" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 22px;">
                                                                                    <asp:RadioButton ID="rbtChung8" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung9" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung10" runat="server" GroupName="Chung"  /></td>
                                                                                <td height="30" align="center" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                                    <asp:RadioButton ID="rbtChung" runat="server" Checked="True" GroupName="Chung"  /></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                <td bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                </td>
                                            </tr>
                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                <td height="30" bgcolor="#CCCCCC" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                    <b>Ý kiến của bạn về gian hàng</b></td>
                                            </tr>
                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                <td align="center" bgcolor="#FFFFFF" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                    <table width="80%" border="0" cellspacing="2" cellpadding="2">
                                                        <tbody>
                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                <td height="30" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                </td>
                                                                <td height="30" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 299px;">
                                                                    </td>
                                                            </tr>
                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                <td height="30" valign="top" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                    &nbsp;Tiêu đề</td>
                                                                <td height="30" align="left" valign="top" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 299px;">
                                                                    <input type="text" name="textfield" style="width: 250px;" id="txtTieuDe" runat="server"></td>
                                                            </tr>
                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                <td height="30" valign="top" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                    &nbsp;Nội dung</td>
                                                                <td height="30" align="left" valign="top" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 299px;">
                                                                    <textarea cols="29" rows="10" name="textarea" id="txtNoiDung" runat="server"></textarea></td>
                                                            </tr>
                                                            <tr style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: rgb(102, 102, 102);">
                                                                <td height="30" valign="top" nowrap="nowrap" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102);">
                                                                </td>
                                                                <td height="30" align="left" style="font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: rgb(102, 102, 102); width: 299px;">
                                                                    <span class="Apple-converted-space">&nbsp;<asp:Button ID="btnSend" runat="server" Text="Gửi đi" CssClass="button" OnClick="btnSend_Click" />
                                                                        <asp:Button ID="btnReset" runat="server" Text="Nhập lại" UseSubmitBehavior="False" CssClass="button" OnClientClick="resetdanhgia()" /></span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
        </div>
    </form>
</body>
</html>
