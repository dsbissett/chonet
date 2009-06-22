using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddCat : Page
{
    private string cuahangid = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    LoadData(Request.QueryString["id"]);
                }
            }
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            if (Request.QueryString["sid"] != null)
            {
                cuahangid = Request.QueryString["sid"];
            }
            if (!Page.IsPostBack)
            {                
                if (Request.QueryString["id"] != null)
                {                    
                    LoadDataForGianHang(Request.QueryString["id"]);
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadDataForGianHang(string Id)
    {
        try
        {
            NhomSanPhamCuaHang nspch = new NhomSanPhamCuaHang();
            DataSet ds = nspch.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenNhomSanPham.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                txtThuTu.Text = ds.Tables[0].Rows[0]["SapXep"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
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
                txtTenNhomSanPham.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
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
            if (txtTenNhomSanPham.Text.Trim() != "")
            {
                if (Common.LoaiNguoiDungID() == 3)
                {
                    NhomSanPham nhomsanpham = new NhomSanPham();
                    if (Request.QueryString["id"] == null)
                    {
                        nhomsanpham.InsertFields(txtTenNhomSanPham.Text, "", 0, false, Convert.ToInt32(txtThuTu.Text), null,
                                                 null, null, null, null, null);
                    }
                    else
                    {
                        nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["id"]),
                                                 txtTenNhomSanPham.Text, null, null, null, Convert.ToInt32(txtThuTu.Text),
                                                 null, null, null, null, null, null);
                    }
                    Cache.Remove("dm1");
                }
                else if (Common.LoaiNguoiDungID() == 2)
                {
                    NhomSanPhamCuaHang nhomsanpham = new NhomSanPhamCuaHang();
                    if (Request.QueryString["id"] == null)
                    {
                        nhomsanpham.InsertFields( 0, 0, int.Parse("0" + txtThuTu.Text),int.Parse(cuahangid),txtTenNhomSanPham.Text,null);
                    }
                    else
                    {
                        nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["id"]),
                                                  null, null, int.Parse("0" + txtThuTu.Text), null, txtTenNhomSanPham.Text,null);
                    }                    
                }
                string strScript = "<script language='JavaScript'>" + "window.parent.RefreshCat();</script>";
                ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}