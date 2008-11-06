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

public partial class AdminExpired_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlGianHang.Attributes.Add("onchange", "return ddlGianHang_onchange();");
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                ddlGianHang.Visible = true;
                LoadGianHang();
                LoadData();
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

    private void LoadData()
    {
        SanPham sanpham = new SanPham();
        DataSet ds = null;
       
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

        DataTable dt = ds.Tables[0];

        dt.DefaultView.RowFilter = "dates > " + ConfigurationManager.AppSettings["ExpireTime"].ToString();
        grdSanPham.DataSource = dt;
        grdSanPham.DataBind();
    }
    protected void pnlSanPham_ContentRefresh(object sender, EventArgs e)
    {
        switch (hidAction.Value.ToLower())
        {
            case "deletelist":
                DeleteList();
                break;
            case "extendlist":
                ExtendList();
                break;
            case "extend":
                Extend();
                break;
            case "delete":           
                break;
        }
        LoadData();
    }

    private void Extend()
    {
        if (hidID.Value != "")
        {
            SanPham sp = new SanPham();
            int sanphamID = int.Parse(hidID.Value.ToString());
            sp.UpdateFields(sanphamID, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, DateTime.Now,
                null, null, null, null, null, null, null, null, null, DateTime.Now);
        }
    }

    private void ExtendList()
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdSanPham.Rows)
            {
                if (row.Cells.FromKey("Selected").Text == "true")
                {
                    SanPham sp = new SanPham();
                    int sanphamID = int.Parse(row.Cells.FromKey("SanPhamID").Value.ToString());
                    sp.UpdateFields(sanphamID, null, null, null, null, null, null, null, null, null,
                        null, null, null, null, null, null, null, null, null, null, null, null, DateTime.Now,
                        null, null, null, null, null, null, null, null, null, DateTime.Now);
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=" + "Access denied!");
        }
    }
    protected void grdSanPham_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Dates").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
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
        LoadData();
    }
    protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    {
        LoadData();
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
    private void DeleteList()
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdSanPham.Rows)
            {
                if (row.Cells.FromKey("Selected").Text == "true")
                {
                    SanPham sp = new SanPham();
                    int sanphamID = int.Parse(row.Cells.FromKey("SanPhamID").Value.ToString());
                    sp.Delete(sanphamID);
                }
            }            
        }
        else
        {
            Response.Redirect("../message.aspx?msg=" + "Access denied!");
        }
    }
    protected void btnDelete_ServerClick(object sender, EventArgs e)
    {
        DeleteList();
    }
}
