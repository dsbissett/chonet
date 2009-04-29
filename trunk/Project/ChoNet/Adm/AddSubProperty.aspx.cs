using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddSubProperty : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            txtTenThuocTinh.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ppid"] != null)
                {
                    LoadThuocTinhCha();
                    ddlThuocChinhCha.SelectedValue = Request.QueryString["ppid"];
                }
                if (Request.QueryString["pid"] != null)
                {
                    LoadData(Request.QueryString["pid"]);
                }
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
            ThuocTinh tt = new ThuocTinh();
            DataSet ds = tt.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenThuocTinh.Text = ds.Tables[0].Rows[0]["TenThuocTinh"].ToString();
                txtThuTu.Text = ds.Tables[0].Rows[0]["ThuTu"].ToString();
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
            ThuocTinh tt = new ThuocTinh();
            if (Request.QueryString["pid"] == null)
            {
                tt.InsertFields(null, txtTenThuocTinh.Text, int.Parse(ddlThuocChinhCha.SelectedValue),
                                int.Parse(txtThuTu.Text));
            }
            else
            {
                tt.UpdateFields(Convert.ToInt32(Request.QueryString["pid"]), null, txtTenThuocTinh.Text, null,
                                int.Parse(txtThuTu.Text));
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadThuocTinhCha()
    {
        ThuocTinh tt = new ThuocTinh();
        DataSet ds = tt.SelectAllThuocTinhByThuocTinhChaAndNhomSanPham(int.Parse(Request.QueryString["cid"]), 0);
        ddlThuocChinhCha.DataSource = ds.Tables[0];
        ddlThuocChinhCha.DataTextField = "TenThuocTinh";
        ddlThuocChinhCha.DataValueField = "ThuocTinhID";
        ddlThuocChinhCha.DataBind();
    }
}