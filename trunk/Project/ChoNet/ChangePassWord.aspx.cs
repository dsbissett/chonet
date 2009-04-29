using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_ChangePassWord : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnLuu.Attributes.Add("onclick", "return btnLuu_Click();");
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByID(Common.NguoiDungID());

            if (ds.Tables[0].Rows.Count > 0)
            {
                hidMatKhau.Value = ds.Tables[0].Rows[0]["MatKhau"].ToString();
            }
        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            nguoidung.UpdateFields(Common.NguoiDungID(), null, null, txtMatKhauMoi.Text, null, null,
                                   null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("../Message.aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }
}