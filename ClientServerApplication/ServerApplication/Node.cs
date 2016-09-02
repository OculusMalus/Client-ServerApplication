using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class Node
    {
        public string value;
        public Node left;
        public Node right;

        public Node(string initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }
}
