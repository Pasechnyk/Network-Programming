using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

// Task - Create question-based application using sockets.

namespace Govorun
{
    public partial class MainWindow : Window
    {
        [ThreadStatic]
        private static Random _random = new Random();

        IPEndPoint? serverEdnpoint = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendBtnClick(object sender, RoutedEventArgs e)
        {
            serverEdnpoint = new IPEndPoint(IPAddress.Parse(addressTxtBox.Text), int.Parse(portTxtBox.Text));

            using UdpClient client = new();

            string message = msgTxtBox.Text;

            // check-up
            if (string.IsNullOrWhiteSpace(msgTxtBox.Text))
            {
                MessageBox.Show("You didn't write the question!");
            }

            byte[] data = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(data, data.Length, serverEdnpoint);

            historyList.Items.Add($"Me: {message} at {DateTime.Now.ToShortTimeString()}");


            // pre-made replies from server
            var messages = new[] { "Yes", "Maybe.", "No.", "Not sure.", "Decide yourself!" };

            string responseText = messages[_random.Next(messages.Length)];

            historyList.Items.Add($"Server: {responseText} at {DateTime.Now.ToShortTimeString()}");
        }
    }
}
