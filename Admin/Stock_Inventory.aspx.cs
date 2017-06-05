﻿#region " Using "
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

public partial class Admin_Stock_Inventory : System.Web.UI.Page
{
    public static int company_id = 0;
    public static int company_id1 = 0;
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
                }
                con.Close();
            }
           

            //SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            //SqlCommand CMD = new SqlCommand("select * from product_stock where Com_Id='" + company_id + "' ORDER BY purchase_invoice asc", con1);
            //DataTable dt1 = new DataTable();
            //con1.Open();
            //SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            //da1.Fill(dt1);
            //GridView1.DataSource = dt1;
            //GridView1.DataBind();


            

            BindData();
            getinvoiceno();
            show_category();
            showrating();
           
            show_company();
            active();
            created();
            TextBox2.Text = "";
          
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
                cmd.CommandText = "select distinct Product_name from product_stock where Com_Id=@Com_Id and " +
                "Product_name like @Product_name + '%'";
                cmd.Parameters.AddWithValue("@Product_name", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id1);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Product_name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchBarcode(string prefixText, int count)
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
  

 






    public static List<string> SearchCustomers10(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct purchase_invoice from product_stock where Com_Id=@Com_Id and " +
                "purchase_invoice like @purchase_invoice + '%'";
                cmd.Parameters.AddWithValue("@purchase_invoice", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id1);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["purchase_invoice"].ToString());
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
                cmd.CommandText = "select distinct Supplier from product_stock where Com_Id=@Com_Id and " +
                "Supplier like @Supplier + '%'";
                cmd.Parameters.AddWithValue("@Supplier", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id1);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Supplier"].ToString());
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
                cmd.Parameters.AddWithValue("@Com_Id",company_id1);
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
    private void show_company()
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Company_detail ORDER BY com_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);




        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "company_name";
        DropDownList1.DataValueField = "com_id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select company", "0"));
        con.Close();
    }


    private void show_category()
    {
     
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from category where Com_Id='" + company_id + "' ORDER BY category_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);




        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "categoryname";
        DropDownList3.DataValueField = "category_id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }
    protected void BindData()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where Com_Id='" + company_id + "' ORDER BY purchase_invoice asc", con1);
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
        int a;
      
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select Max(Emp_Code) from Staff_Entry where Com_Id='" + company_id + "'";
        SqlCommand cmd1 = new SqlCommand(query, con1);
        SqlDataReader dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            
            }
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
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GridView1.PageIndex + 1) + " of " + GridView1.PageCount;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where product_name='" + TextBox1.Text + "' and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where supplier='" + TextBox2.Text + "' and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from subcategory where category_id='" + DropDownList3.SelectedItem.Value + "' and Com_Id='" + DropDownList1.SelectedItem.Value + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "subcategoryname";
        DropDownList4.DataValueField = "subcategory_id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("All", "0"));



        con.Close();
       
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where Category='" + DropDownList3.SelectedItem.Value + "'  and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where subcategory='" + DropDownList4.SelectedItem.Value + "'  and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
       
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where date='" + TextBox3.Text + "'  and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where date between '" + TextBox3.Text + "' and '" + TextBox4.Text + "'  and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
       
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where barcode='" + TextBox6.Text + "'  and Com_Id='" + company_id + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_stock where Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();


      
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from category where Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY category_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);




        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "categoryname";
        DropDownList3.DataValueField = "category_id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("All", "0"));
        con.Close();



        
        SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd1 = new SqlCommand("Select * from product_stock where Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY no asc", con2);
        con2.Open();
        DataSet ds1 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
        da2.Fill(ds1);

        con2.Close();

        company_id1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("Select * from product_stock where purchase_invoice='" + TextBox5.Text + "' and Com_Id='" + DropDownList1.SelectedItem.Value + "' ORDER BY purchase_invoice asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }

}