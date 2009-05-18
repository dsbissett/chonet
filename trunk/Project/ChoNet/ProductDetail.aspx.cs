using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer;
using CHONET.DataAccessLayer.Web;
using System.IO;
using Image=System.Drawing.Image;

public partial class ProductDetail : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["YM"] = "";
            ViewState["SanPhamID"] = "0";
            ViewState["CuaHangID"] = "0";
            ViewState["NguoiDungID"] = "0";
            ViewState["SanPhamMauID"] = "0";
        }

        if (Request.QueryString["id"] != null)
        {
            tblTraGia.Visible = Common.LoaiNguoiDungID() == 1;
            ViewState["SanPhamID"] = Request.QueryString["id"];
            tblCacCuaHang.Visible = false;
            LoadKhuVuc();
            LoadData();
            LoadTab();
            //LoadQuangCao41();
            //LoadQuangCao42();
            switch (hidTabId.Value)
            {
                case "1":
                    LoadTabContent01();
                    break;
                case "2":
                    LoadTabContent02();
                    break;
                case "3":
                    LoadTabContent03();
                    break;
                case "4":
                    LoadTabContent04();
                    break;
            }

            SetSuaGia();
        }
        else
        {
            imgSanPham.Src = "#";
            lblTenSanPham.Text = "";
            divThongTinSanPham.InnerText = "";
            lblGiaSanPham.Text = "";
            lblDonViTienTe.Text = "";
            lblMaSoSanPham.Text = "";
        }
        //pnlAllSanPham.Attributes.Add("onload", "autorefreshsanpham();");
        //string strScript = "<script language='text/javascript'>" + "return autorefreshsanpham();</script>";
        //ClientScript.RegisterStartupScript(Type.GetType("System.String"), "autorefreshsanpham", strScript);
    }

    private void AddSanPhamDaXem(DataTable dtSanPham)
    {
        if (Session["tblSanPhamDaXem"] != null)
        {
            DataTable tblSanPhamDaXem = (DataTable) Session["tblSanPhamDaXem"];
            Boolean blexist = false;
            foreach (DataRow dr in tblSanPhamDaXem.Rows)
            {
                if (dr["SanPhamID"].ToString() == dtSanPham.Rows[0]["SanPhamID"].ToString())
                    blexist = true;
            }
            if (blexist == false)
            {
                DataRow drNew = tblSanPhamDaXem.NewRow();
                for (int j = 0; j < tblSanPhamDaXem.Columns.Count; j++)
                {
                    drNew[j] = dtSanPham.Rows[0][j];
                }
                tblSanPhamDaXem.Rows.Add(drNew);
                Session["tblSanPhamDaXem"] = tblSanPhamDaXem;
            }
        }
        else
        {
            DataTable tblSanPhamDaXem = dtSanPham.Copy();
            Session["tblSanPhamDaXem"] = tblSanPhamDaXem;
        }
    }

    private void SetSuaGia()
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            lblThongBaoGia.Visible = true;
            lblGia.Visible = true;
            ThongBaoGia();
        }
        else
        {
            lblThongBaoGia.Visible = false;
            lblGia.Visible = false;
        }
    }

    private void ThongBaoGia()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectByNguoiDungID(Common.NguoiDungID());
        ds.Tables[0].DefaultView.RowFilter = " (SanPhamMauID <> 0 or TenSanPham='" + ViewState["TenGocSanPham"] +
                                             "') AND SanPhamMauID = " + ViewState["SanPhamMauID"];
                                             //+ " AND SanphamID <> " + ViewState["SanPhamID"];

        if (ds.Tables[0].DefaultView.Count > 0)
        {
            ds.Tables[0].DefaultView.Sort = "GiaSanPham";
            lblGia.Text = String.Format("{0:0,0}", ds.Tables[0].DefaultView[0]["GiaSanPham"]).Replace(",", ".") + " VNĐ";
            ViewState["SanPhamCungLoaiID"] = ds.Tables[0].DefaultView[0]["SanPhamID"];
            linkgianhang.HRef = "ProductDetail.aspx?id=" + ds.Tables[0].DefaultView[0]["SanPhamID"];
            lblThongBaoGia.Visible = true;
        }
        else
        {
            lblThongBaoGia.Visible = false;
            lblGia.Visible = false;
            imgSuaGia.Visible = false;
            linkgianhang.Visible = false;
        }
    }

    //private void LoadQuangCao41()
    //{
        //QuangCao qcao = new QuangCao();
        //DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(int.Parse(ViewState["NguoiDungID"].ToString()), 41);
        //HtmlGenericControl spnQuangCao41 = (HtmlGenericControl)this.Master.FindControl("spnQuangCao01");
        //if (ds.Tables[0].Rows.Count >= 1)
        //{
        //    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
        //    {
        //        spnQuangCao41.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
        //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
        //            + "width=\"210\" height=\"75\" title=\"Quang Cao\">"
        //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
        //            + "<param name=\"quality\" value=\"high\" />"
        //            + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
        //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
        //            + "width=\"210\" height=\"75\"></embed></object>";
        //    }
        //    else
        //    {
        //        spnQuangCao41.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
        //            + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
        //            + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"75px\" width=\"210px\" style=\"Border:none\"/></a>";
        //    }

        //}
        //else
        //{
        //    spnQuangCao41.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"75px\" width=\"210px\" style=\"border:none\"/>";
        //}
    //}

    //private void LoadQuangCao42()
    //{
        //QuangCao qcao = new QuangCao();
        //DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(int.Parse(ViewState["NguoiDungID"].ToString()), 42);
        //int n = ds.Tables[0].Rows.Count;
        //spnQuangCao42a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao42b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao42c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/>";
        //if (n >= 1)
        //{
        //    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
        //    {
        //        spnQuangCao42a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
        //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
        //            + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
        //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
        //            + "<param name=\"quality\" value=\"high\" />"
        //            + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
        //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
        //            + "width=\"312\" height=\"122\"></embed></object>";
        //    }
        //    else
        //    {
        //        spnQuangCao42a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
        //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
        //          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
        //    }
        //    if (n >= 2)
        //    {
        //        if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
        //        {
        //            spnQuangCao42b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
        //                + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
        //                + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
        //                + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
        //                + "<param name=\"quality\" value=\"high\" />"
        //                + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
        //                + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
        //                + "width=\"312\" height=\"122\"></embed></object>";
        //        }
        //        else
        //        {
        //            spnQuangCao42b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
        //              + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
        //              + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
        //        }
        //        if (n >= 3)
        //        {
        //            if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
        //            {
        //                spnQuangCao42c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
        //                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
        //                    + "width=\"312\" height=\"122\" title=\"Quang Cao\">"
        //                    + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
        //                    + "<param name=\"quality\" value=\"high\" />"
        //                    + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
        //                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
        //                    + "width=\"312\" height=\"122\"></embed></object>";
        //            }
        //            else
        //            {
        //                spnQuangCao42c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
        //                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
        //                  + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"312px\" style=\"border:solid 1px #C9C3C3\"/></a>";
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    tblQuangCao42.Visible = false;
        //}
    //}

    private void ShowLink(int NhomSanPhamId)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds2 = nsp.SelectByID(NhomSanPhamId);
        if (ds2.Tables[0].Rows.Count == 1)
        {
            lblDanhMucCon.Text = ds2.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
        }

        DataSet ds1 = nsp.SelectByID(int.Parse(ds2.Tables[0].Rows[0]["NhomChaID"].ToString()));
        if (ds1.Tables[0].Rows.Count == 1)
        {
            lnkDanhMucCha.Text = ds1.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
            lnkDanhMucCha.PostBackUrl = "maincategory.aspx?mcid=" + ds2.Tables[0].Rows[0]["NhomChaID"];
            lblArrow.Visible = true;
        }
        else
        {
            lblArrow.Visible = false;
        }
    }

    private void LoadTab()
    {
        tblTab.Rows.Clear();
        TableRow tr = new TableRow();
        string caption = "";
        for (int i = 1; i < 5; i++)
        {
            switch (i)
            {
                case 1:
                    caption = "Thông tin sản phẩm";
                    if (!Page.IsPostBack)
                        LoadTabContent01();
                    break;
                case 2:
                    caption = "Các cửa hàng bán";
                    if (!Page.IsPostBack)
                        LoadTabContent02();
                    break;
                case 3:
                    caption = "Hỏi đáp, phản hồi";
                    if (!Page.IsPostBack)
                        LoadTabContent03();
                    break;
                case 4:
                    caption = "Trả giá";
                    if (!Page.IsPostBack)
                        LoadTabContent04();
                    break;
            }

            TableCell td = new TableCell();
            string content = "";
            if (i.ToString() == hidTabId.Value)
            {
                //active tab
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                content += "<tr><td width=\"12\"></td>";
                content += "<td class=\"nd2\">" + caption + "</td>";
                content += "<td width=\"12\"></td></tr></table>";
            }
            else
            {
                //inactive tab
                content = "<a href=\"#tab\" onclick=\"TabSelected(" + i + ",false)\">" + caption + "</a>";
                td.CssClass = "nd1";
                td.Height = Unit.Pixel(26);
            }
            td.Text = content;
            td.Width = Unit.Percentage(25);
            td.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(td);
        }
        tblTab.Rows.Add(tr);
    }

    private void LoadTabContent01()
    {
        tblTraGiaContent.Visible = false;
        tblHoiDapContent.Visible = false;
        tblCacCuaHang.Visible = false;
        tblHoiDap.Visible = false;
        tblContent.Rows.Clear();
        SanPham sp = new SanPham();
        DataSet sds = sp.SelectByID(int.Parse(ViewState["SanPhamID"].ToString()));
        if (sds.Tables[0].Rows.Count > 0)
        {
            string strThongTin = sds.Tables[0].Rows[0]["ThongTinSanPham"].ToString().Replace("\r\n", "<br/>");


            TableRow str = new TableRow();

            TableCell std = new TableCell();
            string scontent = "";

            scontent += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
            scontent += "<tr><td align=\"center\"></td>";
            scontent += "</tr><tr><td align=\"left\" style=\"padding-left:15px\">" + strThongTin
                        + "<br />";
            scontent += "</td></tr></table>";

            std.Text = scontent;
            str.Cells.Add(std);

            tblContent.Rows.Add(str);
        }
    }

    private void LoadTabContent02()
    {
        tblTraGiaContent.Visible = false;
        tblHoiDap.Visible = false;
        tblHoiDapContent.Visible = false;
        tblCacCuaHang.Visible = true;
        tblContent.Rows.Clear();

        DataAccess da = new DataAccess();
        string strSql = "Select * from viewsanpham where (sanphamid <>" + int.Parse(ViewState["SanPhamID"].ToString())
                        +
                        (ddlKhuVuc.SelectedIndex == 0
                             ? ""
                             : " and KhuVucID=" + ddlKhuVuc.Items[ddlKhuVuc.SelectedIndex].Value)
                        + " AND sanphammauid<>0 AND sanphammauid=" + int.Parse(0 + ViewState["SanPhamMauID"].ToString())
                        + " OR (Lower(TenSanPham) = (select Lower(TenSanPham) from sanpham where sanphamid=" +
                        int.Parse(ViewState["SanPhamID"].ToString())
                        + " AND NhomSanPhamID=(select nhomsanphamid from sanpham where sanphamid=" +
                        int.Parse(ViewState["SanPhamID"].ToString())
                        + ")))) ORDER BY GiaSanPham, Diem DESC, TenCuaHang ";

        DataSet ds = da.SelectByQuery(strSql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCuaHangBan.Visible = false;
            //string strThongTin = sds.Tables[0].Rows[0]["ThongTinSanPham"].ToString();
            int countrow = tblcontencuahang.Rows.Count;
            for (int j = 1; j < countrow; j++)
            {
                tblcontencuahang.Rows.Remove(tblcontencuahang.Rows[1]);
            }

            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
            {
                string GiaThapNhat = ds.Tables[0].Rows[0]["GiaSanPham"].ToString();
                DataRow dr = ds.Tables[0].Rows[index];
                string GiaHienTai = dr["GiaSanPham"].ToString();
                HtmlTableRow str = new HtmlTableRow();
                HtmlTableCell std1 = new HtmlTableCell();
                HtmlTableCell std2 = new HtmlTableCell();
                HtmlTableCell std3 = new HtmlTableCell();
                HtmlTableCell std4 = new HtmlTableCell();
                HtmlTableCell std5 = new HtmlTableCell();

                std1.Align = "center";
                std2.Align = "left";
                std2.Style.Add("padding-left", "15px");
                std3.Align = "right";
                std3.Style.Add("padding-right", "10px");
                std4.Align = "center";
                std5.Align = "center";

                std1.Style.Add("border-right", "1pt solid");
                std1.Style.Add("border-bottom", "1pt solid");
                std2.Style.Add("border-right", "1pt solid");
                std2.Style.Add("border-bottom", "1pt solid");
                std3.Style.Add("border-right", "1pt solid");
                std3.Style.Add("border-bottom", "1pt solid");
                std4.Style.Add("border-right", "1pt solid");
                std4.Style.Add("border-bottom", "1pt solid");
                std5.Style.Add("border-right", "1pt solid");
                std5.Style.Add("border-bottom", "1pt solid");

                std1.InnerHtml = (index + 1).ToString();
                std2.InnerHtml = "<a href=\"./estore.aspx?sid=" + dr["CuaHangID"] + "\">" + dr["TenCuaHang"] + "</a>" +
                                 "<br><a href=\"./shoppingcart.aspx?spid=" + dr["SanPhamID"] +
                                 "\"><img border=\"0\" src=\"./images/muahang.jpg\"></a>" +
                                 "<a href=\"ymsgr:sendIM?" + dr["YM"] + "\"><img src=\"http://opi.yahoo.com/online?u=" +
                                 dr["YM"] + "&t=1\" border=\"0\"></a>";

                std3.InnerHtml = "<b>" +
                                 String.Format("{0:0,0}", decimal.Parse("0" + dr["GiaSanPham"])).Replace(",", ".") +
                                 " VNĐ </b>";
                if (GiaHienTai == GiaThapNhat)
                    std3.InnerHtml += "<br><font color=red>Giá thấp nhất</font>";
                if (dr["NgayCapNhat"].ToString() != "")
                {
                    std3.InnerHtml += "<br><b> Cập nhật: " +
                                      DateTime.Parse(dr["NgayCapNhat"].ToString()).ToString("dd/MM/yyyy") +
                                      " Lúc: " + DateTime.Parse(dr["NgayCapNhat"].ToString()).ToString("hh:mm") + "</b>";
                }
                else if (dr["NgayThemSanPham"].ToString() != "")
                {
                    std3.InnerHtml += "<br><b> Cập nhật: " +
                                      DateTime.Parse(dr["NgayThemSanPham"].ToString()).ToString("dd/MM/yyyy") +
                                      " Lúc: " + DateTime.Parse(dr["NgayThemSanPham"].ToString()).ToString("hh:mm") +
                                      "</b>";
                }

                //std4.InnerHtml = dr["diem"].ToString();

                int sodiem = (int) decimal.Parse("0" + dr["diem"]);
                for (int i = 0; i < sodiem; i++)
                {
                    std4.InnerHtml += "<img align=\"absmiddle\" border=\"0\" src=\"./images/star1.gif\">";
                }

                for (int i = 10; i > sodiem; i--)
                {
                    std4.InnerHtml += "<img align=\"absmiddle\" border=\"0\" src=\"./images/star0.gif\">";
                }

                std4.InnerHtml += string.Format("{0:0.0}", decimal.Parse("0" + dr["diem"]));
                std4.InnerHtml += "<br><a href=#><img border=0 src=\"./images/poll.gif\">Đánh giá</a>";

                std5.InnerHtml = dr["DiaChi"] + "<b>(" + dr["TenKhuVuc"] + "</b>)<br><b> Tel: </b>" +
                                 dr["DienThoaiDiDong"];

                str.Cells.Add(std1);
                str.Cells.Add(std2);
                str.Cells.Add(std3);
                str.Cells.Add(std4);
                str.Cells.Add(std5);

                tblcontencuahang.Rows.Add(str);
            }
        }
        else
        {
            lblCuaHangBan.Visible = true;
        }
    }

    private void LoadTabContent03()
    {
        tblHoiDap.Visible = Common.NguoiDungID() != 0;
        tblTraGiaContent.Visible = false;
        tblHoiDapContent.Visible = true;
        tblCacCuaHang.Visible = false;
        tblContent.Rows.Clear();
        HoiDapSanPham hdsp = new HoiDapSanPham();
        DataSet hdds = hdsp.SelectHoiDapSanPhamBySanPhamID(int.Parse(ViewState["SanPhamID"].ToString()));
        //string strThongTin = sds.Tables[0].Rows[0]["ThongTinSanPham"].ToString();
        if (hdds.Tables[0].Rows.Count > 0)
        {
            lblHoiDap.Visible = false;
            int countrow = tblHoiDapContent.Rows.Count;
            for (int j = 1; j < countrow; j++)
            {
                tblHoiDapContent.Rows.Remove(tblHoiDapContent.Rows[1]);
            }
            int index = 0;
            foreach (DataRow dr in hdds.Tables[0].Rows)
            {
                index++;
                HtmlTableRow str = new HtmlTableRow();
                HtmlTableCell std1 = new HtmlTableCell();
                HtmlTableCell std2 = new HtmlTableCell();
                HtmlTableCell std3 = new HtmlTableCell();
                HtmlTableCell std4 = new HtmlTableCell();
                //HtmlTableCell std5 = new HtmlTableCell();
                std1.Align = "center";
                std1.Style.Add("border", "1pt solid");
                std2.Align = "left";
                std2.Style.Add("padding-left", "15px");
                std2.Style.Add("border", "1pt solid");
                std3.Align = "left";
                std3.Style.Add("padding-right", "10px");
                std3.Style.Add("border", "1pt solid");
                std4.Align = "center";
                std4.Style.Add("border", "1pt solid");
                //std5.Align = "center";

                std1.InnerHtml = index.ToString();
                std2.InnerHtml = dr["HovaTen"] + "<br>" +
                                 "<a href=\"ymsgr:sendIM?" + dr["YM"] + "\"><img src=\"http://opi.yahoo.com/online?u=" +
                                 dr["YM"] + "&t=1\" border=\"0\"></a>";
                std3.InnerHtml = "<b>" + dr["CauHoi"] + "</b><br>" + dr["ChiTietCauHoi"];
                std4.InnerHtml = "(" + DateTime.Parse(dr["NgayHoi"].ToString()).ToString("dd/MM/yyyy") + ")";

                str.Cells.Add(std1);
                str.Cells.Add(std2);
                str.Cells.Add(std3);
                str.Cells.Add(std4);
                //str.Cells.Add(std5);

                tblHoiDapContent.Rows.Add(str);
            }
        }
        else
        {
            lblHoiDap.Visible = true;
        }
    }

    private void LoadTabContent04()
    {
        tblTraGiaContent.Visible = true;
        tblHoiDap.Visible = false;
        tblHoiDapContent.Visible = false;
        tblCacCuaHang.Visible = false;
        tblContent.Rows.Clear();

        TraGiaSanPham tg = new TraGiaSanPham();
        DataSet sds = tg.SelectTraGiaSanPhamBySanPhamID(int.Parse(ViewState["SanPhamID"].ToString()));
        //string strThongTin = sds.Tables[0].Rows[0]["ThongTinSanPham"].ToString();
        int countrow = tblTraGiaContent.Rows.Count;
        for (int j = 1; j < countrow; j++)
        {
            tblTraGiaContent.Rows.Remove(tblTraGiaContent.Rows[1]);
        }

        int index = 0;
        foreach (DataRow dr in sds.Tables[0].Rows)
        {
            index++;
            HtmlTableRow str = new HtmlTableRow();
            //str.Style.Add("border", "1pt solid");
            HtmlTableCell std1 = new HtmlTableCell();
            HtmlTableCell std2 = new HtmlTableCell();
            HtmlTableCell std3 = new HtmlTableCell();
            HtmlTableCell std4 = new HtmlTableCell();
            HtmlTableCell std5 = new HtmlTableCell();
            std1.Align = "center";
            std1.Style.Add("border-right", "1pt solid");
            std1.Style.Add("border-bottom", "1pt solid");
            std2.Align = "center";
            std2.Style.Add("border-right", "1pt solid");
            std2.Style.Add("border-bottom", "1pt solid");
            std3.Align = "center";
            std3.Style.Add("border-right", "1pt solid");
            std3.Style.Add("border-bottom", "1pt solid");
            std4.Align = "center";
            std4.Style.Add("border-right", "1pt solid");
            std4.Style.Add("border-bottom", "1pt solid");
            std5.Align = "center";
            std5.Style.Add("border-right", "1pt solid");
            std5.Style.Add("border-bottom", "1pt solid");

            std1.InnerHtml = index.ToString();
            std2.InnerHtml = dr["HovaTen"] + "<br>" +
                             "<a href=\"ymsgr:sendIM?" + dr["YM"] + "\"><img src=\"http://opi.yahoo.com/online?u=" +
                             dr["YM"] + "&t=1\" border=\"0\"></a>";
            std3.InnerHtml = "<b>" + String.Format("{0:0,0}", decimal.Parse("0" + dr["GiaMuonMua"])).Replace(",", ".") +
                             " VNĐ";
            std4.InnerHtml = "&nbsp;" + dr["SoLuong"];
            std5.InnerHtml = "&nbsp;" + dr["ChiTiet"];

            str.Cells.Add(std1);
            str.Cells.Add(std2);
            str.Cells.Add(std3);
            str.Cells.Add(std4);
            str.Cells.Add(std5);

            tblTraGiaContent.Rows.Add(str);
        }
    }

    private void LoadData()
    {
        try
        {
            SanPham sanpham = new SanPham();
            DataSet dsSanPham = sanpham.SelectByID(int.Parse(ViewState["SanPhamID"].ToString()));


            if (dsSanPham.Tables[0].Rows.Count > 0)
            {
                DataRow drSanPham = dsSanPham.Tables[0].Rows[0];
                string filename = Server.MapPath(drSanPham["AnhSanPham"].ToString());
                Image image;
                if (File.Exists(filename))
                {
                    image = Image.FromFile(filename);

                    int srcWidth = image.Width;
                    int srcHeight = image.Height;
                    if (image.Width > 323)
                    {
                        Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
                        int thumbHeight = Decimal.ToInt32(sizeRatio * 323);
                        imgSanPham.Width = 323;
                        imgSanPham.Height = thumbHeight;
                    }
                    else if (image.Height > 323)
                    {
                        Decimal sizeRatio = ((Decimal)srcWidth / srcHeight);
                        int thumbWidth = Decimal.ToInt32(sizeRatio * 323);
                        imgSanPham.Height = 323;
                        imgSanPham.Width = thumbWidth;
                    }
                    else
                    {
                        imgSanPham.Height = srcHeight;
                        imgSanPham.Width = srcWidth;
                    }
                }
                imgSanPham.Src = drSanPham["AnhSanPham"].ToString();
                lblTenSanPham.Text = drSanPham["TenSanPham"] + " " + drSanPham["TenSanPhamPhu"];
                Title = lblTenSanPham.Text;
                ViewState["TenGocSanPham"] = drSanPham["TenSanPham"].ToString();
                lblProdName.Text = lblTenSanPham.Text;
                divThongTinSanPham.InnerHtml += drSanPham["MoTaSanPham"].ToString().Replace("\r\n", "<br/>");

                if (bool.Parse(drSanPham["KhuyenMai"].ToString()))
                {
                    tblKhuyenMai.Visible = true;
                    divThongTinKhuyenMai.InnerHtml = drSanPham["MoTaKhuyenMai"].ToString();
                }
                else
                {
                    tblKhuyenMai.Visible = false;
                }

                if (bool.Parse(drSanPham["GiamGia"].ToString()))
                {
                    lbl2.Visible = true;
                    lblGiaMoi.Visible = true;
                    lbl3.Visible = true;
                    lbl1.Text = "Giá cũ: ";
                    lbl2.Text = "Giá mới: ";
                    lblGiaSanPham.Text = String.Format("{0:0,0}", drSanPham["GiaSanPham"]).Replace(",", ".");
                    lblGiaSanPham.Font.Strikeout = true;
                    lblGiaMoi.Text = String.Format("{0:0,0}", drSanPham["GiaKhuyenMai"]).Replace(",", ".");
                    lblGiaSanPhamTraGia.Text = String.Format("{0:0,0}", drSanPham["GiaKhuyenMai"]).Replace(",", ".");
                }
                else
                {
                    lbl1.Text = "Giá sản phẩm";
                    lblGiaSanPham.Text = String.Format("{0:0,0}", drSanPham["GiaSanPham"]).Replace(",", ".");
                    lblGiaSanPhamTraGia.Text = String.Format("{0:0,0}", drSanPham["GiaSanPham"]).Replace(",", ".");
                    lbl2.Visible = false;
                    lblGiaMoi.Visible = false;
                    lbl3.Visible = false;
                }

                lblDonViTienTe.Text = "VNĐ";
                lblMaSoSanPham.Text = drSanPham["MaSoSanPham"].ToString();

                ShowLink(int.Parse(drSanPham["NhomSanPhamID"].ToString()));
                ShowAnhSanPham();
                ShowNhaCungCap(int.Parse(drSanPham["NguoiDungID"].ToString()));
                ViewState["NguoiDungID"] = drSanPham["NguoiDungID"].ToString();
                if (drSanPham["SanPhamMauID"].ToString() != "")
                    ViewState["SanPhamMauID"] = drSanPham["SanPhamMauID"].ToString();
                ViewState["NhomSanPhamID"] = drSanPham["NhomSanPhamID"].ToString();
                LoadSanPhamCungLoai(int.Parse(drSanPham["NhomSanPhamID"].ToString()));

                if (!Page.IsPostBack)
                {
                    AddSanPhamDaXem(dsSanPham.Tables[0]);
                    // bak3 la truong dung de luu so lan xem san pham
                    sanpham.UpdateFields(int.Parse(ViewState["SanPhamID"].ToString()), null, null, null, null,
                                         null, null, null, null, null, null, null, null, null, null, null, null, null,
                                         null, null, null, null, null, null, null, null,
                                         int.Parse(drSanPham["bak3"].ToString()) + 1
                                         , null, null, null, null, null, null, null);
                }

                ShowGianHangDamBao();

                DataAccess da = new DataAccess();
                string strSql =
                    "Select count(distinct cuahangid) as soluong from viewsanpham where ((Lower(TenSanPham) = (select Lower(TenSanPham) from sanpham where sanphamid=" +
                    int.Parse(ViewState["SanPhamID"].ToString()) +
                    ")) OR ((sanphammauid <>0) and (sanphammauid=" + int.Parse(0 + ViewState["SanPhamMauID"].ToString()) +
                    ")))";
                DataSet dssch = da.SelectByQuery(strSql);

                lblSoCuaHang.Text = dssch.Tables[0].Rows[0]["soluong"].ToString() != "0" ? dssch.Tables[0].Rows[0]["soluong"].ToString() : "1";
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n"," "), false);
            Response.Write(ex.ToString());
        }
    }

    private void ShowGianHangDamBao()
    {
        DataAccess da = new DataAccess();
        string strSql = "Select * from viewsanpham where sanphamid <>" + int.Parse(ViewState["SanPhamID"].ToString())
                        +
                        (ddlKhuVuc.SelectedIndex == 0
                             ? ""
                             : " and KhuVucID=" + ddlKhuVuc.Items[ddlKhuVuc.SelectedIndex].Value)
                        + " AND sanphammauid=" + int.Parse(0 + ViewState["SanPhamMauID"].ToString()) +
                        " AND BaoDam <> 0 ORDER BY BaoDam desc, GiaSanPham, Diem DESC, TenCuaHang ";

        DataSet ds = da.SelectByQuery(strSql);

        tblGianHangDuocDamBao.Rows.Clear();


        if (ds.Tables[0].Rows.Count > 0)
        {
            divGianHangDamBao.Style.Add("height", "100px");
            lblGianHangDamBao.Visible = false;
            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
            {
                lblGianHangDamBao.Visible = false;
                DataRow dr = ds.Tables[0].Rows[index];
                HtmlTableRow str = new HtmlTableRow();
                HtmlTableCell std1 = new HtmlTableCell();
                HtmlTableCell std2 = new HtmlTableCell();
                HtmlTableCell std3 = new HtmlTableCell();
                HtmlTableCell std4 = new HtmlTableCell();
                HtmlTableCell std5 = new HtmlTableCell();

                std1.Align = "center";
                std1.Width = "5%";
                std2.Align = "left";
                std2.Style.Add("padding-left", "15px");
                std2.Width = "13%";
                std3.Width = "47%";
                std3.Align = "Center";
                std3.Style.Add("padding-right", "10px");

                std4.Width = "20%";
                std4.Align = "center";
                std5.Width = "16%";
                std5.Align = "center";

                std1.Style.Add("border-right", "1pt solid");
                std1.Style.Add("border-bottom", "1pt solid");
                std2.Style.Add("border-right", "1pt solid");
                std2.Style.Add("border-bottom", "1pt solid");
                std3.Style.Add("border-right", "1pt solid");
                std3.Style.Add("border-bottom", "1pt solid");
                std4.Style.Add("border-right", "1pt solid");
                std4.Style.Add("border-bottom", "1pt solid");
                std5.Style.Add("border-right", "1pt solid");
                std5.Style.Add("border-bottom", "1pt solid");

                std1.InnerHtml = (index + 1).ToString();
                std2.InnerHtml = "<img src=\"http://opi.yahoo.com/online?u=" + dr["YM"] + "&t=1\" border=\"0\">";
                std3.InnerHtml = "<a href=\"./estore.aspx?sid=" + dr["CuaHangID"] + "\">" + dr["TenCuaHang"] +
                                 "(" + dr["TenKhuVuc"] + ")</a>";

                std4.InnerHtml = "<b>" +
                                 String.Format("{0:0,0}", decimal.Parse("0" + dr["GiaSanPham"])).Replace(",", ".") +
                                 " VNĐ </b>";
                std5.InnerHtml = "<a href=\"./shoppingcart.aspx?spid=" + dr["SanPhamID"] +
                                 "\"><img border=\"0\" src=\"./images/muahang.jpg\"></a>";

                str.Cells.Add(std1);
                str.Cells.Add(std2);
                str.Cells.Add(std3);
                str.Cells.Add(std4);
                str.Cells.Add(std5);

                tblGianHangDuocDamBao.Rows.Add(str);
            }
        }
        else
        {
            divGianHangDamBao.Style.Add("height", "40px");
            lblGianHangDamBao.Visible = true;
        }
    }

/*
    private void SelectSanPhamData()
    {
        int intSanPhamID = int.Parse(ViewState["SanPhamID"].ToString());
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectByID(intSanPhamID);
        string strThongTinSP = ds.Tables[0].Rows[0]["ThongTinSanPham"].ToString();

        NhanXetSanPham nx = new NhanXetSanPham();
        DataTable dtNhanXet = nx.SelectBySanPhamID(intSanPhamID).Tables[0];

        HoiDapSanPham hd = new HoiDapSanPham();
        DataTable dtHoiDap = hd.SelectBySanPhamID(intSanPhamID).Tables[0];

        TableRow tr = new TableRow();
        TableCell td = new TableCell();

        if (hidTabId.Value.Trim().Length > 0)
        {
            string content = "";
            switch (hidTabId.Value)
            {
                case "1":
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content +=
                        "<tr><td width=\"12\"><img src=\"./images/left_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                    content += "<td style=\"background-color:#AFAFAF;\" class=\"tab_active\">Thông tin sản phẩm</td>";
                    content +=
                        "<td width=\"12\"><img src=\"./images/right_tab.jpg\" width=\"12\" height=\"27\" /></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //lblTab.Text = "Thông tin sản phẩm";

                    TableRow str = new TableRow();
                    TableCell std = new TableCell();
                    string scontent = "";
                    scontent = "";
                    scontent +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    scontent += "<tr><td align=\"center\">" + strThongTinSP;
                    scontent += "</td></tr></table>";

                    std.Text = scontent;
                    std.Width = Unit.Percentage(16);
                    str.Cells.Add(std);

                    tblContent.Rows.Add(str);

                    break;
                case "2":
                    content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content +=
                        "<tr><td width=\"12\"><img src=\"./images/left_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                    content += "<td style=\"background-color:#AFAFAF;\" class=\"tab_active\">Các cửa hàng bán</td>";
                    content +=
                        "<td width=\"12\"><img src=\"./images/right_tab.jpg\" width=\"12\" height=\"27\" /></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //lblTab.Text = "Hỏi Đáp";

                    break;
                case "3":
                    content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content +=
                        "<tr><td width=\"12\"><img src=\"./images/left_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                    content += "<td style=\"background-color:#AFAFAF;\" class=\"tab_active\">Hỏi đáp, phản hồi</td>";
                    content +=
                        "<td width=\"12\"><img src=\"./images/right_tab.jpg\" width=\"12\" height=\"27\" /></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //lblTab.Text = "Nhận xét sản phẩm";                   
                    break;
                case "4":
                    content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content +=
                        "<tr><td width=\"12\"><img src=\"./images/left_tab.jpg\" width=\"12\" height=\"27\" /></td>";
                    content += "<td style=\"background-color:#AFAFAF;\" class=\"tab_active\">Trả giá</td>";
                    content +=
                        "<td width=\"12\"><img src=\"./images/right_tab.jpg\" width=\"12\" height=\"27\" /></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //lblTab.Text = "Nhận xét sản phẩm";                   
                    break;
            }
        }
        else
        {
            td.Text = "Selected Tab parameter is misisng!";
            tr.Cells.Add(td);
        }

        tblTab.Rows.Add(tr);
    }
*/

    private void ShowNhaCungCap(int id)
    {
        try
        {
            DataAccess da = new DataAccess();
            string strSql = "Select * from viewcuahang where nguoidungid =" + id;

            DataSet ds = da.SelectByQuery(strSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblNguoiBan.Text = dr["HoVaTen"].ToString();

                lblNhaCungCap.Text = dr["TenCuaHang"].ToString();
                lblDienThoaiCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
                lblDienThoaiDiDong.Text = dr["DienThoaiDiDong"].ToString();
                lblDiemDanhGia.Text = string.Format("{0:0.0}", decimal.Parse("0" + dr["Diem"])).Replace(".", ",")
                                      + "(" + int.Parse("0" + dr["Solandanhgia"]) + ")";
                //bak1 = YM
                ViewState["YM"] = dr["YM"].ToString();
                int DamBao = int.Parse("0" + dr["BaoDam"]);
                pnlDamBao.Controls.Clear();
                for (int i = 0; i < DamBao; i++)
                {
                    HtmlImage img = new HtmlImage();
                    img.Src = "./images/kc.jpg";
                    img.Border = 0;
                    pnlDamBao.Controls.Add(img);
                }


                //CuaHang cuahang = new CuaHang();
                //DataSet dsCuaHang = cuahang.SelectByNguoiDungID(id);
                ViewState["CuaHangID"] = dr["CuaHangID"].ToString();
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n", " "), false);
            Response.Write(ex.ToString());
        }
    }

    private void ShowAnhSanPham()
    {
        try
        {
            Anh anh = new Anh();
            DataSet ds = anh.SelectBySanPhamID(int.Parse(ViewState["SanPhamID"].ToString()));

            pnlAnhSanPham.Controls.Clear();
            HtmlImage img = new HtmlImage();
            img.Height = 40;
            img.Width = 40;
            img.Src = imgSanPham.Src;
            img.Style.Add("cursor", "hand");
            img.Attributes.Add("onclick", "Enlarge(this.src);");

            pnlAnhSanPham.Controls.Add(img);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                img = new HtmlImage();
                img.Src = dr["DuongDan"].ToString();
                img.Height = 40;
                img.Width = 40;
                img.Style.Add("cursor", "hand");
                img.Attributes.Add("onclick", "Enlarge(this.src);");
                pnlAnhSanPham.Controls.Add(img);
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n", " "), false);
            Response.Write(ex.ToString());
        }
    }

    protected void pnlProductDetail_ContentRefresh(object sender, EventArgs e)
    {
        if (Common.NguoiDungID() != 0)
        {
            if (hidLuuCauHoi.Value == "true")
            {
                LuuCauHoi();
            }
            if (hidKhuVuc.Value == "true")
            {
                ChangeKhuVuc();
            }
            if (hidTraGia.Value == "true")
            {
                LuuTraGia();
            }
        }

        switch (hidTabId.Value)
        {
            case "1":
                LoadTabContent01();
                break;
            case "2":
                LoadTabContent02();
                break;
            case "3":
                LoadTabContent03();
                break;
            case "4":
                LoadTabContent04();
                break;
        }
    }

    private void LuuTraGia()
    {
        try
        {
            TraGiaSanPham tg = new TraGiaSanPham();
            tg.InsertFields(int.Parse(ViewState["SanPhamID"].ToString()), Common.NguoiDungID(),
                            wneTraGia.ValueDecimal, wneSoLuongTraGia.ValueInt, txtYKienTraGia.Value, null, null);
            hidTraGia.Value = "false";
            //pnlProductDetail.RefreshTargetIDs = "wneSoLuongTraGia";
            //pnlProductDetail.TriggerControlIDs = "wneSoLuongTraGia";
            //wneSoLuongTraGia.Value = "1";
            //wneTraGia.Value = "";
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n"," "), false);
            Response.Write(ex.ToString());
        }
    }

    private void ChangeKhuVuc()
    {
        ddlKhuVuc.SelectedIndex = int.Parse(hidKhuVucID.Value);
        //LoadTabContent02();
    }

    private void LuuCauHoi()
    {
        HoiDapSanPham hd = new HoiDapSanPham();
        hd.InsertFields(int.Parse("0" + ViewState["SanPhamID"]), Common.NguoiDungID(), null, txtCauHoi.Value,
                        null, DateTime.Now, null, null, null, txtChiTietCauHoi.Value);
        txtCauHoi.Value = "";
        txtChiTietCauHoi.Value = "";
        hidLuuCauHoi.Value = "false";
        //LoadTabContent03();
    }

    public string GetInvisible(string UserType)
    {
        string strReturn = "hidden";
        switch (UserType)
        {
            case "admin":
                if (Common.LoaiNguoiDungID() == 3)
                    strReturn = "visibility";
                break;
            case "user":
                if ((Common.LoaiNguoiDungID() == 1) &&
                    (Common.NguoiDungID() != int.Parse("0" + ViewState["NguoiDungID"])))
                    strReturn = "visibility";
                break;
            case "store":
                if ((Common.LoaiNguoiDungID() == 2))
                    strReturn = "visibility";
                break;
            case "store1":
                if ((Common.LoaiNguoiDungID() == 2) && (Common.NguoiDungID() != int.Parse("0" + ViewState["NguoiDungID"])))
                    strReturn = "visibility";
                break;
        }
        return strReturn;
    }

    private void LoadKhuVuc()
    {
        KhuVuc kv = new KhuVuc();
        DataTable dt = kv.SelectAll().Tables[0];

        ddlKhuVuc.DataSource = dt;
        ddlKhuVuc.DataTextField = "TenKhuVuc";
        ddlKhuVuc.DataValueField = "KhuVucID";
        ddlKhuVuc.DataBind();

        ddlKhuVuc.Items.Insert(0, "All");
        ddlKhuVuc.Items[0].Value = "0";
    }

    protected void warpSuaGia_ContentRefresh(object sender, EventArgs e)
    {
        SuaGia();
    }

    private void SuaGia()
    {
        if (wceSuaGia.Visible == false)
        {
            wceSuaGia.Visible = true;
            wceSuaGia.Focus();
            btnSuaGia.Visible = true;
            btnHuySuaGia.Visible = true;
            warpSuaGia.LinkedRefreshControlID = "";
        }
        else
        {
            btnSuaGia.Visible = false;
            wceSuaGia.Visible = false;
            btnHuySuaGia.Visible = false;
            if ((wceSuaGia.Value != null) && (wceSuaGia.Value.ToString() != "NaN"))
            {
                if (hidsuagia.Value == "true")
                {
                    LuuGia();
                    ThongBaoGia();
                    LoadData();
                    if (hidTabId.Value == "2")
                        LoadTabContent02();
                    //warpSuaGia.LinkedRefreshControlID = "pnlProductDetail";
                    warpSuaGia.LinkedRefreshControlID = "pnlDetail";                    
                }
            }
        }
    }
    protected void pnlDetail_OnLoad(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LuuGia()
    {
        try
        {
            SanPham sp = new SanPham();
            sp.UpdateFields(int.Parse("0" + ViewState["SanPhamCungLoaiID"]), null, null, wceSuaGia.ValueDecimal, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, DateTime.Now,
                            null);
        }
        catch (Exception ex)
        {
            //Response.Redirect("Message.aspx?msg=" + ex.Message.Replace("\r\n"," "), false);
            Response.Write(ex.ToString());
        }
    }

    protected void pnlCuaHang_ContentRefresh(object sender, EventArgs e)
    {
        ShowNhaCungCap(int.Parse(ViewState["NguoiDungID"].ToString()));
    }

    private void LoadSanPhamCungLoai(int cid)
    {
        //Scrolling
        tblSanPham01.Rows.Clear();
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectRanDomSixSanPhamByNhomSanPhamID(cid);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < n; i++)
        {
            string tensanpham = ds.Tables[0].Rows[i]["TenSanPham"] + " " +
                                ds.Tables[0].Rows[i]["TenSanPhamPhu"];
            if (tensanpham.Length > 50) tensanpham = tensanpham.Substring(0, 50) + "...";

            TableCell td1 = new TableCell();
            td1.Style.Add("text-align", "center");
            td1.Style.Add("vertical-align", "middle");
            string content1 = "&nbsp;<a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"]
                              + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                              + "\" width=\"90\" height=\"90\" style=\"border:#CCCCCC 1px solid\" />"
                              + "<br>" + tensanpham + "<br>"
                              +
                              string.Format("{0:0,0}", decimal.Parse(ds.Tables[0].Rows[i]["GiaSanPham"].ToString())).
                                  Replace(",", ".") + " VNĐ</a>";
            td1.Text = content1;
            //td1.Width = Unit.Percentage(45);                       
            tr.Cells.Add(td1);
        }
        tblSanPham01.Rows.Add(tr);
    }

    protected void pnlAllSanPham_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPhamCungLoai(int.Parse("0" + ViewState["NhomSanPhamID"]));
    }
}