using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DAL.Interfaces;
using DTO;

namespace DAL.Concrete
{
    public class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;

        public UserDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Login(string username, string password)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                UserDTO user = _mapper.Map<UserDTO>(entities.users.FirstOrDefault(u => u.Login == username));
                return user != null && user.Password.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }

        public UserDTO CreateUser(UserDTO user)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB.RowInsertTime = DateTime.UtcNow;
                userInDB.RowUpdateTime = DateTime.UtcNow;
                entities.users.Add(userInDB);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(userInDB);
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var users = entities.users.ToList();
                return _mapper.Map<List<UserDTO>>(users);
            }
        }

        public UserDTO GetUser(string login)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.users.SingleOrDefault(d => d.Login == login);
                return _mapper.Map<UserDTO>(found);
            }
        }

        public UserDTO GetUser(int id)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.users.SingleOrDefault(d => d.UserID == id);
                return _mapper.Map<UserDTO>(found);
            }
        }
        public void UpdateUser(UserDTO user)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.users.SingleOrDefault(d => d.UserID == user.UserID);
                if (found != null)
                {
                    found.Login = user.Login;
                    found.Email = user.Email;
                    found.Password = user.Password;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }

        public void DeleteUser(UserDTO user)
        {
            using (var entities = new TradingCompanyDBEntities())
            {
                var found = entities.users.SingleOrDefault(d => d.UserID == user.UserID);
                entities.users.Remove(found);
                entities.SaveChanges();
            }
        }
    }
}