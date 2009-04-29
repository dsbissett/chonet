using System;
using System.Data;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class eStoreInfo : Page
{
    private int CuaHangID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sid"] != null)
        {
            try
            {
                CuaHangID = int.Parse(Request.QueryString["sid"]);
                LoadCuaHang();
            }
            catch (Exception ex)
            {
                Response.Redirect("./message.aspx?msg=" + ex.Message);
            }
        }
        else
        {
            Response.Redirect("./message.aspx?msg=Invalid parameter");
        }
    }

    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByID(CuaHangID);
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("./message.aspx?msg=Failed in loading store");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblTenCuaHang.Text = "<a href=\"estore.aspx?sid=" + dr["CuaHangID"] + "\">" + dr["TenCuaHang"] + "</a>";
            lblGioiThieu.Text = dr["GioiThieu"].ToString();
            lblDiaChi.Text = dr["DiaChi"].ToString();
            lblEmail.Text = dr["Email"].ToString();
            lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
            lblDiDong.Text = dr["DienThoaiDiDong"].ToString();
            lblFax.Text = dr["Fax"].ToString();
            lblBack.Text = "<a href=\"estore.aspx?sid=" + dr["CuaHangID"] +
                           "\"><span style=\"color:blue;text-decoration:underline;\">QUAY LẠI TRANG TRƯỚC</span></a>";
        }
    }
}