using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerApplication
{
    class Program
    {
        static void Main(String[] args)
        {
            IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
            TcpListener listen = new TcpListener(ipAddress, 45241);
            Console.WriteLine("[Listening...]");
            listen.Start();
            TcpClient client = listen.AcceptTcpClient();
            Console.WriteLine("[Client connected]");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string ch = Encoding.Unicode.GetString(buffer, 0, data);
            Console.WriteLine("Message recieved: " + ch);
            client.Close();
            Console.ReadKey();
        }
    }
}


