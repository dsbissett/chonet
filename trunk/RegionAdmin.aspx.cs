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

public partial class Adm_RegionAdmin : System.Web.UI.Page
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
    protected void grdKhuVuc_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenKhuVuc").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("GhiChu").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        if (rbtTatCa.Checked == true)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }
}
