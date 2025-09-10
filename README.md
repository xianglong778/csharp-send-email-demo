# 一、已测试邮箱

- [x] [QQ 邮箱](https://wx.mail.qq.com/list/readtemplate?name=app_intro.html#/agreement/authorizationCode)
- [x] [网易邮箱](https://help.mail.163.com/faqDetail.do?code=d7a5dc8471cd0c0e8b4b8f4f8e49998b374173cfe9171305fa1ce630d7f67ac22b85ac2e7c90cd63)

# 二、使用方法

> 第一步：配置参数

```csharp
// 是否启用SSL
private const bool IsSsL = true;

// 发件人邮箱授权码
private const string Password = "XXXXXXXXXXXX";

// 发件人邮箱
private const string FromEmail = "XXXXXXXXXXXX";

// 显示的发件人名称
private const string FromName = "发件人名称";

// SMTP服务器地址
private const string SmtpHost = "smtp.qq.com";

// SMTP端口
private const int SmtpPort = 587;

// 超时时间（ms）
private const int Timeout = 5 * 1000;
```

> 第二步：调用方法

```csharp
try
{
    EmailUtil.SendEmail("目标邮箱", "邮件主题", "邮件内容");
}
catch (Exception e)
{
    Console.WriteLine(e);
}
```
