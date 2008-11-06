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
using System.IO;
using CHONET.DataAccessLayer.Web;
using CHONET.Common;

public partial class Admin_Delete : System.Web.UI.Page
{
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3)
        {
            id = int.Parse("0" + Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    ViewState["TYPE"] = Request.QueryString["type"].ToString();
                    switch (ViewState["TYPE"].ToString().ToLower())
                    {
                        case "hotrotructuyen":
                            lblMessage.Text = "Bạn có muốn xóa hỗ trợ này?";
                            break;
                        case "vitrisanpham":
                            lblMessage.Text = "Bạn có muốn xóa sản phẩm này?";
                            break;
                        case "nhomsanpham":
                            lblMessage.Text = "Bạn có muốn xóa danh mục này?";
                            break;
                        case "cuahangnhomsanpham":
                            lblMessage.Text = "Bạn có muốn xóa danh mục này?";
                            break;
                        case "nguoidung":
                            lblMessage.Text = "Bạn có muốn xóa người dùng này?";
                            break;
                        case "quangcao":
                            lblMessage.Text = "Bạn có muốn xóa quảng cáo này?";
                            break;
                        case "sanpham":
                            lblMessage.Text = "Bạn có muốn xóa sản phẩm này?";
                            break;
                        case "sanphammau":
                            lblMessage.Text = "Bạn có muốn xóa sản phẩm mẫu này?";
                            break;
                        case "hangsanxuat":
                            lblMessage.Text = "Bạn có muốn xóa hãng sản xuất này?";
                            break;
                        case "khuvuc":
                            lblMessage.Text = "Bạn có muốn xóa khu vực này?";
                            break;
                        case "nhanxetsanpham":
                            lblMessage.Text = "Bạn có muốn xóa nhận xét này?";
                            break;
                        case "hoidapsanpham":
                            lblMessage.Text = "Bạn có muốn xóa hỏi đáp này?";
                            break;
                        case "anhsanpham":
                            lblMessage.Text = "Bạn có muốn xóa ảnh này?";
                            break;
                        case "tintuc":
                            lblMessage.Text = "Bạn có muốn xóa tin này?";
                            break;
                    }
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ViewState["TYPE"].ToString())
            {
                case "nhomsanpham":
                    if (Common.LoaiNguoiDungID() == 3)
                    {
                        NhomSanPham nhomsanpham = new NhomSanPham();
                        nhomsanpham.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "vitrisanpham":
                    if (Common.LoaiNguoiDungID() == 3)
                    {
                        ViTriSanPham vtsp = new ViTriSanPham();
                        vtsp.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "cuahangnhomsanpham":
                    if (Common.LoaiNguoiDungID() == 2)
                    {
                        //SanPham sp = new SanPham();
                        //DataSet dssp = sp.SelectByNguoiDungID(Common.NguoiDungID);
                        //dssp.Tables[0].DefaultView.RowFilter = "NhomSanPhamID =" + id;

                        //if (dssp.Tables[0].DefaultView.Count == 0)
                        //{
                        CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();                            
                        chnsp.Delete(id);
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "Bạn không thể xóa Nhóm sản phẩm này";
                        //    Image1.Visible = false;
                        //}
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "nhanxetsanpham":
                    if (Common.LoaiNguoiDungID() != 1)
                    {
                        NhanXetSanPham nhanxet = new NhanXetSanPham();
                        nhanxet.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "tintuc":
                    if ((Common.LoaiNguoiDungID() == 3) || (Common.LoaiNguoiDungID() == 2))
                    {
                        TinTuc tt = new TinTuc();
                        tt.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "hotrotructuyen":
                    if ((Common.LoaiNguoiDungID() == 3) || (Common.LoaiNguoiDungID() == 2))
                    {
                        HoTroTrucTuyen ht = new HoTroTrucTuyen();
                        ht.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "hoidapsanpham":
                    if (Common.LoaiNguoiDungID() != 1)
                    {
                        HoiDapSanPham hoidap = new HoiDapSanPham();
                        hoidap.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "nguoidung":
                    if (Common.LoaiNguoiDungID() == 3)
                    {
                        if (CheckExistCuaHang(id) != true)
                        {
                            NguoiDung nguoidung = new NguoiDung();
                            nguoidung.Delete(id);
                        }
                        else
                        {
                            Response.Redirect("../message.aspx?msg=Không thể xóa người dùng đã có cửa hàng", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "hangsanxuat":
                    if (Common.LoaiNguoiDungID() == 3)
                    {
                        HangSanXuat hsx = new HangSanXuat();
                        hsx.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "khuvuc":
                    if (Common.LoaiNguoiDungID() == 3)
                    {
                        KhuVuc kv = new KhuVuc();
                        kv.Delete(id);
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "quangcao":
                    if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3)
                    {
                        QuangCao qcao = new QuangCao();
                        DataSet ds = qcao.SelectByQuangCaoID(id);
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            if(Common.LoaiNguoiDungID() == 3)
                            {
                                //Administrator
                                if(ds.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString() == "3") qcao.Delete(id);
                            }
                            else
                            {
                                //e-Store
                                if (ds.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString() == "2" 
                                    && ds.Tables[0].Rows[0]["NguoiDungID"].ToString() == Common.NguoiDungID().ToString()) qcao.Delete(id);
                            }
                            
                        }                     
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
                case "sanpham":
                    {
                        SanPham sanpham = new SanPham();
                        DataSet dssp = sanpham.SelectBySanPhamID(id);
                        if (Common.LoaiNguoiDungID() == 2)
                        {
                            if (dssp.Tables[0].Rows.Count == 1)
                            {
                                //e-Store
                                if (dssp.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString() == Common.LoaiNguoiDungID().ToString()
                                    && dssp.Tables[0].Rows[0]["NguoiDungID"].ToString() == Common.NguoiDungID().ToString())
                                {
                                    sanpham.Delete(id);
                                }
                            }
                        }
                        else if (Common.LoaiNguoiDungID() == 3)
                        {
                            if (dssp.Tables[0].Rows.Count == 1)
                            {
                                sanpham.Delete(id);
                            }
                        }
                        else
                        {
                            Response.Redirect("../message.aspx?msg=Access denied");
                        }
                    }
                    break;
                case "sanphammau":
                    {
                        SanPhamMau sanpham = new SanPhamMau();
                        DataSet dssp = sanpham.SelectByID(id);
                        if (Common.LoaiNguoiDungID() == 3)
                        {
                            if (dssp.Tables[0].Rows.Count == 1)
                            {
                                sanpham.Delete(id);
                            }
                        }
                        else
                        {
                            Response.Redirect("../message.aspx?msg=Access denied");
                        }
                    }
                    break;
                case "anhsanpham":
                    if (Common.LoaiNguoiDungID() == 2)
                    {
                        Anh anhsanpham = new Anh();
                        DataSet dssp = anhsanpham.SelectByAnhID(id);
                        if (dssp.Tables[0].Rows.Count == 1)
                        {

                            //e-Store
                            if (dssp.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString() == Common.LoaiNguoiDungID().ToString()
                                && dssp.Tables[0].Rows[0]["NguoiDungID"].ToString() == Common.NguoiDungID().ToString()) 
                            {
                                anhsanpham.Delete(id);
                                
                                if (File.Exists(Server.MapPath(Request.QueryString["src"].ToString())))
                                {
                                    File.Delete(Server.MapPath(Request.QueryString["src"].ToString()));
                                }
                            }
                        } 
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Access denied");
                    }
                    break;
            }            
            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool CheckExistCuaHang(int id)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(id);

        if (ds.Tables[0].Rows.Count > 0)
            return true;

        return false;
    }
}
