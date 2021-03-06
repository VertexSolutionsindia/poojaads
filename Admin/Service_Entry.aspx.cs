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


public partial class Admin_Product_entry : System.Web.UI.Page
{
    DataTable dt = null;
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

            getinvoiceno();
           
          
            show_category();
            showrating();
            BindData();

            active();
            created();


           

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton IMG = (ImageButton)sender;
        GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
        Label29.Text = ROW.Cells[1].Text;
        DropDownList4.SelectedItem.Text = ROW.Cells[2].Text;
       
        TextBox16.Text = ROW.Cells[4].Text;
        TextBox3.Text = ROW.Cells[5].Text;

        this.ModalPopupExtender3.Show();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        

        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("update product_entry set category_id='" + DropDownList4.SelectedItem.Value + "', category_name='" + DropDownList4.SelectedItem.Text + "', product_name='" + HttpUtility.HtmlDecode(TextBox16.Text) + "',product_price='" + HttpUtility.HtmlDecode(TextBox3.Text) + "' where code='" + Label29.Text + "'  and Com_Id='" + company_id + "' ", CON);

        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();
        Label31.Text = "updated successfuly";

        this.ModalPopupExtender3.Hide();
        BindData();
        getinvoiceno();


    }
    protected void Button17_Click(object sender, EventArgs e)
    {
       

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd1 = new SqlCommand("delete from product_entry where code='" + Label29.Text + "' and Com_Id='" + company_id + "' ", con1);
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
                SqlCommand cmd = new SqlCommand("delete from product_entry where code='" + usrid+"'  and Com_Id='" + company_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

               

            }
        }
        BindData();
        getinvoiceno();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Select valid Service Type')", true);
        }
        else if (DropDownList5.SelectedItem.Text =="All")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Select valid Location')", true);
        }
        else if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter valid Service Name')", true);
        }
        else
        {

            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1=new SqlCommand("select * from product_entry where product_name='"+TextBox4.Text+"' ",con1);
            con1.Open();
            SqlDataReader dr1;
            dr1=cmd1.ExecuteReader();
            if (dr1.HasRows)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Service already exist')", true);
                TextBox4.Text = "";
            }
            else
            {


              

                SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("insert into product_entry values(@code,@category_id,@subcategory_id,@product_name,@Com_Id,@category_name,@subcategory_name,@product_price)", CON);
                cmd.Parameters.AddWithValue("@code", Label1.Text);
                cmd.Parameters.AddWithValue("@category_id", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@subcategory_id", DropDownList5.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@product_name", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Com_Id", company_id);
                cmd.Parameters.AddWithValue("@category_name", DropDownList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@subcategory_name", DropDownList5.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@product_price", TextBox2.Text);
                CON.Open();
                cmd.ExecuteNonQuery();
                CON.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Service Added successfully')", true);
                BindData();

                getinvoiceno();
             
                TextBox4.Text = "";
                TextBox2.Text = "";
            }
        }


    }
    private void SaveDetail(GridViewRow row)
    {
        

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox2.Text = "";
        getinvoiceno();
        BindData();
        show_category();

        getsubcategory();
       
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
        SqlCommand CMD = new SqlCommand("select * from product_entry where Com_Id='" + company_id + "' ORDER BY code asc", con);
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
        SqlCommand cmd = new SqlCommand("delete from product_entry where code='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

       
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Service Entry deleted successfully')", true);

        BindData();
        show_category();
        getinvoiceno();


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
                cmd.CommandText = "select product_name from product_entry where Com_Id=@Com_Id and " +
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from subcategory where category_id='" + DropDownList2.SelectedItem.Value + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "subcategoryname";
        DropDownList1.DataValueField = "subcategory_id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));
       


        con.Close();

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_entry where category_id='" + DropDownList2.SelectedItem.Value + "' and Com_Id='" + company_id + "' ORDER BY subcategory_id asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();


       
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {


        //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        //SqlCommand cmd = new SqlCommand("Select * from subcategory where category_id='" + DropDownList4.SelectedItem.Value + "' and Com_Id='" + company_id + "'", con);
        //con.Open();
        //DataSet ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(ds);


        //DropDownList6.DataSource = ds;
        //DropDownList6.DataTextField = "subcategoryname";
        //DropDownList6.DataValueField = "subcategory_id";
        //DropDownList6.DataBind();
        //DropDownList6.Items.Insert(0, new ListItem("All", "0"));



        //con.Close();
        //ModalPopupExtender3.Show();
    }
    private void show_category()
    {
       

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from category where Com_Id='" + company_id + "' ORDER BY category_id asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);


        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "categoryname";
        DropDownList2.DataValueField = "category_id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));


        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "categoryname";
        DropDownList3.DataValueField = "category_id";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("All", "0"));

        DropDownList4.DataSource = ds;
        DropDownList4.DataTextField = "categoryname";
        DropDownList4.DataValueField = "category_id";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("All", "0"));
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
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        getsubcategory();
    }

    private void getsubcategory()
    {
       

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from subcategory where category_id='" + DropDownList3.SelectedItem.Value + "' and Com_Id='" + company_id + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList5.DataSource = ds;
        DropDownList5.DataTextField = "subcategoryname";
        DropDownList5.DataValueField = "subcategory_id";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_entry where product_name='" + TextBox1.Text + "' and Com_Id='" + company_id + "'", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    private void getinvoiceno()
    {
       
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select COUNT(code) from product_entry where Com_Id='" + company_id + "'";
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
    protected void Button3_Click(object sender, EventArgs e)
    {
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from product_entry where category_id='" + DropDownList2.SelectedItem.Value + "' and subcategory_id='"+DropDownList1.SelectedItem.Value+"' and Com_Id='" + company_id + "' ORDER BY subcategory_id asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    //protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //    SqlCommand cmd = new SqlCommand("Select subcategoryname from subcategory where category_id='" + DropDownList6.SelectedItem.Value + "' and Com_Id='" + company_id + "'", con);
    //    con.Open();
    //    DataSet ds = new DataSet();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(ds);


    //    DropDownList6.DataSource = ds;
    //    DropDownList6.DataTextField = "subcategoryname";
    //    DropDownList6.DataValueField = "subcategory_id";
    //    DropDownList6.DataBind();
    //    DropDownList6.Items.Insert(0, new ListItem("All", "0"));



    //    con.Close();
    //    ModalPopupExtender3.Show();
    //}
}