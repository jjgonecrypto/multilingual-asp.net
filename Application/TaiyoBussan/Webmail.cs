using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Security;

namespace TaiyoBussan
{
    public class Webmail
    {
        public static MailAddress Recipient
        {
            get
            {
                return new MailAddress(ConfigurationManager.AppSettings["webmailRecipient"]);
            }
        }

        public static String Subject
        {
            get
            {
                return ConfigurationManager.AppSettings["webmailSubject"];
            }
        }

        public static SmtpClient SMTP
        {
            get
            {
                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);

                NetworkCredential c = new NetworkCredential();

                c.UserName = ConfigurationManager.AppSettings["smtpUsername"];

                c.Password = ConfigurationManager.AppSettings["smtpPassword"];

                smtp.Credentials = c;

                return smtp;
            }
        }

        public static String Template
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/Templates/EmailTemplate.xhtml");
            }
        }


        public String Name;

        public String Email;

        public String Message;

        public Webmail(string name, String mail, string msg)
        {
            this.Name = name;
            this.Email = mail;
            this.Message = msg;
        }

    }
}
