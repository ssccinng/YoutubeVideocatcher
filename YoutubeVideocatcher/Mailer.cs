using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;

namespace PokemonNewsUpdataer_V1
{
    class Mailer
    {
        //public string MailTarget;
        MailAddress From, Target;
        private string Password;
        SmtpClient client;
        MailMessage message;

        public void Sender(string Title, string Content, string[] filepath)
        {
            message.Subject = Title; // 设置邮件的标题
            message.Body = Content;
            message.BodyEncoding = System.Text.Encoding.Default;
            foreach (string file in filepath)
            {
                message.Attachments.Add(new Attachment(file));

            }
            //创建一个SmtpClient 类的新实例,并初始化实例的SMTP 事务的服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = false;
            //身份认证
            client.Credentials = new System.Net.NetworkCredential(From.Address, Password);
            client.Send(message);
            //client.Send(From, Target, Title, Content);
        }

        public void Sender(string Title, string Content)
        {
            message.Subject = Title; // 设置邮件的标题
            message.Body = Content;
            message.BodyEncoding = System.Text.Encoding.Default;
            //创建一个SmtpClient 类的新实例,并初始化实例的SMTP 事务的服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = false;
            //身份认证
            client.Credentials = new System.Net.NetworkCredential(From.Address, Password);
            client.Send(message);
            //client.Send(From, Target, Title, Content);
        }

        public Mailer(string From, string Target, string Password, string Host)
        {
            this.From   = new MailAddress(From, "宝可梦更新检测器");
            this.Target = new MailAddress(Target, "风群水水人");
            this.Password = Password;
            this.message = new MailMessage(this.From, this.Target);
            this.client = new SmtpClient(string.Format("smtp.{0}.com", Host));
            //client.Credentials = new System.Net.NetworkCredential(From, Password);
            if (Host == "qq")
            {
                client.Port = 465;
                //client.Port = 587;//SMTP端口，QQ邮箱填写587 
                client.EnableSsl = true;//启用SSL加密 

            }

        }

        public void ReadInfo()
        {
            Console.Write("请输入邮箱地址: ");
            Console.ReadLine();
            Console.Write("请输入密码: ");
        }
    }
}
