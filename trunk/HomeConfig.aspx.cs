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
using Infragistics.WebUI.Misc;
using CHONET.Common;
public partial class Admin_HomeConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                int loaddm = 0;
                LoadDanhMuc(0, loaddm);
                LoadQuangCao01();
                LoadQuangCao02();
                LoadQuangCao03();
                LoadQuangCao04();
                LoadQuangCao05();
                LoadQuangCao06();
                LoadQuangCao07();
                LoadQuangCao08();
                LoadQuangCao09();
                LoadQuangCao10();
                LoadSanPham01();
                LoadSanPham02();
                //LoadSanPham03();
                LoadSanPham04();
                //LoadSanPham05();
                //LoadSanPham06();
                //LoadSanPham07();
                LoadGianHang();
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    private void LoadDanhMuc(int NhomChaID, int loaddm)
    {
        loaddm++;
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectNhomSanPhamByNhomChaID(NhomChaID);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
                    //{
                        HtmlTableRow tbr = new HtmlTableRow();
                        tbr.Style.Add("padding-left", (loaddm * 15).ToString() + "px");
                        HtmlTableCell tbc1 = new HtmlTableCell();
                        HtmlTableCell tbc2 = new HtmlTableCell();
                        //image cells
                        HtmlTableCell tbc3 = new HtmlTableCell();
                        HtmlTableCell tbc4 = new HtmlTableCell();
                        HtmlTableCell tbc5 = new HtmlTableCell();


                        //tbc1.Style.Add("width", "3%");                        
                        tbc2.InnerText = dr["SapXep"].ToString() + "." + dr["TenNhomSanPham"].ToString();
                        tbc2.ColSpan = 2;
                        tbc3.Style.Add("width", "16px");
                        tbc4.Style.Add("width", "16px");
                        tbc5.Style.Add("width", "16px");
                        tbc3.Style.Add("padding", "0");
                        tbc3.Style.Add("margin", "0");
                        tbc3.Style.Add("cursor", "hand");
                        tbc4.Style.Add("padding", "0");
                        tbc4.Style.Add("margin", "0");
                        tbc4.Style.Add("cursor", "hand");
                        tbc5.Style.Add("padding", "0");
                        tbc5.Style.Add("margin", "0");
                        tbc5.Style.Add("cursor", "hand");

                        HtmlImage img1 = new HtmlImage();
                        HtmlImage img2 = new HtmlImage();
                        HtmlImage img3 = new HtmlImage();

                        img1.Src = "../images/edit.gif";
                        img2.Src = "../images/delete.gif";
                        img3.Src = "../images/add.gif";
                        img1.Alt = "Sửa danh mục cha";
                        img2.Alt = "Xóa danh mục cha";
                        img3.Alt = "Thêm danh mục con";
                        img1.Attributes.Add("onclick", "Edit(" + dr["NhomSanPhamID"].ToString() + ");");
                        img2.Attributes.Add("onclick", "Delete(" + dr["NhomSanPhamID"].ToString() + ");");
                        img3.Attributes.Add("onclick", "AddSub(" + dr["NhomSanPhamID"].ToString() + ",'" +
                            dr["TenNhomSanPham"].ToString() + "');");


                        tbc3.Controls.Add(img1);
                        tbc4.Controls.Add(img2);
                        tbc5.Controls.Add(img3);

                        tbr.Cells.Add(tbc1);
                        tbr.Cells.Add(tbc2);
                        tbr.Cells.Add(tbc3);
                        tbr.Cells.Add(tbc4);
                        tbr.Cells.Add(tbc5);
                        tblDanhMuc.Rows.Add(tbr);

                        LoadDanhMuc(int.Parse(dr["NhomSanPhamID"].ToString()),loaddm);                        
                   // }
                }
            }
