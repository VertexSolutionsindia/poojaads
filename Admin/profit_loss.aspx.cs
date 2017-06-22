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

public partial class Admin_Daily_sales : System.Web.UI.Page
{
    float tot = 0;
    float Costofservice_tot = 0;
    float Expense_tot = 0;
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
                Label1.Text = dr10["financial_year"].ToString();
                TextBox3.Text = Convert.ToDateTime(dr10["start_date"]).ToString("dd-MM-yyyy");
            }
            showrating();
            //BindData();
            //BindData1();
            //BindData2();
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
    protected void Button1_Click(object sender, EventArgs e)
    {


        if (TextBox3.Text != "")
        {
            if (TextBox4.Text != "")
            {
                BindData();
                BindData1();
                BindData2();

                try
                {
                    //----------------------------------------------Finding Grossporift

                    int Tot_Income = Convert.ToInt32(TextBox1.Text);

                    int Tol_CostofService = Convert.ToInt32(TextBox2.Text);

                    int Gross_profit = Tot_Income - Tol_CostofService;

                    TextBox5.Text = Convert.ToString(Gross_profit);
                    //-------------------------------------------------------------------

                    //------------------------------------------------Finding Net Profit
                    int Total_Grossprofit = Convert.ToInt32(TextBox5.Text);

                    int Total_Expense = Convert.ToInt32(TextBox6.Text);

                    int NetProfit = Total_Grossprofit - Total_Expense;

                    TextBox7.Text = Convert.ToString(NetProfit);
                    TextBox8.Text = Convert.ToString(NetProfit);
                }
                catch (Exception er)
                { }

                //--------------------------------------------------------------------

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Select To Date')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Select From Date')", true);
        }

        //----------------------------------------------Finding Grossporift

        //---------------------------------------------------------------------



    }

    protected void BindData()
    {
        if (User.Identity.IsAuthenticated)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select * from user_details where Name='" + User.Identity.Name + "'", con1);
            SqlDataReader dr;
            con1.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                SqlCommand CMD = new SqlCommand("select client_name,Sum(grand_total) as Amount from Order_entry where date between '" +Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" +Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by client_name", con);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(CMD);
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            con1.Close();
        }
    }
    protected void BindData1()
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
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                //SqlCommand CMD = new SqlCommand("SELECT  CONVERT(datetime,date,101) as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM sales_entry as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_entry as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_amount as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,amount,value", con1);
                SqlCommand CMD2 = new SqlCommand("select agent_name,Sum(bill_amount) as bill_amount from agent_bill where bill_date between '" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by agent_name", con2);
                DataTable dt2 = new DataTable();
                con2.Open();
                SqlDataAdapter da2 = new SqlDataAdapter(CMD2);
                da2.Fill(dt2);
                GridView2.DataSource = dt2;
                GridView2.DataBind();
            }
            con.Close();
        }
    }
    protected void BindData2()
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
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
                //SqlCommand CMD = new SqlCommand("SELECT  CONVERT(datetime,date,101) as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM sales_entry as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(paid_amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_entry as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,paid_amount,value union SELECT DISTINCT date as Date, status as Particulars,sum(amount) as Debit,isnull(sum(value),0) as Credit FROM purchase_amount as a where date='" + TextBox3.Text + "' and Com_Id='" + company_id + "' group by date,status,amount,value", con1);
                SqlCommand CMD2 = new SqlCommand("select Expense_Name,Sum(Amount) as Amount from Expence_Entry where date between '" +Convert.ToDateTime( TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" +Convert.ToDateTime( TextBox4.Text).ToString("MM-dd-yyyy") + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "' group by Expense_Name", con2);
                DataTable dt2 = new DataTable();
                con2.Open();
                SqlDataAdapter da2 = new SqlDataAdapter(CMD2);
                da2.Fill(dt2);
                GridView3.DataSource = dt2;
                GridView3.DataBind();
            }
            con.Close();
        }

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
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GridView1.PageIndex + 1) + " of " + GridView1.PageCount;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            tot = tot + float.Parse(e.Row.Cells[1].Text);

        }
        TextBox1.Text = tot.ToString();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        BindData1();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GridView2.PageIndex + 1) + " of " + GridView2.PageCount;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Costofservice_tot = Costofservice_tot + float.Parse(e.Row.Cells[1].Text);

        }
        TextBox2.Text = Costofservice_tot.ToString();

    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        BindData2();
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GridView3.PageIndex + 1) + " of " + GridView3.PageCount;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Expense_tot = Expense_tot + float.Parse(e.Row.Cells[1].Text);

        }
        TextBox6.Text = Expense_tot.ToString();

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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        BindData();
        BindData1();
        BindData2();
    }
}