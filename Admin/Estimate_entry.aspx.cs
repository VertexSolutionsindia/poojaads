
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






public partial class Admin_Sales_entry : System.Web.UI.Page
{
    float tot = 0;
    public static int company_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (User.Identity.IsAuthenticated)
            {
                SqlConnection con1000 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd1000 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1000);
                SqlDataReader dr1000;
                con1000.Open();
                dr1000 = cmd1000.ExecuteReader();
                if (dr1000.Read())
                {
                    company_id = Convert.ToInt32(dr1000["com_id"].ToString());
                    Label3.Text = dr1000["company_name"].ToString();
                }

                con1000.Close();
            }
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd10 = new SqlCommand("select * from currentfinancialyear where no='1'", con10);
            SqlDataReader dr10;
            con10.Open();
            dr10 = cmd10.ExecuteReader();
            if (dr10.Read())
            {
                Label2.Text = dr10["financial_year"].ToString();
            }
            con10.Close();


            

           
            DateTime date = DateTime.Now;
            TextBox20.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
           
            getinvoiceno();
            getinvoiceno1();
            //show_category();

            BindData();



            gettype();
            getclient();
            BindData2();



        }

    }
   
    
   

   
    

    //A method that returns a string which calls the connection string from the web.config
    protected void Button9_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select Client Name')", true);
        }
        else if (TextBox7.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please add Products')", true);
        }

        else
        {
            SqlConnection CON1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from estimate_entry where Invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", CON1);
            CON1.Open();
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("update estimate_entry set client_name=@client_name,cl_code=@cl_code,cl_add=@cl_add,mobile=@mobile,date=@date,Total=@Total,grand_total=@grand_total,Com_Id=@Com_Id where Invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", CON);
                cmd.Parameters.AddWithValue("@Invoice_no", Label1.Text);
                cmd.Parameters.AddWithValue("@client_name", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@cl_code", TextBox8.Text);
                cmd.Parameters.AddWithValue("@cl_add", TextBox2.Text);
                cmd.Parameters.AddWithValue("@mobile", TextBox4.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(TextBox20.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@Total", TextBox7.Text);
             
                cmd.Parameters.AddWithValue("@grand_total", TextBox14.Text);
             
              
             
                cmd.Parameters.AddWithValue("@Com_Id", company_id);




                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Order Details updated successfully')", true);

                //show_category();
                getinvoiceno();
                getinvoiceno1();
                BindData();
                BindData2();
                getclient();
                TextBox8.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = "";

               
                TextBox7.Text = "";
                TextBox14.Text = "";
              
                DateTime date = DateTime.Now;
                TextBox20.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
              
            }
            else
            {
                string status = "Order Bill";
                float value = 0;
                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("insert into estimate_entry values(@Invoice_no,@client_name,@cl_code,@cl_add,@mobile,@date,@Total,@grand_total,@Com_Id,@year,@status,@value)", CON);
                cmd.Parameters.AddWithValue("@Invoice_no", Label1.Text);
                cmd.Parameters.AddWithValue("@client_name", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@cl_code", TextBox8.Text);
                cmd.Parameters.AddWithValue("@cl_add", TextBox2.Text);
                cmd.Parameters.AddWithValue("@mobile", TextBox4.Text);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(TextBox20.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@Total", TextBox7.Text);
             
                cmd.Parameters.AddWithValue("@grand_total", TextBox14.Text);
           
         
           
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Parameters.AddWithValue("@year", Label2.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@value", value);
                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Order Details created successfully')", true);

                //show_category();
                getinvoiceno();
                getinvoiceno1();
                BindData();
                BindData2();
                getclient();
                TextBox8.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = "";

               
            
                TextBox7.Text = "";
                TextBox14.Text = "";
              
                DateTime date = DateTime.Now;
                TextBox20.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
              
            }
            CON1.Close();

        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        getinvoiceno();
        TextBox2.Text = "";
        TextBox4.Text = "";

        TextBox8.Text = "";


        TextBox20.Text = "";
        getclient();
        DropDownList3.SelectedItem.Text = "All";
        DropDownList5.SelectedItem.Text = "All";
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;


        LinkButton Lnk = (LinkButton)sender;
        string name = Lnk.Text;
        Session["name"] = name;
        Response.Redirect("Account_show.aspx");


    }


    protected void BindData()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from estimate_entry_details where invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "' ORDER BY s_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }



    private void getinvoiceno()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select max(invoice_no) from estimate_entry where Com_Id='" + company_id + "' and year='" + Label2.Text + "'";
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
                TextBox3.Text = a.ToString();
                a = a + 1;
                Label1.Text = a.ToString();
            }
        }
    }
    private void getinvoiceno1()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select max(s_no) from estimate_entry_details where invoice_no='" + Label1.Text + "' and  Com_Id='" + company_id + "' and year='" + Label2.Text + "'";
        SqlCommand cmd1 = new SqlCommand(query, con1);
        SqlDataReader dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            string val = dr[0].ToString();
            if (val == "")
            {
                Label9.Text = "1";
            }
            else
            {
                a = Convert.ToInt32(dr[0].ToString());
                a = a + 1;
                Label9.Text = a.ToString();
            }
        }
        con1.Close();
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






    private void gettype()
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
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

        con.Open();

        SqlCommand cmd2 = new SqlCommand("select * from service_name where servicename='" + DropDownList5.SelectedItem.Text + "'", con);
        SqlDataReader dr1;
        dr1 = cmd2.ExecuteReader();
        if (dr1.Read())
        {


            TextBox29.Text = dr1["mrp"].ToString();
            TextBox25.Text = "1";
            TextBox24.Text = dr1["size"].ToString();

            string duration = dr1["width_Height"].ToString();



            int count = 0;
            string[] ar = { "/" };
            foreach (string value in duration.Split(ar, StringSplitOptions.RemoveEmptyEntries))
            {
                if (count == 0) // add it to the first text box
                {
                    TextBox5.Text = value;
                    count++; // increment count to add the next value after the split in the another text box
                }
                else
                {
                    TextBox6.Text = value;
                }

            }
            float rate = float.Parse(TextBox29.Text);
            float qty = float.Parse(TextBox25.Text);
            float total = rate * qty;
            TextBox22.Text = total.ToString();

        }
        con.Close();


    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        est_cost();
    }
    public void est_cost()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from service_name where servicetype_name='" + DropDownList3.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList5.DataSource = ds;
        DropDownList5.DataTextField = "servicename";
        DropDownList5.DataValueField = "servicename_id";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("All", "0"));

        con.Close();

    }
    public void getclient()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Client_Entry where Com_Id='" + company_id + "' ORDER BY Client_Code asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);



        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Client_Name";
        DropDownList1.DataValueField = "Client_Code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));





        con.Close();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from Client_Entry where Client_Name='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        SqlDataReader dr1;
        dr1 = cmd.ExecuteReader();
        if (dr1.Read())
        {


            TextBox8.Text = dr1["Client_Code"].ToString();
            TextBox2.Text = dr1["Client_Add"].ToString();
            TextBox4.Text = dr1["Mobile_No"].ToString();

        }
        con.Close();


    }












    protected void Button4_Click(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select service type')", true);
        }
        else if (DropDownList5.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select service name')", true);
        }
        else
        {
            SqlConnection CON1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from estimate_entry_details where Invoice_no='" + Label1.Text + "' and s_no='" + Label9.Text + "' and Com_Id='" + company_id + "' And year='" + Label2.Text + "'", CON1);
            CON1.Open();
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("update estimate_entry_details set service_type=@service_type,Service_name=@Service_name,Duration=@Duration,Size=@Size,rate=@rate,qty=@qty,Amount=@Amount,wtdth_hright=@wtdth_hright where invoice_no=@invoice_no and s_no=@s_no and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", CON);
                cmd.Parameters.Add("@invoice_no", Label1.Text);
                cmd.Parameters.Add("@s_no", Label9.Text);
                cmd.Parameters.Add("@service_type", DropDownList3.SelectedItem.Text);
                cmd.Parameters.Add("@Service_name", DropDownList5.SelectedItem.Text);
                cmd.Parameters.Add("@Duration", TextBox23.Text);
                cmd.Parameters.Add("@Size", TextBox24.Text);
                cmd.Parameters.Add("@rate", TextBox29.Text);
                cmd.Parameters.AddWithValue("@qty", TextBox25.Text);
                cmd.Parameters.Add("@Amount", TextBox22.Text);
                cmd.Parameters.Add("@wtdth_hright", TextBox5.Text + "/" + TextBox6.Text);





                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();

                BindData();
                getinvoiceno1();
                est_cost();
                gettype();
                TextBox23.Text = "";
              
                TextBox24.Text = "";
                TextBox29.Text = "";
                TextBox25.Text = "";
                TextBox22.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
            else
            {


                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("insert into estimate_entry_details values(@invoice_no,@s_no,@service_type,@Service_name,@Duration,@Size,@rate,@qty,@Amount,@Com_Id,@year,@wtdth_hright)", CON);
                cmd.Parameters.Add("@invoice_no", Label1.Text);
                cmd.Parameters.Add("@s_no", Label9.Text);
                cmd.Parameters.Add("@service_type", DropDownList3.SelectedItem.Text);
                cmd.Parameters.Add("@Service_name", DropDownList5.SelectedItem.Text);
                cmd.Parameters.Add("@Duration", TextBox23.Text);
                cmd.Parameters.Add("@Size", TextBox24.Text);
                cmd.Parameters.Add("@rate", TextBox29.Text);
                cmd.Parameters.AddWithValue("@qty", TextBox25.Text);
                cmd.Parameters.Add("@Amount", TextBox22.Text);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Parameters.Add("@year", Label2.Text);
                cmd.Parameters.Add("@wtdth_hright", TextBox5.Text + "/" + TextBox6.Text);



                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();

                BindData();
                getinvoiceno1();
                est_cost();
                gettype();
                TextBox23.Text = "";
           
                TextBox24.Text = "";
                TextBox29.Text = "";
                TextBox25.Text = "";
                TextBox22.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
        }
    }

    protected void TextBox29_TextChanged(object sender, EventArgs e)
    {
        float size = float.Parse(TextBox25.Text);
        float rate = float.Parse(TextBox29.Text);
        float total = size * rate;
        TextBox22.Text = total.ToString();
    }
    protected void TextBox25_TextChanged(object sender, EventArgs e)
    {
        float rate = float.Parse(TextBox29.Text);

        float qty = float.Parse(TextBox25.Text);
        float total1 = rate * qty;
        TextBox22.Text = total1.ToString();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            tot = tot + float.Parse(e.Row.Cells[8].Text);

        }
        TextBox7.Text = tot.ToString();
        TextBox14.Text = tot.ToString();
       
    }
    protected void TextBox24_TextChanged(object sender, EventArgs e)
    {
        float size = float.Parse(TextBox24.Text);
        float rate = float.Parse(TextBox29.Text);
        float total = size * rate;
        float qty = float.Parse(TextBox25.Text);
        float total1 = total * qty;
        TextBox22.Text = total1.ToString();
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        int sno = Convert.ToInt32(ROW.Cells[0].Text);

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("delete from estimate_entry_details where invoice_no='" + Label1.Text + "' and s_no='" + sno + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindData();
        getinvoiceno1();
    }

    protected void TextBox27_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        getinvoiceno();
        getinvoiceno1();
        BindData();
        getclient();
        TextBox8.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";

       
        TextBox7.Text = "";
        TextBox14.Text = "";
      
        DateTime date = DateTime.Now;
        TextBox20.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
      
        est_cost();
        gettype();
        TextBox23.Text = "";
     
        TextBox24.Text = "";
        TextBox29.Text = "";
        TextBox25.Text = "";
        TextBox22.Text = "";
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        getinvoiceno();
        getinvoiceno1();
        BindData();
        getclient();
        TextBox8.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";

     
       
        TextBox7.Text = "";
        TextBox14.Text = "";
      
        DateTime date = DateTime.Now;
        TextBox20.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
       
        est_cost();
        gettype();
        TextBox23.Text = "";
      
        TextBox24.Text = "";
        TextBox29.Text = "";
        TextBox25.Text = "";
        TextBox22.Text = "";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con1000 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1000 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1000);
            SqlDataReader dr1000;
            con1000.Open();
            dr1000 = cmd1000.ExecuteReader();
            if (dr1000.Read())
            {
                company_id = Convert.ToInt32(dr1000["com_id"].ToString());

                if (Convert.ToInt32(Label1.Text) > Convert.ToInt32(1) )
                {
                    Label1.Text = (Convert.ToInt32(Label1.Text) - 1).ToString();
                   
                }
                if (Convert.ToInt32(TextBox3.Text) > Convert.ToInt32(1))
                {
                   TextBox3.Text= (Convert.ToInt32(TextBox3.Text) - 1).ToString();
                   
                }
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from  estimate_entry where Invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    DropDownList1.SelectedItem.Text = dr2["client_name"].ToString();
                    TextBox8.Text = dr2["cl_code"].ToString();
                    TextBox2.Text = dr2["cl_add"].ToString();
                    TextBox4.Text = dr2["mobile"].ToString();
                    TextBox20.Text = Convert.ToDateTime(dr2["date"]).ToString("dd-MM-yyyy");
                    TextBox7.Text = dr2["Total"].ToString();
                    
                    TextBox14.Text = dr2["grand_total"].ToString();

                   
                }
                con2.Close();


                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand CMD = new SqlCommand("select * from estimate_entry_details where invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "' ORDER BY s_no asc", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                getinvoiceno1();
            }
            con1000.Close();
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con1000 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1000 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1000);
            SqlDataReader dr1000;
            con1000.Open();
            dr1000 = cmd1000.ExecuteReader();
            if (dr1000.Read())
            {
                company_id = Convert.ToInt32(dr1000["com_id"].ToString());

                SqlConnection con21 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd21 = new SqlCommand("select max(Invoice_no) from estimate_entry where  Com_Id='" + company_id + "' and year='" + Label2.Text + "' ", con21);
                SqlDataReader dr21;
                con21.Open();
                dr21 = cmd21.ExecuteReader();
                if (dr21.Read())
                {
                    int value = Convert.ToInt32(dr21[0].ToString());
                    if (Convert.ToInt32(Label1.Text) < Convert.ToInt32(value + 1))
                    {
                        Label1.Text = (Convert.ToInt32(Label1.Text) + 1).ToString();
                    }
                    if (Convert.ToInt32(TextBox3.Text) < Convert.ToInt32(value + 1))
                    {
                        TextBox3.Text = (Convert.ToInt32(TextBox3.Text) + 1).ToString();
                    }
                }
                con21.Close();
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from  estimate_entry where Invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    DropDownList1.SelectedItem.Text = dr2["client_name"].ToString();
                    TextBox8.Text = dr2["cl_code"].ToString();
                    TextBox2.Text = dr2["cl_add"].ToString();
                    TextBox4.Text = dr2["mobile"].ToString();
                    TextBox20.Text = Convert.ToDateTime(dr2["date"]).ToString("dd-MM-yyyy");
                    TextBox7.Text = dr2["Total"].ToString();
                 ;
                    TextBox14.Text = dr2["grand_total"].ToString();
                 
                
                   

                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand CMD = new SqlCommand("select * from estimate_entry_details where invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "' ORDER BY s_no asc", con);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                    da1.Fill(dt1);
                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                    getinvoiceno1();

                }
                else
                {

                    getinvoiceno();
                    getinvoiceno1();
                    BindData();
                    getclient();
                    TextBox8.Text = "";
                    TextBox2.Text = "";
                    TextBox4.Text = "";
                    TextBox20.Text = "";
                 
                  
                    TextBox7.Text = "";
                    TextBox14.Text = "";
                


                }
                con2.Close();
            }
            con1000.Close();
        }
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        this.ModalPopupExtender2.Show();
    }
    protected void BindData2()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con1000 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1000 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1000);
            SqlDataReader dr1000;
            con1000.Open();
            dr1000 = cmd1000.ExecuteReader();
            if (dr1000.Read())
            {
                company_id = Convert.ToInt32(dr1000["com_id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand CMD = new SqlCommand("select * from estimate_entry where Com_Id='" + company_id + "' and year='" + Label2.Text + "' ORDER BY  Invoice_no asc", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView3.DataSource = dt1;
                GridView3.DataBind();
            }
            con1000.Close();
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con1000 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1000 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1000);
            SqlDataReader dr1000;
            con1000.Open();
            dr1000 = cmd1000.ExecuteReader();
            if (dr1000.Read())
            {
                company_id = Convert.ToInt32(dr1000["com_id"].ToString());
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;




                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from estimate_entry where Invoice_no='" + row.Cells[0].Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    Label1.Text = dr2["Invoice_no"].ToString();
                    DropDownList1.SelectedItem.Text = dr2["client_name"].ToString();
                    TextBox8.Text = dr2["cl_code"].ToString();
                    TextBox2.Text = dr2["cl_add"].ToString();
                    TextBox4.Text = dr2["mobile"].ToString();
                    TextBox20.Text = Convert.ToDateTime(dr2["date"]).ToString("dd-MM-yyyy");
                    TextBox7.Text = dr2["Total"].ToString();
                 
                    TextBox14.Text = dr2["grand_total"].ToString();
                   
                  
                   

                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand CMD = new SqlCommand("select * from Order_entry_details where invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label2.Text + "' ORDER BY s_no asc", con);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                    da1.Fill(dt1);
                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                    getinvoiceno1();
                }
                con2.Close();

            }
            con1000.Close();
        }
    }
    #region " [ Button Event ] "
    protected void Button1_Click(object sender, EventArgs e)
    {
        // select appropriate contenttype, while binary transfer it identifies filetype
        string contentType = string.Empty;
        if (DropDownList2.SelectedValue.Equals(".pdf"))
            contentType = "application/pdf";
        if (DropDownList2.SelectedValue.Equals(".doc"))
            contentType = "application/ms-word";
        if (DropDownList2.SelectedValue.Equals(".xls"))
            contentType = "application/xls";

        DataTable dsData = new DataTable();

        DataSet ds = null;
        SqlDataAdapter da = null;



        try
        {
            string constring = ConfigurationManager.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("estimate_invoice", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@No", Convert.ToInt32(TextBox3.Text));
                    cmd.Parameters.AddWithValue("@Com_Id", Convert.ToInt32(company_id));
                    cmd.Parameters.AddWithValue("@year", Label2.Text);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds);
                    con.Close();

                }
            }
        }
        catch
        {
            throw;
        }



        dsData = ds.Tables[0];

        string FileName = "Estimate_" + TextBox3.Text + DropDownList2.SelectedValue;
        string extension;
        string encoding;
        string mimeType;
        string[] streams;
        Warning[] warnings;

        LocalReport report = new LocalReport();
        report.ReportPath = Server.MapPath("~/Admin/Report2.rdlc");
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
        rds.Value = dsData;
        report.DataSources.Add(rds);

        Byte[] mybytes = report.Render(DropDownList2.SelectedItem.Text, null,
                        out extension, out encoding,
                        out mimeType, out streams, out warnings); //for exporting to PDF
        using (FileStream fs = File.Create(Server.MapPath("~/img/") + FileName))
        {
            fs.Write(mybytes, 0, mybytes.Length);
        }

        Response.ClearHeaders();
        Response.ClearContent();
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = contentType;
        Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
        Response.WriteFile(Server.MapPath("~/img/" + FileName));
        Response.Flush();
        Response.Close();
        Response.End();





    }
    #endregion
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        int sno = Convert.ToInt32(ROW.Cells[0].Text);

        SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd2 = new SqlCommand("select * from estimate_entry_details where Invoice_no='" + Label1.Text + "' and s_no='" + sno + "' and Com_Id='" + company_id + "'", con2);
        SqlDataReader dr2;
        con2.Open();
        dr2 = cmd2.ExecuteReader();
        if (dr2.Read())
        {
            Label9.Text = dr2["s_no"].ToString();
            DropDownList3.SelectedItem.Text = dr2["service_type"].ToString();
            TextBox23.Text = dr2["Duration"].ToString();



           
            string duration1 = dr2["wtdth_hright"].ToString();



            int count1 = 0;
            string[] ar1 = { "/" };
            foreach (string value in duration1.Split(ar1, StringSplitOptions.RemoveEmptyEntries))
            {
                if (count1 == 0) // add it to the first text box
                {
                    TextBox5.Text = value;
                    count1++; // increment count to add the next value after the split in the another text box
                }
                else
                {
                    TextBox6.Text = value;
                }

            }


            TextBox24.Text = dr2["size"].ToString();
            TextBox29.Text = dr2["rate"].ToString();
            TextBox25.Text = dr2["qty"].ToString();
            TextBox22.Text = dr2["Amount"].ToString();

            est_cost();



        }
        con2.Close();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        BindData();
        getinvoiceno1();
        est_cost();
        gettype();
        TextBox23.Text = "";
    
        TextBox24.Text = "";
        TextBox29.Text = "";
        TextBox25.Text = "";
        TextBox22.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }
}