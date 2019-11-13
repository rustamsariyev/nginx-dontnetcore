using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core
{
    public class DbSettings
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string GetConnectionString()
        {
            string connectionString = "Server=" + this.Server + "; Port=" + this.Port + "; Database=" + this.Database + "; Username=" + this.Username + "; Password=" + this.Password;
            return connectionString;
        }
    }
}
