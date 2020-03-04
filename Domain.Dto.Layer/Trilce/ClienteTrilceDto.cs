using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto.Layer.Trilce
{
    public class ClienteTrilceDto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
