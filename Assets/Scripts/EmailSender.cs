using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailSender
{

    public static void SendEmail(string subject, string body)
    {
        //check if previous attempts have been sent and send those if not.
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