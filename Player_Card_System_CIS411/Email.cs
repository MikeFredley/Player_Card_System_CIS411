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
            body = "<b>Transaction History</b><br><br>";

            AppendTransactions(transactions);

            Send();
        }

        internal static void EmailTransactionHistory(List<Transaction> transactions)
        {
            body += "<br><br><b>Transaction History</b><br><br>";

            AppendTransactions(transactions);
        }

        private static void AppendTransactions(List<Transaction> transactions)
        {
           // var columnHeader = string.Format($"{"Date",40}{"Transaction Type",45}{"Rounds Changed",20}{"Old Balance",20}{"New Balance",21}{"Reason",20}");
        
            string columnHeader = "<table style='border: 1px solid black'>" +
                                    "<tr>" +
                                       "<th>Date</th>" +
                                       "<th>Transaction Type</th>" +
                                       "<th>Rounds Changed</th>" +
                                       "<th>Old Balance</th>" +
                                       "<th>New Balance</th>" +
                                       "<th>Reason</th> " +
                                    "</tr>";

            body += columnHeader;
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                string columnData = "<tr>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].DateTime + "</td>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].TypeTrans + "</td>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].RoundsChanged+ "</td>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].OldBalance + "</td>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].TotalRounds + "</td>" +
                                       "<td style='border: 1px solid black; text-align: center'>" + transactions[i].Comments+ "</td> " +
                                    "</tr>";
                body += columnData;
                /* var columnData = string.Format($"{transactions[i].DateTime,40}" +
                                                 $"{transactions[i].TypeTrans,30}" +
                                                 $"{transactions[i].RoundsChanged,+30}" +
                                                 $"{transactions[i].OldBalance,+30}" +
                                                 $"{transactions[i].TotalRounds,+30}" +
                                                 $"{transactions[i].Comments,30}");

                 body += "\n" + columnData;*/

                /* body += "\nDate: " + transactions[i].DateTime + ", "
                          + "Transaction Type: " + transactions[i].TypeTrans + ", "
                          + "Rounds Changed: " + transactions[i].RoundsChanged + ", "
                          + "Old Balance: " + transactions[i].OldBalance + ", "
                          + "New Balance: " + transactions[i].TotalRounds + ", "
                          + "Reason: " + transactions[i].Comments 
                          + "\n---------------------------------------------------------------------------------------------------------------------------------------------------"; */
            }
            body += "</table>";
        }

        internal static void SendEmail(Transaction transaction, List<Transaction> resTransactions)
        {
            DateTime date = DateTime.Now;
            userEmail = transaction.EmailedTo;
            subject = "New Transaction";
            body = "A new transaction has occurred on your golf account.<br>"
                 + "Number of Rounds " + transaction.TypeTrans +": " + transaction.RoundsChanged + "<br>"
                 + "Old Balance of Rounds: " + transaction.OldBalance + "<br>"
                 + "New Balance of Rounds: " + transaction.TotalRounds + "<br>"
                 + "Date: " + date + "<br>"
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
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "<span style=''font-family:Courier;font-size: 10pt;''>&nbsp" + body + "</span>";


                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential(Database.OutGoingEmail.EmailAddress, Database.OutGoingEmail.EmailPassword);
                clientDetails.Credentials = nc;
                clientDetails.EnableSsl = true;
                clientDetails.Send(mailDetails);

              //  MessageBox.Show("Email Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Send Email " + ex.Message);
            }
        }
    }
}
