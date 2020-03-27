using Npgsql;
using System.Data;

namespace DbRepository
{
    public class Query
    {
        private readonly string ConnectionString = //"Data Source=(local);Initial Catalog=DapperExample;Integrated Security=SSPI";
            "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=TasksDB;Pooling=true;";

        public Query()
        {

        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(ConnectionString);
            }
        }
    }
}
