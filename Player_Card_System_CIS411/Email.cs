using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Player_Card_System_CIS411
{
    public static class Email
    {

        private static string userEmail;
        private static string subject;
        private static string body;
        static Email()
        {

        }

        internal static void SetUserEmail(string pUserEmail)
        {
            userEmail = pUserEmail;
        }

        internal static void RoundsPurchasedEmail(int pRoundsPurchased, int pNewRounds, string pUserEmail)
        {
            userEmail = pUserEmail;
            DateTime date = DateTime.Now;
            subject = "Rounds Purchased";
            body = "Amount of Rounds Purchased: " + pRoundsPurchased + "\n"
                 + "New Amount of Rounds: " + pNewRounds + "\n"
                 + "Date: " + date;
            SendEmail();
        }

        internal static void RoundsDeductedEmail(int pRoundsDeducted, int pNewRounds, string pUserEmail)
        {
            userEmail = pUserEmail;
            DateTime date = DateTime.Now;
            subject = "Rounds Used";
            body = "Amount of Rounds Used: " + pRoundsDeducted + "\n"
                 + "New Amount of Rounds: " + pNewRounds + "\n"
                 + "Date: " + date;
            SendEmail();
        }

        internal static void RoundsAdjustedEmail(int pRoundsAdjusted, int pNewRounds, string pUserEmail, string pReason)
        {
            userEmail = pUserEmail;
            DateTime date = DateTime.Now;
            subject = "Rounds Adjusted";
            body = "Amount of Rounds Adjusted: " + pRoundsAdjusted + "\n"
                 + "New Amount of Rounds: " + pNewRounds + "\n"
                 + "For Reason: " + pReason + "\n"
                 + "Date: " + date;
            SendEmail();
        }

        private static void SendEmail()
        {
            MailMessage mailDetails = new MailMessage(Database.OutGoingEmail.EmailAddress, userEmail);
            mailDetails.Subject = subject;
            mailDetails.Body = body;

            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Host = "smtp.gmail.com";
            clientDetails.Port = 587;
            string password = PasswordEncrypt.hash(Database.OutGoingEmail.EmailPassword);
            System.Net.NetworkCredential nc = new NetworkCredential(Database.OutGoingEmail.EmailAddress, "oceanvillage123");
            clientDetails.Credentials = nc;
            clientDetails.EnableSsl = true;
            clientDetails.Send(mailDetails);

            Console.WriteLine("Email Sent");
        }
    }
}
