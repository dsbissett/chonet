using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_SelectTemplate : Page
{
    private int PageSize = 12;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            if (!Page.IsPostBack)
            {
                ddlKhuVuc.Attributes.Add("onchange", "return ddl_onchange(0);");
                ddlHangSanXuat.Attributes.Add("onchange", "return ddl_onchange(0);");
                ddlDanhMuc1.Attributes.Add("onchange", "return ddl_onchange(1);");
                ddlDanhMuc2.Attributes.Add("onchange", "return ddl_onchange(2);");
                ddlDanhMuc3.Attributes.Add("onchange", "return ddl_onchange(3);");
                btnSearch.Attributes.Add("onclick", "return ddl_onchange(0);");
                LoadHangSanXuat();
                LoadDanhMuc1();
                LoadDanhMuc2();
                LoadKhuVuc();
                LoadData(1);
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadData(int CurrentPage)
    {
        try
        {
            string KeySearch = GetKeySearch();
            int RowStart = (CurrentPage - 1)*PageSize + 1;
            SanPhamMau sanpham = new SanPhamMau();
            DataSet ds;
            if (CurrentPage == 0)
            {
                ds = sanpham.SelectAllSanPhamMau();
            }
            else
            {
                ds = sanpham.SelectAllSanPhamMauPaging(KeySearch, RowStart, PageSize);
                int NoOfPage = (int) Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString())/PageSize);

                grdSanPhamMau.DisplayLayout.Pager.PageCount = NoOfPage;
                grdSanPhamMau.DisplayLayout.Pager.Pattern = "Trang  [prev]  [default]  [next]";
                if (CurrentPage + 100 < NoOfPage)
                    grdSanPhamMau.DisplayLayout.Pager.Pattern += " [page:" + (CurrentPage + 100) +
                                                                 ": Thêm 100 trang]  Tổng số [pagecount] trang";
                //grdSanPhamMau.DisplayLayout.Pager.
                //int TotalShowPage = NoOfPage > 10 ? 11 : NoOfPage;
                //string[] custompages = new string[TotalShowPage];

                //int StartPage = CurrentPage > 10 ? CurrentPage - 5 : 1;
                //int EndPage = CurrentPage > 10 ? 11 : TotalShowPage;

                //if (NoOfPage > 10)
                //{
                //    custompages[0] = StartPage;
                //    for (int i = 0; i < NoOfPage; i++)
                //    {
                //        custompages[i] = (i + 1).ToString();
                //    }
                //    custompages[
                //}
                //else
                //{
                //    for (int i = 0; i < NoOfPage; i++)
                //    {
                //        custompages[i] = (i + 1).ToString();
                //    }
                //}
                //grdSanPhamMau.DisplayLayout.Pager.CustomLabels = custompages;
            }
            //}
            DataTable dt = ds.Tables[0];

            grdSanPhamMau.DataSource = dt;
            grdSanPhamMau.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }

    //protected void grdSanPham_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    //{
    //    e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
    //    e.Layout.Grid.Columns.FromKey("TenSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
    //    e.Layout.Grid.Columns.FromKey("TenNhomSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;        
    //}    
    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        if (hiddropdown.Value == "1")
            LoadDanhMuc2();
        else if (hiddropdown.Value == "2")
            LoadDanhMuc3();

        //LoadData(grdSanPham.DisplayLayout.Pager.CurrentPageIndex);
        //LoadDanhMuc2();
        int page = 1;
        if (grdSanPhamMau.DisplayLayout.Pager.CurrentPageIndex <= grdSanPhamMau.DisplayLayout.Pager.PageCount)
            page = grdSanPhamMau.DisplayLayout.Pager.CurrentPageIndex;
        LoadData(page);
    }

    private void LoadDanhMuc1()
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds;

        if (Cache["dm1"] == null)
        {
            ds = nsp.SelectNhomSanPhamByNhomChaID(0);
            Cache.Insert("dm1", ds);
        }
        else
        {
            ds = (DataSet) Cache["dm1"];
        }

        ddlDanhMuc1.DataSource = ds.Tables[0];
        ddlDanhMuc1.DataTextField = "TenNhomSanPham";
        ddlDanhMuc1.DataValueField = "NhomSanPhamID";
        ddlDanhMuc1.DataBind();

        ddlDanhMuc1.Items.Insert(0, "Tất cả");
        ddlDanhMuc1.Items[0].Value = "0";
    }

    private void LoadDanhMuc2()
    {
        int index = ddlDanhMuc2.SelectedIndex;
        ddlDanhMuc2.Items.Clear();
        if (ddlDanhMuc1.SelectedIndex != 0)
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(int.Parse(ddlDanhMuc1.SelectedValue));
            ddlDanhMuc2.DataSource = ds.Tables[0];
            ddlDanhMuc2.DataTextField = "TenNhomSanPham";
            ddlDanhMuc2.DataValueField = "NhomSanPhamID";
            ddlDanhMuc2.DataBind();

            ddlDanhMuc2.Items.Insert(0, "Tất cả");
            ddlDanhMuc2.Items[0].Value = "0";
        }
        if ((index > 0) && (index < ddlDanhMuc2.Items.Count))
        {
            ddlDanhMuc2.Items[index].Selected = true;
        }
    }

    protected void LoadDanhMuc3()
    {
        int index = ddlDanhMuc3.SelectedIndex;
        ddlDanhMuc3.Items.Clear();
        if (ddlDanhMuc2.SelectedIndex != 0)
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(int.Parse(ddlDanhMuc2.SelectedValue));
            ddlDanhMuc3.DataSource = ds.Tables[0];
            ddlDanhMuc3.DataTextField = "TenNhomSanPham";
            ddlDanhMuc3.DataValueField = "NhomSanPhamID";
            ddlDanhMuc3.DataBind();

            ddlDanhMuc3.Items.Insert(0, "Tất cả");
            ddlDanhMuc3.Items[0].Value = "0";
        }
        if ((index > 0) && (index < ddlDanhMuc3.Items.Count))
        {
            ddlDanhMuc3.Items[index].Selected = true;
        }
    }

    private void LoadKhuVuc()
    {
        KhuVuc kv = new KhuVuc();
        DataSet ds;

        if (Cache["kv"] == null)
        {
            ds = kv.SelectAll();
            Cache.Insert("kv", ds);
        }
        else
        {
            ds = (DataSet) Cache["kv"];
        }

        ddlKhuVuc.DataSource = ds.Tables[0];
        ddlKhuVuc.DataTextField = "TenKhuVuc";
        ddlKhuVuc.DataValueField = "KhuVucID";
        ddlKhuVuc.DataBind();
        ddlKhuVuc.Items.Insert(0, "Tất cả");
        ddlKhuVuc.Items[0].Value = "0";
    }

    private void LoadHangSanXuat()
    {
        HangSanXuat hsx = new HangSanXuat();
        DataSet ds;
        if (Cache["hsx"] == null)
        {
            ds = hsx.SelectAll();
            Cache.Insert("hsx", ds);
        }
        else
        {
            ds = (DataSet) Cache["hsx"];
        }
        ddlHangSanXuat.DataSource = ds.Tables[0];
        ddlHangSanXuat.DataTextField = "TenHangSanXuat";
        ddlHangSanXuat.DataValueField = "HangSanXuatID";
        ddlHangSanXuat.DataBind();

        ddlHangSanXuat.Items.Insert(0, "Tất cả");
        ddlHangSanXuat.Items[0].Value = "0";
    }

    private string GetKeySearch()
    {
        String key = " 1=1 ";

        if (ddlDanhMuc3.SelectedIndex > 0)
        {
            key += " AND NhomSanPhamID = " + ddlDanhMuc3.SelectedValue;
            key += " AND NhomChaID=" + ddlDanhMuc2.SelectedValue;
        }
        else if (ddlDanhMuc2.SelectedIndex > 0)
        {
            key += " AND ((NhomSanPhamID = " + ddlDanhMuc2.SelectedValue;
            key += " AND NhomChaID=" + ddlDanhMuc1.SelectedValue + ") ";
            key += " OR (NhomChaID=" + ddlDanhMuc2.SelectedValue + ")) ";
        }
        else if (ddlDanhMuc1.SelectedIndex > 0)
        {
            key += " AND (NhomSanPhamID=" + ddlDanhMuc1.SelectedValue;
            key += " OR NhomChaID=" + ddlDanhMuc1.SelectedValue;
            key += " OR NhomChaID IN (SELECT NhomSanPhamID FROM SANPHAMMAU WHERE NhomChaID=" + ddlDanhMuc1.SelectedValue +
                   "))";
        }
        if (ddlHangSanXuat.SelectedIndex > 0)
            key += " AND HangSanXuatID=" + ddlHangSanXuat.SelectedValue;

        if (ddlKhuVuc.SelectedIndex > 0)
        {
            key += " AND KhuVucID=" + ddlKhuVuc.SelectedValue;
        }

        if (txtTenSanPham.Text != "")
            key += " AND TenSanPham like N'%" + txtTenSanPham.Text + "%'";


        return key;
    }
}