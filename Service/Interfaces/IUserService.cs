using System.Collections.Generic;
using Model.DTOs;
using Model.ViewModels;

namespace Service.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetUserById(int id);
        CreateUser UpdateUser(CreateUser user);
        void DeleteUser(int id);
    }
}