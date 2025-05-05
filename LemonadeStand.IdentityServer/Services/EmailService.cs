namespace LemonadeStand.IdentityServer.Services
{
  public class EmailService
  {
    #region fields
    private const string ApiKey = "";
    private const string EmailFrom = "tonnect20@gmail.com";
    private const string sendInblueBaseUrl = "";
    private string firstName;
    private string lastName;
    private string emailTo;
    private string subject;
    private string headerText;
    private string bodyMessage;
    private string tokenUrl;
    private string buttonLabel;
    private string subText;
    #endregion

    #region properties
    public string FirstName
    {
      get { return firstName; }
      set { firstName = value; }
    }

    public string LastName
    {
      get { return lastName; }
      set { lastName = value; }
    }

    public string EmailTo
    {
      get { return emailTo; }
      set { emailTo = value; }
    }

    public string Subject
    {
      get { return subject; }
      set { subject = value; }
    }

    public string HeaderText
    {
      get { return headerText; }
      set { headerText = value; }
    }

    public string BodyMessage
    {
      get { return bodyMessage; }
      set { bodyMessage = value; }
    }

    public string TokenUrl
    {
      get { return tokenUrl; }
      set { tokenUrl = value; }
    }

    public string ButtonLabel
    {
      get { return buttonLabel; }
      set { buttonLabel = value; }
    }

    public string SubText
    {
      get { return subText; }
      set { subText = value; }
    }
    #endregion

    #region constructor
    public EmailService()
    {
    }

    public EmailService(string firstName, string lastName, string emailTo, 
      string headerText, string subject, string bodyMessage, string tokenUrl, 
      string buttonLabel, string subText)
    {
      FirstName = firstName;
      LastName = lastName;
      EmailTo = emailTo;
      HeaderText = headerText;
      Subject = subject;
      BodyMessage = bodyMessage;
      TokenUrl = tokenUrl;
      ButtonLabel = buttonLabel;
      SubText = subText;
    }
    #endregion
  }
}
