using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddProductTemplate : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 3)
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
        txtTenSanPham.Focus();
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
            //ddlNhomSanPham.Attributes.Add("onchange", "ddl_change();");
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
            //btnLuuAndDong.Attributes.Add("onclick", "return CheckNhomSanPham();");
            //btnLuu.Attributes.Add("onclick", "return CheckNhomSanPham();");
            //btnThemMoi.Attributes.Add("onclick", "return CheckNhomSanPham();");
            wdcBatDauKM.Value = DateTime.Now;
            wdcKetThucKM.Value = DateTime.Now;

            //btnLuuAndDong.Attributes.Add("onclick", "return CheckSaved();");
            LoadDanhMucCon(0, 0);
            LoadDropDownDaTa();
            LoadThuocTinhCha();
            LoadThuocTinh();

            ServerValidateEventArgs ServerValidateE = new
                ServerValidateEventArgs("cvNhomSanPham",
                                        false);
            cvNhomSanPham_ServerValidate(ddlNhomSanPham, ServerValidateE);

            if (Request.QueryString["id"] != null)
            {
                LoadData();
            }
        }
    }

    //protected override void OnLoad(EventArgs e)
    //{
    //    base.OnLoad(e);

    //}

    private void LoadDanhMucCon(int NhomChaID, int loaddm)
    {
        NhomSanPham nhomsanpham = new NhomSanPham();
        DataSet ds;
        string cachNsp = "nsp" + NhomChaID;
        if (Cache[cachNsp] == null)
        {
            ds = nhomsanpham.SelectNhomSanPhamByNhomChaID(NhomChaID);
            Cache.Insert(cachNsp, ds);
        }
        else
        {
            ds = (DataSet) Cache[cachNsp];
        }

        if (NhomChaID == 0)
            loaddm = 0;
        string indent = "";
        switch (loaddm)
        {
            case 0:
                indent = "+ ";
                break;
            case 1:
                indent = "+...";
                break;
            case 2:
                indent = "+.....";
                break;
            case 3:
                indent = "+.......";
                break;
            case 4:
                indent = "+.........";
                break;
        }

        int n = ddlNhomSanPham.SelectedIndex;
        loaddm++;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem item = new ListItem(indent + ds.Tables[0].Rows[i]["TenNhomSanPham"],
                                         ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString());
            ddlNhomSanPham.Items.Add(item);
            //item.Enabled = false;
            LoadDanhMucCon(int.Parse(ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString()), loaddm);
            //item.Enabled = true;
        }
    }

    private void LoadDropDownDaTa()
    {
        try
        {
            HangSanXuat hangsanxuat = new HangSanXuat();
            DataSet dsHangSanXuat = hangsanxuat.SelectAll();
            if (Cache["hsx"] == null)
            {
                dsHangSanXuat = hangsanxuat.SelectAll();
                Cache.Insert("hsx", dsHangSanXuat);
            }
            else
            {
                dsHangSanXuat = (DataSet) Cache["hsx"];
            }
            DataTable dtHangSanXuat = dsHangSanXuat.Tables[0];

            ddlHangSanXuat.DataSource = dtHangSanXuat;
            ddlHangSanXuat.DataTextField = "TenHangSanXuat";
            ddlHangSanXuat.DataValueField = "HangSanXuatID";
            ddlHangSanXuat.DataBind();


            KhuVuc khuvuc = new KhuVuc();
            DataSet dsKhuVuc;

            if (Cache["kv"] == null)
            {
                dsKhuVuc = khuvuc.SelectAll();
                Cache.Insert("kv", dsKhuVuc);
            }
            else
            {
                dsKhuVuc = (DataSet) Cache["kv"];
            }

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
                imgAnhChinh.ImageUrl = "." + dr["AnhSanPham"];
                wheThongTinSanPham.Text = dr["ThongTinSanPham"].ToString();

                if (chkGiamGia.Checked)
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
                LoadThuocTinhCha();
                //LoadThuocTinh();
                LoadThuocTinhSanPham(int.Parse(ViewState["ID"].ToString()));
                if (chkKhuyenMai.Checked)
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
                    img.Src = "." + drAnh["DuongDan"];
                    img.Height = 50;
                    img.Width = 50;
                    img.ID = "img" + drAnh["AnhID"];
                    img.Attributes.Add("onclick",
                                       "return XoaAnhPhu('" + drAnh["AnhID"] + "', '" + img.Src + "', this.ID, this);");
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
        if (Page.IsValid)
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

                if (chkKhuyenMai.Checked)
                {
                    NgayBDKM = DateTime.Parse(wdcBatDauKM.Value.ToString());
                    NgayKTKM = DateTime.Parse(wdcKetThucKM.Value.ToString());
                    txtMoTaKhuyenMai.Enabled = true;
                    strMoTaKhuyenMai = txtMoTaKhuyenMai.Text;
                }

                if (chkGiamGia.Checked)
                {
                    txtGiaMoi.Enabled = true;
                    cvGiaMoi.Enabled = true;
                    giamoi = decimal.Parse(txtGiaMoi.Text);
                }

                if (fileAnhChinh.PostedFile.FileName != "")
                {
                    try
                    {
                        //if (fileAnhChinh.PostedFile.ContentLength <= 100000)
                        //{
                        string randomString = "";
                        path += "\\" + Common.NguoiDungID();
                        relativePath = "./Upload/ProdImages" + "/" + Common.NguoiDungID() + "/";
                        int pos = fileAnhChinh.PostedFile.FileName.LastIndexOf('\\');
                        string absolutePath = path + "\\" + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        if (File.Exists(absolutePath))
                        {
                            randomString = DateTime.Now.Ticks + "_";
                            absolutePath = path + "\\" + randomString +
                                           fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);
                        }
                        //fileAnhChinh.PostedFile.SaveAs(absolutePath);
                        Common.ResizeFromStream(absolutePath, 320, fileAnhChinh.PostedFile.InputStream);
                        relativePath += randomString + fileAnhChinh.PostedFile.FileName.Remove(0, pos + 1);

                        if (ViewState["Action"].ToString() == "ADD")
                        {
                            ViewState["ID"] = sanpham.InsertFields(txtTenSanPham.Text, MaSoSanPham,
                                                                   decimal.Parse(txtGiaSanPham.Text), "VNĐ",
                                                                   wheMoTaSanPham.Text,
                                                                   wheThongTinSanPham.Text,
                                                                   int.Parse(ddlNhomSanPham.SelectedValue),
                                                                   int.Parse(ddlHangSanXuat.SelectedValue),
                                                                   Common.NguoiDungID(), relativePath,
                                                                   chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi,
                                                                   NgayBDKM, NgayKTKM,
                                                                   null, int.Parse(ddlKhuVuc.SelectedValue), null, null,
                                                                   chkGiamGia.Checked, null, DateTime.Now, null, null,
                                                                   null, 0, null, null, null, null);
                        }
                        else if (ViewState["Action"].ToString() == "EDIT")
                        {
                            sanpham.UpdateFields(int.Parse(ViewState["ID"].ToString()), txtTenSanPham.Text, null,
                                                 decimal.Parse(txtGiaSanPham.Text), null, wheMoTaSanPham.Text,
                                                 wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue),
                                                 int.Parse(ddlHangSanXuat.SelectedValue),
                                                 Common.NguoiDungID(), relativePath, chkKhuyenMai.Checked,
                                                 strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                                 null, int.Parse(ddlKhuVuc.SelectedValue), null, null,
                                                 chkGiamGia.Checked, null, DateTime.Now, null, null,
                                                 null, null, null, null, null, null);
                        }

                        imgAnhChinh.ImageUrl = "." + relativePath;
                        //}
                        //else
                        //{
                        //    lblAnhChinhErr.Text = "Kích cỡ ảnh quá lớn!";
                        //    return false;
                        //}
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
                        ViewState["ID"] = sanpham.InsertFields(txtTenSanPham.Text, MaSoSanPham,
                                                               decimal.Parse(txtGiaSanPham.Text), "VNĐ",
                                                               wheMoTaSanPham.Text,
                                                               wheThongTinSanPham.Text,
                                                               int.Parse(ddlNhomSanPham.SelectedValue),
                                                               int.Parse(ddlHangSanXuat.SelectedValue),
                                                               Common.NguoiDungID(), null, chkKhuyenMai.Checked,
                                                               strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM,
                                                               null, int.Parse(ddlKhuVuc.SelectedValue), null, null,
                                                               chkGiamGia.Checked, null, DateTime.Now, null, null,
                                                               null, 0, null, null, null, null);
                    }
                    else if (ViewState["Action"].ToString() == "EDIT")
                    {
                        sanpham.UpdateFields(int.Parse(ViewState["ID"].ToString()), txtTenSanPham.Text, null,
                                             decimal.Parse(txtGiaSanPham.Text), null, wheMoTaSanPham.Text,
                                             wheThongTinSanPham.Text, int.Parse(ddlNhomSanPham.SelectedValue),
                                             int.Parse(ddlHangSanXuat.SelectedValue),
                                             Common.NguoiDungID(), null, chkKhuyenMai.Checked, strMoTaKhuyenMai, giamoi,
                                             NgayBDKM, NgayKTKM,
                                             null, int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked,
                                             null, DateTime.Now, null, null,
                                             null, null, null, null, null, null);
                    }
                }

                LuuThuocTinhSanPham();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if (LuuSanPham())
        {
            LoadAnhPhu();
            ViewState["Action"] = "EDIT";
            ViewState["Save"] = "TRUE";
            string strScript =
                "<script language='javascript'>window.parent.SetTitle('Sửa thông tin sản phẩm');</script>";
            ClientScript.RegisterStartupScript(".".GetType(), "settitle", strScript);
        }
        //btnThemMoi.Attributes.Add("onclick", "window.parent.SetTitle('Thêm sản phẩm');");
        //btnLuu.Attributes.Add("onclick", "window.parent.SetTitle('Sửa thông tin sản phẩm');");
    }

    protected void btnLuuAndDong_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (LuuSanPham())
            {
                string strScript = "<script language='JavaScript'>window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
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
            if (LuuSanPham())
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
                //if (fileAnhPhu.PostedFile.ContentLength <= 100000)
                //{
                string randomString = "";
                path += "\\" + Common.NguoiDungID();
                relativePath = "./Upload/ProdImages" + "/" + Common.NguoiDungID() + "/";
                int pos = fileAnhPhu.PostedFile.FileName.LastIndexOf('\\');
                string absolutePath = path + "\\" + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(absolutePath))
                {
                    randomString = DateTime.Now.Ticks + "_";
                    absolutePath = path + "\\" + randomString + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);
                }
                //fileAnhPhu.PostedFile.SaveAs(absolutePath);
                Common.ResizeFromStream(absolutePath, 320, fileAnhPhu.PostedFile.InputStream);
                relativePath += randomString + fileAnhPhu.PostedFile.FileName.Remove(0, pos + 1);

                try
                {
                    Anh anhphu = new Anh();
                    anhphu.InsertFields(null, relativePath, null, null, null, int.Parse(ViewState["ID"].ToString()));

                    LoadAnhPhu();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                //}
                //else
                //{
                //lblAnhPhuErr.Text = "Kích cỡ ảnh quá lớn!";
                //LoadAnhPhu(); 
                //return;
                //Response.Redirect("../message.aspx?msg=File size is too big!", false);
                //}
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

    private void LoadThuocTinhSanPham(int sanphammauid)
    {
        int thuoctinhid = 0;
        int thuoctinhchaid = 0;
        ThuocTinhSanPham ttsp = new ThuocTinhSanPham();
        DataSet ds = ttsp.SelectBySanPhamMauID(sanphammauid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            thuoctinhid = int.Parse(ds.Tables[0].Rows[0]["ThuocTinhID"].ToString());
            ThuocTinh tt = new ThuocTinh();
            DataSet dstt = tt.SelectByID(thuoctinhid);
            if (dstt.Tables[0].Rows.Count > 0)
            {
                thuoctinhchaid = int.Parse(dstt.Tables[0].Rows[0]["thuoctinhchaid"].ToString());
            }
        }
        ddlThuocChinhCha.SelectedValue = thuoctinhchaid.ToString();
        LoadThuocTinh();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            foreach (ListItem li in lbiThuocTinh.Items)
            {
                if (li.Value == dr["ThuocTinhID"].ToString())
                    li.Selected = true;
            }
        }
    }

    private void LoadThuocTinh()
    {
        lbiThuocTinh.Items.Clear();
        if (ddlThuocChinhCha.Items.Count > 0)
        {
            ThuocTinh tt = new ThuocTinh();
            DataSet ds = tt.SelectAllThuocTinhByThuocTinhChaAndNhomSanPham(int.Parse(ddlNhomSanPham.SelectedValue),
                                                                           int.Parse(ddlThuocChinhCha.SelectedValue));
            lbiThuocTinh.DataSource = ds.Tables[0];
            lbiThuocTinh.DataTextField = "TenThuocTinh";
            lbiThuocTinh.DataValueField = "ThuocTinhID";
            lbiThuocTinh.DataBind();
        }
    }

    private void LuuThuocTinhSanPham()
    {
        ThuocTinhSanPham ttsp = new ThuocTinhSanPham();
        int SanPhamMauID = int.Parse(ViewState["ID"].ToString());
        ttsp.DeleteBySanPhamMauID(SanPhamMauID);
        foreach (ListItem li in lbiThuocTinh.Items)
        {
            if (li.Selected)
            {
                ttsp.InsertFields(null, int.Parse(li.Value), SanPhamMauID);
            }
        }
    }

    protected void ddlNhomSanPham_SelectedIndexChanged(object sender, EventArgs e)
    {
        ServerValidateEventArgs ServerValidateE = new
            ServerValidateEventArgs("cvNhomSanPham",
                                    false);
        cvNhomSanPham_ServerValidate(cvNhomSanPham, ServerValidateE);
        LoadThuocTinhCha();
        LoadThuocTinh();
    }

    private bool CheckNhomCon()
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(
            int.Parse("0" + ddlNhomSanPham.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
            return false;
        else
            return true;
    }

    private void LoadThuocTinhCha()
    {
        ThuocTinh tt = new ThuocTinh();
        DataSet ds = tt.SelectAllThuocTinhByThuocTinhChaAndNhomSanPham(int.Parse(ddlNhomSanPham.SelectedValue), 0);
        ddlThuocChinhCha.DataSource = ds.Tables[0];
        ddlThuocChinhCha.DataTextField = "TenThuocTinh";
        ddlThuocChinhCha.DataValueField = "ThuocTinhID";
        ddlThuocChinhCha.DataBind();
    }

    protected void ddlThuocChinhCha_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadThuocTinh();
    }

    protected void cvNhomSanPham_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (CheckNhomCon())
        {
            cvNhomSanPham.IsValid = true;
            args.IsValid = true;
            //Page.IsValid = true;            
        }
        else
        {
            cvNhomSanPham.IsValid = false;
            args.IsValid = false;
            ddlNhomSanPham.Focus();

            //Page.IsValid = false;
        }
    }
}