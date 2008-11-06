<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Adm_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr height="24">
                        <td width="1">
                            <img src="../Images/ShoppingCartLeft.jpg"></td>
                        <td background="../Images/ShoppingCartBkg.jpg">
                            <div class="template_title" style="padding-top: 4px;">
                                Giỏ hàng</div>
                        </td>
                        <td width="1">
                            <img src="../Images/ShoppingCartright.jpg"></td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td width="1" background="../Images/4.jpg">
                            <img src="../Images/4.jpg"></td>
                        <td>
                            <div style="padding: 5px;">
                                <div class="cart_estore_name">
                                    Giỏ hàng của bạn tại công ty <b style="color: red;">Không gian sách</b> (Chỉ bán
                                    hàng online - Xin vui lòng liên hệ trước khi tới cửa hàng - Tel : (04) 2780757)</div>
                                <div align="right">
                                    <table style="border-collapse: collapse;" width="98%" border="1" bordercolor="#cccccc"
                                        cellpadding="4" cellspacing="1">
                                        <tbody>
                                            <tr class="left_menu" align="center" bgcolor="#f2f2f2">
                                                <td width="1%" nowrap="nowrap">
                                                    Thứ tự</td>
                                                <td>
                                                    Tên sản phẩm</td>
                                                <td>
                                                    Giá (VNĐ)</td>
                                                <td>
                                                    Giá (USD)</td>
                                                <td>
                                                    Số Lượng</td>
                                                <td>
                                                    Tổng (VNĐ)</td>
                                                <td>
                                                    Xóa</td>
                                            </tr>
                                            <tr>
                                                <td class="compare_text" align="right">
                                                    1</td>
                                                <td>
                                                    <a href="http://vatgia.com/khonggiansach&amp;&amp;module=product&amp;view=detail&amp;record_id=49612"
                                                        class="top_menu">Đời Tôi - My Life Bill Clinton</a></td>
                                                <td class="compare_text" align="right">
                                                    170.000</td>
                                                <td class="product_price_2" align="right">
                                                    10</td>
                                                <td align="right">
                                                    <input name="quantity1" value="1" size="5" class="form_textbox" style="text-align: right;"
                                                        type="text"></td>
                                                <td class="compare_text" align="right">
                                                    170.000</td>
                                                <td align="center">
                                                    <input value="1" name="delete1" type="checkbox"></td>
                                            </tr>
                                            <tr>
                                                <td class="compare_text" align="right">
                                                    2</td>
                                                <td>
                                                    <a href="http://vatgia.com/khonggiansach&amp;&amp;module=product&amp;view=detail&amp;record_id=25292"
                                                        class="top_menu">Thế Giới Phẳng - Tóm Lược Lịch Sử Thế Giới Thế Kỷ XXI</a></td>
                                                <td class="compare_text" align="right">
                                                    82.000</td>
                                                <td class="product_price_2" align="right">
                                                    5</td>
                                                <td align="right">
                                                    <input name="quantity2" value="1" size="5" class="form_textbox" style="text-align: right;"
                                                        type="text"></td>
                                                <td class="compare_text" align="right">
                                                    82.000</td>
                                                <td align="center">
                                                    <input value="1" name="delete2" type="checkbox"></td>
                                            </tr>
                                            <tr align="left">
                                                <td colspan="3" align="center">
                                                    <input class="form_control" value="Thanh toán" onclick='window.location.href="payment.php?step=1&amp;estore_id=3058"'
                                                        type="button">
                                                    <input class="form_control" value="Tiếp tục mua hàng" onclick='window.location.href="detail.php?&amp;module=product&amp;iPro=25292&amp;iCat=701"'
                                                        type="button">
                                                    <input class="form_control" value="Tính lại" type="submit">
                                                    <input class="form_control" value="Xóa hết" onclick="if(confirm('Bạn có muốn xóa hết giỏ hàng tại công ty Không gian sách?')) { window.location.href='recount.php?clear=1&amp;estore_id=3058&amp;return=ZGV0YWlsLnBocD8mbW9kdWxlPXByb2R1Y3QmaVBybz0yNTI5MiZpQ2F0PTcwMQ=='; }"
                                                        type="button">
                                                </td>
                                                <td colspan="3" class="product_price" align="right">
                                                    <font color="#333333">Thành tiền : </font>252.000 VNĐ</td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <hr size="1" color="#cccccc">
                                <div class="cart_estore_name">
                                    Giỏ hàng của bạn tại công ty <b style="color: red;">Công ty TECHLAND</b> (35 Hàng
                                    Khay - Hoàn Kiếm - Tel : (04) 936 5333)</div>
                                <div align="right">
                                    <table style="border-collapse: collapse;" width="98%" border="1" bordercolor="#cccccc"
                                        cellpadding="4" cellspacing="1">
                                        <tbody>
                                            <tr class="left_menu" align="center" bgcolor="#f2f2f2">
                                                <td width="1%" nowrap="nowrap">
                                                    Thứ tự</td>
                                                <td>
                                                    Tên sản phẩm</td>
                                                <td>
                                                    Giá (VNĐ)</td>
                                                <td>
                                                    Giá (USD)</td>
                                                <td>
                                                    Số Lượng</td>
                                                <td>
                                                    Tổng (VNĐ)</td>
                                                <td>
                                                    Xóa</td>
                                            </tr>
                                            <tr>
                                                <td class="compare_text" align="right">
                                                    1</td>
                                                <td>
                                                    <a href="http://vatgia.com/techland&amp;&amp;module=product&amp;view=detail&amp;record_id=21073"
                                                        class="top_menu">Canon PowerShot S5 IS</a></td>
                                                <td class="compare_text" align="right">
                                                    6.318.400</td>
                                                <td class="product_price_2" align="right">
                                                    359</td>
                                                <td align="right">
                                                    <input name="quantity1" value="1" size="5" class="form_textbox" style="text-align: right;"
                                                        type="text"></td>
                                                <td class="compare_text" align="right">
                                                    6.318.400</td>
                                                <td align="center">
                                                    <input value="1" name="delete1" type="checkbox"></td>
                                            </tr>
                                            <tr align="left">
                                                <td colspan="3" align="center">
                                                    <input class="form_control" value="Thanh toán" onclick='window.location.href="payment.php?step=1&amp;estore_id=11256"'
                                                        type="button">
                                                    <input class="form_control" value="Tiếp tục mua hàng" onclick='window.location.href="detail.php?&amp;module=product&amp;iPro=25292&amp;iCat=701"'
                                                        type="button">
                                                    <input class="form_control" value="Tính lại" type="submit">
                                                    <input class="form_control" value="Xóa hết" onclick="if(confirm('Bạn có muốn xóa hết giỏ hàng tại công ty Công ty TECHLAND?')) { window.location.href='recount.php?clear=1&amp;estore_id=11256&amp;return=ZGV0YWlsLnBocD8mbW9kdWxlPXByb2R1Y3QmaVBybz0yNTI5MiZpQ2F0PTcwMQ=='; }"
                                                        type="button">
                                                </td>
                                                <td colspan="3" class="product_price" align="right">
                                                    <font color="#333333">Thành tiền : </font>6.318.400 VNĐ</td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <hr size="1" color="#cccccc">
                            </div>
                        </td>
                        <td width="1" background="../Images/6.jpg">
                            <img src="../Images/6.jpg"></td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr height="2">
                        <td width="3">
                            <img src="../Images/1.jpg"></td>
                        <td background="../Images/2.jpg">
                            <img src="../Images/2.jpg"></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
