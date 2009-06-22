using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class AddThisProduct : Page
{
    public bool blGiamGia;
    public bool blKhuyenMai;
    private int intProductID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 2)
        {
            Response.Redirect("./message.aspx?msg=Access denied");
        }


        //GetKhuyenMaiGiamGia();
        if (Request.QueryString["pid"] != null)
        {
            intProductID = int.Parse(Request.QueryString["pid"]);
        }

        if (!Page.IsPostBack)
        {
            chkKhuyenMai.Attributes.Add("onclick", "return chkKhuyenMai_onclick(this);");
            chkGiamGia.Attributes.Add("onclick", "return chkGiamGia_onclick(this);");

            wdcBatDauKM.Value = DateTime.Now;
            wdcKetThucKM.Value = DateTime.Now;

            ////btnLuuAndDong.Attributes.Add("onclick", "return CheckSaved();");
            LoadDropDownDaTa();
            LoadData();
        }
    }

    private void LoadData()
    {
        try
        {
            SanPham sp = new SanPham();
            DataSet ds = sp.SelectBySanPhamID(intProductID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                txtGiaSanPham.Text = dr["GiaSanPham"].ToString();
                ViewState["CuaHangID"] = dr["CuaHangID"].ToString();
                ViewState["NhomSanPhamID"] = dr["NhomSanPhamID"].ToString();
                ddlKhuVuc.SelectedValue = dr["KhuVucID"].ToString();
                chkKhuyenMai.Checked = dr["KhuyenMai"].ToString() != "" ? bool.Parse(dr["KhuyenMai"].ToString()) : false;
                chkGiamGia.Checked = dr["GiamGia"].ToString() != "" ? bool.Parse(dr["GiamGia"].ToString()) : false;
                wheThongTinSanPham.Text = dr["ThongTinSanPham"].ToString();
                txtTenPhu.Text = dr["TenSanPhamPhu"].ToString();
                txtTenSanPham.Text = dr["TenSanPham"].ToString();

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
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }

    private void GetKhuyenMaiGiamGia()
    {
        int intKhuyenMai = 0;
        int intGiamGia = 0;
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamByNguoiDungID(Common.NguoiDungID());
        ds.Tables[0].DefaultView.RowFilter = "KhuyenMai=1";
        intKhuyenMai = ds.Tables[0].DefaultView.Count;
        if (intKhuyenMai >= int.Parse(ConfigurationManager.AppSettings["KhuyenMai"]))
            blKhuyenMai = true;

        ds.Tables[0].DefaultView.RowFilter = "GiamGia=1";
        intGiamGia = ds.Tables[0].DefaultView.Count;
        if (intGiamGia >= int.Parse(ConfigurationManager.AppSettings["GiamGia"]))
            blGiamGia = true;
    }

    private void LoadDropDownDaTa()
    {
        try
        {
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

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime? NgayBDKM = null;
            DateTime? NgayKTKM = null;
            string strMoTaKhuyenMai = null;
            string path = Server.MapPath("../Upload/ProdImages");
            decimal? giamoi = null;
            string MaSoSanPham = null;

            int NhomSanPhamID = int.Parse("0" + ViewState["NhomSanPhamID"]);

            int CuaHangID = int.Parse("0" + ViewState["CuaHangID"]);
            if (checkNhomSanPham(NhomSanPhamID, CuaHangID) == false)
            {
                AddNhomSanPhamToCuaHang(NhomSanPhamID, CuaHangID);
            }

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


            SanPham sp = new SanPham();
            sp.CopyAndUpdateFields(intProductID, null, MaSoSanPham, decimal.Parse(txtGiaSanPham.Text),
                                   null, null, wheThongTinSanPham.Text, null, null, Common.NguoiDungID(), null,
                                   chkKhuyenMai.Checked,
                                   strMoTaKhuyenMai, giamoi, NgayBDKM, NgayKTKM, null,
                                   int.Parse(ddlKhuVuc.SelectedValue), null, null, chkGiamGia.Checked, null,
                                   DateTime.Now, null, null, null, null, null, null, null, null, null, DateTime.Now,
                                   txtTenPhu.Text);

            string strScript = "<script language='JavaScript'>this.close();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearData();
        LoadData();
    }

    private void ClearData()
    {
        txtGiaMoi.Text = "";
        txtGiaSanPham.Text = "";
        ddlKhuVuc.SelectedIndex = 0;
        chkGiamGia.Checked = false;
        chkKhuyenMai.Checked = false;
        wdcBatDauKM.Value = DateTime.Now;
        wdcKetThucKM.Value = DateTime.Now;
        txtMoTaKhuyenMai.Text = "";
        wheThongTinSanPham.Text = "";
    }

    private string GenerateMaSoSanPham()
    {
        string maso = DateTime.Now.ToString("yyMMdd");
        int intCount = 0;
        SanPham sanpham = new SanPham();
        intCount = sanpham.CountSanPhamByMaSo(maso);
        maso = "CN" + maso + string.Format("{0:D4}", intCount + 1);
        return maso;
    }

    private bool checkNhomSanPham(int NhomSanPhamID, int CuaHangID)
    {
        CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
        DataSet ds = chnsp.SelectByNhomSanPhamCuaHangID(CuaHangID, NhomSanPhamID);

        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    private void AddNhomSanPhamToCuaHang(int NhomSanPhamID, int CuaHangID)
    {
        CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
        DataSet dschnsp = chnsp.SelectByNhomSanPhamCuaHangID(CuaHangID, NhomSanPhamID);

        if (dschnsp.Tables[0].Rows.Count <= 0)
        {
            chnsp.Insert(CuaHangID, NhomSanPhamID, "");

            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectByID(NhomSanPhamID);
            int NhomChaID = int.Parse(ds.Tables[0].Rows[0]["NhomChaID"].ToString());
            if (NhomChaID != 0)
                AddNhomSanPhamToCuaHang(NhomChaID, CuaHangID);
        }
    }
}