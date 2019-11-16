using Library.Core;
using Library.Core.Postgresql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.PostgresRepository
{
    public class MainPgRepository
    {
        public readonly DbSettings DbSettings;
        public NpgsqlCommand Cmd;
        public readonly LibraryFunctions LibraryFunctions;
        //public readonly LibraryErrorMessages LibraryErrorMessages;

        public MainPgRepository(DbSettings _dbSettings, LibraryFunctions _libraryFunctions/*, LibraryErrorMessages _libraryErrorMessages*/)
        {
            DbSettings = _dbSettings;
            LibraryFunctions = _libraryFunctions;
            //LibraryErrorMessages = _libraryErrorMessages;
        }

        public void CreateFunctionCallQuery(string functionName, NpgsqlConnection connection)
        {
            this.Cmd = new NpgsqlCommand(@$"{functionName}", connection);
            this.Cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public NpgsqlConnection CreateConnection()
        {
            string connectionString = DbSettings.GetConnectionString();
            return new NpgsqlConnection(connectionString);           
        }
    }
}
