using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddSupporter : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 1)
        {
            txtHoTro.Focus();
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
            HoTroTrucTuyen ht = new HoTroTrucTuyen();
            DataSet ds = ht.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHoTro.Text = ds.Tables[0].Rows[0]["TenHoTro"].ToString();
                txtHoVaTen.Text = ds.Tables[0].Rows[0]["HoVaTen"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtYM.Text = ds.Tables[0].Rows[0]["YM"].ToString();
                txtDienThoai.Text = ds.Tables[0].Rows[0]["DienThoai"].ToString();
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
            HoTroTrucTuyen ht = new HoTroTrucTuyen();
            if (Request.QueryString["hid"] == null)
            {
                ht.InsertFields(int.Parse(Request.QueryString["sid"]), txtHoTro.Text, txtYM.Text, txtHoVaTen.Text,
                                txtDienThoai.Text, txtEmail.Text);
            }
            else
            {
                ht.UpdateFields(Convert.ToInt32(Request.QueryString["hid"]), int.Parse(Request.QueryString["sid"]),
                                txtHoTro.Text, txtYM.Text, txtHoVaTen.Text,
                                txtDienThoai.Text, txtEmail.Text);
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshStoreInfo();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}