using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddSubCat : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            txtTenNhomCon.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["subid"] != null)
                {
                    LoadData(Request.QueryString["subid"]);
                }
                txtTenNhomSanPham.Text = Request.QueryString["ten"];
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadData(string Id)
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenNhomCon.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                txtThuTu.Text = ds.Tables[0].Rows[0]["SapXep"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            if (Request.QueryString["subid"] == null)
            {
                nhomsanpham.InsertFields(txtTenNhomCon.Text, null, Convert.ToInt32(Request.QueryString["id"]), false,
                                         Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
            }
            else
            {
                nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["subid"]), txtTenNhomCon.Text, null,
                                         Convert.ToInt32(Request.QueryString["id"]), null,
                                         Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshCat();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}