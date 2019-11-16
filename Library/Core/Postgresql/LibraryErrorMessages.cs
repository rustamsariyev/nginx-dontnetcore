using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Library.Core.Postgresql
{
    public static class LibraryErrorMessages
    {
        public static string lib_0001 = "Book does't exists";


        public static string GetErrorMessage(string errorCode)
        {
            //Get type of MyClass
            Type myType = Type.GetType("Library.Core.Postgresql.LibraryErrorMessages");

            //Get PropertyInfo for property SomeProperty
            PropertyInfo pi = myType.GetProperty(errorCode);
             
            return (String) pi.GetValue(null, null);
        }
    }
}
