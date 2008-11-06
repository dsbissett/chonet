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
using System.IO;
using CHONET.Common;

public partial class Admin_AddProductTemplate : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Common.LoaiNguoiDungID() != 3)
        {           
            Response.Redirect("../message.aspx?msg=Access denied");
        }

        lblAnhChinhErr.Text = "";
        lblAnhPhuErr.Text = "";
        if ((Request.QueryString["id"] == null))
            {
                //Common.ProdAction = "ADD";
                if (ViewState["ID"] == null)
                {
                    ViewState["Action"] = "ADD";
                    wdcBatDauKM.Value = DateTime.Now;
                    wdcKetThucKM.Value = DateTime.Now;
                }
                else
                {
                    ViewState["Action"] = "EDIT";
                }
                
            }
            else
            {
                //Common.ProdAction = "EDIT";                
                ViewState["Action"] = "EDIT";
                ViewState["ID"] = int.Parse(Request.QueryString["id"]);                
            }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["state"] != null)
            {
                ViewState["Save"] = "TRUE";
            }
            else
            {
                ViewState["Save"] = "FALSE";
            }
           
            chkKhuyenMai.Attributes.Add("onclick", "return chkKhuyenMai_onclick(this);");
            chkGiamGia.Attributes.Add("onclick", "return chkGiamGia_onclick(this);");
            btnUpLoad.Attributes.Add("onclick", "return CheckSaved();");            
            
            wdcBatDauKM.Value = DateTime.Now;
            wdcKetThucKM.Value = DateTime.Now;            

            //btnLuuAndDong.Attributes.Add("onclick", "return CheckSaved();");
            LoadDropDownDaTa();
            if (Request.QueryString["id"] != null)
            {                                
                LoadData();
            }            
        }
    }

    private void LoadDropDownDaTa()
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectAll();

            int n = ddlNhomSanPham.SelectedIndex;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["NhomChaID"].ToString() == "0")
                {
                    ListItem item = new ListItem("+ " + ds.Tables[0].Rows[i]["TenNhomSanPham"].ToString(), ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString());                    
                    ddlNhomSanPham.Items.Add(item);
                    //DataSet subds = nhomsanpham.SelectNhomSanPhamByNhomChaID(int.Parse(ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString()));
                    ds.Tables[0].DefaultView.RowFilter = "NhomChaID = " + ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString();
                    DataView dv = ds.Tables[0].DefaultView;

                    for (int j = 0; j < dv.Count; j++)
                    {
                        ListItem subitem = new ListItem("+.... " + dv[j]["TenNhomSanPham"].ToString(),
                            dv[j]["NhomSanPhamID"].ToString());
                        ddlNhomSanPham.Items.Add(subitem);
                    }
                }
            }


            HangSanXuat hangsanxuat = new HangSanXuat();
            DataSet dsHangSanXuat = hangsanxuat.SelectAll();
            DataTable dtHangSanXuat = dsHangSanXuat.Tables[0];

            ddlHangSanXuat.DataSource = dtHangSanXuat;
            ddlHangSanXuat.DataTextField = "TenHangSanXuat";
            ddlHangSanXuat.DataValueField = "HangSanXuatID";
            ddlHangSanXuat.DataBind();


            KhuVuc khuvuc = new KhuVuc();
            DataSet dsKhuVuc = khuvuc.SelectAll();
            DataTable dtKhuVuc = dsKhuVuc.Tables[0];

            ddlKhuVuc.DataSource = dtKhuVuc;
            ddlKhuVuc.DataTextField = "TenKhuVuc";
            ddlKhuVuc.DataValueField = "KhuVucID";
            ddlKhuVuc.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadData()
    {
        try
        {
            SanPhamMau sanpham = new SanPhamMau();
            DataSet ds = sanpham.SelectByID(int.Parse(ViewState["ID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                
                txtTenSanPham.Text = dr["TenSanPham"].ToString();
                //txtMaSoSanPham.Text = dr["MaSoSanPham"].ToString();
                txtGiaSanPham.Text = dr["GiaSanPham"].ToString();
                ddlNhomSanPham.SelectedValue = dr["NhomSanPhamID"].ToString();
                ddlHangSanXuat.SelectedValue = dr["HangSanXuatID"].ToString();
                ddlKhuVuc.SelectedValue = dr["KhuVucID"].ToString();
                chkKhuyenMai.Checked = dr["KhuyenMai"].ToString() != "" ? bool.Parse(dr["KhuyenMai"].ToString()) : false;
                chkGiamGia.Checked = dr["GiamGia"].ToString() != "" ? bool.Parse(dr["GiamGia"].ToString()) : false;
                //txtMoTaSanPham.Text = dr["MoTaSanPham"].ToString();
                wheMoTaSanPham.Text = dr["MoTaSanPham"].ToString();
                imgAnhChinh.ImageUrl = "." + dr["AnhSanPham"].ToString();
                wheThongTinSanPham.Text = dr["ThongTinSanPham"].ToString();

                if (chkGiamGia.Checked == true)
                {
                    cvGiaMoi.Enabled = true;
                    txtGiaMoi.Enabled = true;
                    txtGiaMoi.Text = dr["GiaKhuyenMai"].ToString();
                }
                else
                {
                    txtGiaMoi.Enabled = false;
                }

                //txtDonViTienTe.Text = dr["DonViTienTe"].ToString();
                //txtThongTinSanPham.Text = dr["ThongTinSanPham"].ToString();                

                LoadAnhPhu();
                if (chkKhuyenMai.Checked == true)
                {                                        
                    wdcBatDauKM.Enabled = true;
                    wdcBatDauKM.Value = DateTime.Parse(dr["BatDauKhuyenMai"].ToString());
                    wdcKetThucKM.Enabled = true;
                    wdcKetThucKM.Value = DateTime.Parse(dr["KetThucKhuyenMai"].ToString());
                    txtMoTaKhuyenMai.Enabled = true;
                    txtMoTaKhuyenMai.Text = dr["MoTaKhuyenMai"].ToString();                    
                    cvKhuyenMai.Enabled = true;
                }
                else
                {
                    txtMoTaKhuyenMai.Enabled = false;
                    wdcBatDauKM.Enabled = false;
                    wdcKetThucKM.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }

    public void LoadAnhPhu()
    {
        try
        {
            // Load Anh Phu
            Anh anhphu = new Anh();
            DataSet dsAnh = anhphu.SelectBySanPhamMauID(int.Parse(ViewState["ID"].ToString()));
            if (dsAnh.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drAnh in dsAnh.Tables[0].Rows)
                {
                    HtmlImage img = new HtmlImage();
                    img.Src = "." + drAnh["DuongDan"].ToString();
                    img.Height = 50;
                    img.Width = 50;
                    img.ID = "img" + drAnh["AnhID"].ToString();
                    img.Attributes.Add("onclick", "return XoaAnhPhu('" + drAnh["AnhID"].ToString() + "', '" + img.Src + "', this.ID, this);");
                    pnlAnhPhu.Controls.Add(img);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }
   
    private bool LuuSanPham()
    {
        SanPhamMau sanpham = new SanPhamMau();
        try
        {
            string relativePath = "";
            DateTime? NgayBDKM = null;
            DateTime? NgayKTKM = null;
            string strMoTaKhuyenMai = null;
            string path = Server.MapPath("../Upload/ProdImages");
            decimal? giamoi = null;
            string MaSoSanPham = null;
            
            if (chkKhuyenMai.Checked == true)
            {
                NgayBDKM = DateTime.Parse(wdcBatDauKM.Value.ToString());
                NgayKTKM = DateTime.Parse(wdcKetThucKM.Value.ToString());
                txtMoTaKhuyenMai.Enabled = true;
                strMoTaKhuyenMai = txtMoTaKhuyenMai.Text;
            }

            if (chkGiamGia.Checked == true)
            {
                txtGiaMoi.Enabled = true;
                cvGiaMoi.Enabled = true;
                giamoi = decimal.Parse(txtGiaMoi.Text);
            }

            if (fileAnhChinh.PostedFile.FileName != "")
            {
                try
                {
                    if (fileAnhChinh.PostedFile.ContentLength <= 100000)
                    {
                        string randomString = "";
                        path += "\\" + Common.NguoiDungID().ToString();
                        relativePath = "./Upload/ProdImages" + "/" + Common.NguoiDungID().ToString() + "/";
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
                        //fileAnhChinh.PostedFile.SaveAs(absolutePath);
                        Common.ResizeFromStream(absolutePath, 320, fileAnhChinh.PostedFile.InputStream);
                        relativePath += randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                        if (ViewState["Action"].ToString() == "ADD")
                        {
                            ViewState["ID"] = sanpham.InsertFields(txtTenSanPham.Text, MaSoSanPham, decimal.Parse(txtGiaSanPham.Text), "VNĐ", wheMoTaSanPham.Text,
                                wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue), int.Parse(ddlHangSanXuat.SelectedValue),
                                Common.NguoiDungID(), relativePath, chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                null, int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked, null, DateTime.Now, null, null,
                                null, 0, null, null, null, null);
                        }
                        else if (ViewState["Action"].ToString() == "EDIT")
                        {
                            sanpham.UpdateFields(int.Parse(ViewState["ID"].ToString()), txtTenSanPham.Text, null, decimal.Parse(txtGiaSanPham.Text), null, wheMoTaSanPham.Text,
                                wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue), int.Parse(ddlHangSanXuat.SelectedValue),
                                Common.NguoiDungID(), relativePath, chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                null, int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked, null, DateTime.Now, null, null,
                                null, null, null, null, null, null);
                        }

                        //ViewState["Action"] = "EDIT";
                        //ViewState["Save"] = "TRUE";
                        //string randomString = "";
                        //int pos = fileAnhChinh.PostedFile.FileName.LastIndexOf('\\');
                        //LoadAnhPhu();

                        //if (!Directory.Exists(path))
                        //{
                        //    Directory.CreateDirectory(path);
                        //}

                        //string absolutePath = path + "\\" + fileAnhChinh.FileName;
                        //if (File.Exists(absolutePath))
                        //{
                        //    randomString = DateTime.Now.Ticks.ToString() + "_";
                        //    absolutePath = path + "\\" + fileAnhChinh.FileName;
                        //}
                        //fileAnhChinh.PostedFile.SaveAs(absolutePath);
                        ////relativePath = relativePath;
                        imgAnhChinh.ImageUrl = "." + relativePath;                        
                    }
                    else
                    {
                        lblAnhChinhErr.Text = "Kích cỡ ảnh quá lớn!";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("../message.aspx?msg=" + ex.Message.Replace("\r\n", ""), false);
                }
            }
            else
            {
                if (ViewState["Action"].ToString() == "ADD")
                {
                    ViewState["ID"] = sanpham.InsertFields(txtTenSanPham.Text, MaSoSanPham, decimal.Parse(txtGiaSanPham.Text), "VNĐ", wheMoTaSanPham.Text,
                                wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue), int.Parse(ddlHangSanXuat.SelectedValue),
                                Common.NguoiDungID(), null, chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                null, int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked, null, DateTime.Now, null, null,
                                null, 0, null, null, null, null);
                }
                else if (ViewState["Action"].ToString() == "EDIT")
                {
                    sanpham.UpdateFields(int.Parse(ViewState["ID"].ToString()), txtTenSanPham.Text, null, decimal.Parse(txtGiaSanPham.Text), null, wheMoTaSanPham.Text,
                                wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue), int.Parse(ddlHangSanXuat.SelectedValue),
                                Common.NguoiDungID(), null, chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                null, int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked, null, DateTime.Now, null, null,
                                null, null, null, null, null, null);
                }
                LoadAnhPhu();                
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        return true;
    }
    
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if (LuuSanPham() == true)
        {
            ViewState["Action"] = "EDIT";
            ViewState["Save"] = "TRUE";                
            string strScript = "<script language='javascript'>window.parent.SetTitle('Sửa thông tin sản phẩm');</script>";
            ClientScript.RegisterStartupScript(".".GetType(), "settitle", strScript);
        }
        //btnThemMoi.Attributes.Add("onclick", "window.parent.SetTitle('Thêm sản phẩm');");
        //btnLuu.Attributes.Add("onclick", "window.parent.SetTitle('Sửa thông tin sản phẩm');");
    }
   
    protected void btnLuuAndDong_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (LuuSanPham()==true)
            {
                string strScript = "<script language='JavaScript'>window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }

    protected void btnLuuAndThem_ServerClick(object sender, EventArgs e)
    {
        try
        {
            //string strScript = "<script language='JavaScript'>alert('a');</script> ";
            //ClientScript.RegisterStartupScript(".".GetType(), "addproduct", strScript);
            //btnLuu_ServerClick(sender, e);   
            if (LuuSanPham() == true)
            {
                string strScript = "<script language='javascript'>window.parent.SetTitle('Thêm sản phẩm');</script>";
                ClientScript.RegisterStartupScript(".".GetType(), "settitle", strScript);
                Response.Redirect("AddProduct.aspx?state=true", false);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }    
    
    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        if (fileAnhPhu.PostedFile.FileName != "")
        {
            string relativePath = "";
            string path = Server.MapPath("../Upload/ProdImages");
            //path += "\\" + Common.NguoiDungID.ToString();
            try
            {
                if (fileAnhPhu.PostedFile.ContentLength <= 100000)
                {
                    string randomString = "";
                    path += "\\" + Common.NguoiDungID().ToString();
                    relativePath = "./Upload/ProdImages" + "/" + Common.NguoiDungID().ToString() + "/";
                    int pos = fileAnhPhu.PostedFile.FileName.LastIndexOf('\\');
                    string absolutePath = path + "\\" + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (File.Exists(absolutePath))
                    {
                        randomString = DateTime.Now.Ticks.ToString() + "_";
                        absolutePath = path + "\\" + randomString + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);
                    }
                    //fileAnhPhu.PostedFile.SaveAs(absolutePath);
                    Common.ResizeFromStream(absolutePath, 320, fileAnhPhu.PostedFile.InputStream);
                    relativePath += randomString + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);

                    try
                    {
                        Anh anhphu = new Anh();
                        anhphu.InsertFields(null, int.Parse(ViewState["ID"].ToString()), relativePath, null, null, null);

                        LoadAnhPhu();                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
                else
                {
                    lblAnhPhuErr.Text = "Kích cỡ ảnh quá lớn!";
                    LoadAnhPhu(); 
                    return;
                    //Response.Redirect("../message.aspx?msg=File size is too big!", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../message.aspx?msg=" + ex.Message.Replace("\r\n", ""), false);
            }
        }
    }
   
    protected void pnlAnhPhu_ContentRefresh(object sender, EventArgs e)
    {
        LoadAnhPhu();
    }
   
}
