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
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_Cat1Config : System.Web.UI.Page
{
    public int mcid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["mcid"] != null)
                {
                    mcid = int.Parse(Request.QueryString["mcid"]);                    
                }
                LoadDanhMuc();
                //LoadQuangCao11();
                LoadQuangCao12();
                LoadQuangCao13();
                LoadSanPham11();
                LoadSanPham12();
                LoadSanPham13();
                LoadSanPham14();
                LoadGianHang();
                NhomSanPham nsp = new NhomSanPham();
                DataSet ds = nsp.SelectByID(mcid);
                if (ds.Tables[0].Rows.Count == 1) lblDanhMuc.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                hidCatId.Value = mcid.ToString();
            }
            else
            {
                mcid = int.Parse(hidCatId.Value);
            }            
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    private void LoadDanhMuc()
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
        ds.Tables[0].DefaultView.Sort = "SapXep ASC";
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Set default category
            if(mcid == 0) mcid = int.Parse(ds.Tables[0].Rows[0]["NhomSanPhamID"].ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {                
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                td.Text = "<a href=\"cat1config.aspx?mcid=" + dr["NhomSanPhamID"].ToString() + "\">" + dr["TenNhomSanPham"].ToString() + "</a>";
                tr.Cells.Add(td);
                tblDanhMuc.Rows.Add(tr);                
            }
        }
    }
    //private void LoadQuangCao11()
    //{
    //    QuangCao qcao = new QuangCao();
    //    DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(mcid, 11);
    //    if (ds.Tables[0].Rows.Count >= 1)
    //    {
    //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
    //        {
    //            spnQuangCao11.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
    //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
    //                + "width=\"210\" height=\"75\" title=\"Quang Cao\">"
    //                + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
    //                + "<param name=\"quality\" value=\"high\" />"
    //                + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
    //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
    //                + "width=\"210\" height=\"75\"></embed></object>";
    //        }
    //        else
    //        {
    //            spnQuangCao11.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
    //                + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
    //                + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"75px\" width=\"210px\" style=\"Border:none\"/></a>";
    //        }

    //    }
    //    else
    //    {
    //        spnQuangCao11.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"75px\" width=\"210px\" style=\"border:none\"/>";
    //    }
    //}
    private void LoadQuangCao12()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(mcid, 12);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao12.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"792\" height=\"216\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"792\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao12.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                   + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                   + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"216px\" width=\"792px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao12.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
        }
    }
    private void LoadQuangCao13()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(mcid, 13);
        int n = 4;
        if (ds.Tables[0].Rows.Count <= 4) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px;";
            string content = "";
            if (ds.Tables[0].Rows[i]["LoaiAnh"].ToString() == "FLASH")
            {
                content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"220\" height=\"155\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"220\" height=\"155\"></embed></object>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"].ToString()
                            + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"].ToString()
                            + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString()
                            + "\" style=\"border:solid 1px #C9C3C3; width:220px;\"></a>";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao13.Rows.Add(tr);
        }
    }
    private void LoadSanPham11()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(11, mcid);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 5; i++)
        {
            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><img src=\"." + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
                    + "\" width=\"99\" height=\"89\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></td>";
                content += "</tr><tr><td align=\"center\">" + ds.Tables[0].Rows[i]["TenSanPham"].ToString() + "<br />";
                content += "Giá: <span class=\"price\">" + String.Format("{0:0,0}",ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",",".") 
                    + "</span><br/>" + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</td></tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(20);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham11.Rows.Add(tr);
    }
    private void LoadSanPham12()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(12, mcid);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 5; i++)
        {
            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><img src=\"." + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
                    + "\" width=\"179\" height=\"159\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></td>";
                content += "</tr><tr><td align=\"center\"><b>" + ds.Tables[0].Rows[i]["TenSanPham"].ToString() + "</b><br />";
                content += "Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                    + "</span> " + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</td></tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(20);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham12.Rows.Add(tr);
    }
    private void LoadSanPham13()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(13, mcid);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    double GiaCu = double.Parse("0" + ds.Tables[0].Rows[j * 4 + i]["GiaSanPham"].ToString());
                    double GiaMoi = double.Parse("0" + ds.Tables[0].Rows[j * 4 + i]["GiaKhuyenMai"].ToString());
                    if (GiaMoi != 0)
                    {
                        if (GiaMoi < GiaCu)
                        {
                            content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td>";
                            content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                                + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                            content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                                + "<br />Giá cũ: <span class=\"oldprice\">" + String.Format("{0:0,0}", GiaCu).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "<br/>";
                            content += "Giá mới: <span class=\"price\">" + String.Format("{0:0,0}", GiaMoi).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                        }
                        else
                        {
                            content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td>";
                            content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                                + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                            content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                                + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", GiaMoi).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                        }
                    }
                    else
                    {
                        content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                        content += "<tr><td>";
                        content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                            + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                        content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                            + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", GiaCu).Replace(",", ".")
                            + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                    }
                    
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham13.Rows.Add(tr);
        }
    }
    private void LoadSanPham14()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(14, mcid);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td>";
                    content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                        + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                    content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                        + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[j * 4 + i]["GiaSanPham"]).Replace(",", ".")
                        + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham14.Rows.Add(tr);
        }
    }
    private void LoadGianHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectCuaHangAtViTriCuaHang(11);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 4; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><img src=\"." + ds.Tables[0].Rows[j * 4 + i]["Anh"].ToString() + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></td>";
                    content += "<td><a href=\"#\"><b>" + ds.Tables[0].Rows[j * 4 + i]["TenCuaHang"].ToString() + "</b></a></td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblGianHang.Rows.Add(tr);
        }
    }
    protected void pnlQuangCao11_ContentRefresh(object sender, EventArgs e)
    {
        //LoadQuangCao11();
    }
    protected void pnlQuangCao12_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao12();
    }
    protected void pnlQuangCao13_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao13();
    }   
    protected void pnlSanPham11_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham11();
    }
    protected void pnlSanPham12_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham12();
    }
    protected void pnlSanPham13_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham13();
    }
    protected void pnlSanPham14_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham14();
    }
    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadGianHang();
    }
}
