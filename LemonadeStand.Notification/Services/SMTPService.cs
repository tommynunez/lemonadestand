using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace LemonadeStand.Communication.Services
{
  public class SMTPService
  {
    private const string EmailFrom = "";
    private string firstName;
    private string lastName;
    private string emailTo;
    private string subject;
    private string headerText;
    private string bodyMessage;
    private string tokenUrl;
    private string buttonLabel;
    private string subText;

    private readonly IConfiguration _configuration;

    public string FirstName
    {
      get
      {
        return firstName;
      }
      set
      {
        firstName = value;
      }
    }

    public string LastName
    {
      get
      {
        return lastName;
      }

      set
      {
        lastName = value;
      }
    }

    public string EmailTo
    {
      get
      {
        return emailTo;
      }

      set
      {
        emailTo = value;
      }
    }

    public string Subject
    {
      get
      {
        return subject;
      }

      set
      {
        subject = value;
      }
    }

    public string HeaderText
    {
      get
      {
        return headerText;
      }

      set
      {
        headerText = value;
      }
    }

    public string BodyMessage
    {
      get
      {
        return bodyMessage;
      }

      set
      {
        bodyMessage = value;
      }
    }

    public string TokenUrl
    {
      get
      {
        return tokenUrl;
      }
      set
      {
        tokenUrl = value;
      }
    }

    public string ButtonLabel
    {
      get
      {
        return buttonLabel;
      }

      set
      {
        buttonLabel = value;
      }
    }

    public string SubText
    {
      get
      {
        return subText;
      }
      set
      {
        subText = value;
      }
    }

    public SMTPService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void SendEmail()
    {
      try
      {
        //send email
        using var message = new MailMessage();
        message.To.Add(new MailAddress(emailTo, String.Concat("{0} {1}", firstName, lastName)));
        message.From = new MailAddress(EmailFrom, "Tonnect");
        message.Subject = subject;
        message.Body = BuildBodyTemplate(firstName, lastName, headerText, bodyMessage, tokenUrl, buttonLabel, subText);
        message.IsBodyHtml = true;

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        using var client = new SmtpClient("smtp.gmail.com", 587)
        {
          //this flag has to be set before the credentials
          UseDefaultCredentials = false,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          Credentials = new NetworkCredential(EmailFrom, "")
        };
        client.Send(message);
      }
      catch (Exception ex)
      {

      }
    }

    public string BuildBodyTemplate(string firstName, string lastName, string headerText, string bodyMessage, string tokenUrl, string buttonLabel, string subText)
    {
      string body;
      using (StreamReader streamReader = new StreamReader(string.Format("../../../../{0}/{1}/{2}", "Tonnect", "Templates", "index.html")))
      {
        body = streamReader.ReadToEnd().ToString();
        body = body.Replace("{{headerText}}", headerText.ToString());
        body = body.Replace("{{firstName}}", firstName);
        body = body.Replace("{{lastName}}", lastName);
        body = body.Replace("{{bodyMessage}}", bodyMessage);
        body = body.Replace("{{tokenUrl}}", tokenUrl);
        body = body.Replace("{{buttonLabel}}", buttonLabel);
        body = body.Replace("{{subText}}", subText);
      }
      return body;
    }

    public void SendEmailViaSendinnBlue()
    {

    }
  }
}
