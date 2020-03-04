using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contexts.Layer.Connections
{
    public interface IMysqlContext
    {
        MySqlConnection GetConnection();
    }

    public class MysqlContext : IMysqlContext
    {
        private readonly IConfiguration _configuration;

        public MysqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection GetConnection()
        {
            var connectionString = _configuration.GetSection($"Apis:Mysql").Value;
            return new MySqlConnection(connectionString);
        }

    }
}
