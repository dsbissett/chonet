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

public partial class Adm_StoreConfig : System.Web.UI.Page
{
    public int CuaHangID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-Store only
            if (!Page.IsPostBack)
            {
                LoadCuaHang();
                //LoadHoTro();
                LoadQuangCao(51);
                LoadQuangCao(52);
                LoadQuangCao(53);
                LoadQuangCao(54);
                LoadGianHang();
                LoadDanhMuc(0);
                LoadHoTroTrucTuyen();
            }
        }
    }
    private void LoadDanhMuc(int loaddm)
    {
        try
        {
            CuaHang ch = new CuaHang();
            DataSet dsCH = ch.SelectByNguoiDungID(Common.NguoiDungID());
            int id = 0;
            if (dsCH.Tables[0].Rows.Count == 1)
            {
                DataRow dr = dsCH.Tables[0].Rows[0];                
                id = int.Parse(dr["CuaHangID"].ToString());
            }


            LoadDanhMucCon(0, id, loaddm);
            //NhomSanPham nhomsanpham = new NhomSanPham();
            //DataSet ds = nhomsanpham.SelectNhomSanPhamByCuaHangID(id);            
            //ds.Tables[0].DefaultView.Sort = "SapXep ASC";

            ////Table tbl = new Table();
            //// tbl.CssClass = "ListCat";

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
            //        {
            //            HtmlTableRow tbr = new HtmlTableRow();
            //            //tbr.Style.Add("margin", "0");
            //            //tbr.Style.Add("padding", "0");
            //            //tbr.Style.Add("padding", "0");

            //            HtmlTableCell tbc1 = new HtmlTableCell();
            //            HtmlTableCell tbc2 = new HtmlTableCell();
            //            //image cells
            //            //HtmlTableCell tbc3 = new HtmlTableCell();
            //            HtmlTableCell tbc4 = new HtmlTableCell();
            //            HtmlTableCell tbc5 = new HtmlTableCell();


            //            tbc1.Style.Add("width", "3%");
            //            tbc2.InnerText = dr["SapXep"].ToString() + "." + dr["TenNhomSanPham"].ToString();
            //            tbc2.ColSpan = 2;
            //            //tbc3.Style.Add("width", "16px");
            //            tbc4.Style.Add("width", "16px");
            //            tbc5.Style.Add("width", "16px");
            //            //tbc3.Style.Add("padding", "0");
            //            //tbc3.Style.Add("margin", "0");
            //            //tbc3.Style.Add("cursor", "hand");
            //            tbc4.Style.Add("padding", "0");
            //            tbc4.Style.Add("margin", "0");
            //            tbc4.Style.Add("cursor", "hand");
            //            tbc5.Style.Add("padding", "0");
            //            tbc5.Style.Add("margin", "0");
            //            tbc5.Style.Add("cursor", "hand");

            //            //HtmlImage img1 = new HtmlImage();
            //            HtmlImage img2 = new HtmlImage();
            //            HtmlImage img3 = new HtmlImage();

            //            //img1.Src = "../images/edit.gif";
            //            img2.Src = "../images/delete.gif";
            //            img3.Src = "../images/add.gif";
            //            //img1.Alt = "Sửa danh mục cha";
            //            img2.Alt = "Xóa danh mục cha";
            //            img3.Alt = "Thêm danh mục con";
            //            //img1.Attributes.Add("onclick", "Edit(" + dr["NhomSanPhamID"].ToString() + ");");
            //            img2.Attributes.Add("onclick", "Delete(" + dr["CuaHangNhomSanPhamID"].ToString() + ");");
            //            img3.Attributes.Add("onclick", "AddSub(" + dr["NhomSanPhamID"].ToString() + ",'" +
            //                dr["TenNhomSanPham"].ToString() + "');");


            //            //tbc3.Controls.Add(img1);
            //            tbc4.Controls.Add(img2);
            //            tbc5.Controls.Add(img3);

            //            tbr.Cells.Add(tbc1);
            //            tbr.Cells.Add(tbc2);
            //            //tbr.Cells.Add(tbc3);
            //            tbr.Cells.Add(tbc4);
            //            tbr.Cells.Add(tbc5);

            //            ds.Tables[0].DefaultView.RowFilter = "NhomChaID=" + dr["NhomSanPhamID"].ToString();
            //            DataView dv = ds.Tables[0].DefaultView;

            //            if (dv.Count > 0)
            //            {
            //                img2.Disabled = true;
            //            }
            //            tblDanhMuc.Rows.Add(tbr);

            //            for (int i = 0; i < dv.Count; i++)
            //            {
            //                HtmlTableRow tvr = new HtmlTableRow();

            //                HtmlTableCell tvc1 = new HtmlTableCell();
            //                HtmlTableCell tvc2 = new HtmlTableCell();
            //                HtmlTableCell tvc3 = new HtmlTableCell();
            //                //HtmlTableCell tvc4 = new HtmlTableCell();
            //                HtmlTableCell tvc5 = new HtmlTableCell();
            //                //HtmlTableCell tvc6 = new HtmlTableCell();

            //                //HtmlImage imgv1 = new HtmlImage();
            //                HtmlImage imgv2 = new HtmlImage();

            //                //tvc4.Style.Add("padding", "0");
            //                //tvc4.Style.Add("margin", "0");
            //                tvc5.Style.Add("padding", "0");
            //                tvc5.Style.Add("margin", "0");
            //                //tvc4.Style.Add("cursor", "hand");
            //                tvc5.Style.Add("cursor", "hand");

            //                //HtmlImage img3 = new HtmlImage();
            //                //imgv1.Src = "../images/Edit.gif";
            //                imgv2.Src = "../images/Delete.gif";
            //                //imgv1.Attributes.Add("onclick", "EditSub(" + dr["NhomSanPhamID"].ToString() + ",'" +
            //                //dr["TenNhomSanPham"].ToString() + "'," + dv[i]["NhomSanPhamID"].ToString() + ");");
            //                imgv2.Attributes.Add("onclick", "Delete(" + dv[i]["CuaHangNhomSanPhamID"].ToString() + ");");
            //                //img3.Src = "../images/AddSub.gif";
            //                //imgv1.Alt = "Sửa danh mục con";
            //                imgv2.Alt = "Xóa danh mục con";


            //               // tvc4.Controls.Add(imgv1);
            //                tvc5.Controls.Add(imgv2);
            //                //tbc5.Controls.Add(img3);

            //                tvr.Cells.Add(tvc1);
            //                tvr.Cells.Add(tvc2);
            //                tvr.Cells.Add(tvc3);
            //                //tvr.Cells.Add(tvc4);
            //                tvr.Cells.Add(tvc5);
            //                //tvr.Cells.Add(tvc6);

            //                tvc3.InnerText = dv[i]["SapXep"].ToString() + "." + dv[i]["TenNhomSanPham"].ToString();
            //                tblDanhMuc.Rows.Add(tvr);
            //            }
            //        }
            //    }
            //}
            ////tblDanhMuc.Controls.Add(tbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    private void LoadDanhMucCon(int NhomChaID, int CuaHangID, int loaddm)
    {
        loaddm++;
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectNhomSanPhamByNhomChaAndCuaHangID(CuaHangID, NhomChaID);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //if (dr["NhomChaID"].ToString() == "" || dr["NhomChaID"].ToString() == "0")
                    //{
                    HtmlTableRow tbr = new HtmlTableRow();
                    tbr.Style.Add("padding-left", (loaddm * 10).ToString() + "px");
                    HtmlTableCell tbc1 = new HtmlTableCell();
                    HtmlTableCell tbc2 = new HtmlTableCell();
                    //image cells
                    //HtmlTableCell tbc3 = new HtmlTableCell();
                    HtmlTableCell tbc4 = new HtmlTableCell();
                    HtmlTableCell tbc5 = new HtmlTableCell();


                    //tbc1.Style.Add("width", "3%");                        
                    tbc2.InnerText = dr["SapXep"].ToString() + "." + dr["TenNhomSanPham"].ToString();
                    tbc2.ColSpan = 2;
                    //tbc3.Style.Add("width", "16px");
                    tbc4.Style.Add("width", "16px");
                    tbc5.Style.Add("width", "16px");
                    //tbc3.Style.Add("padding", "0");
                    //tbc3.Style.Add("margin", "0");
                    //tbc3.Style.Add("cursor", "hand");
                    tbc4.Style.Add("padding", "0");
                    tbc4.Style.Add("margin", "0");
                    tbc4.Style.Add("cursor", "hand");
                    tbc5.Style.Add("padding", "0");
                    tbc5.Style.Add("margin", "0");
                    tbc5.Style.Add("cursor", "hand");

                    //HtmlImage img1 = new HtmlImage();
                    HtmlImage img2 = new HtmlImage();
                    HtmlImage img3 = new HtmlImage();

                    //img1.Src = "../images/edit.gif";
                    img2.Src = "../images/delete.gif";
                    img3.Src = "../images/add.gif";
                    //img1.Alt = "Sửa danh mục cha";
                    img2.Alt = "Xóa danh mục cha";
                    img3.Alt = "Thêm danh mục con";
                    //img1.Attributes.Add("onclick", "Edit(" + dr["NhomSanPhamID"].ToString() + ");");
                    img2.Attributes.Add("onclick", "Delete(" + dr["NhomSanPhamID"].ToString() + ");");
                    img3.Attributes.Add("onclick", "AddSub(" + dr["NhomSanPhamID"].ToString() + ",'" +
                        dr["TenNhomSanPham"].ToString() + "');");


                    //tbc3.Controls.Add(img1);
                    tbc4.Controls.Add(img2);
                    tbc5.Controls.Add(img3);

                    tbr.Cells.Add(tbc1);
                    tbr.Cells.Add(tbc2);
                    //tbr.Cells.Add(tbc3);
                    tbr.Cells.Add(tbc4);
                    tbr.Cells.Add(tbc5);
                    tblDanhMuc.Rows.Add(tbr);

                    LoadDanhMucCon(int.Parse(dr["NhomSanPhamID"].ToString()), CuaHangID, loaddm);
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
    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("../message.aspx?msg=You haven't got a store yet");
        }
        else
        {            
            DataRow dr = ds.Tables[0].Rows[0];
            lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
            CuaHangID = int.Parse(dr["CuaHangID"].ToString());
        }
    }
    //private void LoadHoTro()
    //{
    //    CuaHang ch = new CuaHang();
    //    DataSet ds = ch.SelectByNguoiDungID(Common.NguoiDungID());
    //    if (ds.Tables[0].Rows.Count != 1)
    //    {
    //        Response.Redirect("../message.aspx?msg=You haven't got a store yet");
    //    }
    //    else
    //    {
    //        DataRow dr = ds.Tables[0].Rows[0];
    //        lblTenCuaHang2.Text = dr["TenCuaHang"].ToString();
    //        lblCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
    //        lblDiDong.Text= dr["DienThoaiDiDong"].ToString();
    //        CuaHangID = int.Parse(dr["CuaHangID"].ToString());
    //    }
    //}
    private void LoadQuangCao(int aid)
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByNguoiDungID(Common.NguoiDungID(), aid);
        HtmlImage img = new HtmlImage();
        switch (aid)
        {
            case 51:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao51.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"156\" height=\"116\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"156\" height=\"116\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao51.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                          + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"156px\" width=\"116px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }
                else
                {
                    spnQuangCao51.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"116px\" width=\"156px\" style=\"border:solid 1px #C9C3C3\"/>";
                }
                break;
            case 52:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao52.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"628\" height=\"116\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"628\" height=\"116\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao52.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                          + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"628px\" width=\"116px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }
                else
                {
                    spnQuangCao52.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"116px\" width=\"628px\" style=\"border:solid 1px #C9C3C3\"/>";
                }
                break;
            case 53:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao53.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"156\" height=\"116\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"156\" height=\"116\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao53.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                          + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"156px\" width=\"116px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }
                else
                {
                    spnQuangCao53.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"116px\" width=\"156px\" style=\"border:solid 1px #C9C3C3\"/>";
                }
                break;
            case 54:
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
                    {
                        spnQuangCao54.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"490\" height=\"249\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"490\" height=\"249\"></embed></object>";
                    }
                    else
                    {
                        spnQuangCao54.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                          + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"249px\" width=\"490px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                    }
                }
                else
                {
                    spnQuangCao54.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"249px\" width=\"490px\" style=\"border:solid 1px #C9C3C3\"/>";
                }
                break;
        }

    } 
    private void LoadGianHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectCuaHangAtViTriCuaHangByNguoiDungID(Common.NguoiDungID(), 51);
        int n = ds.Tables[0].Rows.Count;        
        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            string content = "";
            content += " <img src=\"." + ds.Tables[0].Rows[i]["Anh"].ToString() 
                + "\" width=\"110\" height=\"73\" hspace=\"4\" vspace=\"4\" style=\"border:#ece2a4 1px solid\" />";
            td.Text = content;
            td.HorizontalAlign = HorizontalAlign.Center;
            tr.Cells.Add(td);
            tblGianHang.Rows.Add(tr);
        }        
    }
    private void LoadHoTroTrucTuyen()
    {
        HoTroTrucTuyen ht = new HoTroTrucTuyen();
        DataSet ds = ht.SelectByCuaHangID(CuaHangID);

        string content = "";
        if (ds.Tables[0].Rows.Count > 0)
        {           
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                content += "<img border='0' style=\"cursor:hand\" src='../images/edit.gif' onclick='EditHTTT(" + dr["HoTroTrucTuyenID"].ToString()
                    + ");' ><img border='0' style=\"cursor:hand\" src='../images/delete.gif' onclick='DeleteHTTT(" + dr["HoTroTrucTuyenID"].ToString()
                    +");'><a href=\"ymsgr:sendIM?" + dr["YM"].ToString() 
                    + "\"><img src=\"http://opi.yahoo.com/online?u="
                    + dr["YM"].ToString() + "&t=1\" border=\"0\"></a>"+
                    dr["TenHoTro"].ToString() + "<br>";
            }
            spnHoTroTrucTuyen.InnerHtml = content;
        }
        //if (ds.Tables[0].Rows.Count != 1)
        //{
        //    Response.Redirect("../message.aspx?msg=You haven't got a store yet");
        //}
        //else
        //{
        //    DataRow dr = ds.Tables[0].Rows[0];
        //    lblTenCuaHang.Text = dr["TenCuaHang"].ToString();
        //    CuaHangID = int.Parse(dr["CuaHangID"].ToString());
        //}
    }
    protected void pnlThongTin_ContentRefresh(object sender, EventArgs e)
    {
        LoadCuaHang();
    }
    protected void pnlHoTro_ContentRefresh(object sender, EventArgs e)
    {
        LoadHoTroTrucTuyen();
    }
    protected void pnlQuangCao51_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(51);
    }
    protected void pnlQuangCao52_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(52);
    }
    protected void pnlQuangCao53_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(53);
    }
    protected void pnlQuangCao54_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao(54);
    }
    protected void pnlGianHang_ContentRefresh(object sender, EventArgs e)
    {
        LoadGianHang();
    }
    protected void pnlDanhMuc_ContentRefresh(object sender, EventArgs e)
    {
        LoadDanhMuc(0);
    }
}
