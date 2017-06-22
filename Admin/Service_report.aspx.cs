#region " Using "
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
#endregion
public partial class Admin_Day_and_month_wise_purchase : System.Web.UI.Page
{
    public static int company_id = 0;
    float m = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (User.Identity.IsAuthenticated)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    company_id = Convert.ToInt32(dr["com_id"].ToString());
                    Label1.Text = dr["company_name"].ToString();
                }
                con.Close();
            }

            getinvoiceno();
            show_ServiceDetails();
            showrating();
            BindData();

            active();
            created();
         



        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {


    }
    protected void Button9_Click(object sender, EventArgs e)
    {

    }
    protected void Button10_Click(object sender, EventArgs e)
    {

    }
    

    protected void Button2_Click(object sender, EventArgs e)
    {

        getinvoiceno();
        show_ServiceDetails();
    }
    private void active()
    {

    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;


        LinkButton Lnk = (LinkButton)sender;
        string name = Lnk.Text;
        Session["name"] = name;
        Response.Redirect("Account_show.aspx");


    }

    private void created()
    {

    }
    protected void BindData()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("SELECT distinct Order_entry_details.Service_name,Order_entry.Invoice_no,Order_entry.client_name,Order_entry.date,Order_entry.cl_add,Order_entry.mobile,Order_entry.presented_bank,Order_entry.grand_total FROM Order_entry INNER JOIN Order_entry_details ON Order_entry.Invoice_no = Order_entry_details.Invoice_no WHERE Order_entry.Com_Id ='" + company_id + "' ORDER BY Order_entry.Invoice_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();



    }
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
      
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("delete from category where category_id='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Category deleted successfully')", true);

        BindData();
        show_ServiceDetails();
        getinvoiceno();


    }
    private void getinvoiceno()
    {


    }
    private void show_ServiceDetails()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("SELECT distinct Order_entry_details.Service_name,Order_entry.Invoice_no FROM Order_entry INNER JOIN Order_entry_details ON Order_entry.Invoice_no = Order_entry_details.Invoice_no where Order_entry.Com_Id='" + company_id + "' ORDER BY Order_entry.Invoice_no asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Service_name";
        DropDownList2.DataValueField = "Invoice_no";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));

        con.Close();
    }
    protected void LoginLink_OnClick(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/login.aspx");

    }

    protected void btnRandom_Click(object sender, EventArgs e)
    {
        Session["name1"] = "";
        Response.Redirect("~/Admin/Category_Add.aspx");
    }


    private void showrating()
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();

    }
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }




    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
      
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
       
    }
   
   
    protected void Button1_Click1(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=gvtoexcel.xls");
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GridView1.PageIndex + 1) + " of " + GridView1.PageCount;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Salary = (Label)e.Row.FindControl("lblSalary");

            m = m + float.Parse(Salary.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalPrice = (Label)e.Row.FindControl("Salary");
            lblTotalPrice.Text = m.ToString();
            TextBox3.Text = m.ToString();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && DropDownList2.SelectedItem.Text != "All")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand CMD = new SqlCommand("SELECT distinct Order_entry_details.Service_name,Order_entry.Invoice_no,Order_entry.client_name,Order_entry.date,Order_entry.cl_add,Order_entry.mobile,Order_entry.presented_bank,Order_entry.grand_total FROM Order_entry INNER JOIN Order_entry_details ON Order_entry.Invoice_no = Order_entry_details.Invoice_no WHERE Order_entry.date Between '" + Convert.ToDateTime(TextBox1.Text).ToString("MM-dd-yyyy") + "' AND '" + Convert.ToDateTime(TextBox2.Text).ToString("MM-dd-yyyy") + "' AND Order_entry_details.Service_name='" + DropDownList2.SelectedItem.Text + "' AND Order_entry.Com_Id ='" + company_id + "' ORDER BY Order_entry.Invoice_no asc", con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {

            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand CMD = new SqlCommand("SELECT distinct Order_entry_details.Service_name,Order_entry.Invoice_no,Order_entry.client_name,Order_entry.date,Order_entry.cl_add,Order_entry.mobile,Order_entry.presented_bank,Order_entry.grand_total FROM Order_entry INNER JOIN Order_entry_details ON Order_entry.Invoice_no = Order_entry_details.Invoice_no WHERE Order_entry_details.Service_name='" + DropDownList2.SelectedItem.Text + "' AND Order_entry.Com_Id ='" + company_id + "' ORDER BY Order_entry.Invoice_no asc", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            else
            {

                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand CMD = new SqlCommand("SELECT distinct Order_entry_details.Service_name,Order_entry.Invoice_no,Order_entry.client_name,Order_entry.date,Order_entry.cl_add,Order_entry.mobile,Order_entry.presented_bank,Order_entry.grand_total FROM Order_entry INNER JOIN Order_entry_details ON Order_entry.Invoice_no = Order_entry_details.Invoice_no WHERE Order_entry.date Between '" + Convert.ToDateTime(TextBox1.Text).ToString("MM-dd-yyyy") + "' AND '" + Convert.ToDateTime(TextBox2.Text).ToString("MM-dd-yyyy") + "' AND Order_entry.Com_Id ='" + company_id + "' ORDER BY Order_entry.Invoice_no asc", con);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                    da1.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Select From And To Date')", true);
                }
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        show_ServiceDetails();
        BindData();
    }
}