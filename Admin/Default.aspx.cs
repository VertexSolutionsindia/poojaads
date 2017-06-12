using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("sakkappan.vertex@gmail.com");
        string s = TextBox1.Text;
        msg.To.Add(TextBox1.Text);
        msg.Body = "";
        msg.IsBodyHtml = true;
        msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Attachment at = new Attachment(Server.MapPath(@"~\img\"+ TextBox2.Text +""));
     
        msg.Attachments.Add(at);
        //msg.Attachments.Add(at1)
        msg.Priority = MailPriority.High;
        msg.Subject = "Special Gift";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.Credentials = new System.Net.NetworkCredential("sakkappan.vertex@gmail.com", "vertex123");
        smtp.Send(msg);
    }
}