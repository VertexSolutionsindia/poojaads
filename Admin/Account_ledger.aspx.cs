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

public partial class Admin_Account_Ledger : System.Web.UI.Page
{
    float tot_Credit= 0;
    float m = 0;
    float m1 = 0;
    float tot_Debit = 0;
    public static int company_id = 0;
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
                    Label3.Text = dr["company_name"].ToString();
                }
                con.Close();
            }
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd10 = new SqlCommand("select * from currentfinancialyear where no='1'", con10);
            SqlDataReader dr10;
            con10.Open();
            dr10 = cmd10.ExecuteReader();
            if (dr10.Read())
            {
                Label1.Text = dr10["financial_year"].ToString();
                TextBox3.Text = Convert.ToDateTime(dr10["start_date"]).ToString("dd-MM-yyyy");
            }
            con10.Close();
            showrating();
            BindData();

            active();
            created();


         

        }
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
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct product_name from product_entry where Com_Id=@Com_Id and " +
                "product_name like @product_name + '%'";
                cmd.Parameters.AddWithValue("@product_name", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["product_name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomers1(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct Vendor_Name from Vendor where Com_Id=@Com_Id and " +
                "Vendor_Name like @Vendor_Name + '%'";
                cmd.Parameters.AddWithValue("@Vendor_Name", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Vendor_Name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomers11(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct barcode from product_stock where Com_Id=@Com_Id and " +
                "barcode like @barcode + '%'";
                cmd.Parameters.AddWithValue("@barcode", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["barcode"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    private void show_category()
    {
        //SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        //SqlCommand CMD = new SqlCommand("SELECT  CONVERT(date,date,101) as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM sales_entry as a where Com_Id='" + company_id + "'  group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_entry where Com_Id='" + company_id + "'  group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_amount where Com_Id='" + company_id + "'  group by date,status,amount,value", con1);
        //DataTable dt1 = new DataTable();
        //con1.Open();
        //SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        //da1.Fill(dt1);
        //GridView1.DataSource = dt1;
        //GridView1.DataBind();
    }
    protected void BindData()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select date,status AS Particulars, sum(value) as Debit,sum(grand_total) as Credit  from Order_entry where Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by date,status,value,grand_total union select date,status AS Particulars, sum(Amount) as Debit,sum(value) as Credit  from Expence_Entry where  Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by date,status,value,Amount union select bill_date,status AS Particulars, sum(bill_amount) as Debit,sum(value) as Credit  from agent_bill where  Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by bill_date,status,value,bill_amount", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {

    }
    private void getinvoiceno()
    {
        
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

    private void showcustomertype()
    {

    }
    private void showrating()
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total : ";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Salary = (Label)e.Row.FindControl("lblDebit");

                m = m + float.Parse(Salary.Text);

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Debit");
                lblTotalPrice.Text = m.ToString();

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Salary = (Label)e.Row.FindControl("lblCredit");

                m1 = m1 + float.Parse(Salary.Text);

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Credit");
                lblTotalPrice.Text = m1.ToString();

            }
        }
        catch (Exception er)
        { }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
      
       
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
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

    protected void Button3_Click(object sender, EventArgs e)
    {
      
        TextBox4.Text = "";
        BindData();
        SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd10 = new SqlCommand("select * from currentfinancialyear where no='1'", con10);
        SqlDataReader dr10;
        con10.Open();
        dr10 = cmd10.ExecuteReader();
        if (dr10.Read())
        {
           
            TextBox3.Text = Convert.ToDateTime(dr10["start_date"]).ToString("dd-MM-yyyy");
        }
        con10.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        //SqlCommand CMD = new SqlCommand("SELECT CONVERT(datetime,date,101) as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM sales_entry as a where date between '" + TextBox3.Text + "' and '" + TextBox4.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_entry as a where date between '" + TextBox3.Text + "' and '" + TextBox4.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_amount as a where date between '" + TextBox3.Text + "' and '" + TextBox4.Text + "' and Com_Id='" + company_id + "'   group by date,status,amount,value", con1);
        SqlCommand CMD = new SqlCommand("select date,status AS Particulars, sum(value) as Debit,sum(grand_total) as Credit  from Order_entry where date between '" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by date,status,value,grand_total union select date,status AS Particulars, sum(Amount) as Debit,sum(value) as Credit  from Expence_Entry where date between '" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by date,status,value,Amount union select bill_date,status AS Particulars, sum(bill_amount) as Debit,sum(value) as Credit  from agent_bill where bill_date between '" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by bill_date,status,value,bill_amount", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
}