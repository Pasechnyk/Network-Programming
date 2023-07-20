using Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace PizzaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrderBtnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTxt.Text) || !string.IsNullOrWhiteSpace(surnameTxt.Text)
                || !string.IsNullOrWhiteSpace(addressTxt.Text) || !string.IsNullOrWhiteSpace(phonesTxt.Text)
                || !string.IsNullOrWhiteSpace(pizzaNameTxt.Text))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7777);
                TcpClient client = new TcpClient();

                try
                {
                    client.Connect(endPoint);
                    Order order = new()
                    {
                        Name = nameTxt.Text,
                        Surname = surnameTxt.Text,
                        Address = addressTxt.Text,
                        Phone = phonesTxt.Text,
                        Pizza = pizzaNameTxt.Text
                    };

                    BinaryFormatter serializer = new BinaryFormatter();
                    using (NetworkStream stream = client.GetStream())
                    {
                        serializer.Serialize(stream, order);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You missed the info! Complete and try again.");
            }
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
