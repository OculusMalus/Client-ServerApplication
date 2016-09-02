using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class ConcurrentDictionary
    {
        string key;
        string userName;

        public ConcurrentDictionary (string key, string username)
        {
            this.key = key;
            this.userName = username;
        }

    }
}
