using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebNavigator;

public partial class EstoreMaster : MasterPage
{
    public int ChuCuaHangID;
    public int CuaHangID;
    private string lp = "";
    private string name = "";
    public int NhomSanPhamID;
    private string up = "";
    //int PageSize = 12;

    protected void Page_Load(object sender, EventArgs e)
    {
        //RedirectToCuahangbyUrlName();
        if (Session["UserFullName"] != null)
        {
            tblchaomung.Visible = true;
            tbldangnhap.Visible = false;
        }

        if (Request.QueryString["sid"] != null)
        {
            try
            {
                CuaHangID = int.Parse(Request.QueryString["sid"]);
                LoadCuaHang();
                if (Request.QueryString["cid"] != null)
                {
                    try
                    {
                        NhomSanPhamID = int.Parse(Request.QueryString["cid"]);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("./message.aspx?msg=" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("./message.aspx?msg=" + ex.Message);
            }
        }
        else
        {
            //Response.Redirect("./message.aspx?msg=Invalid parameter");
        }

        if (!Page.IsPostBack)
        {
            LoadSanPhamDaXem();
            LoadSanPham(23);
            LoadQuangCao(51);
            LoadQuangCao(52);
            LoadQuangCao(53);
            LoadQuangCao(54);
            LoadQuangCao(55);
            LoadQuangCao(56);
            LoadQuangCao(57);
            //LoadDanhMuc();
            LoadUltraMenu(0);
            LoadThongTinCuaHang(ChuCuaHangID);
            //LoadGianHang();
            LoadSanPhamTop();
            //LoadSanPhamAll(NhomSanPhamID,1);
            //LoadBinhChon();            
            LoadHoTroTrucTuyen();

            LichSuTruyCap lstc = new LichSuTruyCap();
            DataSet ds = lstc.SelectByCuaHangID(CuaHangID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lstc.UpdateFields(int.Parse(ds.Tables[0].Rows[0]["LichSuTruyCapID"].ToString()),
                                  int.Parse(ds.Tables[0].Rows[0]["LuotTruyCap"].ToString()) + 1, CuaHangID);
                lblTruyCap.Text = ds.Tables[0].Rows[0]["LuotTruyCap"].ToString();
            }
            else
            {
                lstc.InsertFields(1, CuaHangID);
            }
        }
        lblOnline.Text = Application["songuoionline"].ToString();
    }

    private void RedirectToCuahangbyUrlName()
    {
        string url = Request.RawUrl.ToLower();
        if (url.IndexOf("estore.aspx") == -1)
        {
            string[] urls = url.Split('/');
            string tencuahang = urls[urls.Length - 1];
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectByField("TenCuaHang", tencuahang, "nvarchar");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("Estore.aspx?sid=" + ds.Tables[0].Rows[0]["CuaHangID"]);
            }
        }
    }

    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByCuaHangID(CuaHangID);
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("./message.aspx?msg=Failed in loading store");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
            lblDiaChi.Text = dr["DiaChi"].ToString();
            lblDTCD.Text = dr["DienThoaiCoDinh"].ToString();
            lblDTDD.Text = dr["DienThoaiDiDong"].ToString();
            ChuCuaHangID = int.Parse(dr["NguoiDungID"].ToString());
            ViewState["chucuahangid"] = ChuCuaHangID;

            switch (dr["LoaiCuaHangID"].ToString())
            {
                //case "1":
                //    stsGianHang.Href = "GianHang/VIP/css/style.css";
                //    //LoadTinTuc();
                //    break;
                case "2":
                    stsGianHang.Href = "GianHang/CN/css/style.css";
                    //LoadTinTuc();
                    break;
                case "3":
                    stsGianHang.Href = "GianHang/TT/css/style.css";
                    break;               
                default:
                    stsGianHang.Href = "GianHang/" + dr["TenLoaiCuaHang"].ToString() + "/css/style.css";
                    break;
            }
            if ((dr["LoaiCuaHang"].ToString() == "1") ||
                (dr["LoaiCuaHang"].ToString() == "2"))
            {
                //LoadTinTuc();
            }
        }
    }

