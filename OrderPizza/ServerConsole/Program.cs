using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Collection;
using Newtonsoft.Json;

namespace ServerConsole
{
    class Program
    {
        static IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        static int port = 7777;
        static void Main(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(iPAddress, port);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

            TcpListener server = new TcpListener(localEndPoint);
            server.Start(10);

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Order confirmation. Please wait...");

                    TcpClient client = server.AcceptTcpClient();

                    BinaryFormatter serializer = new BinaryFormatter();
                    var getOrder = (Order)serializer.Deserialize(client.GetStream());

                    Console.WriteLine($"{client.Client.RemoteEndPoint} just made an order!");
                    Console.WriteLine($"Order from {getOrder.Name} {getOrder.Surname}: {getOrder.Pizza}" +
                        $"\n Contacts: {getOrder.Phone}, {getOrder.Address}");

                    var jsonSave = JsonConvert.SerializeObject(getOrder);
                    File.AppendAllText(@"PizzaOrders.json", jsonSave);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saved!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
