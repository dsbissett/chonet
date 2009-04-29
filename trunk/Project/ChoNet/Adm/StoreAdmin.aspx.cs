using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer;
using Infragistics.WebUI.UltraWebGrid;

public partial class Adm_StoreAdmin : Page
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

    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }


    private void LoadData()
    {
        DataAccess da = new DataAccess();

        DataSet ds = da.SelectByQuery("Select * from viewcuahang order by loaicuahang DESC");
        //ds.Tables[0].Select("LoaiCuaHang <> " + type);
        grdGianHang.DataSource = ds.Tables[0];
        grdGianHang.DataBind();
    }

    protected void grdGianHang_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TenLoaiCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        if (rbtTatCa.Checked)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }
}