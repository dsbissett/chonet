using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class Promotion : Page
{
    private int catid;
    private int PageSize = 18;
    public string promotion_code = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pcode"] != null)
        {
            promotion_code = Request.QueryString["pcode"];
            if (Request.QueryString["cid"] != null)
            {
                try
                {
                    catid = int.Parse(Request.QueryString["cid"]);
                    NhomSanPham nsp = new NhomSanPham();
                    DataSet ds = nsp.SelectByID(catid);
                    if (ds.Tables[0].Rows.Count >= 0)
                    {
                        lblCatName.Text = "&gt;&nbsp;" + ds.Tables[0].Rows[0]["TenNhomSanPham"];
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("./message.aspx?msg=" + ex.Message);
                }
            }
        }
        else
        {
            Response.Redirect("./message.aspx?msg=Invalid parameter");
        }
        if (!Page.IsPostBack)
        {
            //LoadDanhMuc();
            LoadMenu(0);
            if (promotion_code == "moi" || promotion_code == "km" || promotion_code == "gg" || promotion_code == "uc")
            {
                if (Request.QueryString["cid"] != null)
                {
                    LoadSanPham(promotion_code, catid, 1);
                }
                else
                {
                    LoadSanPham(promotion_code, 0, 1);
                }
            }
            else
            {
                Response.Redirect("./message.aspx?msg=Invalid parameter");
            }
        }
    }

    private void LoadDanhMuc()
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
                    td.Text = "<a href=\"promotion.aspx?pcode=" + promotion_code + "&cid=" + dr["NhomSanPhamID"] + "\">" +
                              dr["TenNhomSanPham"] + "</a>";
                    tr.Cells.Add(td);
                    tblDanhMuc.Rows.Add(tr);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadSanPham(string pcode, int cid, int CurrentPage)
    {
        SanPham sp = new SanPham();
        DataSet ds = new DataSet();
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        switch (pcode)
        {
            case "km":
                productType.Text = "Khuyến mại";
                if (cid != 0)
                {
                    ds = sp.SelectAllSanPhamKhuyenMaiByNhomSanPhamIDPaging(cid, PageSize, RowStart);
                }
                else
                {
                    ds = sp.SelectAllSanPhamKhuyenMaiPaging(PageSize, RowStart);
                }
                int km = ds.Tables[0].Rows.Count;
                for (int j = 0; j < 6; j++)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < 3; i++)
                    {
                        TableCell td = new TableCell();
                        string content = "";
                        if (j*3 + i < km)
                        {
                            content +=
                                "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\"><img src=\"" + ds.Tables[0].Rows[j*3 + i]["AnhSanPham"]
                                       +
                                       "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                            content += "<td style=\"width:80%\"><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\">" + ds.Tables[0].Rows[j*3 + i]["TenSanPham"]
                                       + "</a><br />Giá: <span class=\"price\">" +
                                       String.Format("{0:0,0}", ds.Tables[0].Rows[j*3 + i]["GiaSanPham"]).Replace(",",
                                                                                                                  ".")
                                       + "</span> " + ds.Tables[0].Rows[j*3 + i]["DonViTienTe"] + "</td></tr></table>";
                        }
                        td.Text = content;
                        td.HorizontalAlign = HorizontalAlign.Left;
                        if (j == 0) td.Width = Unit.Percentage(33);
                        tr.Cells.Add(td);
                    }
                    tblSanPham.Rows.Add(tr);
                }
                break;
            case "gg":
                productType.Text = "Giảm giá";
                if (cid != 0)
                {
                    ds = sp.SelectAllSanPhamGiamGiaByNhomSanPhamIDPaging(cid, PageSize, RowStart);
                }
                else
                {
                    ds = sp.SelectAllSanPhamGiamGiaPaging(PageSize, RowStart);
                }
                int gg = ds.Tables[0].Rows.Count;
                for (int j = 0; j < 6; j++)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < 3; i++)
                    {
                        TableCell td = new TableCell();
                        string content = "";
                        if (j*3 + i < gg)
                        {
                            content +=
                                "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\"><img src=\"" + ds.Tables[0].Rows[j*3 + i]["AnhSanPham"]
                                       +
                                       "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                            content += "<td style=\"width:80%\"><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\">" + ds.Tables[0].Rows[j*3 + i]["TenSanPham"]
                                       + "</a><br />Giá cũ: <span class=\"oldprice\">" +
                                       String.Format("{0:0,0}", ds.Tables[0].Rows[j*3 + i]["GiaSanPham"]).Replace(",",
                                                                                                                  ".")
                                       + "</span> " + ds.Tables[0].Rows[j*3 + i]["DonViTienTe"] + "<br/>"
                                       + "Giá mới: <span class=\"price\">" +
                                       String.Format("{0:0,0}", ds.Tables[0].Rows[j*3 + i]["GiaKhuyenMai"]).Replace(
                                           ",", ".")
                                       + "</span> " + ds.Tables[0].Rows[j*3 + i]["DonViTienTe"] + "</td></tr></table>";
                        }
                        td.Text = content;
                        td.HorizontalAlign = HorizontalAlign.Left;
                        if (j == 0) td.Width = Unit.Percentage(33);
                        tr.Cells.Add(td);
                    }
                    tblSanPham.Rows.Add(tr);
                }
                break;
            case "uc":
                productType.Text = "Ưa chuộng";
                if (cid != 0)
                {
                    ds = sp.SelectAllSanPhamUaChuongByNhomSanPhamIDPaging(cid, PageSize, RowStart);
                }
                else
                {
                    ds = sp.SelectAllSanPhamUaChuongPaging(PageSize, RowStart);
                }
                int n = ds.Tables[0].Rows.Count;
                for (int j = 0; j < 6; j++)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < 3; i++)
                    {
                        TableCell td = new TableCell();
                        string content = "";
                        if (j*3 + i < n)
                        {
                            content +=
                                "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\"><img src=\"" + ds.Tables[0].Rows[j*3 + i]["AnhSanPham"]
                                       +
                                       "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                            content += "<td style=\"width:80%\"><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\">" + ds.Tables[0].Rows[j*3 + i]["TenSanPham"]
                                       + "</a><br />Giá: <span class=\"price\">" +
                                       String.Format("{0:0,0}", ds.Tables[0].Rows[j*3 + i]["GiaSanPham"]).Replace(",",
                                                                                                                  ".")
                                       + "</span> " + ds.Tables[0].Rows[j*3 + i]["DonViTienTe"] + "<br/>"
                                       + "Số lần xem: " + ds.Tables[0].Rows[j*3 + i]["Bak3"] + "</td></tr></table>";
                        }
                        td.Text = content;
                        td.HorizontalAlign = HorizontalAlign.Left;
                        if (j == 0) td.Width = Unit.Percentage(33);
                        tr.Cells.Add(td);
                    }
                    tblSanPham.Rows.Add(tr);
                }
                break;
            case "moi":
                productType.Text = "Mới";
                if (cid != 0)
                {
                    ds = sp.SelectSanPhamByNhomSanPhamIDPaging(cid, RowStart, PageSize);
                }
                else
                {
                    ds = sp.SelectAllSanPhamPaging("", RowStart, PageSize);
                }
                int m = ds.Tables[0].Rows.Count;
                for (int j = 0; j < 6; j++)
                {
                    TableRow tr = new TableRow();
                    for (int i = 0; i < 3; i++)
                    {
                        TableCell td = new TableCell();
                        string content = "";
                        if (j*3 + i < m)
                        {
                            content +=
                                "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\"><img src=\"" + ds.Tables[0].Rows[j*3 + i]["AnhSanPham"]
                                       +
                                       "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                            content += "<td style=\"width:80%\"><a href=\"productdetail.aspx?id=" +
                                       ds.Tables[0].Rows[j*3 + i]["SanPhamID"]
                                       + "\">" + ds.Tables[0].Rows[j*3 + i]["TenSanPham"]
                                       + "</a><br />Giá: <span class=\"price\">" +
                                       String.Format("{0:0,0}", ds.Tables[0].Rows[j*3 + i]["GiaSanPham"]).Replace(",",
                                                                                                                  ".")
                                       + "</span> " + ds.Tables[0].Rows[j*3 + i]["DonViTienTe"] + "<br/>"
                                       + "Số lần xem: " + ds.Tables[0].Rows[j*3 + i]["Bak3"] + "</td></tr></table>";
                        }
                        td.Text = content;
                        td.HorizontalAlign = HorizontalAlign.Left;
                        if (j == 0) td.Width = Unit.Percentage(33);
                        tr.Cells.Add(td);
                    }
                    tblSanPham.Rows.Add(tr);
                }
                break;
        }

        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
        int NumberOfPage = NumberOfRow/PageSize;
        if (NumberOfPage*PageSize < NumberOfRow) NumberOfPage += 1;

        string strPage = "Trang";
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
        lblPage.Text = strPage;
    }

    protected void pnlPage_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham(promotion_code, catid, int.Parse(hidPage.Value));
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
            mni.NavigateUrl = "promotion.aspx?pcode=" + promotion_code + "&cid=" +
                              dr["NhomSanPhamID"];

            mi.ChildItems.Add(mni);
        }
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
                mni.NavigateUrl = "promotion.aspx?pcode=" + promotion_code + "&cid=" +
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
}