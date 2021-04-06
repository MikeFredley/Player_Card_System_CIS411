using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

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

        internal static void EmailTransactionHistory(List<Transaction> transactions, string pUserEmail)
        {
            userEmail = pUserEmail;
            subject = "Transaction History";
            body = "Transaction History\n";
            string.Format("<b>" + body + "</b>");

            AppendTransactions(transactions);

            Send();
        }

        internal static void EmailTransactionHistory(List<Transaction> transactions)
        {
            body += "\n\n\nTransaction History\n";

            AppendTransactions(transactions);
        }

        private static void AppendTransactions(List<Transaction> transactions)
        {
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                body += "\nDate: " + transactions[i].DateTime + "\n"
                         + "Transaction Type: " + transactions[i].TypeTrans + "\n"
                         + "Rounds Changed: " + transactions[i].RoundsChanged + "\n"
                         + "Total Rounds: " + transactions[i].TotalRounds + "\n"
                         + "Reason: " + transactions[i].Comments + "\n--------------------------------------";
            }
        }

        internal static void SendEmail(Transaction transaction, List<Transaction> resTransactions)
        {
            DateTime date = DateTime.Now;
            userEmail = transaction.EmailedTo;
            subject = "New Transaction";
            body = "A new transaction has occured on your golf account.\n"
                 + "Amount of Rounds " + transaction.TypeTrans +": " + transaction.RoundsChanged + "\n"
                 + "New Amount of Rounds: " + transaction.TotalRounds + "\n"
                 + "Date: " + date + "\n"
                 + "Reason: " + transaction.Comments;

            EmailTransactionHistory(resTransactions);

            Send();
        }

        private static void Send()
        {
            try
            {
                MailMessage mailDetails = new MailMessage(Database.OutGoingEmail.EmailAddress, userEmail);
                mailDetails.Subject = subject;
                mailDetails.Body = body;

                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential(Database.OutGoingEmail.EmailAddress, Database.OutGoingEmail.EmailPassword);
                clientDetails.Credentials = nc;
                clientDetails.EnableSsl = true;
                clientDetails.Send(mailDetails);

                MessageBox.Show("Email Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Send Email " + ex.Message);
            }
        }
    }
}
