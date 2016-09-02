using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApplication
{
    public class handleSession
    {
        MessageParse msg = new MessageParse();
        TcpClient chatClient;
        string clientNumber;

        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            chatClient = inClientSocket;
            clientNumber = clineNo;


            Thread getThread = new Thread(GetMessage);
            Thread sendThread = new Thread(SendMessage);

            getThread.Start();
            sendThread.Start();
                   
        }

        private void GetMessage()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[100000];
            string dataFromClient = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = chatClient.GetStream();

                    networkStream.Read(bytesFrom, 0, chatClient.ReceiveBufferSize);
                    dataFromClient = Encoding.Unicode.GetString(bytesFrom);

                    msg.CheckForUserName(dataFromClient);
                    
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$$$"));
                    Console.WriteLine(" >> " + "From client-" + clientNumber + dataFromClient);

                    rCount = Convert.ToString(requestCount);
                    networkStream.Flush();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                    //chatClient.Close();
                }
            }
        }

                private void SendMessage()
        {
            byte[] bytesFrom = new byte[100000];
            Byte[] sendBytes = null;
            string serverResponse = null;
            
            while ((true))
            {
                try
                {
                    NetworkStream networkStream = chatClient.GetStream();
                    serverResponse = Console.ReadLine();

                    serverResponse = serverResponse + "$$$";
                    sendBytes = Encoding.Unicode.GetBytes(serverResponse);

                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                    //chatClient.Close();
                }
            }
        }
    }
}
