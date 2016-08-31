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

            TcpClient client = new TcpClient("10.2.20.7", 45241);
            Console.WriteLine("[Trying to connect to server...]");
            NetworkStream stream = client.GetStream();
            Console.WriteLine("[Connected]");
            string ch = Console.ReadLine();
            byte[] message = Encoding.Unicode.GetBytes(ch);
            stream.Write(message, 0, message.Length);
            Console.WriteLine("--------------Sent--------------");
            client.Close();
            Console.ReadKey();

            }
     }

}



