using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
public partial class ChangeLogo : System.Web.UI.Page
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
                    if (!Page.IsPostBack) LoadCuaHang();
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
            ch.UpdateFields(sid, null, null, null, null, relativePath, null, null, null, null,
                             null, null, null, null, null,
                            null, null, null, null,
                            null, null, null, null, null, null, null);
        }

        const string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
    }

    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByID(sid);
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];            
            imgStore.ImageUrl = "." + dr["Anh"];
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Invalid parameter");
        }
    }
}
