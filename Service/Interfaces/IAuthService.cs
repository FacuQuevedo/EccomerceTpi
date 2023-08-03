using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModels;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        string CrearUsuario(UserViewModel user);
        string Login(AuthDTO user);

    }
}