using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class MessageParse
    {

        public bool CheckForUserName(string dataToParse)
       {
           if (dataToParse.Contains("$$$user$"))
            {
                return true;
            }

           else 
            {
                return false;
            }

        }

    }
}
