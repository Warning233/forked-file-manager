using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Manager
{
    [Serializable]
    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Users() { }
        public Users(string username, string password) 
        {
            Name = username;
            Password = password;
        }
    }
}
