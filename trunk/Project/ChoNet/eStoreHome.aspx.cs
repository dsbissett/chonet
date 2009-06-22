using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebNavigator;

public partial class eStoreHome : Page
{
    private int PageSize = 20;
    //void Page_Init(Object sender, EventArgs e)
    //{
    //    Master._imgTN1 = "./images/but_active_lef.jpg";
    //    Master._imgTN2 = "./images/but_active.jpg";
    //    Master._imgTN3 = "./images/but_active_right.jpg";
    //    Master._imgHP1 = "./images/but_inactive_lef.jpg";
    //    Master._imgHP2 = "./images/but_inactive.jpg";
    //    Master._imgHP3 = "./images/but_inactive_right.jpg";
    //    Master._imgH1 = "./images/but_inactive_lef.jpg";
    //    Master._imgH2 = "./images/but_inactive.jpg";
    //    Master._imgH3 = "./images/but_inactive_right.jpg";
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTab();
        if (!Page.IsPostBack)
        {
            //LoadDanhMuc();
            LoadUltraMenu(0);
            switch (hidTabId.Value)
            {
                case "1":
                    LoadGianHang(0, 1);
                    break;
                case "2":
                    LoadGianHang(1, 1);
                    break;
                case "3":
                    LoadGianHang(2, 1);
                    break;
            }
        }
    }

    private void LoadMenuItems(MenuItem mi, int NhomSanPhamID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(NhomSanPhamID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            MenuItem mni = new MenuItem(
                dr["TenNhomSanPham"].ToString().Length > 30
                    ? dr["TenNhomSanPham"].ToString().Substring(0, 30) + "..."
                    : dr["TenNhomSanPham"].ToString(),
                dr["NhomSanPhamID"].ToString());
            //mni.ToolTip = dr["TenNhomSanPham"].ToString();

            LoadMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
            mni.NavigateUrl = "subcategory.aspx?mcid=" + NhomSanPhamID + "&scid=" +
                              dr["NhomSanPhamID"];
            mi.ChildItems.Add(mni);
        }
    }

    private void LoadMenu(int NhomChaID)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds;

            if (Cache["nsp" + NhomChaID] == null)
            {
                ds = nsp.SelectNhomSanPhamByNhomChaID(NhomChaID);
                Cache["nsp" + NhomChaID] = ds;
            }
            else
            {
                ds = (DataSet) Cache["nsp" + NhomChaID];
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
                    td.Text = "<a href=\"maincategory.aspx?mcid=" + dr["NhomSanPhamID"] + "\">" + dr["TenNhomSanPham"] +
                              "</a>";
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

    private void LoadTab()
    {
        tblTab.Rows.Clear();
        TableRow tr = new TableRow();
        string caption = "";
        for (int i = 1; i < 4; i++)
        {
            switch (i)
            {
                case 1:
                    caption = "TẤT CẢ GIAN HÀNG";
                    if (!Page.IsPostBack)
                        LoadGianHang(0, 1);
                    break;
                case 2:
                    caption = "GIAN HÀNG VIP";
                    if (!Page.IsPostBack)
                        LoadGianHang(1, 1);
                    break;
                case 3:
                    caption = "GIAN HÀNG CHUYÊN NGHIỆP";
                    if (!Page.IsPostBack)
                        LoadGianHang(2, 1);
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
                content = "<a href=\"#tab\" onclick=\"TabSelected(" + i + ")\">" + caption + "</a>";
                td.CssClass = "nd1";
                td.Height = Unit.Pixel(26);
            }
            td.Text = content;
            td.Width = Unit.Percentage(30);
            td.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(td);
        }
        tblTab.Rows.Add(tr);
    }

    //loai cua hang = 1 -> VIP
    //loai cua hang = 2 -> Chuyên nghiệp
    //loai cua hang = 0 -> Binh Thuong
    private void LoadGianHang(int LoaiCuaHang, int CurrentPage)
    {
        tblGianHang.Rows.Clear();
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        CuaHang ch = new CuaHang();
        DataSet ds = new DataSet();

        int NhomSanPhamID = 0;
        if (Request.QueryString["cid"] != null)
            NhomSanPhamID = int.Parse(Request.QueryString["cid"]);
        if (LoaiCuaHang != 0)
        {
            ds = ch.SelectCuaHangInLoaiCuaHangNhomSanPhamIDPaging(txtKeySearch.Text, LoaiCuaHang, NhomSanPhamID,
                                                                  RowStart, PageSize);
        }
        else
        {
            if (NhomSanPhamID == 0)
                ds = ch.SelectAllCuaHangPaging(txtKeySearch.Text, RowStart, PageSize);
            else
                ds = ch.SelectAllCuaHangByNhomSanPhamIDPaging(NhomSanPhamID, txtKeySearch.Text, RowStart, PageSize);
        }
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 10; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 2; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*2 + i < n)
                {
                    DataRow dr = ds.Tables[0].Rows[j * 2 + i];
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";

                    if (dr["LoaiCuaHangID"].ToString() == "26")
                    {
                        content += "<tr><td style=\"widht:110px\"><a href=\"Newestore.aspx?sid=" +
                               dr["CuaHangID"]
                               + "\"><img src=\"" + dr["Anh"]
                               + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></a></td>";
                        content += "<td style=\"width:80%\"><a href=\"Newestore.aspx?sid=" +
                               dr["CuaHangID"]
                               + "\"><b>" + dr["TenCuaHang"] + "</b><br> Đánh giá: ";
                    }
                    else
                    {
                        content += "<tr><td style=\"widht:110px\"><a href=\"estore.aspx?sid=" +
                               dr["CuaHangID"]
                               + "\"><img src=\"" + dr["Anh"]
                               + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></a></td>";
                        content += "<td style=\"width:80%\"><a href=\"estore.aspx?sid=" +
                               dr["CuaHangID"]
                               + "\"><b>" + dr["TenCuaHang"] + "</b><br> Đánh giá: ";
                    }
                    
                    
                    int sodiem = (int) decimal.Parse("0" + dr["diem"]);

                    for (int m = 0; m < sodiem; m++)
                    {
                        content += "<img align=\"absmiddle\" border=\"0\" src=\"./images/star1.gif\">";
                    }

                    for (int m = 10; m > sodiem; m--)
                    {
                        content += "<img align=\"absmiddle\" border=\"0\" src=\"./images/star0.gif\">";
                    }

                    content += string.Format("{0:0.0}", decimal.Parse("0" + dr["diem"]));

                    if (dr["LoaiCuaHang"].ToString() == "1")
                    {
                        content +=
                            "<br><img border=0 src=\"./images/store2.jpg\" /><img src=\"./images/vip.jpg\" border=0 />";
                    }
                    else
                    {
                        content += "<br><img border=0 src=\"./images/store1.jpg\" />";
                    }
                    content += "</a></td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(50);
                tr.Cells.Add(td);
            }
            tblGianHang.Rows.Add(tr);
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
        ddlPage.Items.Clear();
        for (int i = 1; i <= NumberOfPage; i++)
        {
            ListItem li = new ListItem(i.ToString(), i.ToString());
            if (i == CurrentPage) li.Selected = true;
            ddlPage.Items.Add(li);
        }
    }

    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        //LoadTab();
        int page = 1;
        if (hidPage.Value != "")
            page = int.Parse(hidPage.Value);
        switch (hidTabId.Value)
        {
            case "1":
                LoadGianHang(0, page);
                break;
            case "2":
                LoadGianHang(1, page);
                break;
            case "3":
                LoadGianHang(2, page);
                break;
        }
    }

    private void LoadUltraMenuItems(Item mi, int NhomSanPhamID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(NhomSanPhamID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Item mni = new Item();
            mni.Text = dr["TenNhomSanPham"].ToString().Length > 25
                           ? dr["TenNhomSanPham"].ToString().Substring(0, 25) + "..."
                           : dr["TenNhomSanPham"].ToString();
            mni.Tag = dr["NhomSanPhamID"].ToString();
            //mni.ToolTip = dr["TenNhomSanPham"].ToString();            
            LoadUltraMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
            mni.TargetUrl = "EstoreHome.aspx?cid=" + dr["NhomSanPhamID"];
            mi.Items.Add(mni);
        }
    }

    private void LoadUltraMenu(int NhomChaID)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds;

            if (Cache["nsp" + NhomChaID] == null)
            {
                ds = nsp.SelectNhomSanPhamByNhomChaID(NhomChaID);
                Cache["nsp" + NhomChaID] = ds;
            }
            else
            {
                ds = (DataSet) Cache["nsp" + NhomChaID];
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Item mni = new Item();
                mni.Text = dr["TenNhomSanPham"].ToString().Length > 20
                               ? dr["TenNhomSanPham"].ToString().Substring(0, 20) + "..."
                               : dr["TenNhomSanPham"].ToString();
                mni.Tag = dr["NhomSanPhamID"].ToString();
                //mni.ToolTip = dr["TenNhomSanPham"].ToString();

                LoadUltraMenuItems(mni, int.Parse(dr["NhomSanPhamID"].ToString()));
                mni.TargetUrl = "EstoreHome.aspx?cid=" +
                                dr["NhomSanPhamID"];
                uwmMenu.Items.Add(mni);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }
}