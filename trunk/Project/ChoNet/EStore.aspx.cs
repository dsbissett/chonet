using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class eStore : Page
{
    public int ChuCuaHangID;
    public int CuaHangID;
    public int NhomSanPhamID;
    //public string ContentPlaceHolderID = "cphEstore";
    private const int PageSize = 18;

    void Page_PreInit(Object sender, EventArgs e)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByCuaHangID(int.Parse(Request["sid"]));

        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["LoaiCuaHangID"].ToString() == "26"))
        {            
            //ContentPlaceHolderID = "contentEstore";
            this.MasterPageFile = "NewEstoreMaster.master";
        }
        if (Session["masterpage"] != null)
        {
            this.MasterPageFile = (String)Session["masterpage"];
        }
    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserFullName"] != null)
        //{
        //    tblchaomung.Visible = true;
        //    tbldangnhap.Visible = false;
        //}
 

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
            Response.Redirect("./message.aspx?msg=Invalid parameter");
        }
        LoadTab();
        if (!Page.IsPostBack)
        {            
            switch (hidTabId.Value)
            {
                case "1":
                    if (!Page.IsPostBack)
                        LoadTabContent01(1);
                    break;
                case "2":
                    if (!Page.IsPostBack)
                        LoadTabContent02();
                    break;
                case "3":
                    if (!Page.IsPostBack)
                        LoadTabContent03(1);
                    break;
                case "4":
                    if (!Page.IsPostBack)
                        LoadTabContent04(1);
                    break;
            }
        }
    }

    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByID(CuaHangID);
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("./message.aspx?msg=Failed in loading store");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            //lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
            //lblDiaChi.Text = dr["DiaChi"].ToString();
            //lblDTCD.Text = dr["DienThoaiCoDinh"].ToString();
            //lblDTDD.Text = dr["DienThoaiDiDong"].ToString();
            ChuCuaHangID = int.Parse(dr["NguoiDungID"].ToString());
            //imgLoGo.Src = dr["Anh"].ToString();

            //switch (dr["LoaiCuaHang"].ToString())
            //{
            //    case "1":
            //        stsGianHang.Href = "GianHang/VIP/css/style.css";
            //        //LoadTinTuc();
            //        break;
            //    case "2":
            //        stsGianHang.Href = "GianHang/CN/css/style.css";
            //        //LoadTinTuc();
            //        break;
            //    case "3":
            //        stsGianHang.Href = "GianHang/TT/css/style.css";
            //        break;
            //    default:
            //        stsGianHang.Href = "GianHang/TT/css/style.css";
            //        break;
            //}
            //if ((dr["LoaiCuaHang"].ToString() == "1") ||
            //        (dr["LoaiCuaHang"].ToString() == "2"))
            //{
            //    LoadTinTuc();
            //}            
        }
    }

    //private void LoadQuangCao(int aid)
    //{
    //    QuangCao qcao = new QuangCao();
    //    DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(ChuCuaHangID, aid);
    //    switch (aid)
    //    {            
    //        case 54:
    //            if (ds.Tables[0].Rows.Count >= 1)
    //            {
    //                if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
    //                {
    //                    spnQuangCao54.InnerHtml = "<object style=\"border:none\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
    //                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
    //                        + "width=\"421\" height=\"212\" title=\"Quang Cao\">"
    //                        + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
    //                        + "<param name=\"quality\" value=\"high\" />"
    //                        + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
    //                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
    //                        + "width=\"421\" height=\"212\"></embed></object>";
    //                }
    //                else
    //                {
    //                    spnQuangCao54.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
    //                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
    //                      + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"212\" width=\"421\" style=\"border:none\"/></a>";
    //                }
    //            }                
    //            break;           
    //    }
    //}
    //private void LoadDanhMuc()
    //{
    //    try
    //    {
    //        NhomSanPham nhomsanpham = new NhomSanPham();
    //        DataSet ds = nhomsanpham.SelectNhomSanPhamByCuaHangID(CuaHangID);
    //        ds.Tables[0].DefaultView.Sort = "SapXep ASC";
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            foreach (DataRow dr in ds.Tables[0].Rows)
    //            {
    //                if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
    //                {
    //                    TableRow tr = new TableRow();
    //                    TableCell td = new TableCell();
    //                    td.CssClass = "leftmenu";
    //                    td.Text = "<a href=\"estore.aspx?sid=" + CuaHangID.ToString() + "&cid=" + dr["NhomSanPhamID"].ToString() + "\">" + dr["TenNhomSanPham"].ToString() + "</a>";
    //                    tr.Cells.Add(td);
    //                    tblDanhMuc.Rows.Add(tr);
    //                    ds.Tables[0].DefaultView.RowFilter = "NhomChaID=" + dr["NhomSanPhamID"].ToString();
    //                    DataView dv = ds.Tables[0].DefaultView;
    //                    for (int i = 0; i < dv.Count; i++)
    //                    {
    //                        TableRow tr1 = new TableRow();
    //                        TableCell td1 = new TableCell();
    //                        tr1.CssClass = "subleftmenu";
    //                        td1.Style.Value = "padding-left:40px";
    //                        td1.Text = " <a href=\"estore.aspx?sid=" + CuaHangID.ToString() + "&cid=" + dv[i]["NhomSanPhamID"].ToString() + "\">" + "+ " + dv[i]["TenNhomSanPham"].ToString() + "</a>";
    //                        tr1.Cells.Add(td1);
    //                        tblDanhMuc.Rows.Add(tr1);

    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.ToString());
    //    }
    //}
    ////private void LoadHoTro()
    ////{
    ////    CuaHang ch = new CuaHang();
    ////    DataSet ds = ch.SelectByID(CuaHangID);
    ////    if (ds.Tables[0].Rows.Count != 1)
    ////    {
    ////        Response.Redirect("./message.aspx?msg=Invalid parameter");
    ////    }
    ////    else
    ////    {
    ////        DataRow dr = ds.Tables[0].Rows[0];
    ////        lblTenCuaHang2.Text = dr["TenCuaHang"].ToString();
    ////        lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
    ////        lblDiDong.Text = dr["DienThoaiDiDong"].ToString();
    ////        lnkYahoo.HRef = "ymsgr:sendIM?" + dr["YM"].ToString(); ;
    ////    }
    ////}
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
    //        content += "<a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[i]["CuaHangID"].ToString() 
    //            + "\"><img src=\"" + ds.Tables[0].Rows[i]["Anh"].ToString()
    //            + "\" width=\"110\" height=\"73\" hspace=\"4\" vspace=\"4\" style=\"border:#ece2a4 1px solid\" alt=\"" 
    //            + ds.Tables[0].Rows[i]["TenCuaHang"].ToString() + "\" /></a>";
    //        td.Text = content;
    //        td.HorizontalAlign = HorizontalAlign.Center;
    //        tr.Cells.Add(td);
    //        tblGianHang.Rows.Add(tr);
    //    }
    //}
    //private void LoadSanPhamTop()
    //{
    //    SanPham sp = new SanPham();
    //    DataSet ds = sp.SelectTopTenSanPhamByCuaHangID(CuaHangID);
    //    int n = ds.Tables[0].Rows.Count > 3 ? 3 : ds.Tables[0].Rows.Count;
    //    for (int i = 0; i < n; i++)
    //    {
    //        TableRow tr = new TableRow();
    //        TableCell td = new TableCell();
    //        string content = "";
    //        string tensanpham = ds.Tables[0].Rows[i]["TenSanPham"].ToString() +
    //                " " + ds.Tables[0].Rows[i]["TenSanPhamPhu"].ToString();
    //        if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

    //        content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
    //        content += "<tr><td align=\"center\" style=\"width:130px\"><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString() 
    //            + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
    //            + "\" alt=\"" + tensanpham 
    //            + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr><tr>";
    //        content += "<td align=\"center\" ><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString() 
    //            + "\">" + tensanpham + "</a><br />";
    //        content += "Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
    //            + "</span> " + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + " </td></tr></table>";
    //        td.Text = content;
    //        td.HorizontalAlign = HorizontalAlign.Center;
    //        tr.Cells.Add(td);
    //        tblTopTen.Rows.Add(tr);
    //    }
    //}
    private void LoadSanPhamAll(int NhomSanPhamID, int CurrentPage)
    {
        SanPham sp = new SanPham();
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        string keysearch = "";

        if ((txtlp.Value.ToString().Trim() != "NaN") || (txtup.Value.ToString().Trim() != "NaN") ||
            (txtname.Text.Trim() != ""))
        {
            keysearch = " 1=1 ";
            if (txtlp.Value.ToString() != "NaN")
                keysearch += " AND GiaSanPham >= " + txtlp.ValueLong;
            if (txtup.Value.ToString() != "NaN")
                keysearch += " AND GiaSanPham <= " + txtup.ValueLong;
            if (txtname.Text != "")
                keysearch += " AND (TenSanPham like '%" + txtname.Text + "%' or tensanphamphu like '%" + txtname.Text +
                             "%')";
        }


        DataSet ds = new DataSet();
        if (NhomSanPhamID == 0)
        {
            ds = sp.SelectSanPhamByCuaHangIDPaging(CuaHangID, RowStart, PageSize, keysearch);
        }
        else
        {
            ds = sp.SelectSanPhamByCuaHangIDInNhomSanPhamIDPaging(NhomSanPhamID, CuaHangID, RowStart, PageSize);
            //NhomSanPham nsp = new NhomSanPham();
            //DataSet nds = nsp.SelectByID(NhomSanPhamID);
            //if (nds.Tables[0].Rows.Count >= 1)
            //{
            //    //lblTenNhomSanPham.Text = " > " + nds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
            //}
        }


        //ds.Tables[0].DefaultView.RowFilter = "GiaSanPham > " + lp + " AND giasanpham < " + up;

        int n = ds.Tables[0].Rows.Count;
        int sosp = 3;
        int Rownum = PageSize/sosp;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            for (int j = 0; j < 3; j++)
            {
                int index = i*sosp + j;
                TableCell td = new TableCell();
                string content = "";
                if (index < n)
                {
                    string tensanpham = ds.Tables[0].Rows[index]["TenSanPham"] +
                                        " " + ds.Tables[0].Rows[index]["TenSanPhamPhu"];
                    if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content =
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id="
                               + ds.Tables[0].Rows[index]["SanPhamID"] + "\"><img src=\"" +
                               ds.Tables[0].Rows[index]["AnhSanPham"]
                               + "\" alt=\"" + tensanpham
                               +
                               "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id="
                               + ds.Tables[0].Rows[index]["SanPhamID"]
                               + "\">" + tensanpham
                               + "</a><br />Giá: <span class=\"price\">" +
                               String.Format("{0:0,0}", ds.Tables[0].Rows[index]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[index]["DonViTienTe"] + " </td></tr></table>";
                }
                td.Text = content;
                if (i == 0) td.Width = Unit.Percentage(33);
                tr.Cells.Add(td);
            }
            tblSanPham.Rows.Add(tr);
        }


        ddlPage.Visible = true;
        lblPage.Visible = true;
        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
        int NumberOfPage = NumberOfRow/PageSize;
        if (NumberOfPage*PageSize < NumberOfRow) NumberOfPage += 1;
        string strPage = "Trang";

        if (NumberOfPage <= 10)
        {
            for (int i = 1; i <= NumberOfPage; i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
        }
        else
        {
            if (CurrentPage > 1)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (1) + ")\"> |<< </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage - 1) + ")\"> < </a>";
                ;
            }
            for (int i = CurrentPage; i <= (CurrentPage + 10 > NumberOfPage ? NumberOfPage : CurrentPage + 10); i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
            if (CurrentPage + 10 < NumberOfPage)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage + 11) + ")\"> > </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (NumberOfPage) + ")\"> >>| </a>";
            }
        }
        lblPage.Text = strPage;
        ddlPage.Items.Clear();
        for (int i = 1; i <= NumberOfPage; i++)
        {
            ListItem li = new ListItem(i.ToString(), i.ToString());
            if (i == CurrentPage) li.Selected = true;
            ddlPage.Items.Add(li);
        }
    }

    private void LoadTab()
    {
        tblTab.Rows.Clear();
        TableRow tr = new TableRow();
        string caption = "";

        //TableCell firstTd = new TableCell();
        ////string fistTdContent = "<td width=\"2%\" valign=\"bottom\" class=\"tab_noactive\" style="height: 27px">
        //                                                                                //&nbsp;</td>"
        //firstTd.Width = Unit.Percentage(2);
        //firstTd.CssClass = "tab_noactive";
        //firstTd.Height = Unit.Pixel(26);
        //firstTd.VerticalAlign = VerticalAlign.Bottom;
        //tr.Cells.Add(firstTd);
        for (int i = 1; i < 5; i++)
        {
            switch (i)
            {
                case 1:
                    caption = "Tất cả";
                    if (!Page.IsPostBack)
                        LoadTabContent01(1);
                    break;
                case 2:
                    caption = "mới";
                    if (!Page.IsPostBack)
                        LoadTabContent02();
                    break;
                case 3:
                    caption = "Giảm giá";
                    if (!Page.IsPostBack)
                        LoadTabContent03(1);
                    break;
                case 4:
                    caption = "Khuyến mại";
                    if (!Page.IsPostBack)
                        LoadTabContent04(1);
                    break;
            }

            TableCell td = new TableCell();
            string content = "";
            if (i.ToString() == hidTabId.Value)
            {
                //active tab
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                content += "<tr><td width=\"12\"><img src=\"images/left_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                content += "<td class=\"tab_active\">" + caption + "</td>";
                content += "<td width=\"12\"><img src=\"images/right_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                content += "</tr></table>";
                td.Width = Unit.Percentage(25);
            }
            else
            {
                //inactive tab

                content = "<a href=\"#tab\" onclick=\"TabSelected(" + i + ")\">"
                          + caption + "</a>";
                td.CssClass = "tab_noactive";
                td.Style.Add("nowrap", "nowrap");
                td.Width = Unit.Percentage(25);
                td.Height = Unit.Pixel(26);
            }
            td.Text = content;
            td.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(td);
        }
        tblTab.Rows.Add(tr);
    }

    //private void LoadThongTinCuaHang(int id)
    //{
    //    try
    //    {
    //        pnlDamBao.Controls.Clear();
    //        DataAccess da = new DataAccess();
    //        string strSql = "Select * from viewcuahang where nguoidungid =" + id;

    //        DataSet ds = da.SelectByQuery(strSql);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[0];                
    //            lblDiemDanhGia.Text = string.Format("{0:0.0}", decimal.Parse("0" + dr["Diem"].ToString())).Replace(".", ",")
    //                + "(" + int.Parse("0"+ dr["Solandanhgia"].ToString()) + ")";

    //            int DamBao = int.Parse("0" + dr["BaoDam"].ToString());                
    //            for (int i = 0; i < DamBao; i++)
    //            {
    //                HtmlImage img = new HtmlImage();
    //                img.Src = "./images/kc.jpg";
    //                img.Border = 0;
    //                pnlDamBao.Controls.Add(img);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n", " "), false);
    //        Response.Write(ex.ToString());
    //    }
    //}
    private void LoadTabContent01(int CurrentPage)
    {
        LoadSanPhamAll(NhomSanPhamID, CurrentPage);
    }

    private void LoadTabContent02()
    {
        //San pham moi cap nhat  
        tblSanPham.Rows.Clear();
        int sosp = 3;
        int RowNum = PageSize/sosp;
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamMoiCapNhatByCuaHangID(CuaHangID);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < RowNum; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < sosp; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*sosp + i < n)
                {
                    string tensanpham = ds.Tables[0].Rows[j*sosp + i]["TenSanPham"] +
                                        " " + ds.Tables[0].Rows[j*sosp + i]["TenSanPhamPhu"];
                    if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*sosp + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr>";
                    content += "<tr><td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\">" + tensanpham
                               + "</a><br />Giá : <span class=\"price\">"
                               + String.Format("{0:0,0}", ds.Tables[0].Rows[j*sosp + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*sosp + i]["DonViTienTe"] + "<br/>"
                               + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Center;
                if (j == 0) td.Width = Unit.Percentage(33);
                tr.Cells.Add(td);
            }
            tblSanPham.Rows.Add(tr);
        }
        ddlPage.Visible = false;
        lblPage.Visible = false;
    }

    private void LoadTabContent03(int CurrentPage)
    {
        tblSanPham.Rows.Clear();
        //San pham giam gia
        int sosp = 3;
        int RowNum = PageSize/sosp;
        SanPham sp = new SanPham();
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        DataSet ds = sp.SelectAllSanPhamGiamGiaByCuaHangIDPaging(CuaHangID, PageSize, RowStart);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < RowNum; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < sosp; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*sosp + i < n)
                {
                    string tensanpham = ds.Tables[0].Rows[j*sosp + i]["TenSanPham"] +
                                        " " + ds.Tables[0].Rows[j*sosp + i]["TenSanPhamPhu"];
                    if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*sosp + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr>";
                    content += "<tr><td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\">" + tensanpham
                               + "</a><br />Giá cũ: <span class=\"oldprice\">"
                               + String.Format("{0:0,0}", ds.Tables[0].Rows[j*sosp + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*sosp + i]["DonViTienTe"] + "<br/>";
                    content += "Giá mới: <span class=\"price\">"
                               +
                               String.Format("{0:0,0}", ds.Tables[0].Rows[j*sosp + i]["GiaKhuyenMai"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*sosp + i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Center;
                if (j == 0) td.Width = Unit.Percentage(33);
                tr.Cells.Add(td);
            }
            tblSanPham.Rows.Add(tr);
        }
        ddlPage.Visible = true;
        lblPage.Visible = true;
        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        int NumberOfPage = NumberOfRow/PageSize;
        if (NumberOfPage*PageSize < NumberOfRow) NumberOfPage += 1;
        string strPage = "Trang";
        if (NumberOfPage <= 10)
        {
            for (int i = 1; i <= NumberOfPage; i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
        }
        else
        {
            if (CurrentPage > 1)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (1) + ")\"> |<< </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage - 1) + ")\"> < </a>";
                ;
            }
            for (int i = CurrentPage; i <= (CurrentPage + 10 > NumberOfPage ? NumberOfPage : CurrentPage + 10); i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
            if (CurrentPage + 10 < NumberOfPage)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage + 11) + ")\"> > </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (NumberOfPage) + ")\"> >>| </a>";
            }
        }
        lblPage.Text = strPage;
        ddlPage.Items.Clear();
        for (int i = 1; i <= NumberOfPage; i++)
        {
            ListItem li = new ListItem(i.ToString(), i.ToString());
            if (i == CurrentPage) li.Selected = true;
            ddlPage.Items.Add(li);
        }
    }

    private void LoadTabContent04(int CurrentPage)
    {
        tblSanPham.Rows.Clear();
        //San pham khuyen mai
        int sosp = 3;
        int RowNum = PageSize/sosp;
        SanPham sp = new SanPham();
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        DataSet ds = sp.SelectAllSanPhamKhuyenMaiByCuaHangIDPaging(CuaHangID, PageSize, RowStart);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < RowNum; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < sosp; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*sosp + i < n)
                {
                    string tensanpham = ds.Tables[0].Rows[j*sosp + i]["TenSanPham"] +
                                        " " + ds.Tables[0].Rows[j*sosp + i]["TenSanPhamPhu"];
                    if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*sosp + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr>";
                    content += "<tr><td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*sosp + i]["SanPhamID"]
                               + "\">" + tensanpham
                               + "</a><br />Giá: <span class=\"price\">" +
                               String.Format("{0:0,0}", ds.Tables[0].Rows[j*sosp + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + ds.Tables[0].Rows[j*sosp + i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Center;
                if (j == 0) td.Width = Unit.Percentage(33);
                tr.Cells.Add(td);
            }
            tblSanPham.Rows.Add(tr);
        }
        ddlPage.Visible = true;
        lblPage.Visible = true;
        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
        int NumberOfPage = NumberOfRow/PageSize;
        if (NumberOfPage*PageSize < NumberOfRow) NumberOfPage += 1;
        string strPage = "Trang";
        if (NumberOfPage <= 10)
        {
            for (int i = 1; i <= NumberOfPage; i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
        }
        else
        {
            if (CurrentPage > 1)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (1) + ")\"> |<< </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage - 1) + ")\"> < </a>";
                ;
            }
            for (int i = CurrentPage; i <= (CurrentPage + 10 > NumberOfPage ? NumberOfPage : CurrentPage + 10); i++)
            {
                if (i == CurrentPage)
                {
                    strPage += " [" + i + "]";
                }
                else
                {
                    strPage += " <a href=\"javascript:GoToPage(" + i + ")\">" + i + "</a>";
                }
            }
            if (CurrentPage + 10 < NumberOfPage)
            {
                strPage += " <a href=\"javascript:GoToPage(" + (CurrentPage + 11) + ")\"> > </a>";
                strPage += " <a href=\"javascript:GoToPage(" + (NumberOfPage) + ")\"> >>| </a>";
            }
        }
        lblPage.Text = strPage;
        ddlPage.Items.Clear();
        for (int i = 1; i <= NumberOfPage; i++)
        {
            ListItem li = new ListItem(i.ToString(), i.ToString());
            if (i == CurrentPage) li.Selected = true;
            ddlPage.Items.Add(li);
        }
    }

    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        int page = 1;
        if (hidPage.Value != "")
            page = int.Parse(hidPage.Value);
        //LoadSanPhamAll(NhomSanPhamID, int.Parse(hidPage.Value));
        switch (hidTabId.Value)
        {
            case "1":
                LoadTabContent01(page);
                break;
            case "2":
                LoadTabContent02();
                break;
            case "3":
                LoadTabContent03(page);
                break;
            case "4":
                LoadTabContent04(page);
                break;
        }
    }

    //protected void pnlVote_ContentRefresh(object sender, EventArgs e)
    //{
    //    if (Common.SessionIsOK())
    //    {
    //        BinhChon bc = new BinhChon();
    //        DataSet ds = bc.SelectBinhChonByNguoiDungIDAndCuaHangID(Common.NguoiDungID(), CuaHangID);
    //        if (ds.Tables[0].Rows.Count == 0)
    //        {
    //            //bc.InsertFields(CuaHangID, Common.NguoiDungID(), int.Parse(hidVote.Value.ToString()), null, null, null);
    //            LoadBinhChon();
    //            lblMessage.Text = "Bình chọn thành công.";
    //        }
    //        else
    //        {
    //            lblMessage.Text = "Bạn đã thực hiện bình chọn.";
    //        }
    //    }
    //    else
    //    {
    //        lblMessage.Text = "Bạn cần <a href=\"./login.aspx?ReturnUrl=estore.aspx?sid=" + CuaHangID.ToString() + "\">đăng nhập</a> để bình chọn.";
    //    }
    //}
    //protected void pnlCuaHang_ContentRefresh(object sender, EventArgs e)
    //{
    //    LoadThongTinCuaHang(ChuCuaHangID);
    //}
}