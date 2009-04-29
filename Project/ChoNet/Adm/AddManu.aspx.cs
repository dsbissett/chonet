using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_AddManu : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["hid"] != null)
                {
                    LoadData(Request.QueryString["hid"]);
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
            HangSanXuat hsx = new HangSanXuat();
            DataSet ds = hsx.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHangSanXuat.Text = ds.Tables[0].Rows[0]["TenHangSanXuat"].ToString();
                txtThongTin.Text = ds.Tables[0].Rows[0]["ThongTin"].ToString();
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
            if (txtHangSanXuat.Text.Trim() != "")
            {
                HangSanXuat hsx = new HangSanXuat();
                if (Request.QueryString["hid"] == null)
                {
                    hsx.InsertFields(txtHangSanXuat.Text, txtThongTin.Text, null, null, null, null);
                }
                else
                {
                    hsx.UpdateFields(Convert.ToInt32(Request.QueryString["hid"]),
                                     txtHangSanXuat.Text, txtThongTin.Text, null, null, null, null);
                }
                Cache.Remove("hsx");
                string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}