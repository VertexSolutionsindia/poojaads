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

using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
#endregion

public partial class Admin_Agent_bill : System.Web.UI.Page
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
                    Label2.Text = dr["company_name"].ToString();
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
                Label4.Text = dr10["financial_year"].ToString();
            }
            con10.Close();
            getinvoiceno();
        
            showrating();
            BindData2();
            show_department();
            active();
            created();
            getclient();
            gettype();
            getservicename();
            TextBox1.Visible = false;
        }
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        float bill = float.Parse(TextBox6.Text);
        float paid = float.Parse(TextBox7.Text);
        float pending = bill - paid;
        TextBox9.Text = pending.ToString();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd10 = new SqlCommand("select * from service_name where servicename='"+DropDownList4.SelectedItem.Text+"'", con10);
        SqlDataReader dr10;
        con10.Open();
        dr10 = cmd10.ExecuteReader();
        if (dr10.Read())
        {
            TextBox2.Text = dr10["size"].ToString();
            TextBox6.Text = dr10["mrp"].ToString();
        }
        con10.Close();
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
   
    public void getclient()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Agent_Entry where Com_Id='" + company_id + "' ORDER BY Custom_Code asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);



        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Custom_Name";
        DropDownList1.DataValueField = "Custom_Code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));

        con.Close();

    }
    
  
   
   
   

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox3.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter employee name')", true);
        }
        else if (TextBox13.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter mobile no')", true);
        }
        else
        {


            SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("insert into Staff_Entry values(@Emp_Code,@Emp_Name,@Emp_Add,@Com_Id,@Mob_No,@salary)", CON);
           
            CON.Open();
            cmd.ExecuteNonQuery();
            CON.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Staff Entry created successfully')", true);
          
            getinvoiceno();
          
            show_department();

            TextBox13.Text = "";
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
       
      
        show_department();

       
        getinvoiceno();
     
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
    
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

        con.Open();
        SqlCommand cmd = new SqlCommand("delete from Staff_Entry where Emp_Code='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        cmd.ExecuteNonQuery();
        con.Close();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Staff Details deleted successfully')", true);

     
        getinvoiceno();


    }
    private void getinvoiceno()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select Max(bill_no) from agent_bill where Com_Id='" + company_id + "' and year='" + Label4.Text + "'";
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
    
    private void show_department()
    {



        //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        //SqlCommand cmd = new SqlCommand("Select * from Department where Com_Id='" + company_id + "' ORDER BY Depart_Code asc", con);
        //con.Open();
        //DataSet ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(ds);


        //DropDownList1.DataSource = ds;
        //DropDownList1.DataTextField = "Depart_Name";
        //DropDownList1.DataValueField = "Depart_Code";
        //DropDownList1.DataBind();
        //DropDownList1.Items.Insert(0, new ListItem("All", "0"));

        //DropDownList3.DataSource = ds;
        //DropDownList3.DataTextField = "Depart_Name";
        //DropDownList3.DataValueField = "Depart_Code";
        //DropDownList3.DataBind();
        //DropDownList3.Items.Insert(0, new ListItem("All", "0"));

        //con.Close();
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
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

        con.Open();

        SqlCommand cmd2 = new SqlCommand("select * from Agent_Entry where Custom_Name='" + DropDownList1.SelectedItem.Text + "' and Com_Id='"+company_id+"'", con);
        SqlDataReader dr1;
        dr1 = cmd2.ExecuteReader();
        if (dr1.Read())
        {


            TextBox13.Text = dr1["Custom_Add"].ToString();
         

        }
        con.Close();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        getservicename();
    }

    private void getservicename()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from service_name where servicetype_name='" + DropDownList3.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "servicename";
        DropDownList4.DataValueField = "servicename_id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("All", "0"));

        con.Close();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        getinvoiceno();
        TextBox3.Text = "";
        getservicename();
        gettype();
        getclient();
        TextBox13.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox9.Text = "";
        BindData2();
        TextBox1.Visible = false;
        
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        getinvoiceno();
        TextBox3.Text = "";
        getservicename();
        gettype();
        getclient();
        TextBox13.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox9.Text = "";
        BindData2();
        TextBox1.Visible = false;
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
                SqlCommand cmd21 = new SqlCommand("select max(Invoice_no) from Order_entry where  Com_Id='" + company_id + "' and year='" + Label4.Text + "' ", con21);
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
                }
                con21.Close();
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from  agent_bill where bill_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    TextBox3.Text = Convert.ToDateTime(dr2["bill_date"]).ToString("dd-MM-yyyy");
                    DropDownList1.SelectedItem.Text = dr2["agent_name"].ToString();
                    TextBox13.Text = dr2["agent_add"].ToString();
                    TextBox10.Text = Convert.ToDateTime(dr2["fromdate"]).ToString("dd-MM-yyyy");
                    TextBox11.Text = Convert.ToDateTime(dr2["todate"]).ToString("dd-MM-yyyy");
                    DropDownList3.SelectedItem.Text = dr2["service_type"].ToString();
                    TextBox1.Visible = true;
                    TextBox1.Text = dr2["service_name"].ToString();
                    TextBox6.Text = dr2["bill_amount"].ToString();
                    TextBox7.Text = dr2["paid_amount"].ToString();
                    TextBox9.Text = dr2["pending_amount"].ToString();
                    TextBox2.Text = dr2["size"].ToString();
                    getservicename();
                }
                else
                {

                    getinvoiceno();
                    TextBox3.Text = "";
                    getservicename();
                    gettype();
                    getclient();
                    TextBox13.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox9.Text = "";
                    BindData2();

                }
                con2.Close();
            }
            con1000.Close();
        }
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

                if (Convert.ToInt32(Label1.Text) > Convert.ToInt32(1))
                {
                    Label1.Text = (Convert.ToInt32(Label1.Text) - 1).ToString();
                }

                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from  agent_bill where bill_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    TextBox3.Text = Convert.ToDateTime(dr2["bill_date"]).ToString("dd-MM-yyyy");
                    DropDownList1.SelectedItem.Text = dr2["agent_name"].ToString();
                    TextBox13.Text = dr2["agent_add"].ToString();
                    TextBox10.Text = Convert.ToDateTime(dr2["fromdate"]).ToString("dd-MM-yyyy");
                    TextBox11.Text = Convert.ToDateTime(dr2["todate"]).ToString("dd-MM-yyyy");
                    DropDownList3.SelectedItem.Text = dr2["service_type"].ToString();
                    TextBox1.Visible = true;
                    TextBox1.Text = dr2["service_name"].ToString();
                    TextBox6.Text = dr2["bill_amount"].ToString();
                    TextBox7.Text = dr2["paid_amount"].ToString();
                    TextBox9.Text = dr2["pending_amount"].ToString();
                    TextBox2.Text = dr2["size"].ToString();
                    getservicename();
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
    protected void Button9_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select bill date')", true);
        }
        else if (DropDownList1.SelectedItem.Text == "All")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select Agent Name')", true);
            }
        else if (TextBox10.Text==""|| TextBox11.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select from and to date')", true);
        }
        else if (DropDownList3.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select service type')", true);
        }
        else if (DropDownList4.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please select service Name')", true);
        }
        else if (TextBox7.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please give paid amount')", true);
        }

        else
        {
            SqlConnection CON1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from agent_bill where bill_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", CON1);
            CON1.Open();
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                string status = "Agent Bill";
                float value = 0;
                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("update agent_bill set bill_date=@bill_date,agent_name=@agent_name,agent_add=@agent_add,fromdate=@fromdate,todate=@todate,service_type=@service_type,service_name=@service_name,bill_amount=@bill_amount,paid_amount=@paid_amount,pending_amount=@pending_amount,status=@status,value=@value,size=@size where bill_no=@bill_no and Com_Id=@Com_Id and year=@year", CON);
                cmd.Parameters.AddWithValue("@bill_no", Label1.Text);
                cmd.Parameters.AddWithValue("@bill_date", Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@agent_name", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@agent_add", TextBox13.Text);
                cmd.Parameters.AddWithValue("@fromdate", Convert.ToDateTime(TextBox10.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@todate", Convert.ToDateTime(TextBox11.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@service_type", DropDownList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@service_name", DropDownList4.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@bill_amount", TextBox6.Text);
                cmd.Parameters.AddWithValue("@paid_amount", TextBox7.Text);
                cmd.Parameters.AddWithValue("@pending_amount", TextBox9.Text);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Parameters.AddWithValue("@year", Label4.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.Parameters.AddWithValue("@size", TextBox2.Text);



                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();

                float b11 = 0;
                float f11 = 0;
                float c11 = 0;

                SqlConnection con100 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name100 = new SqlCommand("SELECT * FROM receive_amount_status WHERE Buyer = @Buyer and Com_Id='" + company_id + "' and year='" + Label4.Text + "' ", con100);
                check_User_Name100.Parameters.AddWithValue("@Buyer", DropDownList1.SelectedItem.Text);
                con100.Open();
                SqlDataReader reader100 = check_User_Name100.ExecuteReader();
                if (reader100.HasRows)
                {
                    SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd111 = new SqlCommand("Select * from receive_amount where Buyer='" + DropDownList1.SelectedItem.Text + "' and invoice_no='" + Label1.Text + "'  and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con111);
                    con111.Open();
                    SqlDataReader dr111;
                    dr111 = cmd111.ExecuteReader();
                    if (dr111.Read())
                    {

                        b11 = float.Parse(dr111["pending_amount"].ToString());






                        SqlConnection con27 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd27 = new SqlCommand("update receive_amount_status set pending_amount=pending_amount-@pending_amount where Buyer='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con27);
                        cd27.Parameters.AddWithValue("@pending_amount", b11);
                        con27.Open();
                        cd27.ExecuteNonQuery();
                        con27.Close();

                        SqlConnection con272 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd272 = new SqlCommand("update receive_amount set pending_amount=pending_amount-@pending_amount,outstanding=outstanding-@outstanding where Buyer='" + DropDownList1.SelectedItem.Text + "' and  invoice_no='" + Label1.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "' ", con272);
                        cd272.Parameters.AddWithValue("@pending_amount", b11);
                        cd272.Parameters.AddWithValue("@outstanding", b11);
                        con272.Open();
                        cd272.ExecuteNonQuery();
                        con272.Close();

                        SqlConnection con271 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd271 = new SqlCommand("update receive_amount_status set pending_amount=pending_amount+@pending_amount where Buyer='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con271);
                        cd271.Parameters.AddWithValue("@pending_amount", float.Parse(TextBox9.Text));
                        con271.Open();
                        cd271.ExecuteNonQuery();
                        con271.Close();



                        float paid_amount = 0;
                        string status1 = "Agent Bill";
                        SqlConnection con26 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd26 = new SqlCommand("update receive_amount set Estimate_value=@Estimate_value,address=@address,total_amount=@total_amount,pay_amount=@pay_amount,pending_amount=@pending_amount,outstanding=outstanding+@outstanding,status=@status where Buyer='" + DropDownList1.SelectedItem.Text + "' AND invoice_no='" + Label1.Text + "' and year='" + Label4.Text + "'", con26);


                        cmd26.Parameters.AddWithValue("@Estimate_value", float.Parse(TextBox6.Text));
                        cmd26.Parameters.AddWithValue("@address", TextBox3.Text);

                        cmd26.Parameters.AddWithValue("@total_amount", float.Parse(TextBox6.Text));
                        cmd26.Parameters.AddWithValue("@pay_amount", TextBox7.Text);
                        cmd26.Parameters.AddWithValue("@pending_amount", float.Parse(TextBox9.Text));
                        cmd26.Parameters.AddWithValue("@outstanding", float.Parse(TextBox9.Text));
                        cmd26.Parameters.AddWithValue("@status", status1);


                        con26.Open();
                        cmd26.ExecuteNonQuery();
                        con26.Close();



                    }
                    con111.Close();
                }

                con100.Close();


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Order Details updated successfully')", true);

                //show_category();
                getinvoiceno();
                TextBox3.Text = "";
                getservicename();
                gettype();
                getclient();
                TextBox13.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox9.Text = "";
                BindData2();
                TextBox1.Visible = false;
            }
            else
            {
                string status = "Agent Bill";
                float value = 0;
                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("insert into agent_bill values(@bill_no,@bill_date,@agent_name,@agent_add,@fromdate,@todate,@service_type,@service_name,@bill_amount,@paid_amount,@pending_amount,@Com_Id,@year,@status,@value,@size)", CON);
                cmd.Parameters.AddWithValue("@bill_no", Label1.Text);
                cmd.Parameters.AddWithValue("@bill_date", Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@agent_name", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@agent_add", TextBox13.Text);
                cmd.Parameters.AddWithValue("@fromdate", Convert.ToDateTime(TextBox10.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@todate", Convert.ToDateTime(TextBox11.Text).ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@service_type", DropDownList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@service_name", DropDownList4.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@bill_amount", TextBox6.Text);
                cmd.Parameters.AddWithValue("@paid_amount", TextBox7.Text);
                cmd.Parameters.AddWithValue("@pending_amount", TextBox9.Text);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Parameters.AddWithValue("@year",Label4.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.Parameters.AddWithValue("@size",TextBox2.Text);
                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();

                int a111 = 0;
                float b11 = 0;
                float f11 = 0;
                float c11 = 0;
                SqlConnection con100 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd100 = new SqlCommand("SELECT * FROM receive_amount_status WHERE Buyer = @Buyer and Com_Id='" + company_id + "'", con100);
                cmd100.Parameters.AddWithValue("@Buyer", DropDownList1.SelectedItem.Text);
                con100.Open();
                SqlDataReader reader1 = cmd100.ExecuteReader();
                if (reader1.HasRows)
                {
                    SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd111 = new SqlCommand("Select * from receive_amount_status where Buyer='" + DropDownList1.SelectedItem.Text + "' and  Com_Id='" + company_id + "' ", con111);
                    con111.Open();
                    SqlDataReader dr111;
                    dr111 = cmd111.ExecuteReader();
                    if (dr111.Read())
                    {

                        b11 = float.Parse(dr111["pending_amount"].ToString());


                        f11 = float.Parse(TextBox9.Text);

                        c11 = (b11 + f11);




                        float paid_amount = 0;
                        string status1 = "Bill";
                        SqlConnection con24 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd24 = new SqlCommand("insert into receive_amount values(@Buyer,@Pay_date,@Estimate_value,@address,@total_amount,@pay_amount,@pending_amount,@outstanding,@invoice_no,@Com_Id,@status,@year)", con24);
                        cmd24.Parameters.AddWithValue("@Buyer", DropDownList1.SelectedItem.Text);
                        cmd24.Parameters.AddWithValue("@pay_date", Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy"));
                        cmd24.Parameters.AddWithValue("@Estimate_value", float.Parse(TextBox6.Text));
                        cmd24.Parameters.AddWithValue("@address", TextBox13.Text);

                        cmd24.Parameters.AddWithValue("@total_amount", float.Parse(string.Format("{0:0.00}", TextBox6.Text)));
                        cmd24.Parameters.AddWithValue("@pay_amount", TextBox7.Text);
                        cmd24.Parameters.AddWithValue("@pending_amount", float.Parse(string.Format("{0:0.00}", TextBox9.Text)));
                        cmd24.Parameters.AddWithValue("@outstanding", float.Parse(string.Format("{0:0.00}", c11)));

                        cmd24.Parameters.AddWithValue("@invoice_no", Label1.Text);
                        cmd24.Parameters.AddWithValue("@Com_Id", company_id);
                        cmd24.Parameters.AddWithValue("@status", status1);
                        cmd24.Parameters.AddWithValue("@year", Label4.Text);
                        con24.Open();
                        cmd24.ExecuteNonQuery();
                        con24.Close();


                        SqlConnection con23 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd23 = new SqlCommand("update receive_amount_status set address=@address,total_amount=total_amount+@total_amount,pending_amount=pending_amount+@pending_amount where Buyer='" + DropDownList1.SelectedItem.Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con23);

                        cmd23.Parameters.AddWithValue("@address", TextBox13.Text);

                        cmd23.Parameters.AddWithValue("@total_amount", float.Parse(string.Format("{0:0.00}", TextBox6.Text)));

                        cmd23.Parameters.AddWithValue("@pending_amount", float.Parse(string.Format("{0:0.00}", TextBox9.Text)));

                        con23.Open();
                        cmd23.ExecuteNonQuery();
                        con23.Close();


                    }

                    con111.Close();






                }
                else
                {
                    float paid_amount = 0;
                    string status1 = "Bill";
                    SqlConnection con23 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd23 = new SqlCommand("insert into receive_amount_status values(@Buyer,@address,@total_amount,@pending_amount,@paid_amount,@Com_Id,@year)", con23);
                    cmd23.Parameters.AddWithValue("@Buyer", DropDownList1.SelectedItem.Text);
                    cmd23.Parameters.AddWithValue("@address", TextBox13.Text);

                    cmd23.Parameters.AddWithValue("@total_amount", float.Parse(string.Format("{0:0.00}", TextBox6.Text)));

                    cmd23.Parameters.AddWithValue("@pending_amount", float.Parse(string.Format("{0:0.00}", TextBox9.Text)));
                    cmd23.Parameters.AddWithValue("@paid_amount", float.Parse(string.Format("{0:0.00}", TextBox7.Text)));
                    cmd23.Parameters.AddWithValue("@Com_Id", company_id);
                    cmd23.Parameters.AddWithValue("@year", Label4.Text);
                    con23.Open();
                    cmd23.ExecuteNonQuery();
                    con23.Close();
                    string return_by = "";
                    int value1 = 0;
                    SqlConnection con24 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd24 = new SqlCommand("insert into receive_amount values(@Buyer,@Pay_date,@Estimate_value,@address,@total_amount,@pay_amount,@pending_amount,@outstanding,@invoice_no,@Com_Id,@status,@year)", con24);
                    cmd24.Parameters.AddWithValue("@Buyer", DropDownList1.SelectedItem.Text);
                    cmd24.Parameters.AddWithValue("@pay_date", Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy"));
                    cmd24.Parameters.AddWithValue("@Estimate_value", float.Parse(TextBox6.Text));
                    cmd24.Parameters.AddWithValue("@address", TextBox13.Text);

                    cmd24.Parameters.AddWithValue("@total_amount", float.Parse(string.Format("{0:0.00}", TextBox6.Text)));
                    cmd24.Parameters.AddWithValue("@pay_amount", TextBox7.Text);
                    cmd24.Parameters.AddWithValue("@pending_amount", float.Parse(string.Format("{0:0.00}", TextBox9.Text)));
                    cmd24.Parameters.AddWithValue("@outstanding", float.Parse(string.Format("{0:0.00}", TextBox9.Text)));
                    cmd24.Parameters.AddWithValue("@invoice_no", Label1.Text);
                    cmd24.Parameters.AddWithValue("@Com_Id", company_id);
                    cmd24.Parameters.AddWithValue("@status", status1);
                    cmd24.Parameters.AddWithValue("@year", Label4.Text);
                    con24.Open();
                    cmd24.ExecuteNonQuery();
                    con24.Close();


                }
                con100.Close();



                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Order Details created successfully')", true);

                //show_category();
                getinvoiceno();
                TextBox3.Text = "";
                getservicename();
                gettype();
                getclient();
                TextBox13.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox9.Text = "";
                BindData2();
                TextBox1.Visible = false;
            }
            CON1.Close();

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
                SqlCommand cmd2 = new SqlCommand("select * from agent_bill where bill_no='" + row.Cells[0].Text + "' and Com_Id='" + company_id + "' and year='" + Label4.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    Label1.Text = dr2["bill_no"].ToString();
                    TextBox3.Text = Convert.ToDateTime(dr2["bill_date"]).ToString("dd-MM-yyyy");
                    DropDownList1.SelectedItem.Text = dr2["agent_name"].ToString();
                    TextBox13.Text = dr2["agent_add"].ToString();
                    TextBox10.Text = Convert.ToDateTime(dr2["fromdate"]).ToString("dd-MM-yyyy");
                    TextBox11.Text = Convert.ToDateTime(dr2["todate"]).ToString("dd-MM-yyyy");
                    DropDownList3.SelectedItem.Text = dr2["service_type"].ToString();
                    TextBox1.Visible = true;
                    TextBox1.Text = dr2["service_name"].ToString();
                    TextBox6.Text = dr2["bill_amount"].ToString();
                    TextBox7.Text = dr2["paid_amount"].ToString();
                    TextBox9.Text = dr2["pending_amount"].ToString();
                    TextBox2.Text = dr2["size"].ToString();
                    getservicename();
                }
                con2.Close();

            }
            con1000.Close();
        }
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
                SqlCommand CMD = new SqlCommand("select * from agent_bill where Com_Id='" + company_id + "' and year='" + Label4.Text + "' ORDER BY bill_no asc", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView3.DataSource = dt1;
                GridView3.DataBind();
            }
            con1000.Close();
        }

    }
}