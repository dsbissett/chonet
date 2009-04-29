using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_EditAskAnswer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 1)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["aid"] != null)
                {
                    LoadData(Request.QueryString["aid"]);
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
            HoiDapSanPham hd = new HoiDapSanPham();
            DataSet ds = hd.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCauHoi.Text = ds.Tables[0].Rows[0]["CauHoi"].ToString();
                txtTraLoi.Text = ds.Tables[0].Rows[0]["TraLoi"].ToString();
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
            if (txtCauHoi.Text.Trim() != "")
            {
                HoiDapSanPham hd = new HoiDapSanPham();
                if (Request.QueryString["aid"] != null)
                {
                    //hd.UpdateFields(System.Convert.ToInt32(Request.QueryString["aid"].ToString()), null, null,
                    //   null, txtCauHoi.Text, txtTraLoi.Text);
                }
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