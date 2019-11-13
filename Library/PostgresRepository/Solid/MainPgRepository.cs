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
        private readonly DbSettings DbSettings;
        public NpgsqlCommand Cmd { get; set; }
        public LibraryFunctions LibraryFunctions { get; }

        public MainPgRepository(DbSettings _dbSettings)
        {
            this.DbSettings = _dbSettings;
            LibraryFunctions = new LibraryFunctions();
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
