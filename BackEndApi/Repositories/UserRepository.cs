using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public UserRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }

        public List<UserVM> GetAll()
        {
            var users = _context.Users.Select(u => new UserVM
            {
                Id = u.Id,
                PhoneNumber = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Password = u.PasswordHash
            });
            return users.ToList();
        }

        public UserVM GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if(user != null)
            {
                return new UserVM
                {
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.PasswordHash
                };
            } 
            return null;
        }

        public UserVM Add(User user)
        {
            var _user = new User
            {
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
            return new UserVM
            {
                Id = _user.Id,
                PhoneNumber = _user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.PasswordHash
            };
        }

        public bool Update(User user)
        {
            var _user = _context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (_user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.PasswordHash = user.PasswordHash;

                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