//            tblDanhMuc.Controls.Add(tbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    //private void AddDanhMucCon(string NhomChaID)
    //{

    //    ds.Tables[0].DefaultView.RowFilter = "NhomChaID=" + NhomChaID;
    //    DataView dv = ds.Tables[0].DefaultView;

    //    if (dv.Count > 0)
    //    {
    //        img2.Disabled = true;
    //    }
    //    tblDanhMuc.Rows.Add(tbr);

    //    for (int i = 0; i < dv.Count; i++)
    //    {
    //        HtmlTableRow tvr = new HtmlTableRow();

    //        HtmlTableCell tvc1 = new HtmlTableCell();
    //        HtmlTableCell tvc2 = new HtmlTableCell();
    //        HtmlTableCell tvc3 = new HtmlTableCell();
    //        HtmlTableCell tvc4 = new HtmlTableCell();
    //        HtmlTableCell tvc5 = new HtmlTableCell();
    //        //HtmlTableCell tvc6 = new HtmlTableCell();

    //        HtmlImage imgv1 = new HtmlImage();
    //        HtmlImage imgv2 = new HtmlImage();

    //        tvc4.Style.Add("padding", "0");
    //        tvc4.Style.Add("margin", "0");
    //        tvc5.Style.Add("padding", "0");
    //        tvc5.Style.Add("margin", "0");
    //        tvc4.Style.Add("cursor", "hand");
    //        tvc5.Style.Add("cursor", "hand");

    //        //HtmlImage img3 = new HtmlImage();
    //        imgv1.Src = "../images/Edit.gif";
    //        imgv2.Src = "../images/Delete.gif";
    //        imgv1.Attributes.Add("onclick", "EditSub(" + dr["NhomSanPhamID"].ToString() + ",'" +
    //        dr["TenNhomSanPham"].ToString() + "'," + dv[i]["NhomSanPhamID"].ToString() + ");");
    //        imgv2.Attributes.Add("onclick", "Delete(" + dv[i]["NhomSanPhamID"].ToString() + ");");
    //        //img3.Src = "../images/AddSub.gif";
    //        imgv1.Alt = "Sửa danh mục con";
    //        imgv2.Alt = "Xóa danh mục con";


    //        tvc4.Controls.Add(imgv1);
    //        tvc5.Controls.Add(imgv2);
    //        //tbc5.Controls.Add(img3);

    //        tvr.Cells.Add(tvc1);
    //        tvr.Cells.Add(tvc2);
    //        tvr.Cells.Add(tvc3);
    //        tvr.Cells.Add(tvc4);
    //        tvr.Cells.Add(tvc5);
    //        //tvr.Cells.Add(tvc6);

    //        tvc3.InnerText = dv[i]["SapXep"].ToString() + "." + dv[i]["TenNhomSanPham"].ToString();
    //        tblDanhMuc.Rows.Add(tvr);
    //    }
    //}
    private void LoadQuangCao01()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 1);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao01.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"100%\" height=\"75\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"100%\" height=\"75\"></embed></object>";
            }
            else
            {
                spnQuangCao01.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                    + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                    + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"75px\" width=\"100%\" style=\"Border:none\"/></a>";
            }

        }
        else
        {
            spnQuangCao01.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"75px\" width=\"100%\" style=\"border:none\"/>";
        }
    }
    private void LoadQuangCao02()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 2);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao02.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"550\" height=\"216\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"550\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao02.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                   + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                   + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"216px\" width=\"550px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao02.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"216px\" width=\"550px\" style=\"border:none\"/>";
        }
    }
    private void LoadQuangCao03()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 3);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao03a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao03b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao03c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao03a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao03a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao03b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao03b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao03c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"100%\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"100%\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao03c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
    }
    private void LoadQuangCao04()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 4);
        int n = 2;
        if (ds.Tables[0].Rows.Count <= 2) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px; padding-left:4px";
            string content = "";
            if (ds.Tables[0].Rows[i]["LoaiAnh"].ToString() == "FLASH")
            {
                content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"220\" height=\"155\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"220\" height=\"155\"></embed></object>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"].ToString()
                            + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"].ToString()
                            + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString()
                            + "\" style=\"border:solid 1px #C9C3C3; width:220px;\"></a>";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao04.Rows.Add(tr);
        }
    }
    private void LoadQuangCao05()
    {        
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 5);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao05a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao05b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        // spnQuangCao05c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao05a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao05a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao05b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao05b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao05c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"100%\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"100%\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao05c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
    }
    private void LoadQuangCao06()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 6);
        int n = 5;
        if (ds.Tables[0].Rows.Count <= 5) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px;";
            string content = "";
            if (ds.Tables[0].Rows[i]["LoaiAnh"].ToString() == "FLASH")
            {
                content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"220\" height=\"155\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"220\" height=\"155\"></embed></object>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"].ToString()
                            + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"].ToString()
                            + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString()
                            + "\" style=\"border:solid 1px #C9C3C3; width:220px;\"></a>";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao06.Rows.Add(tr);
        }
    }
    private void LoadQuangCao07()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 7);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao07a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao07b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao07c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao07a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao07a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao07b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao07b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao07c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao07c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
    }
    private void LoadQuangCao08()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 8);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao08a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao08b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao08c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao08a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao08a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao08b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao08b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao08c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao08c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
    }
    private void LoadQuangCao09()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 9);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao09a.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao09b.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao09c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao09a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao09a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                  + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                  + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao09b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                        + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                        + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                        + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" />"
                        + "<param name=\"quality\" value=\"high\" />"
                        + "<embed src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                        + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                        + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao09b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"].ToString()
                      + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[1]["NoiDungQuangCao"].ToString()
                      + "\" src=\"." + ds.Tables[0].Rows[1]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao09c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao09c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"." + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
    }
    private void LoadQuangCao10()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 10);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao00.InnerHtml = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"100%\" height=\"75\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"100%\" height=\"75\"></embed></object>";
            }
            else
            {
                spnQuangCao00.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                    + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                    + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"75px\" width=\"100%\" style=\"Border:none\"/></a>";
            }

        }
        else
        {
            spnQuangCao00.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"75px\" width=\"100%\" style=\"border:none\"/>";
        }
    }
    private void LoadSanPham01()
    {

        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(1);
        int n = 20;
        if (ds.Tables[0].Rows.Count < n) n = ds.Tables[0].Rows.Count;
        for (int i = 0; i < n; i++)
        {
            string content1 = "";
            content1 += "<table class=\"product1\" width=\"300px\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
            content1 += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString()
                + "\"><img src=\"." + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
                + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
            content1 += "<td align=\"Left\"><strong>SẢN PHẨM ĐÓN GIỜ VÀNG</strong><br /><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString()
                + "\">" + ds.Tables[0].Rows[i]["TenSanPham"].ToString()
                + "</a><br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".") + "</span>"
            + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</td></tr></table>";
            spnSanPham01.InnerHtml = content1;
        }
    }
    private void LoadSanPham02()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(2);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 5; i++)
        {

            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><img src=\"." + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
                    + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                content += "</tr><tr><td align=\"center\">" + ds.Tables[0].Rows[i]["TenSanPham"].ToString()
                    + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".") + "</span><br/>"
                + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(20);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham02.Rows.Add(tr);

    }
    private void LoadSanPham03()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(3);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 4; i++)
        {
            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><img src=\"." + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
                    + "\" width=\"179\" height=\"159\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></td>";
                content += "</tr><tr><td align=\"center\"><b>" + ds.Tables[0].Rows[i]["TenSanPham"].ToString() + "</b> <br />";
                content += "Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".")
                    + "</span> " + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</td></tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(25);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham03.Rows.Add(tr);
    }
    private void LoadSanPham04()
    {
        //LoadDanhMuc04
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
        DataRow[] dr = ds.Tables[0].Select("Show=true");
        int n = 4;
        if (dr.Length < 4) n = dr.Length;
        TableRow tr = new TableRow();
        for (int i = 0; i < n; i++)
        {
            if ((!Page.IsPostBack && i == 0) || hidCatId.Value == "0") hidCatId.Value = dr[0]["NhomSanPhamID"].ToString();
            TableCell td = new TableCell();
            td.Width = Unit.Percentage(100 / n);
            if (hidCatId.Value.Trim().Length > 0)
            {
                if (dr[i]["NhomSanPhamID"].ToString() == hidCatId.Value)
                {
                    string content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content += "<tr><td width=\"12\"></td>";
                    content += "<td class=\"nd2\">" + dr[i]["TenNhomSanPham"].ToString() + "</td>";
                    content += "<td width=\"12\"></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    lblTab.Text = dr[i]["TenNhomSanPham"].ToString();
                    //LoadSanPham04
                    SanPham sp = new SanPham();
                    DataSet sds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(4, int.Parse(dr[i]["NhomSanPhamID"].ToString()));
                    int sn = sds.Tables[0].Rows.Count;
                    for (int j = 0; j < 2; j++)
                    {
                        TableRow str = new TableRow();
                        for (int si = 0; si < 6; si++)
                        {
                            TableCell std = new TableCell();
                            string scontent = "";
                            if (j * 6 + si < sn)
                            {
                                scontent += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                                scontent += "<tr><td align=\"center\"><img src=\"." + sds.Tables[0].Rows[j * 6 + si]["AnhSanPham"].ToString()
                                    + "\" alt=\"\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                                scontent += "</tr><tr><td align=\"center\"><a href=\"\">" + sds.Tables[0].Rows[j * 6 + si]["TenSanPham"].ToString()
                                    + "</a><br />";
                                scontent += "Giá: <span class=\"price\">" + String.Format("{0:0,0}", sds.Tables[0].Rows[j * 6 + si]["GiaSanPham"]).Replace(",", ".")
                                    + "</span><br/>" + sds.Tables[0].Rows[j * 6 + si]["DonViTienTe"].ToString() + "</td></tr></table>";
                            }
                            std.Text = scontent;
                            if (j == 0) std.Width = Unit.Percentage(16);
                            str.Cells.Add(std);
                        }
                        tblSanPham04.Rows.Add(str);
                    }
                }
                else
                {
                    string content = "<a href=\"#\" onclick=\"RefreshProduct04(" + dr[i]["NhomSanPhamID"].ToString() + ")\">" + dr[i]["TenNhomSanPham"].ToString() + "</a>";
                    td.CssClass = "tab_noactive";
                    td.Text = content;
                    tr.Cells.Add(td);
                }
            }
            else
            {
                td.Text = "Selected Tab parameter is misisng!";
                tr.Cells.Add(td);
            }
        }
        tblDanhMuc04.Rows.Add(tr);
    }
    private void LoadSanPham05()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(05);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    double GiaCu = double.Parse("0" + ds.Tables[0].Rows[j * 4 + i]["GiaSanPham"].ToString());
                    double GiaMoi = double.Parse("0" + ds.Tables[0].Rows[j * 4 + i]["GiaKhuyenMai"].ToString());
                    if (GiaMoi != 0)
                    {
                        if (GiaMoi < GiaCu)
                        {
                            content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td>";
                            content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                                + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                            content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                                + "<br />Giá cũ: <span class=\"oldprice\">" + String.Format("{0:0,0}", GiaCu).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "<br/>";
                            content += "Giá mới: <span class=\"price\">" + String.Format("{0:0,0}", GiaMoi).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                        }
                        else
                        {
                            content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                            content += "<tr><td>";
                            content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                                + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                            content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                                + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", GiaMoi).Replace(",", ".")
                                + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                        }
                    }
                    else
                    {
                        content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                        content += "<tr><td>";
                        content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                            + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                        content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                            + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", GiaCu).Replace(",", ".")
                            + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                    }

                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham05.Rows.Add(tr);
        }
    }
    private void LoadSanPham06()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(6);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 2; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 2 + i < n)
                {
                    content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td>";
                    content += "<img src=\"." + ds.Tables[0].Rows[j * 2 + i]["AnhSanPham"].ToString()
                        + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                    content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 2 + i]["TenSanPham"].ToString()
                        + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[j * 2 + i]["GiaSanPham"]).Replace(",", ".")
                        + "</span> " + ds.Tables[0].Rows[j * 2 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(50);
                tr.Cells.Add(td);
            }
            tblSanPham06.Rows.Add(tr);
        }
    }
    private void LoadSanPham07()
    {
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(7);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td>";
                    content += "<img src=\"." + ds.Tables[0].Rows[j * 4 + i]["AnhSanPham"].ToString()
                        + "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></td>";
                    content += "<td style=\"width:60%\">" + ds.Tables[0].Rows[j * 4 + i]["TenSanPham"].ToString()
                        + "<br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[j * 4 + i]["GiaSanPham"]).Replace(",", ".")
                        + "</span> " + ds.Tables[0].Rows[j * 4 + i]["DonViTienTe"].ToString() + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham07.Rows.Add(tr);
        }
    }
    private void LoadGianHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectCuaHangAtViTriCuaHang(1);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 4; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j * 4 + i < n)
                {
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><img src=\"." + ds.Tables[0].Rows[j * 4 + i]["Anh"].ToString() + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></td>";
                    content += "<td><a href=\"#\"><b>" + ds.Tables[0].Rows[j * 4 + i]["TenCuaHang"].ToString() + "</b></a></td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblGianHang.Rows.Add(tr);
        }
    }
    protected void pnlDanhMuc_ContentRefresh(object sender, EventArgs e)
    {
        int loaddm = 0;
        LoadDanhMuc(0,loaddm);
    }
    protected void pnlQuangCao01_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao01();
    }
    protected void pnlQuangCao02_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao02();
    }
    protected void pnlQuangCao03_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao03();
    }
    protected void pnlQuangCao04_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao04();
    }
    protected void pnlQuangCao05_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao05();
    }
    protected void pnlQuangCao06_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao06();
    }
    protected void pnlQuangCao07_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao07();
    }
    protected void pnlSanPham01_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham01();
    }
    protected void pnlSanPham02_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham02();
    }
    protected void pnlSanPham03_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham03();
    }
    protected void pnlSanPham04_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham04();
    }
    protected void pnlSanPham05_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham05();
    }
    protected void pnlSanPham06_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham06();
    }
    protected void pnlSanPham07_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham07();
    }
    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadGianHang();
    }
    protected void pnlQuangCao00_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao10();
    }
    //protected void pnlSanPham00_ContentRefresh(object sender, EventArgs e)
    //{

    //}
    protected void pnlQuangCao08_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao08();
    }
    protected void pnlQuangCao09_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao09();
    }
}
