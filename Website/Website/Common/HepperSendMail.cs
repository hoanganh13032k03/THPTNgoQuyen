using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Security.Cryptography;


namespace Common
{
  
    public static class HepperSendMail
    {
      //public static VnailmarketDBContext db = new VnailmarketDBContext();
      //  public static DateTime GetDateServer()
      //  {
      //      return  db.Database.SqlQuery<DateTime> ("spGetSystemDate").SingleOrDefault();
      //  }
    
      
        public static bool SendMail(string sMailFrom, string sDisplayName, string sPassword, string sMailTo, string sTite, string sContent)
        {
            try
            {
                // OpenFileDialog dlg = new OpenFileDialog();
                // string filename = dlg.FileName;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer;
                if (sMailFrom.IndexOf("yahoo") >= 0)
                {
                    SmtpServer = new SmtpClient("smtp.mail.yahoo.com", 25);
                    SmtpServer.EnableSsl = false;
                }
                else
                    if (sMailFrom.IndexOf("gmail") >= 0 || sMailFrom.IndexOf("hpu.edu.vn") > 0)
                {
                    SmtpServer = new SmtpClient("smtp.gmail.com", 587);//or 465
                    SmtpServer.Credentials = new System.Net.NetworkCredential(sMailFrom, sPassword);
                    SmtpServer.EnableSsl = true;

                }
                else
                {
                    int Kytu = -1;
                    Kytu = sMailTo.IndexOf("@") + 1;
                    string smtp = sMailFrom;
                    string str = sMailFrom.Substring(0, Kytu);
                    smtp = smtp.Replace(str, "mail.");

                    SmtpServer = new SmtpClient(smtp);
                    SmtpServer.EnableSsl = false;
                }

                SmtpServer.Timeout = 20000;
                mail.From = new MailAddress(sMailFrom, sDisplayName);
                mail.To.Add(sMailTo);
                mail.Subject = sTite;
                mail.IsBodyHtml = true;
                mail.Body = sContent;
                //  Attachment attachment = new Attachment(filename);
                //  mail.Attachments.Add(attachment);

                SmtpServer.Send(mail);

            }
            catch
            {
                return false;
            }
            return true;
        }

      

    }
}