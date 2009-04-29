using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class AdminTemplate_Product : Page
{
    public bool blConfigProduct;
    private int PageSize = 12;

    protected void Page_Load(object sender, EventArgs e)
    {
        //ddlGianHang.Attributes.Add("onchange", "return ddl_onchange();");
        ddlKhuVuc.Attributes.Add("onchange", "return ddl_onchange(0);");
        ddlHangSanXuat.Attributes.Add("onchange", "return ddl_onchange(0);");
        ddlDanhMuc1.Attributes.Add("onchange", "return ddl_onchange(1);");
        ddlDanhMuc2.Attributes.Add("onchange", "return ddl_onchange(2);");
        ddlDanhMucCap3.Attributes.Add("onchange", "return ddl_onchange(3);");
        btnSearch.Attributes.Add("onclick", "return ddl_onchange(0);");
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
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

    private string GetKeySearch()
    {
        String key = " 1=1 ";

        if (ddlDanhMucCap3.SelectedIndex > 0)
        {
            key += " AND NhomSanPhamID = " + ddlDanhMucCap3.SelectedValue;
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
            key += " OR (NhomChaID IN (SELECT NhomSanPhamID FROM NhomSanPham WHERE NhomChaID="
                   + ddlDanhMuc1.SelectedValue + ")))";
        }
        if (ddlHangSanXuat.SelectedIndex > 0)
            key += " AND HangSanXuatID=" + ddlHangSanXuat.SelectedValue;

        if (ddlKhuVuc.SelectedIndex > 0)
        {
            key += " AND KhuVucID=" + ddlKhuVuc.SelectedValue;
        }

        if (txtTenSanPham.Text != "")
            key += " AND TenSanPham like N'%" + txtTenSanPham.Text + "%'";

        if (txtNguoiNhap.Text != "")
            key += " AND HoVaTen like N'%" + txtNguoiNhap.Text + "%'";

        if (Common.LoaiNguoiDungID() == 2)
            key += " AND NguoiDungID=" + Common.NguoiDungID();
        return key;
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

                grdSanPham.DisplayLayout.Pager.PageCount = NoOfPage;

                //for 
                grdSanPham.DisplayLayout.Pager.Pattern = "Trang  [prev]  [default]  [next]  [page:"
                                                         + (CurrentPage + 100) +
                                                         ":Thêm 100 trang]  Tổng số [pagecount] trang";


                //string[] custompages = new string[NoOfPage];
                //for (int i = 0; i < NoOfPage; i++)
                //{
                //    custompages[i] = (i + 1).ToString();
                //}
                //grdSanPham.DisplayLayout.Pager.CustomLabels = custompages;
            }
            //}
            DataTable dt = ds.Tables[0];

            grdSanPham.DataSource = dt;
            grdSanPham.DataBind();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //GridView1.PagerSettings.
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("/r/n", " "));
        }
    }

    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        if (hiddropdown.Value == "1")
            LoadDanhMuc2();
        else if (hiddropdown.Value == "2")
            LoadDanhMuc3();

        LoadData(grdSanPham.DisplayLayout.Pager.CurrentPageIndex);
    }

    //protected void grdSanPham_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    //{
    //    e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
    //    e.Layout.Grid.Columns.FromKey("TenSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
    //    e.Layout.Grid.Columns.FromKey("TenNhomSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
    //    if (rbtTatCa.Checked == true)
    //    {
    //        e.Layout.Pager.AllowPaging = false;
    //    }
    //    //else
    //    //{
    //    //    e.Layout.Pager.AllowPaging = true;
    //    //}
    //}
    //protected void rbtPhanTrang_CheckedChanged(object sender, EventArgs e)
    //{
    //    LoadData(1);
    //}
    //protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    //{
    //    LoadData(0);
    //}
    protected void grdSanPham_PageIndexChanged(object sender, PageEventArgs e)
    {
        //pageColumn = RadioButtonList1.SelectedItem.Value;
        //oleDbSelectCommand1.CommandText = "SELECT CustomerID, ContactName, CompanyName, Phone, Fax, Address FROM Customers WHERE (" + pageColumn + " LIKE '" + alphabet[e.NewPageIndex - 1] + "%')";
        ///doData();
        LoadData(e.NewPageIndex);
    }

    private void LoadDanhMuc1()
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);

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
        ddlDanhMucCap3.Items.Clear();
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
        int index = ddlDanhMucCap3.SelectedIndex;
        ddlDanhMucCap3.Items.Clear();
        if (ddlDanhMuc2.SelectedIndex != 0)
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(int.Parse(ddlDanhMuc2.SelectedValue));
            ddlDanhMucCap3.DataSource = ds.Tables[0];
            ddlDanhMucCap3.DataTextField = "TenNhomSanPham";
            ddlDanhMucCap3.DataValueField = "NhomSanPhamID";
            ddlDanhMucCap3.DataBind();

            ddlDanhMucCap3.Items.Insert(0, "Tất cả");
            ddlDanhMucCap3.Items[0].Value = "0";
        }
        if ((index > 0) && (index < ddlDanhMucCap3.Items.Count))
        {
            ddlDanhMucCap3.Items[index].Selected = true;
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
}