using System;

namespace csharp_send_email_demo
{
    internal static class SendEmailDemo
    {
        public static void Main(string[] args)
        {
            try
            {
                EmailUtil.SendEmail("目标邮箱", "邮件主题", "邮件内容");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}