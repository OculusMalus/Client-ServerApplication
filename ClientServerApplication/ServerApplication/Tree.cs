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

        public Tree(string value)
        {
            top = new Node(value);
        }


        public void AddStart(string value)
        {
            AddRecursive(ref top, value);
            
        }

        private void AddRecursive(ref Node node, string value)
        {
            if (node == null)
            {
                Node newNode = new Node(value);
                node = newNode;
                return;
            }
            if (String.Compare(value, node.value) < 0)
            {
                AddRecursive(ref node.left, value);
                return;
            }
            if (String.Compare(value, node.value)>=0)
            {
                AddRecursive(ref node.right, value);
                return;
            }
        }
    }
}
