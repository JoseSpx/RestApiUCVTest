using Commons;
using Domain.Dto.Layer.Clementina;
using Domain.Dto.Layer.Trilce;
using MySql.Data.MySqlClient;
using Services.Contexts.Layer.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Layer.Trilce
{
    public interface IClienteTrilceService
    {
        BaseResponse InsertarCliente(ClienteTrilceDto clienteTrilceDto); 
    }

    public class ClienteTrilceService : IClienteTrilceService
    {
        private readonly IMysqlContext _mysqlContext;

        public ClienteTrilceService(IMysqlContext mysqlContext)
        {
            _mysqlContext = mysqlContext;
        }

        public BaseResponse InsertarCliente(ClienteTrilceDto clienteTrilceDto)
        {
            MySqlConnection conn = _mysqlContext.GetConnection();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("usp_cliente_insertar", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("_nombre", clienteTrilceDto.Nombre);
            cmd.Parameters.AddWithValue("_apellido", clienteTrilceDto.Apellido);
            cmd.Parameters.AddWithValue("_fechaNacimiento", clienteTrilceDto.FechaNacimiento);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
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
