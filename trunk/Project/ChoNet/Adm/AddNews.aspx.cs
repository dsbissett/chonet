using System;
using System.Data;
using System.IO;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_AddNews : Page
{
    //string ACTION = "ADD";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 1)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["nid"] != null)
                {
                    LoadData(Request.QueryString["nid"]);
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
            TinTuc tt = new TinTuc();
            DataSet ds = tt.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTieuDe.Text = ds.Tables[0].Rows[0]["TieuDe"].ToString();
                txtTomTat.Text = ds.Tables[0].Rows[0]["TomTat"].ToString();
                wheNoiDung.Text = ds.Tables[0].Rows[0]["NoiDung"].ToString();
                imgAnhChinh.ImageUrl = "." + ds.Tables[0].Rows[0]["Anh"];
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
            Cache.Remove("tintuc");
            TinTuc tt = new TinTuc();
            int LoaiTinTuc = rbtTroGiup.Checked ? 1 : 0;
            string relativePath = null;
            string path = Server.MapPath("../Upload/NewsImages");
            if (fileAnhChinh.PostedFile.FileName != "")
            {
                if ((fileAnhChinh.PostedFile.ContentLength <= 100000) || (Common.LoaiNguoiDungID() == 3))
                {
                    string randomString = "";
                    path += "\\" + Common.NguoiDungID();
                    relativePath = "./Upload/NewsImages" + "/" + Common.NguoiDungID() + "/";
                    int pos = fileAnhChinh.PostedFile.FileName.LastIndexOf('\\');
                    string absolutePath = path + "\\" + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (File.Exists(absolutePath))
                    {
                        randomString = DateTime.Now.Ticks + "_";
                        absolutePath = path + "\\" + randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);
                    }
                    Common.ResizeFromStream(absolutePath, 300, fileAnhChinh.PostedFile.InputStream);
                    //fileAnhChinh.PostedFile.SaveAs(absolutePath);
                    relativePath += randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                    if (Request.QueryString["nid"] == null)
                    {
                        tt.InsertFields(txtTieuDe.Text, wheNoiDung.TextXhtml, txtTomTat.Text, Common.NguoiDungID(),
                                        DateTime.Now, relativePath, LoaiTinTuc);
                    }
                    else
                    {
                        tt.UpdateFields(Convert.ToInt32(Request.QueryString["nid"]),
                                        txtTieuDe.Text, wheNoiDung.Text, txtTomTat.Text, Common.NguoiDungID(),
                                        DateTime.Now, relativePath, LoaiTinTuc);
                    }
                    imgAnhChinh.ImageUrl = "." + relativePath;
                }
                else
                {
                    lblAnhChinhErr.Text = "Kích cỡ ảnh quá lớn!";
                    return;
                }
            }
            else
            {
                if (Request.QueryString["nid"] == null)
                {
                    tt.InsertFields(txtTieuDe.Text, wheNoiDung.TextXhtml, txtTomTat.Text, Common.NguoiDungID(),
                                    DateTime.Now, relativePath, LoaiTinTuc);
                }
                else
                {
                    tt.UpdateFields(Convert.ToInt32(Request.QueryString["nid"]),
                                    txtTieuDe.Text, wheNoiDung.Text, txtTomTat.Text, Common.NguoiDungID(), DateTime.Now,
                                    relativePath, LoaiTinTuc);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.Message.Replace("\r\n", ""), false);
        }

        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshNews();</script>";
        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
    }
}