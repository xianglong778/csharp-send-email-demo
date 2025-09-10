using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace csharp_send_email_demo
{
    /// <summary>
    /// 邮件发送工具类，提供 SMTP 协议下的 HTML 格式邮件发送能力，支持 QQ、163 等邮件服务商
    /// </summary>
    public abstract class EmailUtil
    {
        // 是否启用SSL
        private const bool IsSsL = true;

        // 发件人邮箱（需与授权码所属邮箱一致）
        private const string FromEmail = "XXXXXXXXXX";

        // 显示的发件人名称
        private const string FromName = "发件人名称";

        // SMTP服务器地址
        private const string SmtpHost = "smtp.qq.com";

        // SMTP端口
        private const int SmtpPort = 587;

        // 发件人邮箱授权码
        private const string Password = "XXXXXXXXXX";

        // 超时时间（ms）
        private const int Timeout = 5 * 1000;

        /// <summary>
        /// 发送HTML格式邮件
        /// </summary>
        /// <param name="toEmail">目标邮箱地址</param>
        /// <param name="emailTitle">邮件主题</param>
        /// <param name="emailHtmlBody">邮件内容（支持HTML标签，如&lt;br/&gt;换行、&lt;p&gt;段落等）</param>
        /// <remarks>
        /// 使用示例
        /// <code>
        /// try
        /// {
        ///     EmailUtil.SendEmail("目标邮箱", "邮件主题", "邮件内容");
        /// }
        /// catch (Exception e)
        /// {
        ///     Console.WriteLine(e);
        /// }
        /// </code>
        /// </remarks>
        public static void SendEmail(string toEmail, string emailTitle, string emailHtmlBody)
        {
            // 发送邮件
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    // 启用 HTML 内容解析
                    mailMessage.IsBodyHtml = true;
                    // 内容编码
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    // 主题编码
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    // 发件人
                    mailMessage.From = new MailAddress(FromEmail, FromName);
                    // 收件人（仅支持单个）
                    mailMessage.To.Add(toEmail);
                    // 邮件主题
                    mailMessage.Subject = emailTitle;
                    // 邮件内容（支持HTML格式）
                    mailMessage.Body = emailHtmlBody;
                    // 构建发送邮件的客户端
                    using (var client = new SmtpClient(SmtpHost, SmtpPort))
                    {
                        // 是否启用SSL
                        client.EnableSsl = IsSsL;
                        // 身份验证
                        client.Credentials = new NetworkCredential(FromEmail, Password);
                        // 超时时间
                        client.Timeout = Timeout;
                        // 发送邮件
                        client.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"邮件发送失败：{ex.Message}", ex);
            }
        }
    }
}