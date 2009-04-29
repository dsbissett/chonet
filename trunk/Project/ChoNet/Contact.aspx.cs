using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Contact : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int cuahangid = int.Parse(Request.QueryString["sid"]);
            LoadCuaHang(cuahangid);
        }
    }

    private void LoadCuaHang(int CuaHangID)
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
            string content = "";
            content += "Gian Hàng: " + dr["TenCuaHang"] + "<br/>";
            content += "Địa chỉ liên hệ: " + dr["DiaChi"] + "<br/>";
            content += "Điện thoại: " + dr["DienThoaiCoDinh"] + " - " +
                       dr["DienThoaiDiDong"];
            content += "Email: " + dr["Email"];
            ViewState["email"] = dr["Email"].ToString();
            divGianHang.InnerHtml = content;
            //content += int.Parse(dr["NguoiDungID"].ToString());


            //switch (dr["LoaiCuaHang"].ToString())
            //{
            //    case "1":
            //        stsGianHang.Href = "GianHang/VIP/css/style.css";
            //        LoadTinTuc();
            //        break;
            //    case "2":
            //        stsGianHang.Href = "GianHang/CN/css/style.css";
            //        LoadTinTuc();
            //        break;
            //    case "3":
            //        stsGianHang.Href = "GianHang/TT/css/style.css";
            //        break;
            //}
            //if ((dr["LoaiCuaHang"].ToString() == "1") ||
            //        (dr["LoaiCuaHang"].ToString() == "2"))
            //{
            //    LoadTinTuc();
            //}
        }
    }

    protected void btnGui_Click(object sender, EventArgs e)
    {
        try
        {
            string emailto = ViewState["email"].ToString();
            string emailfrom = txtNguoiGui.Text;
            string emailsubject = txtTieuDe.Text; // +Session["UserFullName"].ToString();
            string emailbody = txtNoiDungKemTheo.Text;
            string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
            string emailcc = "";
            string emailbcc = "";

            Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);

            string strScript = "<script language='JavaScript'>" + "this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }
}