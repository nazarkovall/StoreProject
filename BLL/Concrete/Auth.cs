using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class Auth : IAuth
    {
        private readonly IUserDAL userDal;
        public Auth(IUserDAL userDal)
        {
            this.userDal = userDal;
        }
        public bool Login(string username, string password)
        {
            return userDal.Login(username, password);
        }

        public UserDTO GetUserByLogin(string username)
        {
            return userDal.GetUserByLogin(username);
        }

        public UserDTO GetUserById(int id)
        {
            return userDal.GetUserById(id);
        }

        public List<UserDTO> GetUsers()
        {
            return userDal.GetUsers();
        }
    }
}