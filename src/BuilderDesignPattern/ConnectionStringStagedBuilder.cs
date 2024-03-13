using Microsoft.Data.SqlClient;

namespace BuilderDesignPattern
{
    internal class ConnectionStringStagedBuilder : 
        IServerSelectionStage,
        IDatabaseSelectionStage,
        ILoginStage,
        IConnectionInitializationStage
    {
        private string _serverName = string.Empty;
        private string _dbName = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private bool _trustedConnection = false;

        private ConnectionStringStagedBuilder() { }

        public static IServerSelectionStage CreateConnection()
        {
            return new ConnectionStringStagedBuilder();
        }

        public IDatabaseSelectionStage WithServer(string serverName)
        {
            _serverName = serverName;
            return this;
        }

        public ILoginStage WithDatabase(string database)
        {
            _dbName = database;
            return this;
        }

        public IConnectionInitializationStage WithLoginCredentials(string userName, string password)
        {
            _userName = userName;
            _password = password;
            return this;
        }

        public IConnectionInitializationStage WithTrustedConnection()
        {
            _trustedConnection = true;
            return this;
        }

        public SqlConnection Build()
        {
            var connectionString = _trustedConnection switch
            {
                true => $"Server={_serverName}; Database={_dbName}; Trusted_Connection=True; TrustServerCertificate=True;",
                _ => $"Server={_serverName}; Database={_dbName}; User ID={_userName}; Password={_password}; TrustServerCertificate=True;"
            };

            return new SqlConnection(connectionString);
        }
    }

    public interface IServerSelectionStage
    {
        public IDatabaseSelectionStage WithServer(string serverName); 
    }

    public interface IDatabaseSelectionStage
    {
        public ILoginStage WithDatabase(string database);
    }

    public interface ILoginStage
    {
        public IConnectionInitializationStage WithLoginCredentials(string userName, string password);
        public IConnectionInitializationStage WithTrustedConnection();
    }

    public interface IConnectionInitializationStage
    {
        public SqlConnection Build();
    }
}
