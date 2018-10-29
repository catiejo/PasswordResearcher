using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/*
 * IMPORTANT TO NOTE
 * If you want this code to work on iOS, you need to include a link.xml file 
 * in your assets folder with the following:
 * <linker>
 * <assembly fullname="System">
 * <type fullname="System.Net.Configuration.MailSettingsSectionGroup" preserve="all"/>
 * <type fullname="System.Net.Configuration.SmtpSection" preserve="all"/>
 * <type fullname="System.Net.Configuration.SmtpNetworkElement" preserve="all"/>
 * <type fullname="System.Net.Configuration.SmtpSpecifiedPickupDirectoryElement" preserve="all"/>
 * </assembly>
 * </linker>
 * Credit: https://forum.unity.com/threads/ios-xcode-error-when-using-system-net-mail.334932/
 * More Credit: https://answers.unity.com/questions/433283/how-to-send-email-with-c.html
 */
public class EmailSender
{
    public static void SendEmail(string subject, string body)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("zhaw.eva2@gmail.com");
        mail.To.Add("pide@zhaw.ch");
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("zhaw.eva2@gmail.com", "T6hX$}i7}GNHA]2G99.7>DjZ4Pb&KV(P2*x%RW27T") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }
}