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
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
#endregion

public partial class Admin_Expense_entry : System.Web.UI.Page
{

    public static int company_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1);
                SqlDataReader dr;
                con1.Open();
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    company_id = Convert.ToInt32(dr["com_id"].ToString());
                }
                con1.Close();
            }
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd10 = new SqlCommand("select * from currentfinancialyear where no='1'", con10);
            SqlDataReader dr10;
            con10.Open();
            dr10 = cmd10.ExecuteReader();
            if (dr10.Read())
            {
                Label8.Text = dr10["financial_year"].ToString();
            }
            DateTime date = DateTime.Now;
            TextBox8.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
            TextBox2.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
            getinvoiceno();
            getExpenseNameID();
            SearchExpense();
            BindData();
            showpartners();
        }
    }
  private void showpartners()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr1;
            con10.Open();
            dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                company_id = Convert.ToInt32(dr1["com_id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("Select * from partners_entry where Com_Id='" + company_id + "' ORDER BY partner_Code asc", con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "partner_Name";
                DropDownList1.DataValueField = "partner_Code";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select partner", "0"));

                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "partner_Name";
                DropDownList2.DataValueField = "partner_Code";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("Select partner", "0"));

                con.Close();
            }
            con10.Close();
        }
    }

    protected void BindData()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr;
            con10.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                company_id = Convert.ToInt32(dr["com_id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand CMD = new SqlCommand("select * from Expence_Entry where Com_Id='" + company_id + "' and year='"+Label8.Text+"' ORDER BY Exp_Id asc", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            con10.Close();
        }
    }



    //A method that returns a string which calls the connection string from the web.config
    private string GetConnectionString()
    {
        //"DBConnection" is the name of the Connection String
        //that was set up from the web.config file
        return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }

    //A method that Inserts the records to the database


    protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Gridview1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

    }
    protected void Gridview1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

    }
    protected void Gridview1_SelectedIndexChanged(object sender, System.EventArgs e)
    {


    }
    protected void Gridview1_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, System.EventArgs e)
    {

    }
    protected void Gridview1_Load(object sender, System.EventArgs e)
    {

    }

    private void getinvoiceno()
    {

        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr1;
            con10.Open();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                company_id = Convert.ToInt32(dr1["com_id"].ToString());
                int a;

                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                con1.Open();
                string query = "Select max(Exp_Id) from Expence_Entry where Com_Id='" + company_id + "'";
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
                con1.Close();
            }
            con10.Close();
        }
    }

    private void getExpenseNameID()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr1;
            con10.Open();
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                company_id = Convert.ToInt32(dr1["com_id"].ToString());
                int a;
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                con1.Open();
                string query = "Select max(ExpName_Code) from ExpenceName_Add where Com_Id='" + company_id + "'";
                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        Label29.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        Label29.Text = a.ToString();
                    }
                }
                con1.Close();
            }
            con10.Close();
        }
    }

    private void SearchExpense()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr;
            con10.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                company_id = Convert.ToInt32(dr["com_id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("Select * from ExpenceName_Add where Com_Id='" + company_id + "' ORDER BY ExpName_Code asc", con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                //DropDownList3.DataSource = ds;
                //DropDownList3.DataTextField = "Expense_Name";
                //DropDownList3.DataValueField = "ExpName_Code";
                //DropDownList3.DataBind();
                //DropDownList3.Items.Insert(0, new ListItem("All", "0"));

                //DropDownList4.DataSource = ds;
                //DropDownList4.DataTextField = "Expense_Name";
                //DropDownList4.DataValueField = "ExpName_Code";
                //DropDownList4.DataBind();
                //DropDownList4.Items.Insert(0, new ListItem("All", "0"));

                con.Close();
            }
            con10.Close();
        }
    }
    private void SaveDetail(GridViewRow row)
    {


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
       
        TextBox12.Text = "";
        TextBox4.Text = "";
        SearchExpense();
        showpartners();
        BindData();
        DateTime date = DateTime.Now;
        TextBox8.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
        TextBox2.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
       
    }
    private void active()
    {

    }


    private void created()
    {

    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {

        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr;
            con10.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                company_id = Convert.ToInt32(dr["com_id"].ToString());
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("delete from Expence_Entry where Exp_Id='" + row.Cells[1].Text + "' and Com_Id='" + company_id + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Expense entry deleted successfully')", true);

                BindData();
            }
            con10.Close();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr;
            con10.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                company_id = Convert.ToInt32(dr["com_id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("Select * from ExpenceName_Add where Com_Id='" + company_id + "' ORDER BY ExpName_Code asc", con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //DropDownList4.DataSource = ds;
                //DropDownList4.DataTextField = "Expense_Name";
                //DropDownList4.DataValueField = "ExpName_Code";
                //DropDownList4.DataBind();
                //DropDownList4.Items.Insert(0, new ListItem("All", "0"));

                ImageButton IMG = (ImageButton)sender;
                GridViewRow ROW = (GridViewRow)IMG.NamingContainer;
                Label4.Text = ROW.Cells[1].Text;
                TextBox2.Text = ROW.Cells[2].Text;
                TextBox5.Text = ROW.Cells[3].Text;
                TextBox3.Text = ROW.Cells[4].Text;

                this.ModalPopupExtender1.Show();
            }
            con10.Close();
        }
    }

    protected void LoginLink_OnClick(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/login.aspx");

    }

    protected void btnRandom_Click(object sender, EventArgs e)
    {
        // this.ModalPopupExtender2.Show();
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

        //this.ModalPopupExtender1.Show();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        // this.ModalPopupExtender4.Show();
    }




    //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (User.Identity.IsAuthenticated)
    //    {
    //        SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //        SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
    //        SqlDataReader dr;
    //        con10.Open();
    //        dr = cmd.ExecuteReader();
    //        if (dr.Read())
    //        {
    //            company_id = Convert.ToInt32(dr["com_id"].ToString());
    //            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //            SqlCommand CMD = new SqlCommand("select * from ExpenceName_Add where Expense_Name='" + DropDownList3.SelectedItem.Text + "' and Com_Id='" + company_id + "' ORDER BY ExpName_Code asc", con1);
    //            DataTable dt1 = new DataTable();
    //            con1.Open();
    //            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
    //            da1.Fill(dt1);
    //            //GridView1.DataSource = dt1;
    //            //GridView1.DataBind();
    //        }
    //        con10.Close();
    //    }

    //}

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchExpenseName(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["connection"];

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Expense_Name from ExpenceName_Add where Com_Id=@Com_Id and " +
                "Expense_Name like @Expense_Name + '%'";
                cmd.Parameters.AddWithValue("@Expense_Name", prefixText);
                cmd.Parameters.AddWithValue("@Com_id", company_id);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["Expense_Name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, System.EventArgs e)
    {
        // TextBox3.Focus();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        this.ModalPopupExtender3.Show();
        TextBox1.Text = "";
    }
    protected void Button16_Click(object sender, EventArgs e)
    {

        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd11 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
            SqlDataReader dr;
            con10.Open();
            dr = cmd11.ExecuteReader();
            if (dr.Read())
            {
                company_id = Convert.ToInt32(dr["com_id"].ToString());
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd1 = new SqlCommand("select * from ExpenceName_Add where Expense_Name='" + TextBox1.Text + "' ", con1);
                con1.Open();
                SqlDataReader dr1;
                dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Expense Name already exist')", true);
                    TextBox1.Text = "";
                }
                else
                {




                    SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into ExpenceName_Add values(@ExpName_Code,@Expense_Name,@Com_Id)", CON);
                    cmd.Parameters.AddWithValue("@ExpName_Code", Label29.Text);
                    cmd.Parameters.AddWithValue("@Expense_Name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Com_Id", company_id);
                  
                    CON.Open();
                    cmd.ExecuteNonQuery();
                    CON.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Expense Name Added successfully')", true);
                    TextBox1.Text = "";
                    getExpenseNameID();
                    SearchExpense();

                }
            }
            con10.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Please enter expense name')", true);
        }
        else
        {
            if (User.Identity.IsAuthenticated)
            {
                SqlConnection con10 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand cmd1 = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con10);
                SqlDataReader dr;
                con10.Open();
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    company_id = Convert.ToInt32(dr["com_id"].ToString());
                    int value = 0;
                    SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into Expence_Entry values(@Exp_Id,@date,@Expense_Name,@Com_Id,@Amount,@status,@value,@year,@partner_name)", CON);
                    cmd.Parameters.AddWithValue("@Exp_Id", Label1.Text);
                    cmd.Parameters.AddWithValue("@date",Convert.ToDateTime( TextBox8.Text).ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@Expense_Name", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Com_Id", company_id);
                    cmd.Parameters.AddWithValue("@Amount", TextBox12.Text);
                    cmd.Parameters.AddWithValue("@status", "Expense-" + TextBox4.Text);
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@year", Label8.Text);
                    cmd.Parameters.AddWithValue("@partner_name", DropDownList1.SelectedItem.Text);
                    CON.Open();
                    cmd.ExecuteNonQuery();
                    CON.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Expense Entry Added successfully')", true);

                    DateTime date = DateTime.Now;
                    TextBox8.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
                    TextBox2.Text = Convert.ToDateTime(date).ToString("dd-MM-yyyy");
                    TextBox12.Text = "";
                    getinvoiceno();
                    SearchExpense();
                    showpartners();
                    BindData();
                }
                con10.Close();
            }
        }

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
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
                SqlCommand cmd = new SqlCommand("delete from Expence_Entry where Exp_Id='" + usrid + "'  and Com_Id='" + company_id + "' and year='"+Label8.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();



            }
        }
        BindData();
        getinvoiceno();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        int value = 0;
        SqlConnection CON = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("update Expence_Entry set date='" + TextBox2.Text +
            "', Expense_Name='" + HttpUtility.HtmlDecode(TextBox5.Text) + 
            "', Amount='" + HttpUtility.HtmlDecode(TextBox3.Text) +
                "', status='" + HttpUtility.HtmlDecode("Expense-" + TextBox5.Text) +
             "', value='" + value +
            "',partner_name='" + DropDownList2.SelectedItem.Text +
            "' where Exp_Id='" + Label4.Text + "'  and year='" + Label8.Text + "' and Com_Id='" + company_id + "' ", CON);

        CON.Open();
        cmd.ExecuteNonQuery();
        CON.Close();
        Label31.Text = "Updated successfuly";

        this.ModalPopupExtender1.Hide();
        BindData();
        getinvoiceno();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
}