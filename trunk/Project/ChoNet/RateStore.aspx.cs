using System;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class RateStore : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["CuaHangID"] = Request.QueryString["sid"];
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            int? giaca = null;
            int? chatluong = null;
            int? baohanh = null;
            int? phucvu = null;
            int? chung = null;

            if (!rbtGiaCa.Checked)
                giaca = rbtGiaCa1.Checked
                            ? 1
                            : (rbtGiaCa2.Checked
                                   ? 2
                                   : (
                                         rbtGiaCa3.Checked
                                             ? 3
                                             : (rbtGiaCa4.Checked
                                                    ? 4
                                                    : (rbtGiaCa5.Checked
                                                           ? 5
                                                           : (rbtGiaCa6.Checked
                                                                  ? 6
                                                                  : (
                                                                        rbtGiaCa7.Checked
                                                                            ? 7
                                                                            : (rbtGiaCa8.Checked
                                                                                   ? 8
                                                                                   : (rbtGiaCa9.Checked
                                                                                          ? 9
                                                                                          : (rbtGiaCa10.Checked ? 10 : 0)))))))));

            if (!rbtPhucVu.Checked)
                phucvu = rbtPhucVu1.Checked
                             ? 1
                             : (rbtPhucVu2.Checked
                                    ? 2
                                    : (
                                          rbtPhucVu3.Checked
                                              ? 3
                                              : (rbtPhucVu4.Checked
                                                     ? 4
                                                     : (rbtPhucVu5.Checked
                                                            ? 5
                                                            : (rbtPhucVu6.Checked
                                                                   ? 6
                                                                   : (
                                                                         rbtPhucVu7.Checked
                                                                             ? 7
                                                                             : (rbtPhucVu8.Checked
                                                                                    ? 8
                                                                                    : (rbtPhucVu9.Checked
                                                                                           ? 9
                                                                                           : (rbtPhucVu10.Checked
                                                                                                  ? 10
                                                                                                  : 0)))))))));

            if (!rbtChatLuong.Checked)
                chatluong = rbtChatLuong1.Checked
                                ? 1
                                : (rbtChatLuong2.Checked
                                       ? 2
                                       : (
                                             rbtChatLuong3.Checked
                                                 ? 3
                                                 : (rbtChatLuong4.Checked
                                                        ? 4
                                                        : (rbtChatLuong5.Checked
                                                               ? 5
                                                               : (rbtChatLuong6.Checked
                                                                      ? 6
                                                                      : (
                                                                            rbtChatLuong7.Checked
                                                                                ? 7
                                                                                : (rbtChatLuong8.Checked
                                                                                       ? 8
                                                                                       : (rbtChatLuong9.Checked
                                                                                              ? 9
                                                                                              : (rbtChatLuong10.Checked
                                                                                                     ? 10
                                                                                                     : 0)))))))));

            if (!rbtBaoHanh.Checked)
                baohanh = rbtBaoHanh1.Checked
                              ? 1
                              : (rbtBaoHanh2.Checked
                                     ? 2
                                     : (
                                           rbtBaoHanh3.Checked
                                               ? 3
                                               : (rbtBaoHanh4.Checked
                                                      ? 4
                                                      : (rbtBaoHanh5.Checked
                                                             ? 5
                                                             : (rbtBaoHanh6.Checked
                                                                    ? 6
                                                                    : (
                                                                          rbtBaoHanh7.Checked
                                                                              ? 7
                                                                              : (rbtBaoHanh8.Checked
                                                                                     ? 8
                                                                                     : (rbtBaoHanh9.Checked
                                                                                            ? 9
                                                                                            : (rbtBaoHanh10.Checked
                                                                                                   ? 10
                                                                                                   : 0)))))))));

            if (!rbtChung.Checked)
                chung = rbtChung1.Checked
                            ? 1
                            : (rbtChung2.Checked
                                   ? 2
                                   : (
                                         rbtChung3.Checked
                                             ? 3
                                             : (rbtChung4.Checked
                                                    ? 4
                                                    : (rbtChung5.Checked
                                                           ? 5
                                                           : (rbtChung6.Checked
                                                                  ? 6
                                                                  : (
                                                                        rbtChung7.Checked
                                                                            ? 7
                                                                            : (rbtChung8.Checked
                                                                                   ? 8
                                                                                   : (rbtChung9.Checked
                                                                                          ? 9
                                                                                          : (rbtChung10.Checked ? 10 : 0)))))))));

            BinhChon bc = new BinhChon();
            bc.InsertFields(int.Parse("0" + ViewState["CuaHangID"]), Common.NguoiDungID(), giaca, phucvu,
                            baohanh, chatluong, chung, null, null, null, giaca != 0, phucvu != 0, baohanh != 0,
                            chatluong != 0, chung != 0, txtTieuDe.Value, txtNoiDung.Value);

            string strScript = "<script language='JavaScript'>" +
                               "dialogArguments.opener.RefreshCuaHang();this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "RefreshCuaHang", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}