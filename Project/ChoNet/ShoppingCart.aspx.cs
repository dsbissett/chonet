using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class ShoppingCart : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //btnXoa.Attributes.Add("onclick", "RefreshShoppingCart;");
            DataTable dtShoppingCart = new DataTable();
            LoadDanhMuc(0);
            if (Session["dtShoppingCart"] == null)
            {
                AddColumnToDtShoppingCart(dtShoppingCart);
                Session.Add("dtShoppingCart", dtShoppingCart);
            }

            if (Request.QueryString["spid"] != null)
            {
                AddToShoppingCart();
            }

            ShowShoppingCart();

            if (Session["NguoiDungID"] != null)
            {
                btnGuiDonHang.Visible = true;
            }
            else
            {
                btnGuiDonHang.Visible = false;
            }
        }
    }


    private void AddToShoppingCart()
    {
        try
        {
            DataTable dtShoppingCart = new DataTable();
            if (Session["dtShoppingCart"] == null)
            {
                AddColumnToDtShoppingCart(dtShoppingCart);
            }
            else
            {
                dtShoppingCart = (DataTable) Session["dtShoppingCart"];
            }

            if (Request.QueryString["spid"] != null)
            {
                if (CheckExist() == false)
                {
                    SanPham sp = new SanPham();
                    DataSet ds = sp.SelectByID(int.Parse(Request.QueryString["spid"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dtShoppingCart.NewRow();
                        dr["SanPhamID"] = ds.Tables[0].Rows[0]["SanPhamID"].ToString();
                        dr["TenSanPham"] = ds.Tables[0].Rows[0]["TenSanPham"].ToString();
                        dr["GiaSanPham"] = ds.Tables[0].Rows[0]["GiaSanPham"];
                        dr["SoSanPham"] = "1";
                        //dr["MaSoSanPham"] = ds.Tables[0].Rows[0]["MaSoSanPham"].ToString();
                        dr["TongTien"] = decimal.Parse(ds.Tables[0].Rows[0]["GiaSanPham"].ToString())*
                                         int.Parse(dr["SoSanPham"].ToString());
                        dtShoppingCart.Rows.Add(dr);
                        dr["NguoiDungID"] = ds.Tables[0].Rows[0]["NguoiDungID"].ToString();
                        dr["Xoa"] = false;
                        //hidNumber.Value += dr["SanPhamID"].ToString() + "_" + "1|";
                        //hidXoa.Value += dr["SanPhamID"].ToString() + "_" + "false|";
                    }
                }
            }
            Session.Add("dtShoppingCart", dtShoppingCart);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool CheckExist()
    {
        DataTable dtShoppingCart = (DataTable) Session["dtShoppingCart"];

        foreach (DataRow dr in dtShoppingCart.Rows)
        {
            if (dr["SanPhamID"].ToString() == Request.QueryString["spid"])
            {
                return true;
            }
        }
        return false;
    }

    //protected void btnThemVaoGioHang_ServerClick(object sender, EventArgs e)
    //{
    //    if (Common.dtShoppingCart == null)
    //    {
    //        Common.dtShoppingCart = new DataTable();
    //        AddColumnToDtShoppingCart();
    //    }

    //    DataRow dr = Common.dtShoppingCart.NewRow();
    //    dr["TenSanPham"] = lblTenSanPham.Text;
    //    dr["GiaSanPham"] = lblGiaSanPham.Text == "" ? lblGiaSanPham.Text : "0";
    //    dr["SoSanPham"] = hidSoSanPham.Value == "" ? hidSoSanPham.Value : "0";
    //    dr["TongSoTien"] = int.Parse(dr["GiaSanPham"].ToString()) * int.Parse(dr["SoSanPham"].ToString());
    //    Common.dtShoppingCart.Rows.Add(dr);
    //}

    private void AddColumnToDtShoppingCart(DataTable dt)
    {
        dt.Columns.Add("SanPhamID");
        dt.Columns.Add("TenSanPham");
        dt.Columns.Add("GiaSanPham");
        dt.Columns.Add("SoSanPham");
        dt.Columns.Add("TongTien");
        dt.Columns.Add("NguoiDungID");
        dt.Columns.Add("Xoa");
    }

    private void ShowShoppingCart()
    {
        if (Session["dtShoppingCart"] != null)
        {
            divShoppingCart.Controls.Clear();
            int intSoLoai = 0;
            int intSoSanPham = 0;

            DataTable dtShoppingCart = (DataTable) Session["dtShoppingCart"];
            dtShoppingCart.DefaultView.Sort = "NguoiDungID";
            DataView dv = dtShoppingCart.DefaultView;

            HtmlGenericControl div;
            HtmlGenericControl divtbl;
            HtmlTable tbl;
            HtmlTableRow tr;
            HtmlTableCell td;
            string strNguoiDungID = "";
            string strNguoiDungIDNext = "";
            int i = 0;
            if (dv.Count > 0)
            {
                btnTinhLai.Enabled = true;
                btnXoa.Enabled = true;
                btnGuiDonHang.Enabled = true;
                do
                {
                    div = new HtmlGenericControl();
                    strNguoiDungID = dv[i]["NguoiDungID"].ToString();
                    strNguoiDungIDNext = dv[i]["NguoiDungID"].ToString();
                    div.InnerHtml = GetThongTinCuaHang(int.Parse(strNguoiDungID));
                    tbl = new HtmlTable();
                    divtbl = new HtmlGenericControl();
                    divtbl.Style.Add("align", "right");

                    setTableAttributes(tbl, true);
                    int j = 0;
                    HtmlGenericControl divThanhTien = new HtmlGenericControl();
                    divThanhTien.ID = strNguoiDungID;
                    decimal dcmSoTien = 0;
                    while (strNguoiDungIDNext == strNguoiDungID)
                    {
                        DataRowView dr = dv[i];
                        j++;
                        tr = new HtmlTableRow();
                        HtmlGenericControl divTongTien = new HtmlGenericControl();
                        divTongTien.ID = dr["SanPhamID"].ToString();
                        divTongTien.InnerText =
                            string.Format("{0:0,0}", decimal.Parse(dr["TongTien"].ToString())).Replace(",", ".");

                        foreach (DataColumn dc in dtShoppingCart.Columns)
                        {
                            if (dc.ColumnName != "NguoiDungID")
                            {
                                td = new HtmlTableCell();

                                switch (dc.ColumnName)
                                {
                                    case "SanPhamID":
                                        td.Align = "center";
                                        td.Width = "10%";
                                        td.InnerText = j.ToString();
                                        break;
                                    case "TenSanPham":
                                        td.Width = "25%";
                                        td.InnerText = dr[dc.ColumnName].ToString();
                                        td.Align = "center";
                                        break;
                                    case "GiaSanPham":
                                        td.Width = "15%";
                                        td.InnerText =
                                            string.Format("{0:0,0}", decimal.Parse(dr[dc.ColumnName].ToString())).
                                                Replace(",", ".");
                                        td.Align = "right";
                                        break;
                                    case "SoSanPham":
                                        td.Align = "center";
                                        td.Width = "15%";
                                        HtmlInputText txt = new HtmlInputText();
                                        txt.Value = dr[dc.ColumnName].ToString();
                                        txt.MaxLength = 2;
                                        //txt.Width = Unit.Pixel(80);
                                        txt.Attributes.Add("onchange", "changenumber(this,'" + dr["SanPhamID"] + "');");
                                        td.Controls.Add(txt);
                                        break;
                                    case "Xoa":
                                        td.Width = "10%";
                                        td.Align = "center";
                                        CheckBox chk = new CheckBox();
                                        chk.Checked = bool.Parse(dr[dc.ColumnName].ToString());
                                        chk.Attributes.Add("onclick", "setdelete(this, '" + dr["SanPhamID"] + "');");
                                        td.Controls.Add(chk);
                                        break;
                                    case "TongTien":
                                        td.Width = "15%";
                                        //td.InnerText = string.Format("{0:0,0}", dr[dc.ColumnName]).Replace(",", ".");
                                        //td.ID = dr["SanPhamID"].ToString();
                                        td.Controls.Add(divTongTien);
                                        td.Align = "right";
                                        dcmSoTien += decimal.Parse(dr[dc.ColumnName].ToString());
                                        break;
                                    default:
                                        td.Align = "center";
                                        //td.Width = "22%";
                                        td.InnerText = dr[dc.ColumnName].ToString();
                                        break;
                                }
                                tr.Cells.Add(td);
                            }
                        }

                        tbl.Rows.Add(tr);
                        intSoLoai += 1;
                        intSoSanPham += int.Parse(dr["SoSanPham"].ToString());
                        //dblSoTien += double.Parse(dr["TongSoTien"].ToString());
                        //tblShoppingCart.Rows.Insert(1, tr);                         
                        if (i < dv.Count - 1)
                        {
                            strNguoiDungIDNext = dv[i + 1]["NguoiDungID"].ToString();
                            strNguoiDungID = dv[i]["NguoiDungID"].ToString();
                        }
                        else
                        {
                            strNguoiDungIDNext = "no";
                        }
                        i++;
                    }

                    tr = new HtmlTableRow();
                    //HtmlTableCell td1 = new HtmlTableCell();
                    HtmlTableCell td2 = new HtmlTableCell();
                    td2.Align = "center";
                    td2.ColSpan = 6;
                    //td1.InnerHtml = " ";
                    divThanhTien.InnerText = "Tổng số tiền là: " + string.Format("{0:0,0}", dcmSoTien).Replace(",", ".") +
                                             " VNĐ   ";
                    td2.Controls.Add(divThanhTien);
                    //td2.Controls.Add(div);
                    //td2.InnerText = string.Format("{0:0,0}", dcmSoTien).Replace(",", ".");
                    // td2.ID = strNguoiDungID;
                    //tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tbl.Rows.Add(tr);

                    divShoppingCart.Controls.Add(div);
                    divShoppingCart.Controls.Add(divtbl);
                    divShoppingCart.Controls.Add(tbl);
                    HtmlGenericControl hr = new HtmlGenericControl();
                    hr.TagName = "hr";
                    hr.Attributes.Add("height", "1px");
                    hr.Attributes.Add("color", "#ff6600");
                    divShoppingCart.Controls.Add(hr);
                } while (i < dv.Count);
            }
            else
            {
                divShoppingCart.InnerText = "Không có sản phẩm nào trong giỏ hàng của bạn";
                btnTinhLai.Enabled = false;
                btnXoa.Enabled = false;
                btnGuiDonHang.Enabled = false;
            }
            //lblSoLoaiSanPham.Text = "Có " + intSoLoai.ToString() + " mặt hàng được chọn";
            //lblSoSanPham.Text = intSoSanPham.ToString();
            //lblSoTien.Text = string.Format("{0:00.0000}", dblSoTien);
        }
    }

    private void setTableAttributes(HtmlTable tbl, bool blXoa)
    {
        tbl.Width = "98%";
        tbl.Border = 1;
        tbl.BorderColor = "#cccccc";
        tbl.CellPadding = 4;
        tbl.CellSpacing = 1;

        HtmlTableRow tr = new HtmlTableRow();
        tr.Align = "Center";
        tr.BgColor = "#f2f2f2";

        HtmlTableCell td1 = new HtmlTableCell();
        HtmlTableCell td2 = new HtmlTableCell();
        HtmlTableCell td3 = new HtmlTableCell();
        HtmlTableCell td4 = new HtmlTableCell();
        HtmlTableCell td5 = new HtmlTableCell();
        HtmlTableCell td6 = null;
        if (blXoa) td6 = new HtmlTableCell();

        td1.Width = "1%";
        td1.InnerText = "Thứ tự";

        td2.InnerText = "Tên sản phẩm";
        td3.InnerText = "Giá (VNĐ)";
        td4.InnerText = "Số Lượng";
        td5.InnerText = "Tổng (VNĐ)";
        if (blXoa) td6.InnerText = "Xóa";

        tr.Cells.Add(td1);
        tr.Cells.Add(td2);
        tr.Cells.Add(td3);
        tr.Cells.Add(td4);
        tr.Cells.Add(td5);
        if (blXoa) tr.Cells.Add(td6);
        tbl.Rows.Add(tr);
    }

    private string GetThongTinCuaHang(int NguoiDungID)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(NguoiDungID);
        string strThongTin = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            strThongTin = "<p><b>Giỏ hàng của bạn tại công ty: <a class=pathway href='EStore.aspx?sid=" +
                          dr["CuaHangID"] + "'>" + dr["TenCuaHang"] + "</a><br>";
            strThongTin += "Liên hệ theo số điện thoại: " + dr["DienThoaiCoDinh"] + ", " + dr["DienThoaiDiDong"] +
                           " </b></p>";
        }
        return strThongTin;
    }

    private void LoadDanhMuc(int mcid)
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    td.Text = "<a href=\"maincategory.aspx?mcid=" + dr["NhomSanPhamID"] + "\">" + dr["TenNhomSanPham"] +
                              "</a>";
                    tr.Cells.Add(td);
                    tblDanhMuc.Rows.Add(tr);
                    if (int.Parse(dr["NhomSanPhamID"].ToString()) == mcid)
                    {
                        //Danh muc con                        ;
                        DataSet sds = nsp.SelectNhomSanPhamByNhomChaID(mcid);
                        sds.Tables[0].DefaultView.Sort = "SapXep ASC";
                        if (sds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow sdr in sds.Tables[0].Rows)
                            {
                                TableRow str = new TableRow();
                                TableCell std = new TableCell();
                                std.Style.Value = "padding-left:20px";
                                std.Text = "<a href=\"subcategory.aspx?mcid=" + dr["NhomSanPhamID"] + "&scid=" +
                                           sdr["NhomSanPhamID"] + "\">" + "+ " + sdr["TenNhomSanPham"] + "</a>";
                                str.Cells.Add(std);
                                tblDanhMuc.Rows.Add(str);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool checkDelete(int id)
    {
        string[] ids = hidXoa.Value.Split('_');

        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] == id.ToString())
                return true;
        }
        return false;
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (Session["dtShoppingCart"] != null)
        {
            DataTable dtShoppingCart = (DataTable) Session["dtShoppingCart"];

            for (int i = 0; i < dtShoppingCart.Rows.Count; i++)
            {
                if (checkDelete(int.Parse(dtShoppingCart.Rows[i]["SanPhamID"].ToString())))
                {
                    dtShoppingCart.Rows[i].Delete();
                    i--;
                }
            }

            Session["dtShoppingCart"] = dtShoppingCart;
            Response.Redirect("shoppingcart.aspx");
            //ShowShoppingCart(); 
            //WebAsyncRefreshPanel pnl = (WebAsyncRefreshPanel)this.Master.FindControl("pnlShoppingCart");
            //pnl.ContentRefresh();
        }
    }

    protected void btnTinhLai_Click(object sender, EventArgs e)
    {
        if (Session["dtShoppingCart"] != null)
        {
            DataTable dtShoppingCart = (DataTable) Session["dtShoppingCart"];

            for (int i = 0; i < dtShoppingCart.Rows.Count; i++)
            {
                int number = 1;
                if (checkChangeNumber(int.Parse(dtShoppingCart.Rows[i]["SanPhamID"].ToString()), out number))
                {
                    dtShoppingCart.Rows[i]["SoSanPham"] = number;
                    dtShoppingCart.Rows[i]["TongTien"] =
                        string.Format("{0:0,0}", decimal.Parse(dtShoppingCart.Rows[i]["GiaSanPham"].ToString())*number).
                            Replace("'", ".");
                    ;
                }
            }

            Session["dtShoppingCart"] = dtShoppingCart;
            //Response.Redirect("shoppingcart.aspx");
            LoadDanhMuc(0);
            ShowShoppingCart();
        }
    }

    private bool checkChangeNumber(int id, out int number)
    {
        string[] ids = hidNumber.Value.Split('|');
        number = 1;
        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i].Split('_')[0] == id.ToString())
            {
                number = int.Parse(ids[i].Split('_')[1]);
                return true;
            }
        }
        return false;
    }

    protected void btnGuiDonHang_Click(object sender, EventArgs e)
    {
        ShoppingCartToSend();
        StringWriter sw = new StringWriter();
        HtmlTextWriter w = new HtmlTextWriter(sw);

        string emailto = Common.NguoiDungEmail();
        string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
        string emailsubject = "Đơn hàng từ CHONET.VN";
        string emailbody = "<html><body><center><b><size=h1>ĐƠN HÀNG TỪ CHONET.VN</size></b></center><p>";
        string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
        string emailcc = "";
        string emailbcc = "";

        FreezeChildControls(divShoppingCart.Controls);
        divShoppingCart.RenderControl(w);
        emailbody += sw.GetStringBuilder() + "</body></html>";

        Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);

        LoadDanhMuc(0);
        ShowShoppingCart();
    }

    protected void FreezeChildControls(ControlCollection children)
    {
        LiteralControl FrozenControl;
        for (int n = 0; n < children.Count; n++)
        {
            Trace.Write("Freezing a control at " + n + "...");
            if (children[n].GetType().Equals((new TextBox()).GetType()))
            {
                TextBox tb = (TextBox) children[n];
                FrozenControl = new LiteralControl("<i>" + tb.Text + "</i>");
                FrozenControl.ID = "Frozen_" + tb.ID;
                tb.Parent.Controls.AddAt(tb.Parent.Controls.IndexOf(tb) + 1, FrozenControl);
                tb.Visible = false;
                Trace.Write("that is a frozen TextBox");
            }
            else if (children[n].GetType().Equals((new RadioButtonList()).GetType()))
            {
                RadioButtonList rbl = (RadioButtonList) children[n];
                FrozenControl = new LiteralControl("<i>" + rbl.SelectedValue + "</i>");
                FrozenControl.ID = "Frozen_" + rbl.ID;
                rbl.Parent.Controls.AddAt(rbl.Parent.Controls.IndexOf(rbl) + 1, FrozenControl);
                rbl.Visible = false;
            }
            else if (children[n].GetType().Equals((new DropDownList()).GetType()))
            {
                DropDownList ddl = (DropDownList) children[n];
                FrozenControl = new LiteralControl("<i>" + ddl.SelectedItem.Text + "</i>");
                FrozenControl.ID = "Frozen_" + ddl.ID;
                ddl.Parent.Controls.AddAt(ddl.Parent.Controls.IndexOf(ddl) + 1, FrozenControl);
                ddl.Visible = false;
            }
            else if (children[n].GetType().Equals((new CheckBox()).GetType()))
            {
                CheckBox cb = (CheckBox) children[n];
                if (cb.Checked)
                    FrozenControl = new LiteralControl("<i>(x)</i>");
                else
                    FrozenControl = new LiteralControl("(&nbsp;)");
                FrozenControl.ID = "Frozen_" + cb.ID;
                cb.Parent.Controls.AddAt(cb.Parent.Controls.IndexOf(cb) + 1, FrozenControl);
                cb.Visible = false;
            }

                // Remove the validators, as they are no longer necessary
            else if (children[n].GetType().Equals((new RequiredFieldValidator()).GetType()))
            {
                children[n].Visible = false;
            }
            else if (children[n].GetType().Equals((new RegularExpressionValidator()).GetType()))
            {
                children[n].Visible = false;
            }
            else if (children[n].GetType().Equals((new CustomValidator()).GetType()))
            {
                children[n].Visible = false;
            }
            else
            {
                Trace.Write("Type " + children[n].GetType() + " does not need freezing");
            }
            if (children[n].HasControls())
            {
                FreezeChildControls(children[n].Controls);
            }
        }
    }

    private void ShoppingCartToSend()
    {
        if (Session["dtShoppingCart"] != null)
        {
            int intSoLoai = 0;
            int intSoSanPham = 0;
            int DonHangID = 0;

            DonHang dh = new DonHang();
            DonHangID = dh.InsertFields(Common.NguoiDungID(), null, null, null, null, null);

            DataTable dtShoppingCart = (DataTable) Session["dtShoppingCart"];
            dtShoppingCart.DefaultView.Sort = "NguoiDungID";
            DataView dv = dtShoppingCart.DefaultView;

            HtmlGenericControl div;
            HtmlGenericControl divtbl;
            HtmlTable tbl;
            HtmlTableRow tr;
            HtmlTableCell td;
            string strNguoiDungID = "";
            string strNguoiDungIDNext = "";
            int i = 0;
            if (dv.Count > 0)
            {
                btnTinhLai.Enabled = true;
                btnXoa.Enabled = true;
                do
                {
                    div = new HtmlGenericControl();
                    strNguoiDungID = dv[i]["NguoiDungID"].ToString();
                    strNguoiDungIDNext = dv[i]["NguoiDungID"].ToString();

                    int chid = 0;
                    string tench = "";
                    div.InnerHtml = GetThongTinCuaHang(int.Parse(strNguoiDungID), out chid, out tench);
                    tbl = new HtmlTable();
                    divtbl = new HtmlGenericControl();
                    divtbl.Style.Add("align", "right");

                    setTableAttributes(tbl, false);
                    int j = 0;
                    HtmlGenericControl divThanhTien = new HtmlGenericControl();
                    divThanhTien.ID = strNguoiDungID;
                    decimal dcmSoTien = 0;
                    while (strNguoiDungIDNext == strNguoiDungID)
                    {
                        DataRowView dr = dv[i];
                        j++;
                        tr = new HtmlTableRow();
                        HtmlGenericControl divTongTien = new HtmlGenericControl();
                        divTongTien.ID = dr["SanPhamID"].ToString();
                        divTongTien.InnerText =
                            string.Format("{0:0,0}", decimal.Parse(dr["TongTien"].ToString())).Replace(",", ".");
                        AddDonHangToDB(dr, DonHangID, chid, tench);

                        foreach (DataColumn dc in dtShoppingCart.Columns)
                        {
                            if ((dc.ColumnName != "NguoiDungID") && (dc.ColumnName != "Xoa"))
                            {
                                td = new HtmlTableCell();

                                switch (dc.ColumnName)
                                {
                                    case "SanPhamID":
                                        td.Align = "center";
                                        td.Width = "10%";
                                        td.InnerText = j.ToString();
                                        break;
                                    case "TenSanPham":
                                        td.Width = "25%";
                                        td.InnerText = dr[dc.ColumnName].ToString();
                                        td.Align = "center";
                                        break;
                                    case "GiaSanPham":
                                        td.Width = "15%";
                                        td.InnerText =
                                            string.Format("{0:0,0}", decimal.Parse(dr[dc.ColumnName].ToString())).
                                                Replace(",", ".");
                                        td.Align = "right";
                                        break;
                                    case "SoSanPham":
                                        td.Align = "right";
                                        td.Width = "15%";
                                        td.InnerText = dr[dc.ColumnName].ToString();
                                        //txt.Width = Unit.Pixel(80);                                        
                                        break;
                                    case "Xoa":
                                        break;
                                    case "TongTien":
                                        td.Width = "15%";
                                        //td.InnerText = string.Format("{0:0,0}", dr[dc.ColumnName]).Replace(",", ".");
                                        //td.ID = dr["SanPhamID"].ToString();
                                        td.Controls.Add(divTongTien);
                                        td.Align = "right";
                                        dcmSoTien += decimal.Parse(dr[dc.ColumnName].ToString());
                                        break;
                                    default:
                                        td.Align = "center";
                                        //td.Width = "22%";
                                        td.InnerText = dr[dc.ColumnName].ToString();
                                        break;
                                }
                                tr.Cells.Add(td);
                            }
                        }

                        tbl.Rows.Add(tr);
                        intSoLoai += 1;
                        intSoSanPham += int.Parse(dr["SoSanPham"].ToString());
                        //dblSoTien += double.Parse(dr["TongSoTien"].ToString());
                        //tblShoppingCart.Rows.Insert(1, tr);                         
                        if (i < dv.Count - 1)
                        {
                            strNguoiDungIDNext = dv[i + 1]["NguoiDungID"].ToString();
                            strNguoiDungID = dv[i]["NguoiDungID"].ToString();
                        }
                        else
                        {
                            strNguoiDungIDNext = "no";
                        }
                        i++;
                    }

                    tr = new HtmlTableRow();
                    //HtmlTableCell td1 = new HtmlTableCell();
                    HtmlTableCell td2 = new HtmlTableCell();
                    td2.Align = "center";
                    td2.ColSpan = 6;
                    //td1.InnerHtml = " ";
                    divThanhTien.InnerText = "Tổng số tiền là: " + string.Format("{0:0,0}", dcmSoTien).Replace(",", ".") +
                                             " VNĐ   ";
                    td2.Controls.Add(divThanhTien);
                    //td2.Controls.Add(div);
                    //td2.InnerText = string.Format("{0:0,0}", dcmSoTien).Replace(",", ".");
                    // td2.ID = strNguoiDungID;
                    //tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tbl.Rows.Add(tr);

                    divShoppingCart.Controls.Add(div);
                    divShoppingCart.Controls.Add(divtbl);
                    divShoppingCart.Controls.Add(tbl);
                    HtmlGenericControl hr = new HtmlGenericControl();
                    hr.TagName = "hr";
                    hr.Attributes.Add("height", "1px");
                    hr.Attributes.Add("color", "#ff6600");
                    divShoppingCart.Controls.Add(hr);
                } while (i < dv.Count);
            }
            else
            {
                divShoppingCart.InnerText = "Không có sản phẩm nào trong giỏ hàng của bạn";
                btnTinhLai.Enabled = false;
                btnXoa.Enabled = false;
            }
            //lblSoLoaiSanPham.Text = "Có " + intSoLoai.ToString() + " mặt hàng được chọn";
            //lblSoSanPham.Text = intSoSanPham.ToString();
            //lblSoTien.Text = string.Format("{0:00.0000}", dblSoTien);
        }
    }

    private void AddDonHangToDB(DataRowView dr, int dhid, int chid, string tench)
    {
        ChiTietDonHang ctdh = new ChiTietDonHang();

        ctdh.InsertFields(dhid, int.Parse(dr["SanPhamID"].ToString()), dr["TenSanPham"].ToString(),
                          decimal.Parse(dr["GiaSanPham"].ToString()),
                          int.Parse(dr["SoSanPham"].ToString()), decimal.Parse(dr["TongTien"].ToString()), chid, tench);
    }

    private string GetThongTinCuaHang(int NguoiDungID, out int chid, out string tench)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByNguoiDungID(NguoiDungID);
        string strThongTin = "";
        chid = 0;
        tench = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            chid = int.Parse(dr["CuaHangID"].ToString());
            tench = dr["TenCuaHang"].ToString();
            strThongTin = "<p><b>Giỏ hàng của bạn tại công ty: <a class=pathway href='EStore.aspx?sid=" +
                          dr["CuaHangID"] + "'>" + dr["TenCuaHang"] + "</a><br>";
            strThongTin += "Liên hệ theo số điện thoại: " + dr["DienThoaiCoDinh"] + ", " + dr["DienThoaiDiDong"] +
                           " </b></p>";
        }
        return strThongTin;
    }

    protected void btnTiepTuc_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}