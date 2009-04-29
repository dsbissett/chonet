using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class Search : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadSanPham("list");
        }
    }

    private void LoadSanPham(string mode)
    {
        try
        {
            DataSet ds = null;
            string strOrder = "";
            if (hidSapXep.Value != "")
            {
                strOrder = " ORDER BY " + hidSapXep.Value;
            }

            if (Request.QueryString["keyword"] != null)
            {
                string keyword = Server.UrlDecode(Request.QueryString["keyword"]);
                int cid = int.Parse("0" + Request.QueryString["cid"]);

                SanPham sp = new SanPham();
                ds = sp.SearchByKeyWordAndNhomSanPhamID(keyword, cid, strOrder);
                if (hidSapXep.Value != "")
                {
                    ds.Tables[0].DefaultView.Sort = hidSapXep.Value;
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblMessage.Text = "Không tìm thấy kết quả nào với từ khóa: " + keyword;
                }
                else
                {
                    lblMessage.Text = "Tìm thấy " + ds.Tables[0].Rows.Count + " kết quả phù hợp với từ khóa: " + keyword;
                }
            }
            else if (Request.QueryString["search"] != null)
            {
                string strWhere = Server.UrlDecode(Request.QueryString["search"]);
                string strKeyWord = Server.UrlDecode(Request.QueryString["Key"]);

                SanPham sp = new SanPham();
                ds = sp.AdvanceSearch(strKeyWord, strWhere, strOrder);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblMessage.Text = "Không tìm thấy kết quả nào với các yêu cầu bạn chọn";
                }
                else
                {
                    lblMessage.Text = "Tìm thấy " + ds.Tables[0].Rows.Count + " kết quả phù hợp với yêu cầu của bạn";
                }
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                tblSanPham.Rows.Clear();
                int NumberItems = 15;
                int intNoOfPage = 0;
                if (ds.Tables[0].Rows.Count%NumberItems == 0)
                {
                    intNoOfPage = ds.Tables[0].Rows.Count/NumberItems;
                }
                else
                {
                    intNoOfPage = ds.Tables[0].Rows.Count/NumberItems + 1;
                }

                int PageNo = int.Parse(hidPageNumber.Value);
                AddPageLink(PageNo, intNoOfPage);
                AddGoToddl(PageNo, intNoOfPage);
                int m = intNoOfPage;

                if (PageNo*NumberItems <= ds.Tables[0].Rows.Count)
                {
                    m = (PageNo)*NumberItems;
                }
                else
                {
                    m = ds.Tables[0].Rows.Count;
                }

                switch (mode)
                {
                    case "list":
                        for (int i = (PageNo - 1)*NumberItems; i < m; i++)
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            TableRow tr = new TableRow();
                            TableCell td = new TableCell();
                            string content = "";
                            content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td width=\"3%\"></td>";
                            content += "<td width=\"24%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"] +
                                       "\"><img src=\"" + dr["AnhSanPham"]
                                       +
                                       "\" width=\"179\" height=\"159\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                            content += "<td width=\"73%\"><b><a href=\"productdetail.aspx?id=" + dr["SanPhamID"]
                                       + "\">" + dr["TenSanPham"] + "</a></b><br />";
                            content += "<strong>Mã sản phẩm</strong>:  	" + dr["MaSoSanPham"] + "<br />";
                            content += "<strong>Mô tả</strong>: " + dr["MoTaSanPham"] + "<br />";
                            //content += "<strong>Danh mục</strong>:  	" + dr["TenNhomSanPham"].ToString() + "<br />";
                            //content += "<strong>Hãng sản xuất</strong>:  	" + dr["TenHangSanXuat"].ToString() + "<br />";
                            //content += "<strong>Khu vực</strong>:  	" + dr["TenKhuvuc"].ToString() + "<br />";
                            if (bool.Parse(dr["KhuyenMai"].ToString()))
                            {
                                content += "<strong>Thời gian bán</strong>:  từ [" +
                                           DateTime.Parse(dr["BatDauKhuyenMai"].ToString()).ToString("dd/MM/yyyy") +
                                           "] đến ["
                                           + DateTime.Parse(dr["KetThucKhuyenMai"].ToString()).ToString("dd/MM/yyyy") +
                                           "]<br />";
                            }
                            if (bool.Parse(dr["GiamGia"].ToString()))
                            {
                                // content += "<strong>Giá </strong>: 	" + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".");
                                content += "<strong>Giá cũ</strong>: <span class=\"oldprice\">"
                                           + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".") + "</span> " +
                                           dr["DonViTienTe"] + "<br/>";
                                content += "<strong>Giá mới</strong>: <span class=\"price\">"
                                           + String.Format("{0:0,0}", dr["GiaKhuyenMai"]).Replace(",", ".") + "</span> " +
                                           dr["DonViTienTe"];
                            }
                            else
                            {
                                //content += "<strong>Giá </strong>: 	" + String.Format("{0:0,0}", dr["GiaKhuyenMai"]).Replace(",", ".");
                                content += "<strong>Giá</strong>: <span class=\"price\">" +
                                           String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                                           + "</span> " + dr["DonViTienTe"];
                            }

                            content += " </td></tr></table>";
                            td.Text = content;
                            td.Style.Value = "border-bottom:#CCCCCC dotted 1px";
                            tr.Cells.Add(td);
                            tblSanPham.Rows.Add(tr);
                        }
                        imgList.Src = "./images/xs1.jpg";
                        imgIcon.Src = "./images/xs2.jpg";
                        break;
                    case "icon":
                        int n = m;
                        int nrow = NumberItems/3 + 1;
                        for (int i = (PageNo - 1)*NumberItems; i < (PageNo - 1)*NumberItems + nrow; i++)
                        {
                            TableRow tr = new TableRow();
                            for (int j = 0; j < 3; j++)
                            {
                                int index = (PageNo - 1)*NumberItems + (i - (PageNo - 1)*NumberItems)*3 + j;
                                TableCell td = new TableCell();
                                td.Width = Unit.Percentage(33);
                                string content = "";
                                if (index < n)
                                {
                                    DataRow dr = ds.Tables[0].Rows[index];
                                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                                    content += "<tr><td width=\"10%\"></td>";
                                    content += "<td width=\"90%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"] +
                                               "\">"
                                               + "<img src=\"" + dr["AnhSanPham"]
                                               +
                                               "\" width=\"179\" height=\"159\" style=\"border:#CCCCCC 1px solid\" /></a></td></tr>";

                                    content +=
                                        "<tr><td></td><td><strong>Mã SP</strong>: <a href=\"productdetail.aspx?id=" +
                                        dr["SanPhamID"]
                                        + "\">" + dr["MaSoSanPham"] + "</a><br/>";
                                    content += "<strong>Tên SP</strong>: " + dr["TenSanPham"] + "<br/>";
                                    if (bool.Parse(dr["KhuyenMai"].ToString()))
                                    {
                                        content += "<strong>Thời gian</strong>: Từ [" +
                                                   DateTime.Parse(dr["BatDauKhuyenMai"].ToString()).ToString(
                                                       "dd/MM/yyyy")
                                                   + "] đến [" +
                                                   DateTime.Parse(dr["KetThucKhuyenMai"].ToString()).ToString(
                                                       "dd/MM/yyyy") + "]<br />";
                                    }
                                    if (bool.Parse(dr["GiamGia"].ToString()))
                                    {
                                        content += "<strong>Giá cũ</strong>: <span class=\"oldprice\">"
                                                   + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".") +
                                                   "</span> " + dr["DonViTienTe"] + "<br/>";
                                        content += "<strong>Giá mới</strong>: <span class=\"price\">"
                                                   + String.Format("{0:0,0}", dr["GiaKhuyenMai"]).Replace(",", ".") +
                                                   "</span> " + dr["DonViTienTe"];
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
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""), false);
            Response.Write(ex.ToString());
        }
    }

    private void AddGoToddl(int PageNo, int intNoOfPage)
    {
        slGoTo.Items.Clear();
        for (int i = 1; i <= intNoOfPage; i++)
        {
            slGoTo.Items.Add(i.ToString());
        }
        slGoTo.Value = PageNo.ToString();
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

    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        if (hidView.Value != "")
        {
            ViewState["view"] = hidView.Value;
        }
        else if (ViewState["view"] != null)
        {
            hidView.Value = ViewState["view"].ToString();
        }
        else
        {
            hidView.Value = "list";
        }
        string mode = hidView.Value;

        LoadSanPham(mode);
    }
}