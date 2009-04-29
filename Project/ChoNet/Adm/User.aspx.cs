using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Admin_User : Page
{
    public DropDownList ddlLoaiNguoiDung;
    public DropDownList ddlNguoiDung;

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
            if (CheckExistCuaHang(int.Parse(hidID.Value)) != true)
            {
                cuahang.InsertFields(null, null, int.Parse(hidID.Value), null, null, null, null,
                                     null, null, null, null, null, null, null, null, null,
                                     null, null, null, null, null, null, null, null, 2);
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

    protected void GrdNguoiDung_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("Command").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("HoVaTen").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("GioiTinh").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TaiKhoan").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Email").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("DienThoaiDiDong").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("DienThoaiCoDinh").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("LoaiNguoiDung").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
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