using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class Adm_PropertyAdmin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Page.IsPostBack)
        {
            //LoadDanhMucCon(0,0);
            LoadTree();
            //if (tvNhomSanPham.Nodes.Count > 0)
            //{
            //    tvNhomSanPham.Nodes[0].Selected = true;
            //    hidSelectedNode.Value = tvNhomSanPham.Nodes[0].Value;
            //}
            //ddlDanhMucCap1.Items[0].Selected =true;
            //ddlDanhMucCap1.Text = "Tất cả";
        }
        else
        {
            LoadData();
        }
        //LoadThuocTinhCon();
    }

    private void LoadData()
    {
        grdThuocTinh.DataSource = null;
        grdThuocTinhCon.DataSource = null;
        grdThuocTinh.DataBind();
        grdThuocTinhCon.DataBind();
        if (int.Parse("0" + tvNhomSanPham.SelectedValue) > 0)
        {
            ThuocTinh tt = new ThuocTinh();
            DataSet ds;

            int NhomSanPhamID = int.Parse("0" + tvNhomSanPham.SelectedValue);

            ds = tt.SelectByThuocTinhChaID(0);
            ds.Tables[0].DefaultView.RowFilter = "NhomSanPhamID = " + NhomSanPhamID;

            ds.Tables[0].DefaultView.Sort = "ThuocTinhID DESC";
            grdThuocTinh.DataSource = ds.Tables[0];
            grdThuocTinh.DataBind();

            if (ViewState["id"] == null)
                grdThuocTinh.SelectedIndex = 0;
            else
                setSelected(int.Parse(ViewState["id"].ToString()));

            LoadThuocTinhCon();
        }
        if (grdThuocTinh.Rows.Count <= 0)
            lblThuocTinh.Visible = true;
        else
            lblThuocTinh.Visible = false;
    }

    private void setSelected(int p)
    {
        for (int i = 0; i < grdThuocTinh.Rows.Count; i++)
        {
            if (grdThuocTinh.DataKeys[i].Value.ToString() == ViewState["id"].ToString())
                grdThuocTinh.SelectedIndex = grdThuocTinh.Rows[i].RowIndex;
        }
    }

    private void LoadThuocTinhCon()
    {
        if (grdThuocTinh.SelectedDataKey != null)
        {
            ThuocTinh tt = new ThuocTinh();
            int ThuocTinhChaID = int.Parse("0" + grdThuocTinh.SelectedDataKey.Value);
            DataSet ds = tt.SelectByThuocTinhChaID(ThuocTinhChaID);

            grdThuocTinhCon.DataSource = ds;
            grdThuocTinhCon.DataBind();
        }
    }

    protected void grdThuocTinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdThuocTinh.PageIndex = e.NewPageIndex;
    }

    protected void grdThuocTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["id"] = grdThuocTinh.SelectedIndex;

        LoadThuocTinhCon();
    }

    protected void grdThuocTinhCon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdThuocTinhCon.PageIndex = e.NewPageIndex;
    }

    private void LoadTreeItems(TreeNode tn, int NhomChaID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(NhomChaID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            TreeNode node = new TreeNode(dr["TenNhomSanPham"].ToString(), dr["NhomSanPhamID"].ToString());
            LoadTreeItems(node, int.Parse(dr["NhomSanPhamID"].ToString()));
            tn.ChildNodes.Add(node);
        }
    }

    private void LoadTree()
    {
        try
        {
            TreeNode node = new TreeNode("Danh mục sản phẩm", "0");
            LoadTreeItems(node, 0);
            tvNhomSanPham.Nodes.Add(node);
        }
        catch (Exception ex)
        {
            Response.Redirect("../message/aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }

    protected void tvNhomSanPham_SelectedNodeChanged(object sender, EventArgs e)
    {
        lblDanhMuc.Text = tvNhomSanPham.SelectedNode.Text;
        hidSelectedNode.Value = tvNhomSanPham.SelectedNode.Value;
        LoadData();
    }
}