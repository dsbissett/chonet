using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_Admin : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Common.LoaiNguoiDungID() == 2)
            {
                LoadCuaHang();
            }
            lbluser.Text = Page.User.Identity.Name;
            if (Common.LoaiNguoiDungID() == 3)
            {
                //Administrator
                mnuChoNet.Items[0].Hidden = false;
                mnuChoNet.Items[7].Hidden = false;
                //mnuChoNet.Items[1].Hidden = true;
                //mnuChoNet.Items[7].Hidden = true;

                mnuChoNet.Items[2].Items[1].Hidden = false;
                //mnuChoNet.Items[2].Items[2].Hidden = false;
                mnuChoNet.Items[2].Items[3].Hidden = false;
                mnuChoNet.Items[6].Items[0].Hidden = false;
                mnuChoNet.Items[6].Items[1].Hidden = false;
                mnuChoNet.Items[6].Items[2].Hidden = true;
                mnuChoNet.Items[6].Items[3].Hidden = false;
                mnuChoNet.Items[6].Items[4].Hidden = true;
                mnuChoNet.Items[6].Items[5].Hidden = true;
                mnuChoNet.Items[6].Items[6].Hidden = true;
            }
            else if (Common.LoaiNguoiDungID() == 2)
            {
                //e-Store
                mnuChoNet.Items[0].Hidden = true;
                //mnuChoNet.Items[8].Hidden = true;
                //mnuChoNet.Items[1].Hidden = false;
                mnuChoNet.Items[7].Hidden = true;

                mnuChoNet.Items[2].Items[1].Hidden = true;
                //mnuChoNet.Items[2].Items[2].Hidden = true;
                mnuChoNet.Items[2].Items[3].Hidden = true;
                mnuChoNet.Items[6].Items[0].Hidden = true;
                mnuChoNet.Items[6].Items[1].Hidden = true;
                mnuChoNet.Items[6].Items[2].Hidden = true;
                mnuChoNet.Items[6].Items[3].Hidden = true;
                mnuChoNet.Items[6].Items[4].Hidden = false;
                mnuChoNet.Items[6].Items[5].Hidden = false;
                mnuChoNet.Items[6].Items[6].Hidden = false;
                CuaHang ch = new CuaHang();
                DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());

                if ((ds.Tables[0].Rows.Count > 0) &&
                    ((ds.Tables[0].Rows[0]["LoaiCuaHang"].ToString() == "1") ||
                     (ds.Tables[0].Rows[0]["LoaiCuaHang"].ToString() == "2")))
                {
                    mnuChoNet.Items[3].Hidden = false;
                }
                else
                {
                    mnuChoNet.Items[3].Hidden = true;
                }
                lblTenCongTy.Text = "<b>CÔNG TY TNHH TM quảng cáo trực tuyến CN</b><br/>TEL: 09808080808";
            }
            else
            {
                Response.Redirect("../message.aspx?msg=Access denied");
            }
        }
    }

    protected void lnkSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Response.Redirect("default.aspx");
    }
    private void LoadCuaHang()
    {
        try
        {
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Session["CuaHangID"] = dr["CuaHangID"].ToString();
            }
       }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}