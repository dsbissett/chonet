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

public partial class NewEstoreMaster : System.Web.UI.MasterPage
{
    public int ChuCuaHangID;
    public int CuaHangID;
    private string lp = "";
    private string name = "";
    public int NhomSanPhamID;
    private string up = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //RedirectToCuahangbyUrlName();
        if (Session["UserFullName"] != null)
        {
            tblchaomung.Visible = true;
            divDangNhap.Visible = false;
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

        //if (!Page.IsPostBack)
        //{
        LoadSanPhamDaXem();
        LoadDanhMucTinTuc();
        LoadTinTucMoi();
        //    LoadSanPham(23);
        LoadQuangCao(51);
        //    LoadQuangCao(52);
        //    LoadQuangCao(53);
        //    LoadQuangCao(54);
        //    LoadQuangCao(55);
        //    LoadQuangCao(56);
            LoadQuangCao(57);
        //    //LoadDanhMuc();
            LoadUltraMenu(0);
        //    LoadThongTinCuaHang(ChuCuaHangID);
        //    //LoadGianHang();
            LoadSanPhamTop();
        //    //LoadSanPhamAll(NhomSanPhamID,1);
        //    //LoadBinhChon();            
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
        //}
        lblOnline.Text = Application["songuoionline"].ToString();
    }
    private void LoadCuaHang()
    {
        if (Session["UserFullName"] != null)
        {
            tblchaomung.Visible = true;
            divDangNhap.Visible = false;
        }

        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByCuaHangID(CuaHangID);
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("./message.aspx?msg=Failed in loading store");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblLienHe.Text = dr["TenCuaHang"].ToString() + " " 
                +  dr["DiaChi"].ToString() + " - " + dr["DienThoaiCoDinh"].ToString()
                + " - " +  dr["DienThoaiDiDong"].ToString();
            ChuCuaHangID = int.Parse(dr["NguoiDungID"].ToString());
            ViewState["chucuahangid"] = ChuCuaHangID;

            //switch (dr["LoaiCuaHangID"].ToString())
            //{
            //    //case "1":
            //    //    stsGianHang.Href = "GianHang/VIP/css/style.css";
            //    //    //LoadTinTuc();
            //    //    break;
            //    case "2":
            //        stsGianHang.Href = "GianHang/CN/css/style.css";
            //        //LoadTinTuc();
            //        break;
            //    case "3":
            //        stsGianHang.Href = "GianHang/TT/css/style.css";
            //        break;
            //    default:
            //        stsGianHang.Href = "GianHang/" + dr["TenLoaiCuaHang"].ToString() + "/css/style.css";
            //        break;
            //}
            //if ((dr["LoaiCuaHang"].ToString() == "1") ||
            //    (dr["LoaiCuaHang"].ToString() == "2"))
            //{
            //    //LoadTinTuc();
            //}
        }
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
                ds = (DataSet)Cache[cachemenu];
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
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
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
                content += "<p class=\"t-c\"><a href=\"ymsgr:sendIM?" + dr["YM"]
                           + "\"><img src=\"http://opi.yahoo.com/online?u="
                           + dr["YM"] + "&t=2\" border=\"0\"></a></br>" +
                           dr["TenHoTro"] + "</p><br>";
            }
            spnHoTroTrucTuyen.InnerHtml = content;
        }
    }

    private void LoadSanPhamDaXem()
    {
        if (Session["tblSanPhamDaXem"] != null)
        {
            DataTable tableSanPhamDaXem = (DataTable)Session["tblSanPhamDaXem"];
            int n = tableSanPhamDaXem.Rows.Count;
            string content = "";
            for (int i = 0; i < n; i++)
            {
                DataRow dr = tableSanPhamDaXem.Rows[i]; 
                string tensanpham = dr["TenSanPham"] +
                                    " " + dr["TenSanPhamPhu"];
                if (tensanpham.Length > 50) tensanpham = tensanpham.Substring(0, 50) + "...";

                content += "<p class=\"t-l pad-01 mr-t5 fl\">";
                content += "<a href=\"productdetail.aspx?id=" +
                           dr["SanPhamID"]
                           + "\"><img src=\"" + dr["AnhSanPham"]
                           + "\" alt=\"" + tensanpham
                           + "\" width=\"71\" height=\"62\" border=\"0\" class=\"fl mr-r3\" />";
                content +=  tensanpham + "<br />";
                content += "<font color=\"#f00\">" + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                           + "</font> " + dr["DonViTienTe"] + "</a></p>";                
            }
            spnSanPhamDaXem.InnerHtml = content;
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
                                                  + "width=\"1000\" height=\"195\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<param name=\"wmode\" value=\"transparent\" />"
                                                  + "<embed wmode=\"transparent\" src=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"1000\" height=\"195\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao51.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                  + "\" target=\"_blank\"><img alt=\"" +
                                                  ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                  + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" width=\"1000\" height=\"195\" style=\"border:none\"/></a>";
                    }
                }
                break;
        
            //case 54:
            //    if (ds.Tables[0].Rows.Count >= 1)
            //    {
            //        if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            //        {
            //            spnQuangCao54.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
            //                                      +
            //                                      "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
            //                                      + "width=\"421\" height=\"212\" title=\"Quang Cao\">"
            //                                      + "<param name=\"movie\" value=\"" +
            //                                      ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
            //                                      + "<param name=\"quality\" value=\"high\" />"
            //                                      + "<param name=\"wmode\" value=\"transparent\" />"
            //                                      + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
            //                                      "\" quality=\"high\""
            //                                      +
            //                                      "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
            //                                      + "width=\"421\" height=\"212\"></embed></object>";
            //        }
            //        else
            //        {
            //            spnQuangCao54.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
            //                                      + "\" target=\"_blank\"><img alt=\"" +
            //                                      ds.Tables[0].Rows[0]["NoiDungQuangCao"]
            //                                      + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
            //                                      "\" height=\"212\" width=\"421\" style=\"border:none\"/></a>";
            //        }
            //    }
            //    //else
            //    //{
            //    //    spnQuangCao54.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"249px\" width=\"490px\" style=\"border:none\"/>";
            //    //}
            //    break;

            //case 55:
            //    if (ds.Tables[0].Rows.Count >= 1)
            //    {
            //        spnQuangCao55.InnerHtml = "";
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            //            {
            //                spnQuangCao55.InnerHtml += "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
            //                                           +
            //                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
            //                                           + "width=\"110px\"  title=\"Quang Cao\">"
            //                                           + "<param name=\"movie\" value=\"" +
            //                                           ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
            //                                           + "<param name=\"quality\" value=\"high\" />"
            //                                           + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
            //                                           "\" quality=\"high\""
            //                                           +
            //                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
            //                                           + "width=\"110px\" ></embed></object>";
            //            }
            //            else
            //            {
            //                spnQuangCao55.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
            //                                           + "\" target=\"_blank\"><img alt=\"" +
            //                                           ds.Tables[0].Rows[i]["NoiDungQuangCao"]
            //                                           + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
            //                                           "\" width=\"110px\" style=\"border:none\"/></a>";
            //            }
            //        }
            //    }

            //    break;

            //case 56:
            //    if (ds.Tables[0].Rows.Count >= 1)
            //    {
            //        spnQuangCao56.InnerHtml = "";
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            //            {
            //                spnQuangCao56.InnerHtml += "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
            //                                           +
            //                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
            //                                           + "width=\"110\"  title=\"Quang Cao\">"
            //                                           + "<param name=\"movie\" value=\"" +
            //                                           ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
            //                                           + "<param name=\"quality\" value=\"high\" />"
            //                                           + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
            //                                           "\" quality=\"high\""
            //                                           +
            //                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
            //                                           + "width=\"110\" ></embed></object>";
            //            }
            //            else
            //            {
            //                spnQuangCao56.InnerHtml += "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
            //                                           + "\" target=\"_blank\"><img alt=\"" +
            //                                           ds.Tables[0].Rows[i]["NoiDungQuangCao"]
            //                                           + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] +
            //                                           "\" width=\"110\" style=\"border:none\"/></a>";
            //            }
            //        }
            //    }
            //    break;

            case 57:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao57.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                  +
                                                  "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                  + "width=\"181\" height=\"136\" title=\"Quang Cao\">"
                                                  + "<param name=\"movie\" value=\"" +
                                                  ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                  + "<param name=\"quality\" value=\"high\" />"
                                                  + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                  "\" quality=\"high\""
                                                  +
                                                  "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                  + "width=\"181\" height=\"136\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao57.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                   ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                                   + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                   "\" height=\"136\" width=\"181\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }

                break;
        }
    }

    protected void lnkSignOut_Click(object sender, EventArgs e)
    {
        if (Session.IsNewSession != true)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
        }
        tblchaomung.Visible = false;
        divDangNhap.Visible = true;
        lblErr.Text = "";
    }

    protected void btnDangNhap_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByField("taikhoan", txtTaiKhoan.Value.Trim(), "nvarchar");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((ds.Tables[0].Rows[0]["matkhau"].ToString() == txtMatKhau.Value) &&
                    bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString()))
                {
                    Session.Clear();
                    Session.Add("LoaiNguoiDungID", ds.Tables[0].Rows[0]["LoaiNguoiDungID"]);
                    Session.Add("NguoiDungID", ds.Tables[0].Rows[0]["NguoiDungID"]);
                    Session.Add("UserFullName", ds.Tables[0].Rows[0]["HoVaTen"]);
                    Session.Add("NguoiDungEmail", ds.Tables[0].Rows[0]["Email"]);

                    FormsAuthentication.SetAuthCookie(txtTaiKhoan.Value.Trim(),false);
                    tblchaomung.Visible = true;
                    divDangNhap.Visible = false;
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

    private void LoadSanPhamTop()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectTopTenSanPhamByCuaHangID(CuaHangID);
        int n = ds.Tables[0].Rows.Count > 3 ? 3 : ds.Tables[0].Rows.Count;
        string content = "";
        for (int i = 0; i < n; i++)
        {
            string tensanpham = ds.Tables[0].Rows[i]["TenSanPham"] +
                                " " + ds.Tables[0].Rows[i]["TenSanPhamPhu"];
            //if (tensanpham.Length > 50) tensanpham = tensanpham.Substring(0, 50) + "...";

            content += "<a href=\"productdetail.aspx?id=" +
                       ds.Tables[0].Rows[i]["SanPhamID"]
                       + "\"><p class=\"mr-l25 fl mr-t8 pad-b10\">"
                       + "<img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                       + "\" alt=\"" + tensanpham
                       + "\" width=\"130\" height=\"110\" border=\"0\" style=\"cursor:hand\"/>"            
                       + "</p><br><p align=\"center\"><strong>" +
                       String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                       + " " + ds.Tables[0].Rows[i]["DonViTienTe"] + " </strong></p></a>";
                        
        }
        spnSanPhamXemNhieu.InnerHtml = content;
    }

    private void LoadDanhMucTinTuc()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectByNguoiDungID(ChuCuaHangID);

        string content = "";
        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
            content += "<li><a href=\"#\">Tin cong ty</a></li>"
                            + "<li><a href=\"#\">Tin tuc lien quan</a></li>";
        //}
        spnDanhMucTinTuc.InnerHtml = content;
    }

    private void LoadTinTucMoi()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectByNguoiDungIDPaging(ChuCuaHangID, 1, 5);

        string content = "<ul class=\"list-news\">";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            content += "<li><a href=\"EstoreNews.aspx?sid="+ CuaHangID + "&nid=" + dr["TinTucID"].ToString() +"\">" 
                + dr["TieuDe"].ToString() + "</a></li>";                            
        }
        content += "</ul>";
        spnTinTuc.InnerHtml = content ;
    }
}
