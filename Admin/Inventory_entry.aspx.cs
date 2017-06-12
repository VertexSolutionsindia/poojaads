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


public partial class Admin_Vendor : System.Web.UI.Page
{
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
                }
                con.Close();
            }
           
            getinvoiceno();
            show_category();
            showrating();
            BindData();
            show_product();
            active();
            created();
            show_vendor();
         
            show_ser();

           

        }

    }
   
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        Label29.Text = ROW.Cells[1].Text;
        TextBox6.Text = ROW.Cells[2].Text;
        TextBox16.Text = ROW.Cells[3].Text;
        TextBox5.Text = ROW.Cells[4].Text;
        TextBox7.Text = ROW.Cells[5].Text;
        TextBox8.Text = ROW.Cells[6].Text;
        TextBox9.Text = ROW.Cells[7].Text;
        TextBox10.Text = ROW.Cells[8].Text;
        TextBox1.Text = ROW.Cells[9].Text;
        TextBox14.Text = ROW.Cells[10].Text;
        TextBox15.Text = ROW.Cells[11].Text;
        TextBox21.Text = ROW.Cells[12].Text;
        this.ModalPopupExtender3.Show();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
       

        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("update Inventory set Taxi_Com='" + HttpUtility.HtmlDecode(TextBox6.Text) + "', Taxi_No='" + HttpUtility.HtmlDecode(TextBox16.Text) + "',Taxi_Drv_nme='" + HttpUtility.HtmlDecode(TextBox5.Text) + "',Taxi_Drvr_No='" + HttpUtility.HtmlDecode(TextBox7.Text) + "',Serv_name='" + HttpUtility.HtmlDecode(TextBox8.Text) + "',Durationfrm='" + HttpUtility.HtmlDecode(Convert.ToDateTime(TextBox9.Text).ToString("MM-dd-yyyy")) + "',durationto='" + HttpUtility.HtmlDecode(Convert.ToDateTime(TextBox10.Text).ToString("MM-dd-yyyy")) + "',cost='" + HttpUtility.HtmlDecode(TextBox1.Text) + "',due_date='" + HttpUtility.HtmlDecode(Convert.ToDateTime(TextBox14.Text).ToString("MM-dd-yyyy")) + "',advance='" + HttpUtility.HtmlDecode(TextBox15.Text) + "',balance='" + HttpUtility.HtmlDecode(TextBox21.Text) + "' where Invent_No='" + Label29.Text + "'  and Com_Id='" + company_id + "' ", CON);

        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();
        Label31.Text = "Updated successfuly";

        this.ModalPopupExtender3.Hide();
        BindData();
        getinvoiceno();
        show_vendor();

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd1 = new SqlCommand("delete from Vendor where Vendor_Code='" + Label29.Text + "' and Com_Id='" + company_id + "' ", con1);
        con1.Open();
        cmd1.ExecuteNonQuery();
        con1.Close();


        Label31.Text = "Deleted successfuly";

        this.ModalPopupExtender3.Hide();
        BindData();
        getinvoiceno();
        show_vendor();

    }
    protected void Button14_Click(object sender, EventArgs e)
    {
      
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            //Finiding checkbox control in gridview for particular row
            CheckBox chkdelete = (CheckBox)gvrow.FindControl("CheckBox3");
            //Condition to check checkbox selected or not
            if (chkdelete.Checked)
            {
                //Getting UserId of particular row using datakey value
                int usrid = Convert.ToInt32(gvrow.Cells[1].Text);
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Inventory where Invent_No='" + usrid + "' and Com_Id='" + company_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        BindData();
        getinvoiceno();

    }
    private void show_product()
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from product_entry where Com_Id='" + company_id + "' ORDER BY code asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "product_name";
        DropDownList1.DataValueField = "code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));


       

       
        con.Close();
    }

    private void show_vendor()
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Inventory where Com_Id='" + company_id + "' ORDER BY Invent_No asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Taxi_Com";
        DropDownList2.DataValueField = "Invent_No";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));


     


        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox19.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter Taxi Driver No')", true);
        }
        else if (DropDownList1.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please Select Service Type')", true);
        }
        else if (TextBox17.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter Due Date')", true);
        }
        else
        {
          

            SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("insert into Inventory values(@Invent_No,@Taxi_Com,@Taxi_No,@Taxi_Drv_nme,@Taxi_Drvr_No,@Serv_type,@Serv_name,@Durationfrm,@durationto,@cost,@due_date,@advance,@balance,@Com_Id)", CON);
            cmd.Parameters.AddWithValue("@Invent_No", Label1.Text);
            cmd.Parameters.AddWithValue("@Taxi_Com", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Taxi_No", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Taxi_Drv_nme", TextBox18.Text);
            cmd.Parameters.AddWithValue("@Taxi_Drvr_No", TextBox19.Text);
            cmd.Parameters.AddWithValue("@Serv_type", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Serv_name", DropDownList6.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Durationfrm", Convert.ToDateTime(TextBox11.Text).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@durationto", Convert.ToDateTime(TextBox12.Text).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@cost", TextBox4.Text);
            cmd.Parameters.AddWithValue("@due_date", Convert.ToDateTime(TextBox17.Text).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@advance", TextBox13.Text);
            cmd.Parameters.AddWithValue("@balance", TextBox20.Text);
            cmd.Parameters.AddWithValue("@Com_Id", company_id);
            CON.Open();
            cmd.ExecuteNonQuery();
            CON.Close();

             

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Display Management created successfully')", true);
            BindData();
            show_category();
            getinvoiceno();
            show_product();
            show_vendor();
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox18.Text = "";
            TextBox19.Text = "";
            DropDownList1.SelectedItem.Text="All";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox4.Text = "";
            TextBox17.Text = "";
            TextBox13.Text = "";
            TextBox20.Text = "";
         
            
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        BindData();
        show_category();
        getinvoiceno();
        show_product();
        show_vendor();
        TextBox3.Text = "";
        TextBox2.Text = "";
        TextBox18.Text = "";
        TextBox19.Text = "";
        DropDownList1.SelectedItem.Text = "All";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox4.Text = "";
        TextBox17.Text = "";
        TextBox13.Text = "";
        TextBox20.Text = "";

      
    }
    private void active()
    {

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
                cmd.CommandText = "select distinct Taxi_Drvr_No from Inventory where Com_Id=@Com_Id and " +
                "Taxi_Drvr_No like @Taxi_Drvr_No + '%'";
                cmd.Parameters.AddWithValue("@Taxi_Drvr_No", prefixText);
                cmd.Parameters.AddWithValue("@Com_Id",company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Taxi_Drvr_No"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    //protected void TextBox15_TextChanged(object sender, EventArgs e)
    //{
    //    SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //    SqlCommand CMD = new SqlCommand("select * from Vendor where Mobile_no='" + TextBox1.Text + "' and Com_Id='" + company_id + "' ", con1);
    //    DataTable dt1 = new DataTable();
    //    con1.Open();
    //    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
    //    da1.Fill(dt1);
    //    GridView1.DataSource = dt1;
    //    GridView1.DataBind();
    //}
  
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
        SqlCommand CMD = new SqlCommand("select * from Inventory where Com_Id='" + company_id + "' ORDER BY Invent_No asc", con);
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

        con.Open();
        SqlCommand cmd = new SqlCommand("delete from Inventory where Invent_No='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();
       
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Inventory deleted successfully')", true);

        BindData();
        show_category();
        getinvoiceno();


    }
    private void getinvoiceno()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select Count(Invent_No) from Inventory where Com_Id='" + company_id + "'";
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
    private void show_category()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Inventory where Com_Id='" + company_id + "' ORDER BY Invent_No asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "Taxi_Com";
        DropDownList2.DataValueField = "Invent_No";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));

        con.Close();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TaxNo();
    }

    private void TaxNo()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Inventory where Taxi_Com ='" + DropDownList2.SelectedItem.Text + "' and  Com_Id='" + company_id + "' ORDER BY Invent_No asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList5.DataSource = ds;
        DropDownList5.DataTextField = "Taxi_No";
        DropDownList5.DataValueField = "Invent_No";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("All", "0"));

        con.Close();

    }
     protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
     {


        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Inventory where Taxi_No ='" + DropDownList5.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
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
    protected void Button5_Click(object sender, EventArgs e)
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

    protected void TextBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("select * from Customer_Entry where Custom_Name='" + TextBox3.Text + "' and Com_Id='" + company_id + "'", con);
        SqlDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TextBox2.Text = dr["Custom_Add"].ToString();

        }
        con.Close();
    }
    public void show_ser()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from category where Com_Id='" + company_id + "' ORDER BY category_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);



        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "categoryname";
        DropDownList1.DataValueField = "category_id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));


        con.Close();
        show_name();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            show_name();
        
    }
    private void show_name()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from service_name where servicetype_name='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList6.DataSource = ds;
        DropDownList6.DataTextField = "servicename";
        DropDownList6.DataValueField = "servicename_id";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("All", "0"));

        con.Close();
    }
        
    
    protected void DropDownLis6_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from product_entry where product_name='" + DropDownList6.SelectedItem.Text + "' and category_name='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
       
        SqlDataReader dr1;
        dr1 = cmd.ExecuteReader();
        if (dr1.Read())
        {



            TextBox4.Text = dr1["product_price"].ToString();
        }
        con.Close();
    }
    protected void TextBox13_SelectedIndexChanged(object sender, EventArgs e)
    {
       
 
    }


   
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
        if (TextBox13.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter Advance Amount')", true);
        }
        else if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please Cost of the service ')", true);
        }
        else
        {

            TextBox20.Text = (Double.Parse(TextBox4.Text) - Double.Parse(TextBox13.Text)).ToString();
        }
       
    }
}