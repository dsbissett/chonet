using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CHONET.DataAccessLayer.Web;
using CHONET.Common;

public partial class Adm_DetailConfig : System.Web.UI.Page
{
    public int CuaHangID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-Store only
            if (!Page.IsPostBack)
            {
                LoadHoTro();
                LoadQuangCao41();
                LoadQuangCao42();
            }
        }
    }
    private void LoadHoTro()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("../message.aspx?msg=You haven't got a store yet");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
            lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
            lblDiDong.Text = dr["DienThoaiDiDong"].ToString();
            CuaHangID = int.Parse(dr["CuaHangID"].ToString());
        }
    }
    private void LoadQuangCao41()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(Common.NguoiDungID(), 41);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao41.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"210\" height=\"75\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"210\" height=\"75\"></embed></object>";
            }
            else
            {
                spnQuangCao41.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                    + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                    + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"75px\" width=\"210px\" style=\"Border:none\"/></a>";
            }

        }
        else
        {
            spnQuangCao41.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"75px\" width=\"210px\" style=\"border:none\"/>";
        }
    }
    private void LoadQuangCao42()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 42);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao42a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao42b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao42c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao42a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"312\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao42a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao42b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"312\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao42b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                if (n >= 3)
                {
                    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao42c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"312\" height=\"122\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao42c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }
            }
        }
    }
    protected void pnlQuangCao41_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao41();
    }
    protected void pnlQuangCao42_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao42();
    }
    protected void pnlHoTro_ContentRefresh(object sender, EventArgs e)
    {
        LoadHoTro();
    }
}
