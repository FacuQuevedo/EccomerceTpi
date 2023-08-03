using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string? Nombre { get; set; }
        public string? UserType { get; set; }
    }
}
