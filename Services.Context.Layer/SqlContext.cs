using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Services.Contexts.Layer
{
    public interface ISqlContext
    {
        SqlConnection GetConnection();
    }

    public class SqlContext : ISqlContext
    {
        private readonly IConfiguration _configuration;

        public SqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = _configuration.GetSection($"Apis:Sql").Value;
            return new SqlConnection(connectionString);
        }

    }
}
