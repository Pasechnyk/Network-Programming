using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Task - Create Mail Sender application using SMTP

namespace MailProtocol
{
    public partial class MessageWindow : Window
    {
        OpenFileDialog dialog = new OpenFileDialog();

        const string myMailAddress = "pasechnyknastya@gmail.com";
        const string accountPassword = "nastya";

        public MessageWindow()
        {
            InitializeComponent();
        }

        private void SendMailClick(object sender, RoutedEventArgs e)
        {
            // create new mail
            MailMessage mail = new MailMessage(myMailAddress, toTxtBox.Text)
            {
                Subject = subjectTxtBox.Text,
                Body = $"<h1>My Mail Message from C#</h1><p>{bodyTxtBox.Text}</p>",
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            // add attachments
            var result = MessageBox.Show("Do you want to attach a file?", "Attach File", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("You can now attach multiple files!");

                OpenFileDialog dialog = new OpenFileDialog();

                //multiple files attachment
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == true)
                {
                    mail.Attachments.Add(new Attachment(dialog.FileName));
                }
            }

            // send mail message
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myMailAddress, accountPassword),
                EnableSsl = true
            };

            client.Send(mail);

        }
    }
}
