using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApplication
{
    public class HandleSession : IComparable
    {
        static Dictionary<string, User> usersDictionary = new Dictionary<string, User>();
        MessageParse msg = new MessageParse();
        public TcpClient chatClient;
        //string clientNumber;
        public string userName;
        int i = 1;

        public HandleSession(TcpClient client)
        {
            this.chatClient = client;
        }


        public void StartClient(TcpClient inClientSocket, string clineNo)
        {
            chatClient = inClientSocket;
            int clientNumber = Convert.ToInt32(clineNo);

            byte[] bytesFrom = new byte[100000];
            NetworkStream networkStream = chatClient.GetStream();
            networkStream.Read(bytesFrom, 0, chatClient.ReceiveBufferSize);

            string dataFromClient = Encoding.Unicode.GetString(bytesFrom);
            userName = (msg.CheckForUserName(dataFromClient)) ? dataFromClient.Substring(0, dataFromClient.IndexOf("$$$")) : "User #" + clineNo;
            Console.WriteLine(" >> " + userName + " has joined!");

            User user = new User(chatClient, userName, clientNumber);
            usersDictionary.Add(userName, user);

            Thread getThread = new Thread(HandleMessage);
            Thread sendThread = new Thread(SendMessage);

            getThread.Start();
            sendThread.Start();

        }

        private void HandleMessage()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[100000];
            string dataFromClient = null;
            //string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;

                    NetworkStream networkStream = chatClient.GetStream();

                    networkStream.Read(bytesFrom, 0, chatClient.ReceiveBufferSize);

                    dataFromClient = Encoding.Unicode.GetString(bytesFrom);

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$$$"));

                    Queue<string> messageQ = new Queue<string>();

                    messageQ.Enqueue(dataFromClient);

                    Console.WriteLine(" >> " + "From client- " + dataFromClient);

                    
                    Dictionary<string, User>.KeyCollection usersKeys = usersDictionary.Keys;

                                            
                    foreach (string userName in usersKeys)
                    {
                        NetworkStream relayStream = chatClient.GetStream();

                        string message = dataFromClient;//messageQ.Dequeue();

                        message = "  >> " + "From " + userName + ": " + message + "$$$";

                        byte[] outStream = Encoding.Unicode.GetBytes(message);

                        relayStream.Write(outStream, 0, outStream.Length);

                        networkStream.Flush();
                    }
                    //{
                    //    Byte[] echoBytes = new byte[100000];
                    //    //Byte[] echoBytes = null;
                    //    //NetworkStream EchoStream = chatClient.GetStream();
                    //    echoBytes = Encoding.Unicode.GetBytes(dataFromClient);

                    //    networkStream.Write(echoBytes, 0, echoBytes.Length);
                    //}

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
            //Byte[] sendBytes = null;
            //string serverResponse = null;

            while ((true))
            {
                try
                {
                    NetworkStream stream = chatClient.GetStream();

                    string message = Console.ReadLine();

                    message = "  " + message + "$$$";

                    byte[] outStream = Encoding.Unicode.GetBytes(message);

                    stream.Write(outStream, 0, outStream.Length);

                    stream.Flush();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                    //chatClient.Close();
                }
            }
        }

        public int CompareTo(object obj)
        {
            return string.Compare(((HandleSession)obj).userName, userName);
        }

    }
}
