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

public partial class Admin_SelectProd : System.Web.UI.Page
{
    int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Common.LoaiNguoiDungID() == 3)
        {
            int pid = int.Parse(Request.QueryString["pid"]);
            btnDong.Attributes.Add("onclick", "CloseSelect(" + pid + ")");             
            if (!Page.IsPostBack)
            {                
                ddlKhuVuc.Attributes.Add("onchange", "return ddl_onchange();");
                ddlHangSanXuat.Attributes.Add("onchange", "return ddl_onchange();");
                ddlDanhMuc1.Attributes.Add("onchange", "return ddl_onchange();");
                ddlDanhMuc2.Attributes.Add("onchange", "return ddl_onchange();");
                btnSearch.Attributes.Add("onclick", "return ddl_onchange();");
                LoadHangSanXuat();
                LoadDanhMuc1();
                LoadDanhMuc2();
                LoadKhuVuc();
                LoadData(1);
            }
            

            spanMax.InnerText = "0";
            switch (pid)
            {
                case 1:
                    spanMax.InnerText = "1";
                    break;
                case 2:
                    spanMax.InnerText = "5";
                    break;
                case 3:
                    spanMax.InnerText = "4";
                    break;
                case 4:
                    spanMax.InnerText = "12";
                    break;
                case 5:
                    spanMax.InnerText = "12";
                    break;
                case 6:
                    spanMax.InnerText = "6";
                    break;
                case 7:
                    spanMax.InnerText = "12";
                    break;
                case 11:
                    spanMax.InnerText = "5";
                    break;
                case 12:
                    spanMax.InnerText = "4";
                    break;
                case 13:
                    spanMax.InnerText = "12";
                    break;
                case 14:
                    spanMax.InnerText = "12";
                    break;
                case 21:
                    spanMax.InnerText = "1";
                    break;
                case 22:
                    spanMax.InnerText = "4";
                    break;
            }
            if (spanMax.InnerText != "0")
            {
                if (Request.QueryString["rid"] != null)
                {
                    int rid = int.Parse(Request.QueryString["rid"]);
                    ddlKhuVuc.SelectedValue = rid.ToString();
                    spanSelect.InnerText = LoadSanPham(pid, rid).ToString();
                }
                else
                {
                    spanSelect.InnerText = LoadSanPham(pid).ToString();
                }
            }
            else
            {
                Response.Redirect("../message.aspx?msg=Invalid parameter");
            }
        }            
    }
    private int LoadSanPham(int Vitri)
    {        
        SanPham sanpham = new SanPham();
        DataSet ds = sanpham.SelectSanPhamByVTSP(Vitri);
       
        DataTable dt = ds.Tables[0];

        grdSanPham.DataSource = dt;
        grdSanPham.DataBind();

        return dt.Rows.Count;
    }
    private int LoadSanPham(int ViTri, int KhuVucID)
    {
        SanPham sanpham = new SanPham();
        DataSet ds = sanpham.SelectSanPhamByVTSPKhuVucID(ViTri, KhuVucID);

        DataTable dt = ds.Tables[0];

        grdSanPham.DataSource = dt;
        grdSanPham.DataBind();

        return dt.Rows.Count;
    }
    private void LoadData(int CurrentPage)
    {
        try
        {
            string KeySearch = GetKeySearch();
            int RowStart = (CurrentPage - 1) * PageSize + 1;
            SanPham sanpham = new SanPham();
            DataSet ds;
          
            ds = sanpham.SelectAllSanPhamPaging(KeySearch, RowStart, PageSize);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";

            int NoOfPage = (int)Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString()) / PageSize);

            grdProduct.DisplayLayout.Pager.PageCount = NoOfPage;

            string[] custompages = new string[NoOfPage];
            for (int i = 0; i < NoOfPage; i++)
            {
                custompages[i] = (i + 1).ToString();
            }
            grdProduct.DisplayLayout.Pager.CustomLabels = custompages;

            DataTable dt = ds.Tables[0];

            grdProduct.DataSource = dt;
            grdProduct.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("/r/n", " "));
        }
    }
    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        int pid = int.Parse(Request.QueryString["pid"]);

        if (hidAdd.Value.ToLower() == "true")
        {            
            //string pid = Request.QueryString["pid"];
            string rid = Request.QueryString["rid"] ?? "";
            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdProduct.Rows)
            {
                if (row.Cells.FromKey("Selected").Text == "true")
                {
                    ViTriSanPham vtsp = new ViTriSanPham();
                    int sanphamID = int.Parse(row.Cells.FromKey("SanPhamID").Value.ToString());
                    if (rid != "")
                    {
                        vtsp.InsertFields(sanphamID, pid, 0, int.Parse(rid));                        
                    }
                    else
                    {                     
                        vtsp.InsertFields(sanphamID, pid, 0, null);                        
                    }
                }
            }
        }
        
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadSanPham(pid, rid).ToString();
        }
        else
        {
            spanSelect.InnerText = LoadSanPham(pid).ToString();
        }
    }
    protected void grdProduct_PageIndexChanged(object sender, Infragistics.WebUI.UltraWebGrid.PageEventArgs e)
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
        if ((index > 0 ) && (index < ddlDanhMuc2.Items.Count))
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
    protected void pnlAllSanPham_ContentRefresh(object sender, EventArgs e)
    {
        LoadDanhMuc2();
        LoadData(grdProduct.DisplayLayout.Pager.CurrentPageIndex);
    }
    private string GetKeySearch()
    {
        String key = " 1=1 ";

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
       
        return key;
    }
}
