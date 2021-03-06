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


public partial class Admin_Purchase_pay_amount : System.Web.UI.Page
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
                SqlDataReader dr1;
                con1.Open();
                dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    company_id = Convert.ToInt32(dr1["com_id"].ToString());
                    Label2.Text = dr1["company_name"].ToString();
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
                Label1.Text = dr10["financial_year"].ToString();
            }
            con10.Close();
            getinvoiceno();
            show_category();
            showrating();
            BindData();
            ClentName();
            clientmobile();
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
   

  
    private void show_category()
    {
   

    //    SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
    //    SqlCommand CMD = new SqlCommand("select * from pay_amount where Com_Id='" + company_id + "'", con1);
    //    DataTable dt1 = new DataTable();
    //    con1.Open();
    //    SqlDataAdapter da1 = new SqlDataAdapter(CMD);
    //    da1.Fill(dt1);
    //    GridView1.DataSource = dt1;
    //    GridView1.DataBind();
    }
    protected void BindData()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from Order_entry where Com_Id='" + company_id + "' and year='"+Label1.Text+"' ORDER BY Invoice_no asc", con1);
        DataTable dt1 = new DataTable();
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

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from Order_entry where date='" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "'  and  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand CMD = new SqlCommand("select * from Order_entry where date between '" + Convert.ToDateTime(TextBox3.Text).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(TextBox4.Text).ToString("MM-dd-yyyy") + "'  and  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con);
        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(CMD);
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /*Tell the compiler that the control is rendered
         * explicitly by overriding the VerifyRenderingInServerForm event.*/
    }


    private void ClentName()
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Order_entry where Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);



        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "client_name";
        DropDownList3.DataValueField = "Invoice_no";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("All", "0"));


        con.Close();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "All")
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand CMD = new SqlCommand("select * from Order_entry where  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand CMD = new SqlCommand("select * from Order_entry where client_name='" + DropDownList3.SelectedItem.Text + "' and  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con2);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "All")
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand CMD = new SqlCommand("select * from Order_entry where  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
            SqlCommand CMD = new SqlCommand("select * from Order_entry where mobile='" + DropDownList6.SelectedItem.Text + "' and  Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con2);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(CMD);
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
    }
    private void clientmobile()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        SqlCommand cmd = new SqlCommand("Select * from Order_entry where Com_Id='" + company_id + "' and year='" + Label1.Text + "' ORDER BY Invoice_no asc", con);
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);

        DropDownList6.DataSource = ds;
        DropDownList6.DataTextField = "mobile";
        DropDownList6.DataValueField = "Invoice_no";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("All", "0"));


        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("delete from Order_entry where Invoice_no='" + usrid + "' and Com_Id='" + company_id + "' and year='" + Label1.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataBind();
                BindData();
            }
        }
    }

 

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            // select appropriate contenttype, while binary transfer it identifies filetype
            string contentType = string.Empty;
            if (DropDownList1.SelectedValue.Equals(".pdf"))
                contentType = "application/pdf";
            if (DropDownList1.SelectedValue.Equals(".doc"))
                contentType = "application/ms-word";
            if (DropDownList1.SelectedValue.Equals(".xls"))
                contentType = "application/xls";

            DataTable dsData = new DataTable();

            DataSet ds = null;
            SqlDataAdapter da = null;



            try
            {
                string constring = ConfigurationManager.AppSettings["connection"];
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("order_invoice", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@No", int.Parse(TextBox1.Text));
                        cmd.Parameters.AddWithValue("@Com_Id", Convert.ToInt32(company_id));
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

            string FileName = "File_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + DropDownList1.SelectedValue;
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;

            LocalReport report = new LocalReport();
            report.ReportPath = Server.MapPath("~/Admin/Report.rdlc");
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
            rds.Value = dsData;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render(DropDownList1.SelectedItem.Text, null,
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
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert Message", "alert('Enter the INVOICE NUMBER')", true);
        }
    }
}