    private void LoadSanPhamDaXem()
    {
        if (Session["tblSanPhamDaXem"] != null)
        {
            DataTable tableSanPhamDaXem = (DataTable) Session["tblSanPhamDaXem"];
            int n = tableSanPhamDaXem.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                DataRow dr = tableSanPhamDaXem.Rows[i];
                string content = "";
                string tensanpham = dr["TenSanPham"] +
                                    " " + dr["TenSanPhamPhu"];
                if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"left\" style=\"width:74px\"><a href=\"productdetail.aspx?id=" +
                           dr["SanPhamID"]
                           + "\"><img src=\"" + dr["AnhSanPham"]
                           + "\" alt=\"" + tensanpham
                           + "\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "<td align=\"left\" style=\"width:80%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"]
                           + "\">" + tensanpham + "</a><br />";
                content += "Giá: <span class=\"price\">" + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                           + "</span> " + dr["DonViTienTe"] + " </td></tr></table>";
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Center;
                tr.Cells.Add(td);
                tblSanPhamDaXem.Rows.Add(tr);
            }
        }
    }

    private void LoadMenuItems(MenuItem mi, int NhomSanPhamID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomSanPhamID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            MenuItem mni = new MenuItem(
                dr["TenNhomSanPham"].ToString().Length > 30
                    ? dr["TenNhomSanPham"].ToString().Substring(0, 30) + "..."
                    : dr["TenNhomSanPham"].ToString(),
                dr["NhomSanPhamID"].ToString());
            //mni.ToolTip = dr["TenNhomSanPham"].ToString();

            LoadMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
            mni.NavigateUrl = "estore.aspx?sid=" + CuaHangID + "&cid=" + dr["NhomSanPhamID"];
            mi.ChildItems.Add(mni);
        }
    }

    private void LoadMenu(int NhomChaID)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds;
            string cachemenu = "nsp" + CuaHangID + "_" + NhomChaID;
            if (Cache[cachemenu] == null)
            {
                ds = nsp.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomChaID);
                Cache[cachemenu] = ds;
            }
            else
            {
                ds = (DataSet) Cache[cachemenu];
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MenuItem mni = new MenuItem(
                    dr["TenNhomSanPham"].ToString().Length > 30
                        ? dr["TenNhomSanPham"].ToString().Substring(0, 30) + "..."
                        : dr["TenNhomSanPham"].ToString(),
                    dr["NhomSanPhamID"].ToString());
                //mni.ToolTip = dr["TenNhomSanPham"].ToString();

                LoadMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
                mni.NavigateUrl = "estore.aspx?sid=" + CuaHangID + "&cid=" + dr["NhomSanPhamID"];
                mnuNhomSanPham.Items.Add(mni);
                ;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }

    private void LoadQuangCao(int aid)
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(ChuCuaHangID, aid);
        switch (aid)
        {
            case 51:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao51.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "z-index=\"0\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"593\" height=\"117\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<param name=\"wmode\" value=\"transparent\" />"
                                                  + "<embed wmode=\"transparent\" src=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"593\" height=\"117\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao51.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" height=\"117\" width=\"593\" style=\"border:none\"/></a>";
                    }
                }
                break;
                //case 52:
                //    if (ds.Tables[0].Rows.Count >= 1)
                //    {
                //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                //        {
                //            spnQuangCao52.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //                + "width=\"628\" height=\"116\" title=\"Quang Cao\">"
                //                + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                //                + "<param name=\"quality\" value=\"high\" />"
                //                + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //                + "width=\"628\" height=\"116\"></embed></object>";
                //        }
                //        else
                //        {
                //            spnQuangCao52.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                //              + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                //              + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"116px\" width=\"628px\" style=\"border:none\"/></a>";
                //        }
                //    }
                //    break;
                //case 53:
                //    if (ds.Tables[0].Rows.Count >= 1)
                //    {
                //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                //        {
                //            spnQuangCao53.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //                + "width=\"156\" height=\"116\" title=\"Quang Cao\">"
                //                + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                //                + "<param name=\"quality\" value=\"high\" />"
                //                + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //                + "width=\"156\" height=\"116\"></embed></object>";
                //        }
                //        else
                //        {
                //            spnQuangCao53.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                //              + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                //              + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"116px\" width=\"156px\" style=\"border:none\"/></a>";
                //        }
                //    }
                //    //else
                //    //{
                //    //    spnQuangCao53.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"116px\" width=\"156px\" style=\"border:none\"/>";
                //    //}
                //    break;
            case 54:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao54.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"421\" height=\"212\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<param name=\"wmode\" value=\"transparent\" />"
                                                  + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"421\" height=\"212\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao54.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" height=\"212\" width=\"421\" style=\"border:none\"/></a>";
                    }
                }
                //else
                //{
                //    spnQuangCao54.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"249px\" width=\"490px\" style=\"border:none\"/>";
                //}
                break;

            case 55:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    spnQuangCao55.InnerHtml = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                        {
                            spnQuangCao55.InnerHtml += "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                       +
                                                       "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                       + "width=\"110px\"  title=\"Quang Cao\">"
                                                       + "<param name=\"movie\" value=\"" +
                                                       ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                                                       + "<param name=\"quality\" value=\"high\" />"
                                                       + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                       "\" quality=\"high\""
                                                       +
                                                       "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                       + "width=\"110px\" ></embed></object>";
                        }
                        else
                        {
                            spnQuangCao55.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                                                       + "\" target=\"_blank\"><img alt=\"" +
                                                       ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                                                       + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                       "\" width=\"110px\" style=\"border:none\"/></a>";
                        }
                    }
                }

                break;

            case 56:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    spnQuangCao56.InnerHtml = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                        {
                            spnQuangCao56.InnerHtml += "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                       +
                                                       "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                       + "width=\"110\"  title=\"Quang Cao\">"
                                                       + "<param name=\"movie\" value=\"" +
                                                       ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                                                       + "<param name=\"quality\" value=\"high\" />"
                                                       + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                       "\" quality=\"high\""
                                                       +
                                                       "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                       + "width=\"110\" ></embed></object>";
                        }
                        else
                        {
                            spnQuangCao56.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                                                       + "\" target=\"_blank\"><img alt=\"" +
                                                       ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                                                       + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
                                                       "\" width=\"110\" style=\"border:none\"/></a>";
                        }
                    }
                }
                break;

            case 57:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao57.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"150\" height=\"150\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"150\" height=\"150\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao57.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                   ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                   + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                   "\" height=\"150\" width=\"150\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }

                break;
        }
    }

    private void LoadDanhMucCha()
    {
    }

    private void LoadDanhMuc()
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectNhomSanPhamByCuaHangID(CuaHangID);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
                    {
                        TableRow tr = new TableRow();
                        TableCell td = new TableCell();
                        td.CssClass = "leftmenu";
                        td.Text = "<a href=\"estore.aspx?sid=" + CuaHangID + "&cid=" + dr["NhomSanPhamID"] + "\">" +
                                  dr["TenNhomSanPham"] + "</a>";
                        tr.Cells.Add(td);
                        tblDanhMuc.Rows.Add(tr);
                        ds.Tables[0].DefaultView.RowFilter = "NhomChaID=" + dr["NhomSanPhamID"];
                        DataView dv = ds.Tables[0].DefaultView;
                        for (int i = 0; i < dv.Count; i++)
                        {
                            TableRow tr1 = new TableRow();
                            TableCell td1 = new TableCell();
                            tr1.CssClass = "subleftmenu";
                            td1.Style.Value = "padding-left:40px";
                            td1.Text = " <a href=\"estore.aspx?sid=" + CuaHangID + "&cid=" + dv[i]["NhomSanPhamID"] +
                                       "\">" + "+ " + dv[i]["TenNhomSanPham"] + "</a>";
                            tr1.Cells.Add(td1);
                            tblDanhMuc.Rows.Add(tr1);
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

    //private void LoadHoTro()
    //{
    //    CuaHang ch = new CuaHang();
    //    DataSet ds = ch.SelectByID(CuaHangID);
    //    if (ds.Tables[0].Rows.Count != 1)
    //    {
    //        Response.Redirect("./message.aspx?msg=Invalid parameter");
    //    }
    //    else
    //    {
    //        DataRow dr = ds.Tables[0].Rows[0];
    //        lblTenCuaHang2.Text = dr["TenCuaHang"].ToString();
    //        lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
    //        lblDiDong.Text = dr["DienThoaiDiDong"].ToString();
    //        lnkYahoo.HRef = "ymsgr:sendIM?" + dr["YM"].ToString(); ;
    //    }
    //}
    //private void LoadGianHang()
    //{
    //    CuaHang ch = new CuaHang();
    //    DataSet ds = ch.SelectCuaHangAtViTriCuaHangByCuaHangID(CuaHangID, 51);
    //    int n = ds.Tables[0].Rows.Count;
    //    for (int i = 0; i < n; i++)
    //    {
    //        TableRow tr = new TableRow();
    //        TableCell td = new TableCell();
    //        string content = "";
    //        content += "<a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[i]["CuaHangID"]
    //                   + "\"><img src=\"" + ds.Tables[0].Rows[i]["Anh"]
    //                   +
    //                   "\" width=\"110\" height=\"73\" hspace=\"4\" vspace=\"4\" style=\"border:#ece2a4 1px solid\" alt=\""
    //                   + ds.Tables[0].Rows[i]["TenCuaHang"] + "\" /></a>";
    //        td.Text = content;
    //        td.HorizontalAlign = HorizontalAlign.Center;
    //        tr.Cells.Add(td);
    //        tblGianHang.Rows.Add(tr);
    //    }
    //}

    private void LoadSanPhamTop()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectTopTenSanPhamByCuaHangID(CuaHangID);
        int n = ds.Tables[0].Rows.Count > 3 ? 3 : ds.Tables[0].Rows.Count;
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
            tblTopTen.Rows.Add(tr);
        }
    }

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
                content += "<a href=\"ymsgr:sendIM?" + dr["YM"]
                           + "\"><img src=\"http://opi.yahoo.com/online?u="
                           + dr["YM"] + "&t=1\" border=\"0\"></a>&nbsp;&nbsp;" +
                           dr["TenHoTro"] + "<br>";
            }
            spnHoTroTrucTuyen.InnerHtml = content;
        }
    }

    private void LoadThongTinCuaHang(int id)
    {
        try
        {
            pnlDamBao.Controls.Clear();
            DataAccess da = new DataAccess();
            string strSql = "Select * from viewcuahang where nguoidungid =" + id;

            DataSet ds = da.SelectByQuery(strSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblDiemDanhGia.Text = string.Format("{0:0.0}", decimal.Parse("0" + dr["Diem"])).Replace(".", ",")
                                      + "(" + int.Parse("0" + dr["Solandanhgia"]) + ")";

                int DamBao = int.Parse("0" + dr["BaoDam"]);
                for (int i = 0; i < DamBao; i++)
                {
                    HtmlImage img = new HtmlImage();
                    img.Src = "./images/kc.jpg";
                    img.Border = 0;
                    pnlDamBao.Controls.Add(img);
                }
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n", " "), false);
            Response.Write(ex.ToString());
        }
    }

    private void LoadSanPham(int ViTriID)
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectAllSanPhamAtViTriSanPhamByNguoiDungID(23, Common.NguoiDungID());
        int n = ds.Tables[0].Rows.Count > 3 ? 3 : ds.Tables[0].Rows.Count;
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

    protected void pnlCuaHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadThongTinCuaHang(ChuCuaHangID);
    }

    protected void lnkSignOut_Click(object sender, EventArgs e)
    {
        if (Session.IsNewSession != true)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
        }
        tblchaomung.Visible = false;
        tbldangnhap.Visible = true;
    }

    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByField("taikhoan", txtTaiKhoan.Text.Trim(), "nvarchar");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((ds.Tables[0].Rows[0]["matkhau"].ToString() == txtMatKhau.Text) &&
                    bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString()))
                {
                    Session.Clear();
                    Session.Add("LoaiNguoiDungID", ds.Tables[0].Rows[0]["LoaiNguoiDungID"]);
                    Session.Add("NguoiDungID", ds.Tables[0].Rows[0]["NguoiDungID"]);
                    Session.Add("UserFullName", ds.Tables[0].Rows[0]["HoVaTen"]);
                    Session.Add("NguoiDungEmail", ds.Tables[0].Rows[0]["Email"]);

                    //FormsAuthentication.RedirectFromLoginPage(txtTaiKhoan.Text.Trim(), false);
                    tblchaomung.Visible = true;
                    tbldangnhap.Visible = false;
                }
                else
                {
                    lblErr.Visible = true;
                    lblErr.Text = "Đăng nhập lỗi";
                }
            }
            else
            {
                lblErr.Visible = true;
                lblErr.Text = "Đăng nhập lỗi";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.Message);
            return;
        }
    }

    protected void tmleft_Tick(object sender, EventArgs e)
    {
        LoadQuangCao(55);
    }

    protected void tmright_Tick(object sender, EventArgs e)
    {
        LoadQuangCao(56);
    }

    protected void tmSanPhamHot_Tick(object sender, EventArgs e)
    {
        LoadSanPham(23);
    }

    private void LoadUltraMenuItems(Item mi, int NhomSanPhamID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomSanPhamID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Item mni = new Item();
            mni.Text = dr["TenNhomSanPham"].ToString().Length > 30
                           ? dr["TenNhomSanPham"].ToString().Substring(0, 30) + "..."
                           : dr["TenNhomSanPham"].ToString();
            mni.Tag = dr["NhomSanPhamID"].ToString();
            //mni.ToolTip = dr["TenNhomSanPham"].ToString();

            LoadUltraMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
            mni.TargetUrl = "estore.aspx?sid=" + CuaHangID + "&cid=" + dr["NhomSanPhamID"];
            mi.Items.Add(mni);
        }
    }

    private void LoadUltraMenu(int NhomChaID)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds;
            string cachemenu = "nsp" + CuaHangID + "_" + NhomChaID;
            if (Cache[cachemenu] == null)
            {
                ds = nsp.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomChaID);
                Cache[cachemenu] = ds;
            }
            else
            {
                ds = (DataSet) Cache[cachemenu];
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Item mni = new Item();
                mni.Text = dr["TenNhomSanPham"].ToString().Length > 30
                               ? dr["TenNhomSanPham"].ToString().Substring(0, 30) + "..."
                               : dr["TenNhomSanPham"].ToString();
                mni.Tag = dr["NhomSanPhamID"].ToString();
                //mni.ToolTip = dr["TenNhomSanPham"].ToString();

                LoadUltraMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
                mni.TargetUrl = "estore.aspx?sid=" + CuaHangID + "&cid=" + dr["NhomSanPhamID"];
                uwmMenu.Items.Add(mni);
                ;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }

    //protected void btnTimKiem_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Estore.aspx?sid=" + Request.QueryString["sid"].ToString() + "&lp=" + lp + "&up=" + up + "&name=" + name, true);
    //}
}