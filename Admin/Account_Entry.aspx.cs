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

public partial class Admin_Cutomer_type : System.Web.UI.Page
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

            TextBox3.Focus();
            this.Form.DefaultButton = Button1.UniqueID;

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
        Label16.Text = ROW.Cells[1].Text;
        TextBox11.Text = ROW.Cells[2].Text;
        TextBox6.Text = ROW.Cells[3].Text;
        TextBox7.Text = ROW.Cells[4].Text;
        TextBox8.Text = ROW.Cells[5].Text;
        TextBox9.Text = ROW.Cells[6].Text;
        this.ModalPopupExtender2.Show();

    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        
        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("update Account_Entry set Acc_nickname='" + HttpUtility.HtmlDecode(TextBox11.Text) + "', Acc_name='" + HttpUtility.HtmlDecode(TextBox6.Text) + "', Banck='" + HttpUtility.HtmlDecode(TextBox7.Text) + "', Acc_No='" + HttpUtility.HtmlDecode(TextBox8.Text) + "', IFSC_Code='" + HttpUtility.HtmlDecode(TextBox9.Text) + "' where Account_id='" + HttpUtility.HtmlDecode(Label16.Text) + "'  and Com_Id='" + company_id + "' ", CON);

        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();
        Label18.Text = "updated successfuly";
        this.ModalPopupExtender2.Show();
        showcustomertype();
        show_category();
        BindData();
        getinvoiceno();

    }
    protected void Button10_Click(object sender, EventArgs e)
    {
     
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("delete from Account_Entry where Account_id='" + Label16.Text + "' and Com_Id='" + company_id + "' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Label18.Text = "Deleted successfuly";
        BindData();

        getinvoiceno();

    }
    protected void Button1_Click(object sender, EventArgs e)
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

                if (TextBox3.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter Account Nick Name')", true);
                }
                else
                {

                    SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand cmd1 = new SqlCommand("select * from Account_Entry where Acc_nickname='" + TextBox3.Text + "' and Com_Id='" + company_id + "' ", con1);
                    con1.Open();
                    SqlDataReader dr1;
                    dr1 = cmd1.ExecuteReader();
                    if (dr1.HasRows)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Account Entry already exist')", true);
                        TextBox3.Text = "";
                    }
                    else
                    {


                        SqlConnection CON4 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                        SqlCommand cmd4 = new SqlCommand("insert into Account_Entry values(@Account_id,@Acc_nickname,@Acc_name,@Banck,@Acc_No,@IFSC_Code,@Com_Id)", CON4);
                        cmd4.Parameters.AddWithValue("@Account_id", Label1.Text);
                        cmd4.Parameters.AddWithValue("@Acc_nickname", HttpUtility.HtmlDecode(TextBox3.Text));
                        cmd4.Parameters.AddWithValue("@Acc_name", HttpUtility.HtmlDecode(TextBox1.Text));
                        cmd4.Parameters.AddWithValue("@Banck", HttpUtility.HtmlDecode(TextBox2.Text));
                        cmd4.Parameters.AddWithValue("@Acc_No", HttpUtility.HtmlDecode(TextBox4.Text));
                        cmd4.Parameters.AddWithValue("@IFSC_Code", HttpUtility.HtmlDecode(TextBox5.Text));
                        cmd4.Parameters.AddWithValue("@Com_Id", company_id);
                        CON4.Open();
                        cmd4.ExecuteNonQuery();
                        CON4.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Bank Account Details added successfully')", true);
                        BindData();
                        show_category();
                        getinvoiceno();
                        TextBox3.Text = "";
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";

                    }
                   
                }

               
            }
            con.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        TextBox3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        getinvoiceno();
        show_category();
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
        SqlCommand CMD = new SqlCommand("select * from Account_Entry where Com_Id='" + company_id + "' ORDER BY Account_id asc", con);
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
        SqlCommand cmd = new SqlCommand("delete from Account_Entry where Account_id='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Account Details deleted successfully')", true);

        BindData();
        show_category();
        getinvoiceno();


    }
    private void getinvoiceno()
    {
       
        int a;

        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        con1.Open();
        string query = "Select COUNT(Account_id) from Account_Entry where Com_Id='" + company_id + "'";
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
            SqlCommand cmd = new SqlCommand("Select * from Account_Entry where Com_Id='" + company_id + "' ORDER BY Account_id asc", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "Acc_nickname";
            DropDownList2.DataValueField = "Account_id";
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
    protected void Button11_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            //Finiding checkbox control in gridview for particular row
            CheckBox chkdelete = (CheckBox)gvrow.FindControl("CheckBox2");
            //Condition to check checkbox selected or not
            if (chkdelete.Checked)
            {
                //Getting UserId of particular row using datakey value
                int usrid = Convert.ToInt32(gvrow.Cells[1].Text);
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Account_Entry where Account_id='" + usrid + "' and Com_Id='" + company_id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        BindData();
        getinvoiceno();

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
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from Account_Entry where Account_id='" + DropDownList2.SelectedItem.Value + "' and Com_Id='" + company_id + "' ORDER BY Account_id asc", con1);
        DataTable dt1 = new DataTable();
        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
}
