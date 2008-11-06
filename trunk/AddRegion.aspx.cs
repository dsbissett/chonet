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

public partial class Adm_Region : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["kid"] != null)
                {
                    LoadData(Request.QueryString["kid"].ToString());
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
            KhuVuc kv = new KhuVuc();
            DataSet ds = kv.SelectByID(System.Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenKhuVuc.Text = ds.Tables[0].Rows[0]["TenKhuVuc"].ToString();
                txtGhiChu.Text = ds.Tables[0].Rows[0]["GhiChu"].ToString();
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
            if (txtTenKhuVuc.Text.Trim() != "")
            {
                KhuVuc kv = new KhuVuc();
                if (Request.QueryString["kid"] == null)
                {
                    kv.InsertFields(txtTenKhuVuc.Text, txtGhiChu.Text, null, null, null, null, null);
                }
                else
                {
                    kv.UpdateFields(System.Convert.ToInt32(Request.QueryString["kid"].ToString()),
                        txtTenKhuVuc.Text, txtGhiChu.Text, null,null,null, null, null);
                }
                string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}
