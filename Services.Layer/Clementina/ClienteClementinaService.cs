using Commons;
using Domain.Dto.Layer.Clementina;
using Services.Contexts.Layer;
using System;
using System.Data.SqlClient;

namespace Services.Layer.Clementina
{
    public interface IClienteClementinaService
    {
        BaseResponse InsertarCliente(ClienteClementinaDto clienteClementinaDto);
    }

    public class ClienteClementinaService : IClienteClementinaService
    {
        private readonly ISqlContext _sqlContext;

        public ClienteClementinaService(ISqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public BaseResponse InsertarCliente(ClienteClementinaDto clienteClementinaDto)
        {
            var conn = _sqlContext.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("[dbo].[usp_cliente_insertar]", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@nombre", clienteClementinaDto.Nombre);
            cmd.Parameters.AddWithValue("@apellido", clienteClementinaDto.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", clienteClementinaDto.FechaNacimiento);

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
