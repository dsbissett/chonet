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

public partial class Admin_User : System.Web.UI.Page
{
    public DropDownList ddlNguoiDung;
    public DropDownList ddlLoaiNguoiDung;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //if (!Page.IsPostBack)
            //{
                LoadGridData();
            //}
        }
        else
        {
            Response.Redirect("message.aspx?msg=Access denied");
        }
    }

    private void LoadGridData()
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectAllNguoiDung();
            DataTable dt = ds.Tables[0];

            GrdNguoiDung.DataSource = dt;
            GrdNguoiDung.DataBind();            

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    // Tạo cửa hàng
    protected void pnlUser_ContentRefresh(object sender, EventArgs e)
    {
        try
        {
            CuaHang cuahang = new CuaHang();
            if (CheckExistCuaHang(int.Parse(hidID.Value.ToString())) != true)
            {
                cuahang.InsertFields(null, null, int.Parse(hidID.Value.ToString()), null, null, null, null,
                    null, null, null, null, null, null, null, null, null, 
                    null, null, null, null, null, null, null, null, 3);
            }
            LoadGridData();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool CheckExistCuaHang(int id)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(id);
        if (ds.Tables[0].Rows.Count > 0)
            return true;

        return false;
    }
    protected void GrdNguoiDung_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("HoVaTen").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("GioiTinh").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TaiKhoan").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Email").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("DienThoaiDiDong").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("DienThoaiCoDinh").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("LoaiNguoiDung").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
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
