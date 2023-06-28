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
using System.Windows.Shapes;

namespace MessengerApp
{
    public partial class MessengerWindow : Window
    {
        UdpClient client = new UdpClient();
        private bool isListening = false;

        public MessengerWindow(string name)
        {
            InitializeComponent();

            nameTxtBox.Text = name;
        }

        private async void Listen()
        {
            while (isListening)
            {
                // add name and date of message sent
                string date = DateTime.Now.ToShortTimeString();
                string userName = nameTxtBox.Text;

                var res = await client.ReceiveAsync();
                string msg = Encoding.UTF8.GetString(res.Buffer);

                string fullMsg = $"{userName}: {msg} \nTime: {date}";
                msgList.Items.Add(fullMsg);
            }
        }

        private void SendBtnClick(object sender, RoutedEventArgs e)
        {
            // if message is empty
            if (string.IsNullOrWhiteSpace(msgTxtBox.Text)) return;

            string text = msgTxtBox.Text;

            // if message is join or leave
            if (text == "<join>" || text == "<leave>") return;

            SendMessage(text);
        }

        private void JoinBtnClick(object sender, RoutedEventArgs e)
        {
            SendMessage("<join>");
            string userName = nameTxtBox.Text;
            string joinMsg = $"-----------{userName} has just joined!-----------";
            msgList.Items.Add(joinMsg);

            isListening = true;
            Listen();
        }

        private void LeaveBtnClick(object sender, RoutedEventArgs e)
        {
            SendMessage("<leave>");
            string userName = nameTxtBox.Text;
            string leaveMsg = $"-----------{userName} has just left!-----------";
            msgList.Items.Add(leaveMsg);
            isListening = false;
        }

        private void SendMessage(string text)
        {
            IPEndPoint serverIP = new(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

            byte[] data = Encoding.UTF8.GetBytes(text);
            client.Send(data, data.Length, serverIP);
        }
    }
}
