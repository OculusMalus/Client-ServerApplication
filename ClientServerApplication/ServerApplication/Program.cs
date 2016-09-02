using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace ServerApplication
{
    class Program

    {


        static void Main(String[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("10.2.20.17");
            TcpListener listener = new TcpListener(ipAddress, 15357);
            TcpClient chatClient = default(TcpClient);
            MessageParse msg = new MessageParse();
            string userName;

            int counter = 0;
            //start listening for client requests
            listener.Start();
            Console.WriteLine(" >> " + "Server Started");
            int i = 1;
            //enter the listening loop
            while (i != 0)
            {
                chatClient = listener.AcceptTcpClient();
                NetworkStream networkStream = chatClient.GetStream();

               
                byte[] bytesFrom = new byte[100000];
                // Loop to receive all the data sent by the client.
                
                i = networkStream.Read(bytesFrom, 0, chatClient.ReceiveBufferSize);


                string dataFromClient = Encoding.Unicode.GetString(bytesFrom);
                    userName = (msg.CheckForUserName(dataFromClient)) ? dataFromClient.Substring(0, dataFromClient.IndexOf("$$$")) : "User #" + counter;
                    counter += 1;
    
                    Tree userTree = new Tree(userName);
                    //broadcast that a user has joined
                    Console.WriteLine(" >> " + userName + " has joined!");


                
                    handleSession client = new handleSession();
                    client.startClient(chatClient, Convert.ToString(counter));
                    i = networkStream.Read(bytesFrom, 0, chatClient.ReceiveBufferSize);
                }
                chatClient.Close();
                listener.Stop();

                Console.WriteLine(" >> " + "exit");
                Console.ReadLine();
            }

        }
        }
           
    






