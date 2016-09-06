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

namespace ServerApplication
{
    public class ChatServer
    {

        static IPAddress ipAddress = IPAddress.Parse("10.2.20.14");
        TcpListener listener = new TcpListener(ipAddress, 15357);
        TcpClient chatClient = default(TcpClient);
        Tree userTree = new Tree();
        int counter = 0;

        public void BeginService()
        {
            try
            {
                listener.Start();
                Console.WriteLine(" >> " + "Server Started");

                while (true)
                {
                    chatClient = listener.AcceptTcpClient();

                    HandleSession client = new HandleSession(chatClient);
                   
                    userTree.AddStart(client);
                    counter += 1;
                    Thread startClient = new Thread(() => client.StartClient (chatClient, Convert.ToString(counter)));

                    startClient.Start();
                    
                }

                chatClient.Close();

                listener.Stop();

                Console.WriteLine(" >> " + "exit");

                Console.ReadLine();

            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
