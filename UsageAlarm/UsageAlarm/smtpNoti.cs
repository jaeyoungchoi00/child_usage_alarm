using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace UsageAlarm
{
    public class smtpNoti
    {
        private static bool mailSent = false;
        private MailMessage message; 


        public void sendEmailAsync(string toAddr, string minute)
        {
            SmtpClient client = new SmtpClient("emailserver", 587);
            //client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            //client.EnableSsl = true;  // SSL을 사용한다.
            //client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential("email@address.com", "password");
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;

            MailAddress from = new MailAddress("destination", "Name", System.Text.Encoding.UTF8);

            MailAddress to = new MailAddress(toAddr);

            //MailMessage message = new MailMessage(from, to);
            message = new MailMessage(from, to);

            message.Body = "This is sent by an Home PC UsageAlarm application. " + minute + " minutes used.";
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "UsageAlarm notification";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            // Set the method that is called back when the send operation ends.
            client.SendCompleted += Client_SendCompleted;

            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "Usage Alarm";
            client.SendAsync(message, userState);

        }

        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;

            // Clean up.
            message.Dispose(); 

        }
    }
}
