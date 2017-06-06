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


public partial class Admin_Department_Entry : System.Web.UI.Page
{
    float tot = 0;
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
            getinvoiceno1();
            //show_category();
            showrating();
            BindData();

            active();
            created();
            gettype();
            getclient();


           

        }

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        Session["supplier"] = ROW.Cells[0].Text;

        Response.Redirect("Oreders_Report.aspx");

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        Label29.Text = ROW.Cells[1].Text;
        TextBox16.Text = ROW.Cells[2].Text;
        TextBox9.Text = ROW.Cells[3].Text;
        TextBox5.Text = ROW.Cells[4].Text;
        TextBox6.Text = ROW.Cells[5].Text;
        TextBox10.Text = ROW.Cells[6].Text;
        TextBox1.Text = ROW.Cells[7].Text;
        TextBox3.Text = ROW.Cells[8].Text;
        TextBox18.Text = ROW.Cells[9].Text;
       
        this.ModalPopupExtender3.Show();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {

      

        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("update Order_entry set client_name='" + HttpUtility.HtmlDecode(TextBox16.Text) + "',cl_code='" + HttpUtility.HtmlDecode(TextBox9.Text) + "',cl_add='" + HttpUtility.HtmlDecode(TextBox5.Text) + "',mobile='" + HttpUtility.HtmlDecode(TextBox6.Text) + "',Serv_Type='" + HttpUtility.HtmlDecode(TextBox10.Text) + "',Serv_Name='" + HttpUtility.HtmlDecode(TextBox1.Text) + "',Timefrom='" + HttpUtility.HtmlDecode(TextBox3.Text) + "',timeto='" + HttpUtility.HtmlDecode(TextBox18.Text) + "' where id='" + Label29.Text + "'  and Com_Id='" + company_id + "' ", CON);

        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();
        Label31.Text = "Updated successfuly";

        this.ModalPopupExtender3.Hide();
        BindData();
        getinvoiceno();


    }
    protected void Button17_Click(object sender, EventArgs e)
    {
       

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd1 = new SqlCommand("delete from Department where Depart_Code='" + Label29.Text + "'  and Com_Id='" + company_id + "' ", con1);
        con1.Open();
        cmd1.ExecuteNonQuery();
        con1.Close();


        Label31.Text = "Deleted successfuly";

        this.ModalPopupExtender3.Hide();
        BindData();
        getinvoiceno();

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
                SqlCommand cmd = new SqlCommand("delete from Order_entry where id='" + usrid + "' and Com_Id='" + company_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        BindData();
        getinvoiceno();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please Client Name')", true);
        }
        
        else
        {

           

            SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("insert into Order_entry values(@id,@client_name,@cl_code,@cl_add,@mobile,@Serv_Type,@Serv_Name,@Timefrom,@timeto,@Serv_Cost,@advance,@blnce,@payment_clctd,@blnce_pay,@Com_Id,@total_amt,@Order_Date)", CON);
            cmd.Parameters.Add("@id",Label1.Text);
             cmd.Parameters.Add("@client_name",DropDownList1.SelectedItem.Text);
             cmd.Parameters.Add("@cl_code",TextBox8.Text);
             cmd.Parameters.Add("@cl_add",TextBox2.Text);
             cmd.Parameters.Add("@mobile",TextBox4.Text);
             cmd.Parameters.Add("@Serv_Type", DropDownList3.SelectedItem.Text);
             cmd.Parameters.Add("@Serv_Name", DropDownList5.SelectedItem.Text);
             cmd.Parameters.Add("@Timefrom", TextBox4.Text);
         
           
           
        
          
            
             CON.Open();
             cmd.ExecuteNonQuery();
             CON.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Order Details created successfully')", true);
            BindData();
            //show_category();
            getinvoiceno();
           
            TextBox2.Text = "";
            TextBox4.Text = "";
          
            TextBox8.Text = "";
          
          
            TextBox20.Text = "";
            getclient();
            DropDownList3.SelectedItem.Text = "All";
            DropDownList5.SelectedItem.Text = "All";

           
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
        SqlCommand CMD = new SqlCommand("select * from Order_entry_details where invoice_no='"+Label1.Text+"' and Com_Id='" + company_id + "' ORDER BY invoice_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }


    //protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    //{
      
    //    ImageButton img = (ImageButton)sender;
    //    GridViewRow row = (GridViewRow)img.NamingContainer;
    //    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("delete from Department where Depart_Code='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Deaprtment Details deleted successfully')", true);

    //    BindData();
    //    //show_category();
    //    getinvoiceno();


    //}
    private void getinvoiceno()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select COUNT(invoice_no) from Order_entry where Com_Id='" + company_id + "'";
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
    private void getinvoiceno1()
    {
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select COUNT(invoice_no) from Order_entry_details where invoice_no='"+Label1.Text+"' and  Com_Id='" + company_id + "'";
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
    }
    //private void show_category()
    //{

    //    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //    SqlCommand cmd = new SqlCommand("Select * from Department where Com_Id='" + company_id + "' ORDER BY Depart_Code asc", con);
    //    con.Open();
    //    DataSet ds = new DataSet();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(ds);


    //    DropDownList2.DataSource = ds;
    //    DropDownList2.DataTextField = "Depart_Name";
    //    DropDownList2.DataValueField = "Depart_Code";
    //    DropDownList2.DataBind();
    //    DropDownList2.Items.Insert(0, new ListItem("All", "0"));

    //    con.Close();
    //}
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
    //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //    SqlCommand CMD = new SqlCommand("select * from Department where Depart_Code='" + DropDownList2.SelectedItem.Value + "' and Com_Id='" + company_id + "' ORDER BY Depart_Code asc", con1);
    //    DataTable dt1 = new DataTable();
    //    con1.Open();
    //    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
    //    da1.Fill(dt1);
    //    GridView1.DataSource = dt1;
    //    GridView1.DataBind();
    
    //}


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

        SqlCommand cmd2 = new SqlCommand("select * from product_entry where product_name='" + DropDownList5.SelectedItem.Text + "'", con);
        SqlDataReader dr1;
        dr1 = cmd2.ExecuteReader();
        if (dr1.Read())
        {


           
           
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
        SqlCommand cmd = new SqlCommand("Select * from product_entry where category_name='" + DropDownList3.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
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


    DropDownList2.DataSource = ds;
    DropDownList2.DataTextField = "Client_Name";
    DropDownList2.DataValueField = "Client_Code";
    DropDownList2.DataBind();
    DropDownList2.Items.Insert(0, new ListItem("All", "0"));


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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Order_entry where client_name='" + DropDownList2.SelectedItem.Text + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList6.DataSource = ds;
        DropDownList6.DataTextField = "mobile";
        DropDownList6.DataValueField = "id";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("All", "0"));

        con.Close();

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from Order_entry where mobile='"+ DropDownList6.SelectedItem.Text +"' and  Com_Id='" + company_id + "' ORDER BY id asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }











    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("insert into Order_entry_details values(@invoice_no,@s_no,@service_type,@Service_name,@Duration,@Size,@rate,@qty,@Amount,@Com_Id)", CON);
        cmd.Parameters.Add("@invoice_no", Label1.Text);
        cmd.Parameters.Add("@s_no", Label9.Text);
        cmd.Parameters.Add("@service_type", DropDownList3.SelectedItem.Text);
        cmd.Parameters.Add("@Service_name", DropDownList5.SelectedItem.Text);
        cmd.Parameters.Add("@Duration",TextBox23.Text+"-"+TextBox21.Text);
        cmd.Parameters.Add("@Size",TextBox24.Text);
        cmd.Parameters.Add("@rate", TextBox29.Text);
        cmd.Parameters.AddWithValue("@qty", TextBox25.Text);
        cmd.Parameters.Add("@Amount", TextBox22.Text);
        cmd.Parameters.AddWithValue("@Com_Id", company_id);





        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();

        BindData();
        getinvoiceno1();
        est_cost();
        gettype();
       
    }
    protected void TextBox24_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void TextBox29_TextChanged(object sender, EventArgs e)
    {
        float size = float.Parse(TextBox24.Text);
        float rate = float.Parse(TextBox29.Text);
        float total = size * rate;
        TextBox22.Text = total.ToString();
    }
    protected void TextBox25_TextChanged(object sender, EventArgs e)
    {
        float size = float.Parse(TextBox24.Text);
        float rate = float.Parse(TextBox29.Text);
        float total = size * rate;
        float qty = float.Parse(TextBox25.Text);
        float total1 = total * qty;
        TextBox22.Text = total1.ToString();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            tot = tot + float.Parse(e.Row.Cells[7].Text);

        }
        TextBox7.Text = tot.ToString();

       
       
    }
}