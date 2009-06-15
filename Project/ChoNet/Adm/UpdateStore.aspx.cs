using System;
using System.Data;
using System.IO;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_UpdateStore : Page
{
    private int sid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            if (Request.QueryString["sid"] != null)
            {
                try
                {
                    sid = int.Parse(Request.QueryString["sid"]);
                    if (!Page.IsPostBack) LoadCuaHang(sid);
                }
                catch (Exception ex)
                {
                    Response.Redirect("../message.aspx?msg=" + ex.Message);
                }
            }
            else
            {
                Response.Redirect("../message.aspx?msg=Invalid parameter");
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadCuaHang(int sid)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByID(sid);
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            txtTen.Text = dr["TenCuaHang"].ToString();
            txtDiaChi.Text = dr["DiaChi"].ToString();
            txtCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
            txtDiDong.Text = dr["DienThoaiDiDong"].ToString();
            txtFax.Text = dr["Fax"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            ;
            txtWebSite.Text = dr["WebSite"].ToString();
            txtYahoo.Text = dr["YM"].ToString();
            txtLienHe.Text = dr["ThongTinLienHe"].ToString();
            txtGioiThieu.Text = dr["GioiThieu"].ToString();
            imgStore.ImageUrl = "." + dr["Anh"];
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Invalid parameter");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CuaHang ch = new CuaHang();
        string path = Server.MapPath("../Upload/StoreImages");
        string randomString = "";
        string relativePath = "";
        if (fileStore.PostedFile.FileName != "")
        {
            try
            {
                if (fileStore.PostedFile.ContentLength <= 300000)
                {
                    int pos = fileStore.PostedFile.FileName.LastIndexOf('\\');
                    string absolutePath = path + "\\" + fileStore.PostedFile.FileName.Remove(0, pos + 1);
                    if (File.Exists(absolutePath))
                    {
                        randomString = DateTime.Now.Ticks + "_";
                        absolutePath = path + "\\" + randomString + fileStore.PostedFile.FileName.Remove(0, pos + 1);
                    }
                    //fileStore.PostedFile.SaveAs(absolutePath);
                    Common.ResizeFromStream(absolutePath, 320, fileStore.PostedFile.InputStream);
                    //File.Delete(Server.MapPath(imgAnhQuangCao.Src));
                    relativePath = "./Upload/StoreImages/" + randomString +
                                   fileStore.PostedFile.FileName.Remove(0, pos + 1);
                }
                else
                {
                    Response.Redirect("../message.aspx?msg=File size is too big!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../message.aspx?msg=" + ex.Message);
                return;
            }
        }
        if (relativePath != "")
        {
            ch.UpdateFields(sid, txtTen.Text, txtGioiThieu.Text, null, txtEmail.Text, relativePath, txtDiDong.Text,
                            txtCoDinh.Text,
                            txtLienHe.Text, txtDiaChi.Text, txtWebSite.Text, txtFax.Text, txtYahoo.Text, null, null,
                            null, null, null, null,
                            null, null, null, null, null, null, null, null);
        }
        else
        {
            ch.UpdateFields(sid, txtTen.Text, txtGioiThieu.Text, null, txtEmail.Text, null, txtDiDong.Text,
                            txtCoDinh.Text,
                            txtLienHe.Text, txtDiaChi.Text, txtWebSite.Text, txtFax.Text, txtYahoo.Text, null, null,
                            null, null, null,
                            null, null, null, null, null, null, null, null, null);
        }
        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshStoreInfo();</script>";
        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
    }
}