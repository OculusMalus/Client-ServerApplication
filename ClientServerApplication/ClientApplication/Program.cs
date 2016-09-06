using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;

namespace ClientApplication
{

    class Program
    {
        static void Main(String[] args)
        {
            TcpClient client = new TcpClient("10.2.20.14", 15357);
            Console.WriteLine("[Trying to connect to server...]");

            NetworkStream stream = client.GetStream();
            Console.WriteLine("[Connected]");

            Console.WriteLine("Please enter a username");
            string userName = Console.ReadLine();

            userName = "  " + userName + "$$$user$";
            byte[] outStream = Encoding.Unicode.GetBytes(userName);

            stream.Write(outStream, 0, outStream.Length);
            stream.Flush();

            RunChat chat = new RunChat();
            chat.Chat(client);
        }
    }
}




