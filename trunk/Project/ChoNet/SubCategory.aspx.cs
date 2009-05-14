using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class SubCategory : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                int mcid = int.Parse("0" + Request.QueryString["mcid"]);
                int scid = int.Parse("0" + Request.QueryString["scid"]);
                LoadMenu(scid);
                LoadDuongDan(mcid, scid);
                LoadQuangCao22();
                LoadQuangCao23();
                LoadSanPham(scid, "icon", 1);
                loadSearchDropdown();
                //LoadProperty(scid);
            }
            catch (Exception ex)
            {
                Response.Redirect("message.aspx?msg=" + ex.Message);
            }
        }
    }

    private void LoadProperty(int scid)
    {
        ThuocTinh tt = new ThuocTinh();
        DataSet ds = tt.SelectByNhomSanPhamID(scid);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            wucProperty wucThuocTinh = (wucProperty) Page.LoadControl("wucProperty.ascx");
            wucThuocTinh.PropertyName = dr["TenThuocTinh"].ToString();
            wucThuocTinh.PropertyID = int.Parse(dr["ThuocTinhId"].ToString());
            pnlThuocTinh.Controls.Add(wucThuocTinh);
        }
    }

    private void LoadDuongDan(int mcid, int scid)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds1 = nsp.SelectByID(mcid);
        if (ds1.Tables[0].Rows.Count == 1)
        {
            lnkDanhMucCha.Text = ds1.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
            lnkDanhMucCha.NavigateUrl = "subcategory.aspx?mcid=" + ds1.Tables[0].Rows[0]["NhomChaID"] + "&scid=" + mcid;
        }
        else
        {
            lnkDanhMucCha.Text = "";
        }
        DataSet ds2 = nsp.SelectByID(scid);
        if (ds2.Tables[0].Rows.Count == 1)
        {
            lblDanhMucCon.Text = ds2.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
            this.Title = lblDanhMucCon.Text;
        }
        else
        {
            lblDanhMucCon.Text = "";
        }
    }

    private void LoadQuangCao22()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 22);
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
                          + "width=\"205\" height=\"155\" title=\"Quang Cao\">"
                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                          + "<param name=\"quality\" value=\"high\" />"
                          + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" quality=\"high\""
                          +
                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                          + "width=\"205\" height=\"155\"></embed></object></a>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                          + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"]
                          + "\" style=\"border:solid 1px #C9C3C3; width:205px; height:155px\">";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao22.Rows.Add(tr);
        }
    }

    private void LoadQuangCao23()
    {
        //QuangCao qcao = new QuangCao();
        //DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 23);
        //if (ds.Tables[0].Rows.Count >= 1)
        //{
        //    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
        //    {
        //        spnQuangCao23.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
        //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
        //            + "width=\"100%\" height=\"110\" title=\"Quang Cao\">"
        //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
        //            + "<param name=\"quality\" value=\"high\" />"
        //            + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
        //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
        //            + "width=\"100%\" height=\"110\"></embed></object>";
        //    }
        //    else
        //    {
        //        spnQuangCao23.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
        //           + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
        //           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"110px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
        //    }
        //}
        //else
        //{
        //    spnQuangCao23.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
        //}
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

        //NhomSanPham nsp = new NhomSanPham();
        //DataSet dsnsp = nsp.SelectAll();

        //ddlDanhMuc.DataSource = dsnsp.Tables[0];
        //ddlDanhMuc.DataTextField = "TenNhomSanPham";
        //ddlDanhMuc.DataValueField = "NhomSanPhamID";
        //ddlDanhMuc.DataBind();
        //ddlDanhMuc.Items.Insert(0, "Tất cả");
        //ddlDanhMuc.Items[0].Value = "";

        HangSanXuat hangsanxuat = new HangSanXuat();
        DataSet dsHangSanXuat = hangsanxuat.SelectAll();
        if (Cache["hsx"] == null)
        {
            dsHangSanXuat = hangsanxuat.SelectAll();
            Cache.Insert("hsx", dsHangSanXuat);
        }
        else
        {
            dsHangSanXuat = (DataSet) Cache["hsx"];
        }
        DataTable dtHangSanXuat = dsHangSanXuat.Tables[0];

        ddlHangSanXuat.DataSource = dtHangSanXuat;
        ddlHangSanXuat.DataTextField = "TenHangSanXuat";
        ddlHangSanXuat.DataValueField = "HangSanXuatID";
        ddlHangSanXuat.DataBind();


        KhuVuc khuvuc = new KhuVuc();
        DataSet dsKhuVuc;

        if (Cache["kv"] == null)
        {
            dsKhuVuc = khuvuc.SelectAll();
            Cache.Insert("kv", dsKhuVuc);
        }
        else
        {
            dsKhuVuc = (DataSet) Cache["kv"];
        }

        DataTable dtKhuVuc = dsKhuVuc.Tables[0];

        ddlKhuVuc.DataSource = dtKhuVuc;
        ddlKhuVuc.DataTextField = "TenKhuVuc";
        ddlKhuVuc.DataValueField = "KhuVucID";
        ddlKhuVuc.DataBind();
    }

    private void LoadSanPham(int NhomSanPhamID, string mode, int CurrentPage)
    {
        SanPham sp = new SanPham();
        DataSet ds = new DataSet();
        int PageSize = 5;
        int RowStart = 1;
        //string spid="";
        //if (Request.QueryString["spid"] != null)
        //{
        //    spid = Request.QueryString["spid"];
        //}
        switch (mode)
        {
            case "list":
                PageSize = 15;
                RowStart = (CurrentPage - 1)*PageSize + 1;
                ds = sp.SelectSanPhamByNhomSanPhamIDPaging(NhomSanPhamID, ListShowedProperty(), RowStart, PageSize);
                //ds.Tables[0].DefaultView.RowFilter = "ThuocTinhID in (" + ListShowedProperty() + ")";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    string content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content +=
                        "<tr><td width=\"3%\"><input type=\"checkbox\" name=\"checkbox3\" value=\"checkbox\" /></td>";
                    content += "<td width=\"24%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"]
                               + "\"><img src=\"" + dr["AnhSanPham"]
                               + "\" width=\"179\" height=\"159\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td width=\"73%\"><strong>Mã SP</strong>: <a href=\"productdetail.aspx?id=" +
                               dr["SanPhamID"]
                               + "\">" + dr["MaSoSanPham"] + "</a><br />";
                    content += "<strong>Tên SP</strong>: " + dr["TenSanPham"] + "<br/>";
                    content += "<strong>Mô tả</strong>: " + dr["MoTaSanPham"] + "<br/>";
                    content += "<strong>Thời gian</strong>: Từ [" +
                               DateTime.Parse(dr["NgayThemSanPham"].ToString()).ToString("dd/mm/yyyy")
                               + "] đến [" + DateTime.Parse(dr["NgayCapNhat"].ToString()).ToString("dd/mm/yyyy") +
                               "]<br />";
                    if (bool.Parse(dr["GiamGia"].ToString()))
                    {
                        content += "<strong>Giá cũ</strong>: <span class=\"oldprice\">"
                                   + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".") + "</span> " +
                                   dr["DonViTienTe"] + "<br/>";
                        content += "<strong>Giá mới</strong>: <span class=\"price\">"
                                   + String.Format("{0:0,0}", dr["GiaKhuyenMai"]).Replace(",", ".") + "</span> " +
                                   dr["DonViTienTe"];
                    }
                    else
                    {
                        content += "<strong>Giá</strong>: <span class=\"price\">" +
                                   String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                                   + "</span> " + dr["DonViTienTe"];
                    }
                    content += "</td></tr></table>";
                    td.Text = content;
                    td.Style.Value = "border-bottom:#CCCCCC dotted 1px";
                    tr.Cells.Add(td);
                    tblSanPham.Rows.Add(tr);
                }
                imgList.Src = "./images/xs1.jpg";
                imgIcon.Src = "./images/xs2.jpg";
                break;
            case "icon":
                PageSize = 15;
                RowStart = (CurrentPage - 1)*PageSize + 1;
                ds = sp.SelectSanPhamByNhomSanPhamIDPaging(NhomSanPhamID, ListShowedProperty(), RowStart, PageSize);
                //ds.Tables[0].Select("ThuocTinhID in (" + ListShowedProperty() + ")");
                int n = ds.Tables[0].Rows.Count;
                int nrow = n/3 + 1;
                for (int i = 0; i < nrow; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < 3; j++)
                    {
                        int index = i*3 + j;
                        TableCell td = new TableCell();
                        td.Width = Unit.Percentage(33);
                        string content = "";
                        if (index < n)
                        {
                            DataRow dr = ds.Tables[0].Rows[index];
                            content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content +=
                                "<tr><td width=\"10%\"><input type=\"checkbox\" name=\"checkbox3\" value=\"checkbox\" /></td>";
                            content += "<td width=\"90%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"]
                                       + "\"><img src=\"" + dr["AnhSanPham"]
                                       +
                                       "\" width=\"179\" height=\"159\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr>";
                            content += "<tr><td></td><td><strong>Mã SP</strong>: <a href=\"productdetail.aspx?id=" +
                                       dr["SanPhamID"]
                                       + "\">" + dr["MaSoSanPham"] + "</a><br/>";
                            content += "<strong>Tên SP</strong>: " + dr["TenSanPham"] + "<br/>";
                            content += "<strong>Thời gian</strong>: Từ [" +
                                       DateTime.Parse(dr["NgayThemSanPham"].ToString()).ToString("dd/mm/yyyy")
                                       + "] đến [" + DateTime.Parse(dr["NgayCapNhat"].ToString()).ToString("dd/mm/yyyy") +
                                       "]<br />";
                            if (bool.Parse(dr["GiamGia"].ToString()))
                            {
                                content += "<strong>Giá cũ</strong>: <span class=\"oldprice\">"
                                           + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".") + "</span> " +
                                           dr["DonViTienTe"] + "<br/>";
                                content += "<strong>Giá mới</strong>: <span class=\"price\">"
                                           + String.Format("{0:0,0}", dr["GiaKhuyenMai"]).Replace(",", ".") + "</span> " +
                                           dr["DonViTienTe"];
                            }
                            else
                            {
                                content += "<strong>Giá</strong>: <span class=\"price\">" +
                                           String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                                           + "</span> " + dr["DonViTienTe"];
                            }
                            content += "</td></tr></table>";
                        }
                        td.Text = content;
                        tr.Cells.Add(td);
                    }
                    tblSanPham.Rows.Add(tr);
                }
                imgList.Src = "./images/xs3.jpg";
                imgIcon.Src = "./images/xs4.jpg";
                break;
        }

        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
        int NumberOfPage = NumberOfRow/PageSize;
        AddPageLink(CurrentPage, NumberOfPage);
        //int NumberOfRow = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
        //int NumberOfPage = NumberOfRow / PageSize;
        //if (NumberOfPage * PageSize < NumberOfRow) NumberOfPage += 1;
        //string strPage = "Trang";
        //for (int i = 1; i <= NumberOfPage; i++)
        //{

        //    if (i == CurrentPage)
        //    {
        //        strPage += " [" + i.ToString() + "]";
        //    }
        //    else
        //    {
        //        strPage += " <a href=\"javascript:GoToPage(" + i.ToString() + ")\">" + i.ToString() + "</a>";
        //    }
        //}
        //lblPage.Text = strPage;
        //lblPage2.Text = strPage;

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
        int scid = int.Parse("0" + Request.QueryString["scid"]);
        string mode = hidView.Value;
        int page = int.Parse(hidPage.Value);
        LoadSanPham(scid, mode, page);
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
            //strSearch += " AND NhomSanPhamID=" + int.Parse(ddlDanhMuc.Value.Trim()) + " ";
            strSearch += " AND (NhomSanPhamID=" + ddlDanhMuc.Value;
            strSearch += " OR NhomChaID=" + ddlDanhMuc.Value;
            strSearch += " OR (NhomChaID IN (SELECT NhomSanPhamID FROM NhomSanPham WHERE NhomChaID="
                         + ddlDanhMuc.Value + ")))";
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

    private void LoadMenuItems(MenuItem mi, int NhomSanPhamID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(NhomSanPhamID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            MenuItem mni = new MenuItem(
                dr["TenNhomSanPham"].ToString(), dr["NhomSanPhamID"].ToString());

            LoadMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
            mni.NavigateUrl = "subcategory.aspx?mcid=" + NhomSanPhamID + "&scid=" +
                              dr["NhomSanPhamID"];
            mi.ChildItems.Add(mni);
        }
    }

    private void AddPageLink(int PageNo, int intNoOfPage)
    {
        pnlTop.Controls.Clear();
        pnlBottom.Controls.Clear();
        HtmlAnchor htmABottom;
        HtmlAnchor htmATop;
        // add tu trang o dau
        Label lblPageTop = new Label();
        lblPageTop.Text = " Trang : ";
        Label lblPageBottom = new Label();
        lblPageBottom.Text = " Trang : ";
        pnlTop.Controls.Add(lblPageTop);
        pnlBottom.Controls.Add(lblPageBottom);

        // add dau ve trang nhat va ve trang truoc do
        htmABottom = new HtmlAnchor();
        htmATop = new HtmlAnchor();
        htmATop.InnerText = "<< ";
        htmABottom.InnerText = "<< ";
        if (PageNo != 1)
        {
            htmATop.HRef = "javascript:GoToPage(1);";
            htmABottom.HRef = "javascript:GoToPage(1);";
        }
        else
        {
            htmATop.HRef = "";
            htmABottom.HRef = "";
        }
        pnlBottom.Controls.Add(htmABottom);
        pnlTop.Controls.Add(htmATop);

        //add link den cac trang 
        htmABottom = new HtmlAnchor();
        htmATop = new HtmlAnchor();
        htmATop.InnerText = " < ";
        htmABottom.InnerText = " < ";
        if (PageNo > 1)
        {
            htmATop.HRef = "javascript:GoToPage(" + (PageNo - 1) + ");";
            htmABottom.HRef = "javascript:GoToPage(" + (PageNo - 1) + ");";
        }
        else
        {
            htmATop.HRef = "";
            htmABottom.HRef = "";
        }
        pnlBottom.Controls.Add(htmABottom);
        pnlTop.Controls.Add(htmATop);

        int n = 0;
        int j = 0;
        if (intNoOfPage > 10)
        {
            if (PageNo >= 10)
            {
                if (PageNo + 5 < intNoOfPage)
                {
                    n = PageNo + 5;
                }
                else
                {
                    n = intNoOfPage;
                }
                j = PageNo - 4;

                Label lbltop = new Label();
                lbltop.Text = " ... ";
                pnlTop.Controls.Add(lbltop);

                Label lblbottom = new Label();
                lblbottom.Text = " ... ";
                pnlBottom.Controls.Add(lblbottom);
            }
            else
            {
                n = intNoOfPage - (intNoOfPage - 10);
                j = 1;
            }
        }
        else
        {
            n = intNoOfPage;
            j = 1;
        }

        for (int i = j; i <= n; i++)
        {
            htmABottom = new HtmlAnchor();
            htmATop = new HtmlAnchor();
            if (i == PageNo)
            {
                htmABottom.InnerText = "[" + i + "] ";
                htmABottom.HRef = "";
                htmATop.InnerText = "[" + i + "] ";
                htmATop.HRef = "";
            }
            else
            {
                htmABottom.InnerText = i + " ";
                htmABottom.HRef = "javascript:GoToPage(" + i + ");";
                htmATop.InnerText = i + " ";
                htmATop.HRef = "javascript:GoToPage(" + i + ");";
            }
            pnlBottom.Controls.Add(htmABottom);
            pnlTop.Controls.Add(htmATop);
        }

        // add dau ...
        if ((intNoOfPage > 3) && (PageNo > 3) && (n < intNoOfPage))
        {
            Label lbltop = new Label();
            lbltop.Text = " ... ";
            pnlTop.Controls.Add(lbltop);

            Label lblbottom = new Label();
            lblbottom.Text = " ... ";
            pnlBottom.Controls.Add(lblbottom);
        }


        //add ve trang cuoi va ve trang sau do
        htmABottom = new HtmlAnchor();
        htmATop = new HtmlAnchor();
        htmATop.InnerText = " > ";
        htmABottom.InnerText = " > ";
        if (PageNo < intNoOfPage)
        {
            htmATop.HRef = "javascript:GoToPage(" + (PageNo + 1) + ");";
            htmABottom.HRef = "javascript:GoToPage(" + (PageNo + 1) + ");";
        }
        else
        {
            htmATop.HRef = "";
            htmABottom.HRef = "";
        }
        pnlBottom.Controls.Add(htmABottom);
        pnlTop.Controls.Add(htmATop);


        htmABottom = new HtmlAnchor();
        htmATop = new HtmlAnchor();
        htmATop.InnerText = " >>";
        htmABottom.InnerText = " >>";
        if (PageNo != intNoOfPage)
        {
            htmATop.HRef = "javascript:GoToPage(" + intNoOfPage + ");";
            htmABottom.HRef = "javascript:GoToPage(" + intNoOfPage + ");";
        }
        else
        {
            htmATop.HRef = "";
            htmABottom.HRef = "";
        }
        pnlBottom.Controls.Add(htmABottom);
        pnlTop.Controls.Add(htmATop);
    }

    private void LoadMenu(int NhomChaID)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(NhomChaID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MenuItem mni = new MenuItem(
                    dr["TenNhomSanPham"].ToString(), dr["NhomSanPhamID"].ToString());

                LoadMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
                mni.NavigateUrl = "subcategory.aspx?mcid=" + NhomChaID + "&scid=" +
                                  dr["NhomSanPhamID"];
                mnuNhomSanPham.Items.Add(mni);
                ;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }

    private string ListShowedProperty()
    {
        string list_spid = "";
        if (Request.QueryString["spid"] != null)
        {
            string[] spid = Request.QueryString["spid"].Split(',');

            for (int i = 0; i < spid.Length - 1; i++)
            {
                list_spid += spid.GetValue(i).ToString().Split('_')[0] + ",";
            }
            list_spid += spid.GetValue(spid.Length - 1).ToString().Split('_')[0];
        }
        return list_spid;
    }
}