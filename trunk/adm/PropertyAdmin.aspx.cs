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

public partial class Adm_PropertyAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((Common.LoaiNguoiDungID() != 3) && (Common.LoaiNguoiDungID() != 2))
        //{
        //    Response.Redirect("../message.aspx?msg=Access denied");
        //}
        //if (!Page.IsPostBack)
        //{
        //    LoadData(0);
        //}
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadNhomSanPham();
        LoadData(int.Parse(ddlNhomSanPham.SelectedValue));
    }

    private void LoadData(int NhomSanPhamID)
    {
        ThuocTinh tt = new ThuocTinh();
        DataSet ds;
        if (NhomSanPhamID == 0)
        {
            ds = tt.SelectAll();
        }
        else
        {
            ds = tt.SelectByNhomSanPhamID(NhomSanPhamID);
        }

        grdThuocTinh.DataSource = ds.Tables[0];
        grdThuocTinh.DataBind();
    }

    private void LoadNhomSanPham()
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectAll();

        ddlNhomSanPham.DataSource = ds.Tables[0];
        ddlNhomSanPham.DataTextField = "TenNhomSanPham";
        ddlNhomSanPham.DataValueField = "NhomSanPhamID";
        ddlNhomSanPham.DataBind();

        ddlNhomSanPham.Items.Insert(0, "Tất cả");
        ddlNhomSanPham.Items[0].Value = "0";
    }
    
    protected void ddlNhomSanPham_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(int.Parse(ddlNhomSanPham.SelectedValue));

    }
}
