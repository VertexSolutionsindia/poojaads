
#region " Using "
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;

using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
#endregion






public partial class Admin_Sales_entry : System.Web.UI.Page
{
    float tot = 0;
    float tot1 = 0;
    DataTable dt = null;
    public static int company_id = 0;
    public static string company_id1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (User.Identity.IsAuthenticated)
            {
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    company_id = Convert.ToInt32(dr2["com_id"].ToString());
                }
                con2.Close();
            }

            DateTime date = DateTime.Now;
            TextBox8.Text = Convert.ToDateTime(date).ToString("MM-dd-yyyy");
            TextBox8.Attributes.Add("onkeypress", "return controlEnter('" + TextBox13.ClientID + "', event)");
            TextBox13.Attributes.Add("onkeypress", "return controlEnter('" + TextBox14.ClientID + "', event)");
          


          
        
           
            getinvoiceno();
           
            show_category();
            showrating();
            BindData();
            show_tax();
            getinvoicenoid();
            show_type();
            active();
            created();
            show_category1();
            show_acc();
           
           

            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            con1.Open();
            string query = "Select * from Company_detail  where com_id='" + company_id + "'";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {

                company_id1 = dr["Address"].ToString();
               
            }
            con1.Close();
           

        }
       
    }
   
    
   

   
    

    //A method that returns a string which calls the connection string from the web.config
    private string GetConnectionString()
    {
        //"DBConnection" is the name of the Connection String
        //that was set up from the web.config file
        return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
    private void getinvoiceno()
    {
        int a;
       


        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select max(invoice_no) from sales_entry where  Com_Id='" + company_id + "'";
        SqlCommand cmd1 = new SqlCommand(query, con1);
        SqlDataReader dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            string val = dr[0].ToString();
            if (val == "")
            {
                Label1.Text = "1";
            }
            else
            {
                a = Convert.ToInt32(dr[0].ToString());
                a = a + 1;
                Label1.Text = a.ToString();
            }
        }
    }
    private void show_type()
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox13.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter customer name')", true);

        }
        else if (TextBox32.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter Payment Term')", true);
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("insert into Estimate values(@Est_No,@est_Date,@Custom_Name,@Mob_No,@Cust_Add,@Acc_nickname,@Acc_No,@Acc_Nme,@ifsc,@Com_Id,@service_type,@service_name,@est_cost,@serv_from,@serve_to,@pay_term)", con);
            cmd.Parameters.AddWithValue("@Est_No", Label1.Text);
            cmd.Parameters.AddWithValue("est_Date", TextBox8.Text);
            cmd.Parameters.AddWithValue("@Custom_Name", TextBox13.Text);
            cmd.Parameters.AddWithValue("@Mob_No", TextBox6.Text);
            cmd.Parameters.AddWithValue("@Cust_Add", TextBox14.Text);
            cmd.Parameters.AddWithValue("@Acc_nickname", DropDownList4.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Acc_No", DropDownList6.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Acc_Nme", DropDownList7.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@ifsc", DropDownList8.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Com_Id", company_id);
      
            cmd.Parameters.AddWithValue("@service_type", DropDownList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@service_name", DropDownList5.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@est_cost", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@serv_from", TextBox30.Text);
            cmd.Parameters.AddWithValue("@serve_to", TextBox31.Text);
            cmd.Parameters.AddWithValue("@pay_term", TextBox32.Text);
           

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Invoice created successfully')", true);

            getinvoiceno();

            show_category();
            showrating();
            BindData();
            show_tax();
            getinvoicenoid();
            show_type();
            active();
            created();
            show_category1();
            show_acc();
            TextBox30.Text = "";
            TextBox31.Text = "";
            TextBox32.Text = "";
            TextBox8.Text = "";
            TextBox13.Text = "";

            TextBox6.Text = "";
            TextBox14.Text = "";



        }
    }
    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
    }
    protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
     
        ImageButton img = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)img.NamingContainer;
        int s_no = Convert.ToInt32(ROW.Cells[0].Text);
        string barcode =ROW.Cells[1].Text;
        float qty = float.Parse(ROW.Cells[6].Text);

        SqlConnection CON11 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd11 = new SqlCommand("update product_stock set qty=qty+@qty where barcode='" + barcode + "' and Com_Id='" + company_id + "'", CON11);





        cmd11.Parameters.AddWithValue("@qty", qty);

        CON11.Open();
        cmd11.ExecuteNonQuery();
        CON11.Close();

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

        con1.Open();
        SqlCommand cmd1 = new SqlCommand("delete from sales_entry where s_no='" + s_no + "' and invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "'", con1);
        cmd1.ExecuteNonQuery();
        con1.Close();



       

        BindData();
       

    }
    private void SaveDetail(GridViewRow row)
    {

        
        


    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        getinvoiceno();

        show_category();
        showrating();
        BindData();
        show_tax();
        getinvoicenoid();
        show_type();
        active();
        created();
        show_category1();
        show_acc();
        TextBox30.Text = "";
        TextBox31.Text = "";
        TextBox32.Text = "";
        TextBox8.Text = "";
        TextBox13.Text = "";

        TextBox6.Text = "";
        TextBox14.Text = "";

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
        SqlCommand CMD = new SqlCommand("select * from sales_entry_details where invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' order by s_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {

       
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("delete from product_entry where code='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Product entry deleted successfully')", true);

        BindData();
        show_category();



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
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomers1(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct barcode from product_stock where Com_Id=@Com_Id and  " +
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

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomers2(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct Mobile_no from Customer_Entry where Com_Id=@Com_Id and  " +
                "Mobile_no like @Mobile_no + '%'";
                cmd.Parameters.AddWithValue("@Mobile_no", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Mobile_no"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchCustomersdetails(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select distinct Custom_Name from Customer_Entry where Com_Id=@Com_Id and " +
                "Custom_Name like @Custom_Name + '%'";
                cmd.Parameters.AddWithValue("@Custom_Name", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Custom_Name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        



    }
    private void show_tax()
    {
        
    }
    private void show_category()
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
       
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    

   
    
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("select * from Customer_entry where Mobile_no='" + TextBox6.Text + "'", con);
                    SqlDataReader dr1;
                    dr1 = cmd2.ExecuteReader();
                    if (dr1.Read())
                    {


                        TextBox13.Text = dr1["Custom_Name"].ToString();
                        TextBox14.Text = dr1["Custom_Add"].ToString();
                    }
                    con.Close();


       
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

       
    }

    //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    //{

       
    //}
    
    protected void Button5_Click(object sender, EventArgs e)
    {

        Session["Name"] = TextBox13.Text;






        Response.Redirect("SALES_REPORT_VIEW.aspx");
    }
    protected void Gridview2_Load(object sender, System.EventArgs e)
    {

    }


   
    protected void TextBox3_TextChanged(object sender, System.EventArgs e)
    {
       

    }
    
    
    protected void Gridview2_PreRender(object sender, System.EventArgs e)
    {

    }
    protected void TextBox16_TextChanged(object sender, System.EventArgs e)
    {
       
    }
    protected void TextBox2_TextChanged(object sender, System.EventArgs e)
    {
       
    }
    protected void TextBox17_TextChanged(object sender, System.EventArgs e)
    {
       
    }

    protected void TextBox18_TextChanged(object sender, System.EventArgs e)
    {
        
    }
    protected void Button3_Click1(object sender, System.EventArgs e)
    {
       
    }

    protected void TextBox7_TextChanged(object sender, System.EventArgs e)
    {
   
    }

    protected void Gridview2_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        
    }
   
   
    protected void Button3_Click2(object sender, System.EventArgs e)
    {
        
       
    }

    protected void TextBox1_TextChanged(object sender, System.EventArgs e)
    {


       
    }
    protected void TextBox15_TextChanged(object sender, System.EventArgs e)
    {
       
       
    }

    protected void TextBox4_TextChanged(object sender, System.EventArgs e)
    {
       
    }
    protected void Button6_Click(object sender, System.EventArgs e)
    {
       
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
      



    }
    private void getinvoicenoid()
    {
  
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select Max(Est_No) from Estimate where Com_Id='" + company_id + "'";
        SqlCommand cmd1 = new SqlCommand(query, con1);
        SqlDataReader dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            string val = dr[0].ToString();
            if (val == "")
            {
                Label1.Text = "1";
            }
            else
            {
                a = Convert.ToInt32(dr[0].ToString());
                a = a + 1;
                Label1.Text = a.ToString();
            }
        }
    }
  
    protected void TextBox26_TextChanged(object sender, System.EventArgs e)
    {
        
    }
    protected void TextBox13_TextChanged(object sender, System.EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

        con.Open();

        SqlCommand cmd2 = new SqlCommand("select * from Customer_entry where Custom_Name='" + TextBox13.Text + "'", con);
        SqlDataReader dr1;
        dr1 = cmd2.ExecuteReader();
        if (dr1.Read())
        {


            TextBox6.Text = dr1["Mobile_no"].ToString();
            TextBox14.Text = dr1["Custom_Add"].ToString();
        }
        con.Close();
    }
    protected void TextBox16_TextChanged1(object sender, System.EventArgs e)
    {

    }



    protected void TextBox23_TextChanged(object sender, System.EventArgs e)
    {
      
    }
    protected void Button5_Click1(object sender, System.EventArgs e)
    {
       
    }
   
  
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        getsubcategory();
    }

    private void getsubcategory()
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from product_entry where category_id='" + DropDownList3.SelectedItem.Value + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList5.DataSource = ds;
        DropDownList5.DataTextField = "product_name";
        DropDownList5.DataValueField = "code";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }
    private void show_category1()
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
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        est_cost();
    }
    public void est_cost()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from product_entry where product_name='" + DropDownList5.SelectedItem.Text + "' and category_name='" + DropDownList3.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "product_price";
        DropDownList2.DataValueField = "code";
        DropDownList2.DataBind();
      
        con.Close();
    }
    public void show_acc()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Account_Entry where Com_Id='" + company_id + "' ORDER BY Account_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);



        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "Acc_nickname";
        DropDownList4.DataValueField = "Account_id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("All", "0"));


        con.Close();

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Account_Entry where Acc_nickname='" + DropDownList4.SelectedItem.Text + "'  and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList6.DataSource = ds;
        DropDownList6.DataTextField = "Acc_No";
        DropDownList6.DataValueField = "Account_id";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Account_Entry where Acc_No='" + DropDownList6.SelectedItem.Text + "' and Acc_nickname='" + DropDownList4.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList7.DataSource = ds;
        DropDownList7.DataTextField = "Acc_name";
        DropDownList7.DataValueField = "Account_id";
        DropDownList7.DataBind();
        DropDownList7.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Account_Entry where Acc_name='" + DropDownList7.SelectedItem.Text + "' and Acc_No='" + DropDownList6.SelectedItem.Text + "' and Acc_nickname='" + DropDownList4.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList8.DataSource = ds;
        DropDownList8.DataTextField = "IFSC_Code";
        DropDownList8.DataValueField = "Account_id";
        DropDownList8.DataBind();
       
        con.Close();
    }
}