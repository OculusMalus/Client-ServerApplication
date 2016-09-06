using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class Node
    {
        public HandleSession value;
        public Node left;
        public Node right;

        public Node(HandleSession client)
        {
            value = client;
            left = null;
            right = null;
        }
    }
}
