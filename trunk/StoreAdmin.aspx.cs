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
using CHONET.DataAccessLayer;

public partial class Adm_StoreAdmin : System.Web.UI.Page
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
    protected void grdGianHang_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TenLoaiCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
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
   

