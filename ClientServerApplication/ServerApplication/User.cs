using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerApplication
{
    public class User
    {
        string userName;
        int userNumber;
        public NetworkStream userStream;

        public User(TcpClient client, string userName, int userNumber)
        {
            this.userName = userName;
            this.userNumber = userNumber;
        }
    }

}    
