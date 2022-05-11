using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Aman.Services
{
    public class SendEmail
    {
        public const string FROM_EMAILS = "noreply@mailkamfr.com";
        public const string TO_EMAILS = "amalproperties20@gmail.com";
        public const string BCC_EMAILS = "khenawy@gmail.com,shaun2461@gmail.com";
        public const string EMAIL_PLATFORM_ID = "0";
        public const string EMAIL_PLATFORM_NAME = "AMAL";
        #region "Public Constants"

        #endregion

        #region "Private Variables"
        private string m_CC;
        private string m_BCC;
        private string[] m_Attachment;
        private MailPriority m_Priority;
        #endregion
        private static bool m_IsBodyHTML;

        #region "Public Properties"
        public string EmailFromChiroTouch
        {
            get { return FROM_EMAILS; }
        }
        public string EmailCC
        {
            get { return m_CC; }
            set { m_CC = value; }
        }
        public string EmailBCC
        {
            get { return m_BCC; }
            set { m_BCC = value; }
        }
        public string[] EmailAttachment
        {
            get { return m_Attachment; }
            set { m_Attachment = value; }
        }
        public MailPriority EmailPriority
        {
            get { return m_Priority; }
            set { m_Priority = value; }
        }
        public bool IsBodyHTML
        {
            get { return m_IsBodyHTML; }
            set { m_IsBodyHTML = value; }
        }

        public int PortNumber { get; set; }
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }

        #endregion

        #region "ENUM"
        public enum MailPriority
        {
            NormalPriority = 0,
            LowPriority = 1,
            HightPriority = 2
        }
        #endregion

        #region "Constructor and Destructor"

        public SendEmail()
        {
            // Initialize without a course
            EmailCC = "";
            EmailBCC = "";
            EmailPriority = MailPriority.NormalPriority;
            IsBodyHTML = false;

            this.PortNumber = 587;
            this.Server = "email-smtp.us-west-1.amazonaws.com";
            this.UserName = "AKIAT5UUSNNTEXPZMDO7";
            this.Password = "BOeektjYNuoFkFxCuiSVAZ31Fk5JyRbzEd249h2Xftpj";
            this.EnableSsl = true;
            //EmailAttachment = Nothing
            return;

        }

        public string SendEmailNow(string EmailSubject, string EmailBody, MailAddress EmailFrom, string EmailTo = TO_EMAILS)
        {
            int i = 0;
            string[] tmpEmail = null;

            try
            {
                //Exit Point
                if (string.IsNullOrEmpty(EmailFrom.Address.Trim()))
                    return "No email from!";
                if (string.IsNullOrEmpty(EmailTo.Trim()))
                    return "No email to!";
                if (string.IsNullOrEmpty(EmailSubject.Trim()))
                    return "No email subject!";
                if (string.IsNullOrEmpty(EmailBody.Trim()))
                    return "No email body!";


                ////Remove khaled
                //EmailTo = "khenawy@gmail.com";
                //EmailCC = null;

                //'This is the message
                MailMessage Message = new MailMessage(EmailFrom.Address, EmailTo, EmailSubject, EmailBody);

                //Add the name and Message
                Message.From = new MailAddress(EmailFrom.Address, EmailFrom.DisplayName);

                if ((EmailCC != null))
                {
                    if (!string.IsNullOrEmpty(EmailCC.Trim()))
                    {
                        //Start the validation process.
                        tmpEmail = EmailCC.Split(',');
                        if ((tmpEmail != null) && tmpEmail.Length >= 1)
                        {
                            for (i = 0; i <= tmpEmail.Length - 1; i++)
                            {
                                if (isEmailAddressValid(tmpEmail[i]))
                                {
                                    Message.CC.Add(tmpEmail[i]);
                                }
                                else
                                {
                                    //Write to a log file
                                }
                            }
                        }
                    }
                }

                //Reset
                tmpEmail = null;

                if ((EmailBCC != null))
                {
                    if (!string.IsNullOrEmpty(EmailBCC.Trim()))
                    {
                        //Start the validation process.
                        tmpEmail = EmailBCC.Split(',');
                        if ((tmpEmail != null) && tmpEmail.Length >= 1)
                        {
                            for (i = 0; i <= tmpEmail.Length - 1; i++)
                            {
                                if (isEmailAddressValid(tmpEmail[i]))
                                {
                                    Message.Bcc.Add(tmpEmail[i]);
                                }
                                else
                                {
                                    //Write to a log file
                                }
                            }
                        }
                    }
                }

                try
                {
                    if ((EmailAttachment != null))
                    {
                        for (int Counter = 0; Counter <= EmailAttachment.Length - 1; Counter++)
                        {
                            System.Net.Mail.Attachment Attachment = new System.Net.Mail.Attachment(EmailAttachment[Counter]);
                            //Add it to the mail message
                            Message.Attachments.Add(Attachment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Attachment failed but continue
                }

                //By default, it's set to Normal
                //Message.Priority = EmailPriority;
                Message.IsBodyHtml = IsBodyHTML;

                //Send email through port 25 then 465 then Gamil account  port 465 then 25
                string ret = SendEmailViaHost(ref Message, Server, UserName, Password, PortNumber, this.EnableSsl);

                Message.Dispose();

                return ret;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string SendEmailViaHost(ref MailMessage Message, string HostName, string UserName, string Password, int port, bool EnableSsl)
        {
            try
            {
                //Set the credentials
                System.Net.NetworkCredential Credentials = new System.Net.NetworkCredential();
                Credentials.UserName = UserName;
                Credentials.Password = Password;

                //This is the SMTP Server
                SmtpClient Host = null;

                if (port == 0) //Go with default
                    Host = new SmtpClient(HostName);
                else
                    Host = new SmtpClient(HostName, port);

                Host.UseDefaultCredentials = false;
                Host.Credentials = Credentials;
                Host.EnableSsl = EnableSsl;

                //'Send the message
                Host.Send(Message);

                return "";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public static bool isEmailAddressValid(string EmailAddress)
        {
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-­9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";
            Regex reg = new Regex(strRegex);

            try
            {
                if (reg.IsMatch(EmailAddress))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }

        public static string LoadFileContents(string fileName)
        {
            try
            {

                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                {
                    StreamReader sr = new StreamReader(fileStream);
                    string s = sr.ReadToEnd();
                    fileStream.Flush();
                    fileStream.Close();
                    return s;
                }
            }
            catch (Exception ex)
            {
               return null;
            }
        }

        #endregion

    }
}
