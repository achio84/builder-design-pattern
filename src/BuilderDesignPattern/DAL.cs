﻿using Microsoft.Data.SqlClient;

namespace BuilderDesignPattern
{
    internal sealed class DAL
    {
        private SqlConnection GetConnectionString()
        {
            //return new SqlConnection("Server=localhost; Database=IdentityServer2; Trusted_Connection=True; TrustServerCertificate=True;");

            //var builder = new ConnectionStringBuilder();
            //var connection = builder
            //    .WithDbServer("localhost")
            //    .WithDatabaseName("IdentityServer2")
            //    .WithTrustedConnection()
            //    .Build();

            var connection = ConnectionStringStagedBuilder
                .CreateConnection()
                .WithServer("localhost")
                .WithDatabase("IdentityServer2")
                .WithTrustedConnection()
                .Build();

            return connection;
        }

        public async Task<DateTimeOffset> GetDateTimeOffset(CancellationToken cancellationToken)
        {
            using(var conn = GetConnectionString())
            {
                if(conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT GETDATE();";
                    var currentDate = await cmd.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    if (currentDate != null)
                    {
                        return DateTimeOffset.Parse(currentDate.ToString());
                    }
                }
                return DateTimeOffset.MinValue;
            }
            
        }
    }
}
