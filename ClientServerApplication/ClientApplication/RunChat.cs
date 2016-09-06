using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApplication
{
    public class RunChat
    {
        TcpClient client;


        public void Chat(TcpClient client)
        {
            this.client = client;
            Thread getThread = new Thread(GetMessage);
            Thread sendThread = new Thread(SendMessage);
            getThread.Start();
            sendThread.Start();

        }
        public void SendMessage()
        {
            while ((true))
            {
                NetworkStream stream = client.GetStream();

                string message = Console.ReadLine();

                message = "  " + message + "$$$";

                byte[] outStream = Encoding.Unicode.GetBytes(message);

                stream.Write(outStream, 0, outStream.Length);

                stream.Flush();
            }
        }

        public void GetMessage()
        {
            while ((true))
            {
                NetworkStream stream = client.GetStream();

                byte[] inStream = new byte[100250];

                stream.Read(inStream, 0, client.ReceiveBufferSize);

                string returnData = Encoding.Unicode.GetString(inStream);

                Console.ReadKey();

                returnData = returnData.Substring(0, returnData.IndexOf("$$$"));

                Console.WriteLine("Data from Server : " + returnData);

                stream.Flush();
            }
        }
    }
}
