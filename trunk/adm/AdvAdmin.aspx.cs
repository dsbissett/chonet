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

public partial class Admin_AdvAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //Administrator
            LoadQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID());
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //e-Store
            LoadQuangCaoByNguoiDungID(Common.NguoiDungID());
        }
        else
        {
            //Common user
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    private void LoadQuangCaoByNguoiDungID(int NguoiDungID)
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectByNguoiDungID(NguoiDungID);
        grdAdv.DataSource = ds;
        grdAdv.DataBind();                    
    }
    private void LoadQuangCaoByLoaiNguoiDungID(int LoaiNguoiDungID)
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectByLoaiNguoiDungID(LoaiNguoiDungID);
        grdAdv.DataSource = ds;
        grdAdv.DataBind();
    }
    protected void grdAdv_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("DuongDan").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("NoiDungQuangCao").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("LoaiAnh").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
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
