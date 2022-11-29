using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO CreateUser(UserDTO user);
        List<UserDTO> GetAllUsers();
        UserDTO GetUser(string login);
        UserDTO GetUser(int id);
        bool Login(string username, string password);
        void UpdateUser(UserDTO user);
        void DeleteUser(UserDTO user);
    }
}