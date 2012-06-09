using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Mail;
using System.Net;
using Localization;

namespace TaiyoBussan
{
    public class Util
    {
        public static void SendWebmail(Webmail webmail, BaseLocale locale)
        {
            
            MailAddress from = new MailAddress(webmail.Email, webmail.Name);

            MailAddress to = Webmail.Recipient;

            MailMessage msg = new MailMessage(from, to);

            msg.BodyEncoding = System.Text.Encoding.UTF8;

            msg.IsBodyHtml = true;

            //open the email template
            XmlDocument xml = new XmlDocument();
            xml.Load(Webmail.Template);

            //add the data
            XmlNode nameNode = xml.SelectSingleNode("//insert[@key='name']");
            nameNode.AppendChild(xml.CreateTextNode(webmail.Name));

            XmlNode emailNode = xml.SelectSingleNode("//insert[@key='email']");
            emailNode.AppendChild(xml.CreateTextNode(webmail.Email));

            XmlNode msgNode = xml.SelectSingleNode("//insert[@key='message']");
            msgNode.AppendChild(xml.CreateTextNode(webmail.Message));

            XmlNode dateNode = xml.SelectSingleNode("//insert[@key='date']");
            dateNode.AppendChild(xml.CreateTextNode(DateTime.Now.ToLongDateString()));

            XmlNode timeNode = xml.SelectSingleNode("//insert[@key='time']");
            timeNode.AppendChild(xml.CreateTextNode(DateTime.Now.ToLongTimeString()));

            XmlNode langNode = xml.SelectSingleNode("//insert[@key='lang']");
            langNode.AppendChild(xml.CreateTextNode(locale.Culture.NativeName));

            msg.Body = xml.InnerXml;

            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Subject = Webmail.Subject;

            SmtpClient smtp = Webmail.SMTP;

            smtp.Send(msg);

        }
    }
}
