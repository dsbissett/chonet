using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Adm_RegionAdmin : Page
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

    protected void pnlKhuVuc_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        KhuVuc kv = new KhuVuc();
        DataSet ds = kv.SelectAll();

        grdKhuVuc.DataSource = ds.Tables[0];
        grdKhuVuc.DataBind();
    }

    protected void grdKhuVuc_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenKhuVuc").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("GhiChu").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
    }
}