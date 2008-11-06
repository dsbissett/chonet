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

public partial class Admin_AddSupporter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            txtHoTro.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["hid"] != null)
                {
                    LoadData(Request.QueryString["hid"].ToString());
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
            DataSet ds = ht.SelectByID(System.Convert.ToInt32(Id));

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
                ht.InsertFields(int.Parse(Request.QueryString["sid"].ToString()), txtHoTro.Text, txtYM.Text, txtHoVaTen.Text,
                    txtDienThoai.Text, txtEmail.Text);
            }
            else
            {
                ht.UpdateFields(System.Convert.ToInt32(Request.QueryString["hid"].ToString()), int.Parse(Request.QueryString["sid"].ToString()), txtHoTro.Text, txtYM.Text, txtHoVaTen.Text,
                    txtDienThoai.Text, txtEmail.Text);
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshStoreInfo();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }        
    }
}
