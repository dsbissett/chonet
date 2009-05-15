using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_StoreConfig : Page
{
    public int CuaHangID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-Store only
            if (!Page.IsPostBack)
            {
                LoadCuaHang();
                //LoadHoTro();
                LoadQuangCao(51);
                LoadQuangCao(52);
                LoadQuangCao(53);
                LoadQuangCao(54);
                LoadQuangCao(55);
                LoadQuangCao(56);
                LoadQuangCao(57);
                //LoadGianHang();
                LoadDanhMuc(0);
                LoadHoTroTrucTuyen();
            }
        }
    }

    private void LoadDanhMuc(int loaddm)
    {
        try
        {
            CuaHang ch = new CuaHang();
            DataSet dsCH = ch.SelectByNguoiDungID(Common.NguoiDungID());
            int id = 0;
            if (dsCH.Tables[0].Rows.Count == 1)
            {
                DataRow dr = dsCH.Tables[0].Rows[0];
                id = int.Parse(dr["CuaHangID"].ToString());
            }


            LoadDanhMucCon(0, id, loaddm);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadDanhMucCon(int NhomChaID, int CuaHangID, int loaddm)
    {
        loaddm++;
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomChaID);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
                    //{
                    HtmlTableRow tbr = new HtmlTableRow();
                    tbr.Style.Add("padding-left", (loaddm*10) + "px");
                    HtmlTableCell tbc1 = new HtmlTableCell();
                    HtmlTableCell tbc2 = new HtmlTableCell();
                    //image cells
                    //HtmlTableCell tbc3 = new HtmlTableCell();
                    HtmlTableCell tbc4 = new HtmlTableCell();
                    HtmlTableCell tbc5 = new HtmlTableCell();


                    //tbc1.Style.Add("width", "3%");                        
                    tbc2.InnerText = dr["SapXep"] + "." + dr["TenNhomSanPham"];
                    tbc2.ColSpan = 2;
                    //tbc3.Style.Add("width", "16px");
                    tbc4.Style.Add("width", "16px");
                    tbc5.Style.Add("width", "16px");
                    //tbc3.Style.Add("padding", "0");
                    //tbc3.Style.Add("margin", "0");
                    //tbc3.Style.Add("cursor", "hand");
                    tbc4.Style.Add("padding", "0");
                    tbc4.Style.Add("margin", "0");
                    tbc4.Style.Add("cursor", "hand");
                    tbc5.Style.Add("padding", "0");
                    tbc5.Style.Add("margin", "0");
                    tbc5.Style.Add("cursor", "hand");

                    //HtmlImage img1 = new HtmlImage();
                    HtmlImage img2 = new HtmlImage();
                    HtmlImage img3 = new HtmlImage();

                    //img1.Src = "../images/edit.gif";
                    img2.Src = "../images/delete.gif";
                    img3.Src = "../images/add.gif";
                    //img1.Alt = "Sửa danh mục cha";
                    img2.Alt = "Xóa danh mục cha";
                    img3.Alt = "Thêm danh mục con";
                    //img1.Attributes.Add("onclick", "Edit(" + dr["NhomSanPhamID"].ToString() + ");");
                    img2.Attributes.Add("onclick", "Delete(" + dr["CuaHangNhomSanPhamID"] + ");");
                    img3.Attributes.Add("onclick", "AddSub(" + dr["NhomSanPhamID"] + ",'" +
                                                   dr["TenNhomSanPham"] + "');");


                    //tbc3.Controls.Add(img1);
                    tbc4.Controls.Add(img2);
                    tbc5.Controls.Add(img3);

                    tbr.Cells.Add(tbc1);
                    tbr.Cells.Add(tbc2);
                    //tbr.Cells.Add(tbc3);
                    tbr.Cells.Add(tbc4);
                    tbr.Cells.Add(tbc5);
                    tblDanhMuc.Rows.Add(tbr);

                    LoadDanhMucCon(int.Parse(dr["NhomSanPhamID"].ToString()), CuaHangID, loaddm);
                    // }
                }
            }
            //            tblDanhMuc.Controls.Add(tbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadCuaHang()
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
            //lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
            CuaHangID = int.Parse(dr["CuaHangID"].ToString());
            imgLogo.Src = "." + dr["Anh"].ToString();
        }
    }

    //private void LoadHoTro()
    //{
    //    CuaHang ch = new CuaHang();
    //    DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());
    //    if (ds.Tables[0].Rows.Count != 1)
    //    {
    //        Response.Redirect("../message.aspx?msg=You haven't got a store yet");
    //    }
    //    else
    //    {
    //        DataRow dr = ds.Tables[0].Rows[0];
    //        lblTenCuaHang2.Text = dr["TenCuaHang"].ToString();
    //        lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
    //        lblDiDong.Text= dr["DienThoaiDiDong"].ToString();
    //        CuaHangID = int.Parse(dr["CuaHangID"].ToString());
    //    }
    //}
    private void LoadQuangCao(int aid)
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(Common.NguoiDungID(), aid);
        HtmlImage img = new HtmlImage();
        switch (aid)
        {
            case 51:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao51.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"593\" height=\"117\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"." +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"593\" height=\"117\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao51.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" height=\"117\" width=\"593\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }

                break;
                //case 52:
                //    if (ds.Tables[0].Rows.Count >= 1)
                //    {
                //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                //        {
                //            spnQuangCao52.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //                + "width=\"628\" height=\"116\" title=\"Quang Cao\">"
                //                + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                //                + "<param name=\"quality\" value=\"high\" />"
                //                + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //                + "width=\"628\" height=\"116\"></embed></object>";
                //        }
                //        else
                //        {
                //            spnQuangCao52.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                //              + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                //              + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"628px\" width=\"116px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //        }
                //    }
                //    else
                //    {
                //        spnQuangCao52.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"116px\" width=\"628px\" style=\"border:solid 1px #C9C3C3\"/>";
                //    }
                //    break;
                //case 53:
                //    if (ds.Tables[0].Rows.Count >= 1)
                //    {
                //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                //        {
                //            spnQuangCao53.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //                + "width=\"156\" height=\"116\" title=\"Quang Cao\">"
                //                + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                //                + "<param name=\"quality\" value=\"high\" />"
                //                + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //                + "width=\"156\" height=\"116\"></embed></object>";
                //        }
                //        else
                //        {
                //            spnQuangCao53.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                //              + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                //              + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"156px\" width=\"116px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //        }
                //    }
                //    else
                //    {
                //        spnQuangCao53.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"116px\" width=\"156px\" style=\"border:solid 1px #C9C3C3\"/>";
                //    }
                //    break;
            case 54:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao54.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"490\" height=\"249\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"." +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"490\" height=\"249\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao54.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" height=\"249px\" width=\"490px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }

                break;

            case 55:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    divAdvLeft.InnerHtml = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                        {
                            divAdvLeft.InnerHtml += "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                    +
                                                    "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                    + "width=\"110\" title=\"Quang Cao\">"
                                                    + "<param name=\"movie\" value=\"." +
                                                    ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                                                    + "<param name=\"quality\" value=\"high\" />"
                                                    + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                    "\" quality=\"high\""
                                                    +
                                                    "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                    + "width=\"110\" ></embed></object><br>";
                        }
                        else
                        {
                            divAdvLeft.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                                                    + "\" target=\"_blank\"><img alt=\"" +
                                                    ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                                                    + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                    "\"  width=\"110\" style=\"border:solid 1px #C9C3C3\"/></a><br>";
                        }
                    }
                }

                break;

            case 56:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    divAdvRight.InnerHtml = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                        {
                            divAdvRight.InnerHtml += "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                     +
                                                     "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                     + "width=\"110\" title=\"Quang Cao\">"
                                                     + "<param name=\"movie\" value=\"." +
                                                     ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                                                     + "<param name=\"quality\" value=\"high\" />"
                                                     + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                     "\" quality=\"high\""
                                                     +
                                                     "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                     + "width=\"110\" ></embed></object><br>";
                        }
                        else
                        {
                            divAdvRight.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                                                     + "\" target=\"_blank\"><img alt=\"" +
                                                     ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                                                     + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                     "\"  width=\"110\" style=\"border:solid 1px #C9C3C3\"/></a><br>";
                        }
                    }
                }

                break;

            case 57:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        tblQuangCao57.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"110\" height=\"249\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"." +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"110\" height=\"249\"></embed></object>";
                    }
                    else
                    {
                       tblQuangCao57.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" height=\"249px\" width=\"110\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }

                break;
        }
    }

    //private void LoadGianHang()
    //{
    //    CuaHang ch = new CuaHang();
    //    DataSet ds = ch.SelectCuaHangAtViTriCuaHangByNguoiDungID(Common.NguoiDungID(), 51);
    //    int n = ds.Tables[0].Rows.Count;
    //    for (int i = 0; i < n; i++)
    //    {
    //        TableRow tr = new TableRow();
    //        TableCell td = new TableCell();
    //        string content = "";
    //        content += " <img src=\"." + ds.Tables[0].Rows[i]["Anh"]
    //                   +
    //                   "\" width=\"110\" height=\"73\" hspace=\"4\" vspace=\"4\" style=\"border:#ece2a4 1px solid\" />";
    //        td.Text = content;
    //        td.HorizontalAlign = HorizontalAlign.Center;
    //        tr.Cells.Add(td);
    //        tblGianHang.Rows.Add(tr);
    //    }
    //}

    private void LoadHoTroTrucTuyen()
    {
        HoTroTrucTuyen ht = new HoTroTrucTuyen();
        DataSet ds = ht.SelectByCuaHangID(CuaHangID);

        string content = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                content += "<img border='0' style=\"cursor:hand\" src='../images/edit.gif' onclick='EditHTTT(" +
                           dr["HoTroTrucTuyenID"]
                           +
                           ");' ><img border='0' style=\"cursor:hand\" src='../images/delete.gif' onclick='DeleteHTTT(" +
                           dr["HoTroTrucTuyenID"]
                           + ");'><a href=\"ymsgr:sendIM?" + dr["YM"]
                           + "\"><img src=\"http://opi.yahoo.com/online?u="
                           + dr["YM"] + "&t=1\" border=\"0\"></a>" +
                           dr["TenHoTro"] + "<br>";
            }
            spnHoTroTrucTuyen.InnerHtml = content;
        }
        //if (ds.Tables[0].Rows.Count != 1)
        //{
        //    Response.Redirect("../message.aspx?msg=You haven't got a store yet");
        //}
        //else
        //{
        //    DataRow dr = ds.Tables[0].Rows[0];
        //    lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
        //    CuaHangID = int.Parse(dr["CuaHangID"].ToString());
        //}
    }

    protected void pnlThongTin_ContentRefresh(object sender, EventArgs e)
    {
        LoadCuaHang();
    }

    protected void pnlHoTro_ContentRefresh(object sender, EventArgs e)
    {
        LoadHoTroTrucTuyen();
    }

    protected void pnlQuangCao51_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(51);
    }

    protected void pnlQuangCao52_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(52);
    }

    protected void pnlQuangCao53_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(53);
    }

    protected void pnlQuangCao54_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(54);
    }

    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        //LoadGianHang();
        LoadQuangCao(57);
    }

    protected void pnlDanhMuc_ContentRefresh(object sender, EventArgs e)
    {
        LoadDanhMuc(0);
    }

    protected void pnlleftbanner_Load(object sender, EventArgs e)
    {
        LoadQuangCao(55);
    }

    protected void pnlrightbanner_Load(object sender, EventArgs e)
    {
        LoadQuangCao(56);
    }

    protected void pnlSanPhamHot_Load(object sender, EventArgs e)
    {
        LoadSanPham(23);
    }
    protected void pnlLogo_Load(object sender, EventArgs e)
    {
        LoadCuaHang();
    }
    private void LoadSanPham(int ViTriID)
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectAllSanPhamAtViTriSanPhamByNguoiDungID(23, Common.NguoiDungID());
        int n = ds.Tables[0].Rows.Count > 12 ? 12 : ds.Tables[0].Rows.Count;
        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            string content = "";
            string tensanpham = ds.Tables[0].Rows[i]["TenSanPham"] +
                                " " + ds.Tables[0].Rows[i]["TenSanPhamPhu"];
            if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

            content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
            content += "<tr><td align=\"center\" style=\"width:130px\"><a href=\"productdetail.aspx?id=" +
                       ds.Tables[0].Rows[i]["SanPhamID"]
                       + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                       + "\" alt=\"" + tensanpham
                       +
                       "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr><tr>";
            content += "<td align=\"center\" ><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"]
                       + "\">" + tensanpham + "</a><br />";
            content += "Giá: <span class=\"price\">" +
                       String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                       + "</span> " + ds.Tables[0].Rows[i]["DonViTienTe"] + " </td></tr></table>";
            td.Text = content;
            td.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(td);
            tblSanPhamHot.Rows.Add(tr);
        }
    }
}