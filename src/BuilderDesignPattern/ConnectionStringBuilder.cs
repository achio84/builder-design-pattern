using Microsoft.Data.SqlClient;

namespace BuilderDesignPattern
{
    internal sealed class ConnectionStringBuilder
    {
        private string _serverName = string.Empty;
        private string _dbName = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private bool _trustedConnection = false;


        public ConnectionStringBuilder()
        {
        }

        public ConnectionStringBuilder WithDbServer(string serverName)
        {
            _serverName = serverName;
            return this;
        }

        public ConnectionStringBuilder WithDatabaseName(string dbName)
        {
            _dbName = dbName;
            return this;
        }

        public ConnectionStringBuilder WithLogin(string userName, string password)
        {
            _userName = userName;
            _password = password;
            return this;
        }

        public ConnectionStringBuilder WithTrustedConnection()
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
}
