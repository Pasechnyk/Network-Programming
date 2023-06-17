using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Task - Authorize and navigate in gmail folders using IMAP.

namespace MailClient
{
    public partial class MainWindow : Window
    {
        private string mailAddress;
        private string mailPassword;

        public MainWindow()
        {
            InitializeComponent();

            mailAddress = loginTxt.Text;
            mailPassword = passwordTxt.Password;

            showAllBtn.IsEnabled = false;
            showDraftBtn.IsEnabled = false;
            showJunkBtn.IsEnabled = false;
        }

        private void LogInBtnClick(object sender, RoutedEventArgs e)
        {
            var password = passwordTxt.Password;

            if (string.IsNullOrWhiteSpace(loginTxt.Text) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Access denied: \n - fields are empty.");
                return;
            }

            showAllBtn.IsEnabled = true;
            showDraftBtn.IsEnabled = true;
            showJunkBtn.IsEnabled = true;
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowAllBtnClick(object sender, RoutedEventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate(mailAddress, mailPassword);

                foreach (var item in client.GetFolders(client.PersonalNamespaces[0]))
                {
                    mailListBox.Items.Add(item.Name);
                }
            }

        }

        private void ShowDraftBtnClick(object sender, RoutedEventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate(mailAddress, mailPassword);

                foreach (var item in client.GetFolder(SpecialFolder.Drafts))
                {
                    mailListBox.Items.Add(item.Headers);
                }
            }
        }

        private void ShowJunkBtnClick(object sender, RoutedEventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate(mailAddress, mailPassword);

                foreach (var item in client.GetFolder(SpecialFolder.Trash))
                {
                    mailListBox.Items.Add(item.Headers);
                }
            }
        }
    }
}
