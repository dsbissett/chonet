using System;
using System.Data;
using System.IO;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddAdv : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3 || Common.LoaiNguoiDungID() == 2)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //Edit, show the data from database
                    int id = int.Parse(Request.QueryString["id"]);
                    QuangCao qcao = new QuangCao();
                    DataSet ds = qcao.SelectByQuangCaoID(id);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        int NguoiDungID = int.Parse(ds.Tables[0].Rows[0]["NguoiDungID"].ToString());
                        int LoaiNguoiDungID = int.Parse(ds.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString());
                        if ((Common.LoaiNguoiDungID() == 3 && LoaiNguoiDungID == 3)
                            ||
                            (Common.LoaiNguoiDungID() == 2 && LoaiNguoiDungID == 2 &&
                             Common.NguoiDungID() == NguoiDungID))
                        {
                            txtDuongDan.Text = ds.Tables[0].Rows[0]["DuongDan"].ToString();
                            txtNoiDung.Text = ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString();
                            imgAnhQuangCao.Src = "." + ds.Tables[0].Rows[0]["DuongDanAnh"];
                            txtGhiChu.Text = ds.Tables[0].Rows[0]["GhiChu"].ToString();
                            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                            {
                                rbtFlash.Checked = true;
                                flashQuangCao.Visible = true;
                                flashQuangCao.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                          +
                                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                          + "width=\"300\" height=\"200\" title=\"Quang Cao\">"
                                                          + "<param name=\"movie\" value=\"." +
                                                          ds.Tables[0].Rows[0]["DuongDanAnh"] + "\" />"
                                                          + "<param name=\"quality\" value=\"high\" />"
                                                          + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                                          "\" quality=\"high\""
                                                          +
                                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                          + "width=\"300\" height=\"200\"></embed></object> ";
                            }
                            else
                            {
                                rbtImage.Checked = true;
                                imgAnhQuangCao.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Redirect("../message.aspx?msg=Access denied");
                        }
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Invalid parameter");
                    }
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3 || Common.LoaiNguoiDungID() == 2)
        {
            QuangCao qcao = new QuangCao();
            if (Request.QueryString["id"] == null)
            {
                //Add new
                string path = Server.MapPath("../Upload/AdvImages");
                string relativePath = "";
                string randomString = "";
                string mediaType = "IMAGE";
                if (rbtFlash.Checked) mediaType = "FLASH";
                if (fileQuangCao.PostedFile.FileName != "")
                {
                    try
                    {
                        if ((fileQuangCao.PostedFile.ContentLength <= 300000) || (Common.LoaiNguoiDungID() == 3))
                        {
                            int pos = fileQuangCao.PostedFile.FileName.LastIndexOf('\\');
                            string absolutePath = path + "\\" + fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
                            if (File.Exists(absolutePath))
                            {
                                randomString = DateTime.Now.Ticks + "_";
                                absolutePath = path + "\\" + randomString +
                                               fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
                            }
                            fileQuangCao.PostedFile.SaveAs(absolutePath);
                            relativePath = "./Upload/AdvImages/" + randomString +
                                           fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
                        }
                        else
                        {
                            Response.Redirect("../message.aspx?msg=File size is bigger than 300KB!");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("../message.aspx?msg=" + ex.Message);
                        return;
                    }
                }
                qcao.InsertFields(txtDuongDan.Text, txtNoiDung.Text, relativePath, Common.NguoiDungID(), txtGhiChu.Text,
                                  mediaType, null, null, null, null, null);
            }
            else
            {
                //Edit
                int id = int.Parse(Request.QueryString["id"]);
                string path = Server.MapPath("../Upload/AdvImages");
                string randomString = "";
                string relativePath = "";
                string mediaType = "IMAGE";
                if (rbtFlash.Checked) mediaType = "FLASH";
                if (fileQuangCao.PostedFile.FileName != "")
                {
                    try
                    {
                        if ((fileQuangCao.PostedFile.ContentLength <= 300000) || (Common.LoaiNguoiDungID() == 3))
                        {
                            int pos = fileQuangCao.PostedFile.FileName.LastIndexOf('\\');
                            string absolutePath = path + "\\" + fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
                            if (File.Exists(absolutePath))
                            {
                                randomString = DateTime.Now.Ticks + "_";
                                absolutePath = path + "\\" + randomString +
                                               fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
                            }

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            fileQuangCao.PostedFile.SaveAs(absolutePath);
                            //if (rbtFlash.Checked == true)
                            //{
                            //    fileQuangCao.PostedFile.SaveAs(absolutePath);
                            //}
                            //else
                            //{
                            //    Common.ResizeFromStream(absolutePath, 320, fileQuangCao.PostedFile.InputStream);
                            //}
                            //File.Delete(Server.MapPath(imgAnhQuangCao.Src));
                            relativePath = "./Upload/AdvImages/" + randomString +
                                           fileQuangCao.PostedFile.FileName.Remove(0, pos + 1);
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
                    qcao.UpdateFields(id, txtDuongDan.Text, txtNoiDung.Text, relativePath, null, txtGhiChu.Text,
                                      mediaType, null, null, null, null, null);
                }
                else
                {
                    qcao.UpdateFields(id, txtDuongDan.Text, txtNoiDung.Text, null, null, txtGhiChu.Text, mediaType, null,
                                      null, null, null, null);
                }
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
}