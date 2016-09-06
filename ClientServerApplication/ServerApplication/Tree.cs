using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class Tree 
    {
        Node top;

        public void AddStart(HandleSession client)
        {
            AddRecursive(ref top, client);
            
        }

        private void AddRecursive(ref Node node, HandleSession client)
        {
            if (node == null)
            {
                top = new Node(client);
                return;
            }
            if (client.CompareTo(node.value) < 0)
            {
                AddRecursive(ref node.left, client);
                return;
            }
            if (client.CompareTo(node.value) >=0)
            {
                AddRecursive(ref node.right, client);
                return;
            }
        }
    }
}
