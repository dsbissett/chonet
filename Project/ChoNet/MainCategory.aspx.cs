using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class MainCategory : Page
{
    private int mcid;
    private int scid;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mcid = int.Parse("0" + Request.QueryString["mcid"]);
            if (Request.QueryString["mcid"] != null)
                scid = int.Parse("0" + Request.QueryString["scid"]);
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.Message);
        }
        if (!Page.IsPostBack)
        {
            try
            {
                LoadDanhMuc(mcid, scid);
                //LoadQuangCao11();
                LoadQuangCao12();
                LoadQuangCao13();
                LoadSanPham11();
                LoadSanPham12();
                LoadSanPham13();
                LoadSanPham14();
                LoadGianHang();
                loadSearchDropdown();
            }
            catch (Exception ex)
            {
                Response.Redirect("message.aspx?msg=" + ex.Message);
            }
        }
    }

    private void LoadDanhMuc(int mcid, int scid)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    td.CssClass = "leftmenu";
                    td.Text = "<a href=\"maincategory.aspx?mcid=" + dr["NhomSanPhamID"] + "\">" + dr["TenNhomSanPham"] +
                              "</a>";
                    tr.Cells.Add(td);
                    tblDanhMuc.Rows.Add(tr);
                    if (int.Parse(dr["NhomSanPhamID"].ToString()) == mcid)
                    {
                        //Danh muc con
                        lblDanhMuc.Text = dr["TenNhomSanPham"].ToString();
                        DataSet sds = nsp.SelectNhomSanPhamByNhomChaID(mcid);
                        sds.Tables[0].DefaultView.Sort = "SapXep ASC";
                        if (sds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow sdr in sds.Tables[0].Rows)
                            {
                                TableRow str = new TableRow();
                                TableCell std = new TableCell();
                                str.CssClass = "subleftmenu";
                                //std.Style.Value = "padding-left:50px";
                                std.Text = "<a href=\"maincategory.aspx?mcid=" + dr["NhomSanPhamID"] + "&scid=" +
                                           sdr["NhomSanPhamID"] + "\">" + "+ " + sdr["TenNhomSanPham"] + "</a>";
                                str.Cells.Add(std);
                                tblDanhMuc.Rows.Add(str);
                                if (int.Parse(sdr["NhomSanPhamID"].ToString()) == scid)
                                {
                                    //Danh muc con
                                    lblDanhMuc.Text = dr["TenNhomSanPham"].ToString();
                                    DataSet ssds = nsp.SelectNhomSanPhamByNhomChaID(scid);
                                    ssds.Tables[0].DefaultView.Sort = "SapXep ASC";
                                    if (ssds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow ssdr in ssds.Tables[0].Rows)
                                        {
                                            TableRow sstr = new TableRow();
                                            TableCell sstd = new TableCell();
                                            sstr.CssClass = "subleftmenu";
                                            //std.Style.Value = "padding-left:50px";
                                            sstd.Text = "<a href=\"subcategory.aspx?mcid=" + sdr["NhomSanPhamID"] +
                                                        "&scid=" +
                                                        ssdr["NhomSanPhamID"] + "\">" + "--- " + ssdr["TenNhomSanPham"] +
                                                        "</a>";
                                            sstr.Cells.Add(sstd);
                                            tblDanhMuc.Rows.Add(sstr);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadQuangCao11()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(mcid, 11);
        HtmlGenericControl spnQuangCao41 = (HtmlGenericControl) Master.FindControl("spnQuangCao01");
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao41.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"210\" height=\"75\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"210\" height=\"75\"></embed></object>";
            }
            else
            {
                spnQuangCao41.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"75px\" width=\"210px\" style=\"Border:none\"/></a>";
            }
        }
        else
        {
            spnQuangCao41.InnerHtml =
                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"75px\" width=\"210px\" style=\"border:none\"/>";
        }
    }

    private void LoadQuangCao12()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(mcid, 12);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao12.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"792\" height=\"216\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"792\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao12.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"216px\" width=\"792px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao12.InnerHtml =
                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
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
                          +
                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                          + "width=\"210\" height=\"155\" title=\"Quang Cao\">"
                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                          + "<param name=\"quality\" value=\"high\" />"
                          + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" quality=\"high\""
                          +
                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                          + "width=\"210\" height=\"155\"></embed></object>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                          + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"]
                          + "\" style=\"border:solid 1px #C9C3C3; width:210px; height:155px\"></a>";
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
                content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                           +
                           "\" width=\"99\" height=\"89\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\">" + ds.Tables[0].Rows[i]["TenSanPham"] + "</a><br />";
                content += "Giá: <span class=\"price\">" +
                           String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                           + "</span><br/>" + ds.Tables[0].Rows[i]["DonViTienTe"] + "</td></tr></table>";
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
        //San pham ua chuong
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectTopFourSanPhamUaChuongByNhomSanPhamID(mcid);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 5; i++)
        {
            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                           +
                           "\" width=\"179\" height=\"159\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "</tr><tr><td align=\"center\"><b><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\">" + ds.Tables[0].Rows[i]["TenSanPham"] + "</a></b><br />";
                content += "Giá: <span class=\"price\">" +
                           String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                           + "</span> " + ds.Tables[0].Rows[i]["DonViTienTe"] + "</td></tr></table>";
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
        //San pham giam gia
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamGiamGiaByNhomSanPhamID(mcid);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*4 + i < n)
                {
                    double GiaCu = double.Parse("0" + ds.Tables[0].Rows[j*4 + i]["GiaSanPham"]);
                    double GiaMoi = double.Parse("0" + ds.Tables[0].Rows[j*4 + i]["GiaKhuyenMai"]);
                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*4 + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*4 + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*4 + i]["SanPhamID"]
                               + "\">" + ds.Tables[0].Rows[j*4 + i]["TenSanPham"]
                               + "</a><br />Giá cũ: <span class=\"oldprice\">" +
                               String.Format("{0:0,0}", GiaCu).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*4 + i]["DonViTienTe"] + "<br/>";
                    content += "Giá mới: <span class=\"price\">" + String.Format("{0:0,0}", GiaMoi).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*4 + i]["DonViTienTe"] + "</td></tr></table>";
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
        //San pham moi cap nhat
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamMoiCapNhatByNhomSanPhamID(mcid);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*4 + i < n)
                {
                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*4 + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*4 + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*4 + i]["SanPhamID"]
                               + "\">" + ds.Tables[0].Rows[j*4 + i]["TenSanPham"]
                               + "</a><br />Giá: <span class=\"price\">" +
                               String.Format("{0:0,0}", ds.Tables[0].Rows[j*4 + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*4 + i]["DonViTienTe"] + "</td></tr></table>";
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
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 3; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*3 + i < n)
                {
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[j*3 + i]["CuaHangID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*3 + i]["Anh"]
                               + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></a></td>";
                    content += "<td><a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[j*3 + i]["CuaHangID"]
                               + "\"><b>" + ds.Tables[0].Rows[j*3 + i]["TenCuaHang"] + "</b></a></td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(33);
                tr.Cells.Add(td);
            }
            tblGianHang.Rows.Add(tr);
        }
    }

    private void loadSearchDropdown()
    {
        ddlDanhMuc.Items.Clear();
        NhomSanPham nhomsanpham = new NhomSanPham();
        DataSet ds = nhomsanpham.SelectNhomSanPhamByNhomChaID(0);

        ddlDanhMuc.Items.Insert(0, "Tất cả");
        ddlDanhMuc.Items[0].Value = "";

        int n = ddlDanhMuc.SelectedIndex;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem item = new ListItem("+ " + ds.Tables[0].Rows[i]["TenNhomSanPham"],
                                         ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString());
            ddlDanhMuc.Items.Add(item);
            DataSet subds =
                nhomsanpham.SelectNhomSanPhamByNhomChaID(int.Parse(ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString()));
            for (int j = 0; j < subds.Tables[0].Rows.Count; j++)
            {
                ListItem subitem = new ListItem("+.... " + subds.Tables[0].Rows[j]["TenNhomSanPham"],
                                                subds.Tables[0].Rows[j]["NhomSanPhamID"].ToString());
                ddlDanhMuc.Items.Add(subitem);
            }
        }

        HangSanXuat hsx = new HangSanXuat();
        DataSet dshsx = hsx.SelectAll();

        ddlHangSanXuat.DataSource = dshsx.Tables[0];
        ddlHangSanXuat.DataTextField = "TenHangSanXuat";
        ddlHangSanXuat.DataValueField = "HangSanXuatID";
        ddlHangSanXuat.DataBind();
        ddlHangSanXuat.Items.Insert(0, "Tất cả");
        ddlHangSanXuat.Items[0].Value = "";

        KhuVuc kv = new KhuVuc();
        DataSet dskv = kv.SelectAll();

        ddlKhuVuc.DataSource = dskv.Tables[0];
        ddlKhuVuc.DataTextField = "TenKhuVuc";
        ddlKhuVuc.DataValueField = "KhuVucID";
        ddlKhuVuc.DataBind();
        ddlKhuVuc.Items.Insert(0, "Tất cả");
        ddlKhuVuc.Items[0].Value = "";
    }

    protected void btnTimKiem_ServerClick(object sender, EventArgs e)
    {
        string strSearch = "";
        string strKeyWord = "";
        if (txtMaSanPham.Value.Trim() != "")
        {
            strSearch += " AND MaSoSanPham like '%" + txtMaSanPham.Value.Trim() + "%' ";
        }
        if (txtTenSanPham.Value.Trim() != "")
        {
            strSearch += " AND TenSanPham like '%" + txtTenSanPham.Value.Trim() + "%' ";
        }
        if (ddlDanhMuc.Value.Trim() != "")
        {
            strSearch += " AND NhomSanPhamID=" + int.Parse(ddlDanhMuc.Value.Trim()) + " ";
        }
        if (ddlHangSanXuat.Value.Trim() != "")
        {
            strSearch += " AND HangSanXuatID=" + int.Parse(ddlHangSanXuat.Value.Trim()) + " ";
        }
        if (ddlKhuVuc.Value.Trim() != "")
        {
            strSearch += " AND KhuVucID=" + int.Parse(ddlKhuVuc.Value.Trim()) + " ";
        }

        if (txtTuKhoa.Value.Trim() != "")
        {
            strKeyWord = txtTuKhoa.Value.Trim();
        }

        Response.Redirect("search.aspx?search=" + Server.UrlEncode(strSearch) + "&Key=" + Server.UrlEncode(strKeyWord));
    }
}