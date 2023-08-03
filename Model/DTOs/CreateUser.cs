using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class CreateUser
    {
        public int IdUser { get; set; }
        public string ?Name { get; set; }
        public string ?Lastname { get; set; }
        public string ?Mail { get; set; }
        public string ?Password { get; set; }
        public int IdRol { get; set; }
    }
}
