using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core
{
    public class AllSettings
    {
        public DbSettings dbSettings { get; set; }
        public JwtSettings jwtSettings { get; set; }
    }
}
