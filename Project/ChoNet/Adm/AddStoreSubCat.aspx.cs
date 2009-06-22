using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddStoreSubCat : Page
{
    private string CuaHangID="0";
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
        else if (Common.LoaiNguoiDungID()==2)
        {
            txtTenNhomCon.Focus();
            if (Request.QueryString["sid"] != null)
            {
                CuaHangID = Request.QueryString["sid"];
            }
            if (!Page.IsPostBack)
            {
                LoadDanhMucCon(0, 0);
                if (Request.QueryString["id"] != null)
                {
                    LoadDataForCuaHang(Request.QueryString["id"]);
                }                
                txtTenNhomSanPham.Text = Request.QueryString["ten"];
            } 
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadDataForCuaHang(string Id)
    {
        try
        {
            NhomSanPhamCuaHang nhomsanpham = new NhomSanPhamCuaHang();
            DataSet ds = nhomsanpham.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenNhomCon.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                ddlNhomSanPham.SelectedValue = ds.Tables[0].Rows[0]["NhomSanPhamID"].ToString();
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
            if (Common.LoaiNguoiDungID() == 3)
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
            }
            else if (Common.LoaiNguoiDungID()==2)
            {
                NhomSanPhamCuaHang nhomsanpham = new NhomSanPhamCuaHang();
                CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
                if (Request.QueryString["id"] == null)
                {
                    int chnspid = chnsp.InsertFields(int.Parse(CuaHangID), int.Parse(ddlNhomSanPham.SelectedValue), null);
                    nhomsanpham.InsertFields(Convert.ToInt32(Request.QueryString["pid"]), int.Parse(ddlNhomSanPham.SelectedValue)
                        , Convert.ToInt32(txtThuTu.Text), int.Parse(CuaHangID), txtTenNhomCon.Text, chnspid);
                    
                }
                else
                {
                    NhomSanPhamCuaHang nsp = new NhomSanPhamCuaHang();
                    DataSet ds = nsp.SelectByID(int.Parse(Request["id"]));
                    int chnspid = int.Parse("0" + ds.Tables[0].Rows[0]["CuaHangNhomSanPhamID"].ToString());
                    //chnsp.UpdateFields();
                    nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["id"]),
                                             null, int.Parse(ddlNhomSanPham.SelectedValue),
                                             Convert.ToInt32(txtThuTu.Text), null, txtTenNhomCon.Text,null); 
                    chnsp.UpdateFields(chnspid,int.Parse(CuaHangID),int.Parse(ddlNhomSanPham.SelectedValue),null);
                }
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshCat();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadDanhMucCon(int NhomChaID, int loaddm)
    {
        NhomSanPham nhomsanpham = new NhomSanPham();
        DataSet ds;
        string cachNsp = "nsp" + NhomChaID;
        if (Cache[cachNsp] == null)
        {
            ds = nhomsanpham.SelectNhomSanPhamByNhomChaID(NhomChaID);
            Cache.Insert(cachNsp, ds);
        }
        else
        {
            ds = (DataSet)Cache[cachNsp];
        }

        if (NhomChaID == 0)
            loaddm = 0;
        string indent = "";
        switch (loaddm)
        {
            case 0:
                indent = "+ ";
                break;
            case 1:
                indent = "+...";
                break;
            case 2:
                indent = "+.....";
                break;
            case 3:
                indent = "+.......";
                break;
            case 4:
                indent = "+.........";
                break;
        }

        int n = ddlNhomSanPham.SelectedIndex;
        loaddm++;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem item = new ListItem(indent + ds.Tables[0].Rows[i]["TenNhomSanPham"],
                                         ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString());
            ddlNhomSanPham.Items.Add(item);
            //item.Enabled = false;
            LoadDanhMucCon(int.Parse(ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString()), loaddm);
            //item.Enabled = true;
        }
    }
}