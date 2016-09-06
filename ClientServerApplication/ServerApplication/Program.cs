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

            ChatServer server = new ChatServer();
            server.BeginService();
        }

    }
}
        
           
    






