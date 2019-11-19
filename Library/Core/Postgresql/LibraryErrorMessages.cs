using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Library.Core.Postgresql
{
    public static class LibraryErrorMessages
    {
        public static Dictionary<String, String> lib_user_errors = new Dictionary<string, string>()
        {
            {"lib_0001", "The book was not found." },
            {"lib_0002", "The books were not found."},
            {"lib_sys_0001", "Database is unaccessible." }
        };

        public static string GetErrorMessage(string errorCode)
        {
            string errorMessage = "";

            if (errorCode.StartsWith("lib"))
            {
                errorMessage = lib_user_errors[errorCode];                
            }
            else
            {
                errorMessage = lib_user_errors["lib_sys_0001"];
            }

            return errorMessage;            
        }
    }
}
