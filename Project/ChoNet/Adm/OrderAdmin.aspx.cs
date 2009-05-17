using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_OrderAdmin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Common.LoaiNguoiDungID() != 2) && (Common.LoaiNguoiDungID() != 3))
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        int id = 0;

        if (Common.LoaiNguoiDungID() == 3)
        {
            id = 0;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            id = Common.NguoiDungID();
        }

        DonHang dh = new DonHang();
        DataSet ds = dh.SelectByNguoiDungID(id);

        grdDonHang.DataSource = ds.Tables[0];
        grdDonHang.DataBind();
    }

    protected void pnlDonHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }
}