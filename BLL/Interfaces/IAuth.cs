using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAuth
    {
        bool Login(string username, string password);
        List<UserDTO> GetUsers();
        UserDTO GetUserByLogin(string username);
        UserDTO GetUserById(int id);
    }
}