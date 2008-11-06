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
using CHONET.Common;
using Infragistics.WebUI.UltraWebGrid;

public partial class Admin_Product : System.Web.UI.Page
{
    int PageSize = 12;
    public bool blConfigProduct = false;
    public string ShowEdit = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlGianHang.Attributes.Add("onchange", "return ddl_onchange();");
        ddlKhuVuc.Attributes.Add("onchange", "return ddl_onchange();");
        ddlHangSanXuat.Attributes.Add("onchange", "return ddl_onchange();");
        ddlDanhMuc1.Attributes.Add("onchange", "return ddl_onchange();");
        ddlDanhMuc2.Attributes.Add("onchange", "return ddl_onchange();");
        btnSearch.Attributes.Add("onclick", "return ddl_onchange();");        
        if (Common.LoaiNguoiDungID() == 2)
        {
            ShowEdit = "visible";
            if (!Page.IsPostBack)
            {
                btnAdd.Visible = true;
                btnAddFromTemplate.Visible = true;
                ddlGianHang.Visible = false;
                LoadHangSanXuat();
                LoadDanhMuc1();
                LoadDanhMuc2();
                LoadKhuVuc();
                LoadData(1);
                //CheckConfigProduct();
            }
        }
        else if (Common.LoaiNguoiDungID() == 3)
        {
            ShowEdit = "hidden";
            if (!Page.IsPostBack)
            {
                btnAddFromTemplate.Visible = false;
                btnAdd.Visible = false;
                ddlGianHang.Visible = true;
                LoadGianHang();
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

    //private void CheckConfigProduct()
    //{
    //    CuaHang ch = new CuaHang();
    //    string CuaHangID = ch.SelectByNguoiDungID(Common.NguoiDungID).Tables[0]
    //    //CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
    //    //DataSet ds = chnsp.s
    //}

    private void LoadData(int CurrentPage)
    {
        string KeySearch = GetKeySearch();
        int RowStart = (CurrentPage - 1) * PageSize + 1;
        SanPham sanpham = new SanPham();
        DataSet ds = null;
        if (CurrentPage == 0)
        {
            if (Common.LoaiNguoiDungID() == 2)
            {
                ds = sanpham.SelectSanPhamByNguoiDungID(Common.NguoiDungID());
            }
            else
            {
                if (ddlGianHang.Items.Count > 0)
                {
                    if (ddlGianHang.SelectedIndex == 0)
                    {
                        ds = sanpham.SelectAllSanPham();
                    }
                    else
                    {
                        ds = sanpham.SelectAllSanPhamByCuaHangID(int.Parse(ddlGianHang.SelectedValue.ToString()));
                    }
                }
            }
        }
        else
        {
            if (Common.LoaiNguoiDungID() == 2)
            {
                ds = sanpham.SelectAllSanPhamPaging(KeySearch, RowStart, PageSize);
            }
            else
            {
                if (ddlGianHang.Items.Count > 0)
                {
                    ds = sanpham.SelectAllSanPhamPaging( KeySearch,RowStart, PageSize);                                                                
                }
            }
            int NoOfPage = (int)Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString()) / PageSize);

            grdSanPham.DisplayLayout.Pager.PageCount = NoOfPage;

            string[] custompages = new string[NoOfPage];
            for (int i = 0; i < NoOfPage; i++)
            {
                custompages[i] = (i + 1).ToString();
            }
            grdSanPham.DisplayLayout.Pager.CustomLabels = custompages;
        }
        DataTable dt = ds.Tables[0];

        grdSanPham.DataSource = dt;
        grdSanPham.DataBind();
    }

    private string GetKeySearch()
    {
        String key = " 1=1 ";
        if (ddlGianHang.SelectedIndex > 0)
            key += " AND CuaHangID=" + ddlGianHang.SelectedValue;

        if (ddlDanhMuc1.SelectedIndex > 0)
            key += " AND NhomChaID=" + ddlDanhMuc1.SelectedValue;

        if (ddlDanhMuc2.SelectedIndex > 0)
            key += " AND NhomSanPhamID = " + ddlDanhMuc2.SelectedValue;

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
    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        LoadDanhMuc2();
        LoadData(grdSanPham.DisplayLayout.Pager.CurrentPageIndex);
    }
    protected void grdSanPham_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("MaSoSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TenNhomSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        if (rbtTatCa.Checked == true)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }
    protected void rbtPhanTrang_CheckedChanged(object sender, EventArgs e)
    {
        LoadData(grdSanPham.DisplayLayout.Pager.CurrentPageIndex);
    }
    protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    {
        LoadData(0);
    }
    private void LoadGianHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectAll();

        ddlGianHang.DataSource = ds.Tables[0];
        ddlGianHang.DataTextField = "TenCuaHang";
        ddlGianHang.DataValueField = "CuaHangID";        
        ddlGianHang.DataBind();

        ddlGianHang.Items.Insert(0, "Tất cả gian hàng");
        ddlGianHang.SelectedIndex = 0;
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
    private void LoadKhuVuc()
    {
        KhuVuc kv = new KhuVuc();
        DataSet ds = kv.SelectAll();

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
        DataSet ds = hsx.SelectAll();

        ddlHangSanXuat.DataSource = ds.Tables[0];
        ddlHangSanXuat.DataTextField = "TenHangSanXuat";
        ddlHangSanXuat.DataValueField = "HangSanXuatID";
        ddlHangSanXuat.DataBind();

        ddlHangSanXuat.Items.Insert(0, "Tất cả");
        ddlHangSanXuat.Items[0].Value = "0";
    }
    protected void grdSanPham_PageIndexChanged(object sender, Infragistics.WebUI.UltraWebGrid.PageEventArgs e)
    {
        //pageColumn = RadioButtonList1.SelectedItem.Value;
        //oleDbSelectCommand1.CommandText = "SELECT CustomerID, ContactName, CompanyName, Phone, Fax, Address FROM Customers WHERE (" + pageColumn + " LIKE '" + alphabet[e.NewPageIndex - 1] + "%')";
        ///doData();
        LoadData(e.NewPageIndex);
    }
}
