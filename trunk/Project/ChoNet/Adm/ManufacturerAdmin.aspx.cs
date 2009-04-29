using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Adm_ManufacturerAdmin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 3)
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }

    protected void pnlHangSanXuat_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        HangSanXuat hsx = new HangSanXuat();
        DataSet ds = hsx.SelectAll();

        grdHangSanXuat.DataSource = ds.Tables[0];
        grdHangSanXuat.DataBind();
    }

    protected void grdHangSanXuat_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenHangSanXuat").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("ThongTin").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        //if (rbtTatCa.Checked == true)
        //{
        //    e.Layout.Pager.AllowPaging = false;
        //}
        //else
        //{
        //    e.Layout.Pager.AllowPaging = true;
        //}
    }
}