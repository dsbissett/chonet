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
using System.IO;

public partial class Adm_AddNews : System.Web.UI.Page
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
                    LoadData(Request.QueryString["nid"].ToString());                    
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
            DataSet ds = tt.SelectByID(System.Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTieuDe.Text = ds.Tables[0].Rows[0]["TieuDe"].ToString();
                txtTomTat.Text = ds.Tables[0].Rows[0]["TomTat"].ToString();
                wheNoiDung.Text = ds.Tables[0].Rows[0]["NoiDung"].ToString();
                imgAnhChinh.ImageUrl = "." + ds.Tables[0].Rows[0]["Anh"].ToString();
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
            TinTuc tt = new  TinTuc();
            string relativePath = null;
            string path = Server.MapPath("../Upload/NewsImages");
            if (fileAnhChinh.PostedFile.FileName != "")
            {
                if (fileAnhChinh.PostedFile.ContentLength <= 100000)
                {
                    string randomString = "";
                    path += "\\" + Common.NguoiDungID().ToString();
                    relativePath = "./Upload/NewsImages" + "/" + Common.NguoiDungID().ToString() + "/";
                    int pos = fileAnhChinh.PostedFile.FileName.LastIndexOf('\\');
                    string absolutePath = path + "\\" + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (File.Exists(absolutePath))
                    {
                        randomString = DateTime.Now.Ticks.ToString() + "_";
                        absolutePath = path + "\\" + randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);
                    }
                    Common.ResizeFromStream(absolutePath, 300, fileAnhChinh.PostedFile.InputStream);
                    //fileAnhChinh.PostedFile.SaveAs(absolutePath);
                    relativePath += randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                    if (Request.QueryString["nid"] == null)
                    {
                        tt.InsertFields(txtTieuDe.Text, wheNoiDung.TextXhtml, txtTomTat.Text, Common.NguoiDungID(), DateTime.Now, relativePath);
                    }
                    else
                    {
                        tt.UpdateFields(System.Convert.ToInt32(Request.QueryString["nid"].ToString()),
                            txtTieuDe.Text, wheNoiDung.Text, txtTomTat.Text, Common.NguoiDungID(), DateTime.Now, relativePath);
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
                    tt.InsertFields(txtTieuDe.Text, wheNoiDung.TextXhtml, txtTomTat.Text, Common.NguoiDungID(), DateTime.Now, relativePath);
                }
                else
                {
                    tt.UpdateFields(System.Convert.ToInt32(Request.QueryString["nid"].ToString()),
                        txtTieuDe.Text, wheNoiDung.Text, txtTomTat.Text, Common.NguoiDungID(), DateTime.Now, relativePath);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.Message.Replace("\r\n", ""), false);
        }

        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshNews();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
    }
}
