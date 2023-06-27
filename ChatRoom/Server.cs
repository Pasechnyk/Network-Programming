using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

// Server 

const int port = 3737;
const string JOIN_CMD = "<join>";
const string LEAVE_CMD = "<leave>";

UdpClient server = new UdpClient(port);

// list of the chat members
HashSet<IPEndPoint> members = new();

while (true)
{
    IPEndPoint clientIP = null;
    byte[] data = server.Receive(ref clientIP);

    string message = Encoding.UTF8.GetString(data);

    Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}, from: {clientIP}");

    switch (message)
    {
        case JOIN_CMD:
            // check for members count
            if (members.Count >= 10)
            {
                return;
            }
            members.Add(clientIP);
            break;
        case LEAVE_CMD:
            members.Remove(clientIP);
            break;
        default:
            // prohibit sending message if not part of collection
            if (!members.Contains(clientIP)) return;

            foreach (var m in members)
                server.Send(data, data.Length, m);
            break;
    }
}
