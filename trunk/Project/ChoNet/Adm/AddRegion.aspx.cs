using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_Region : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["kid"] != null)
                {
                    LoadData(Request.QueryString["kid"]);
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
            DataSet ds = kv.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenKhuVuc.Text = ds.Tables[0].Rows[0]["TenKhuVuc"].ToString();
                txtGhiChu.Text = ds.Tables[0].Rows[0]["GhiChu"].ToString();
                if (ds.Tables[0].Rows[0]["HienThi"].ToString() != "")
                    chkHienThi.Checked = bool.Parse(ds.Tables[0].Rows[0]["HienThi"].ToString());
                chkSuKien.Checked = ds.Tables[0].Rows[0]["bak3"].ToString() == "1" ? true : false;
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
                int sukien = 0;
                int KhuVucID = 0;
                if (chkSuKien.Checked)
                    sukien = 1;
                if (Request.QueryString["kid"] == null)
                {
                    kv.InsertFields(txtTenKhuVuc.Text, txtGhiChu.Text, null, chkHienThi.Checked, null, null, sukien);
                }
                else
                {
                    KhuVucID = Convert.ToInt32(Request.QueryString["kid"]);
                    kv.UpdateFields(KhuVucID,
                                    txtTenKhuVuc.Text, txtGhiChu.Text, null, chkHienThi.Checked, null, null, sukien);
                }
                Cache.Remove("kv");
                if (sukien == 1)
                    UpdateSuKien(KhuVucID);
                string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void UpdateSuKien(int KhuVucID)
    {
        KhuVuc kv = new KhuVuc();
        DataSet ds = kv.SelectAll();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            int kvid = int.Parse(dr["KhuVucID"].ToString());
            if (KhuVucID != kvid)
                kv.UpdateFields(int.Parse(dr["KhuVucID"].ToString()), null, null, null, null, null, null, 0);
        }
    }
}