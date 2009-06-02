using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CHONET.DataAccessLayer.Web;
public partial class StoreProductList : System.Web.UI.Page
{
    string keysearch;
    string CuaHangID="0";
    int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request["search"] != null) && (Request["sid"] != null))
        {
            keysearch = Request["search"];
            CuaHangID = Request["sid"];
            //ddlPage.Attributes.Add("onchange", "GoToPage(" + ddlPage.SelectedValue + ")");
        }
        if (!Page.IsPostBack)
        {            
            LoadSanPhamByKeySearch(1);           
        }
    }

    private void LoadSanPhamByKeySearch(int CurrentPage)
    {
        SanPham sp = new SanPham();
        int RowStart = (CurrentPage - 1) * PageSize + 1;        

        DataSet ds = new DataSet();

        ds = sp.SelectSanPhamByCuaHangIDPaging(int.Parse(CuaHangID), RowStart, PageSize, keysearch);

        int n = ds.Tables[0].Rows.Count;
        int sosp = 4;
        int Rownum = PageSize / sosp;
        string content = "";
        bool blbreak = false;
        for (int i = 0; i < n; i++)
        {
            if (blbreak) break;
            content += "<div class=\"w590 fl\">";
            for (int j = 0; j < sosp; j++)
            {
                int index = i * sosp + j;
                if (index >= n)
                {
                    blbreak = true;
                    break;
                }
                //string content = "";

                string tensanpham = ds.Tables[0].Rows[index]["TenSanPham"] +
                                    " " + ds.Tables[0].Rows[index]["TenSanPhamPhu"];
                //if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                content += "<div class=\"w110 fl mr-01 pad-02 border-dot\">"
                           + "<a href=\"productdetail.aspx?id="
                           + ds.Tables[0].Rows[index]["SanPhamID"] + "\"><img src=\"" +
                           ds.Tables[0].Rows[index]["AnhSanPham"]
                           + "\" alt=\"" + tensanpham
                           + "\" width=\"113\" height=\"110\" /></a><br/>"
                           + "<span class=\"t-c fl pad-b10\" > " + tensanpham
                           + "</span><br/><span class=\"t-c tf-up fs-14 fl\"><b>" +
                           String.Format("{0:0,0}", ds.Tables[0].Rows[index]["GiaSanPham"]).Replace(",", ".")
                           + " " + ds.Tables[0].Rows[index]["DonViTienTe"] + "</b> </span></div>";

            }
            content += "</div><div style=\"clear:both\"></div><div class=\"line\"></div>";
            //tblSanPham.Rows.Add(tr);
        }
        spnSanPham.InnerHtml = content;


        int NumberOfRow = int.Parse(ds.Tables[1].Rows[0]["Total"].ToString());
        int NumberOfPage = NumberOfRow / PageSize;
        if (NumberOfPage * PageSize < NumberOfRow) NumberOfPage += 1;
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
    protected void udpSanPham_Load(object sender, EventArgs e)
    {
        int page = 1;
        if (hidPage.Value != "")
            page = int.Parse(hidPage.Value);
        LoadSanPhamByKeySearch(page);
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSanPhamByKeySearch(int.Parse("0" + ddlPage.SelectedValue));
    }
}
