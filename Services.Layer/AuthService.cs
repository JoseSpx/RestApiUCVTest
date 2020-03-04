using Commons;
using MySql.Data.MySqlClient;
using Services.Contexts.Layer;
using Services.Contexts.Layer.Connections;
using System;
using System.Data.SqlClient;

namespace Services.Layer
{
    public interface IAuthService
    {
        public BaseResponse Login(string usuario, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ISqlContext _sqlContext;

        public AuthService(ISqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public BaseResponse Login(string usuario, string password)
        {
            var conn = _sqlContext.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("[dbo].[usp_login]", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@password", password);

            var reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                return new BaseResponse()
                {
                    Success = Convert.ToBoolean(reader["success"]),
                    Message = reader["message"].ToString()
                };
            }
            return null;
        }
    }
}
