using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core.ControllerHelperClasses
{
    public class LibraryControllerBase : ControllerBase
    {
        DbSettings dbSettings { get; }

        public LibraryControllerBase(DbSettings _dbSettings)
        {
            dbSettings = _dbSettings;
        }      
    }
}
