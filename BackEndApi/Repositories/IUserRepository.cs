
using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface IUserRepository
    {
        List<UserVM> GetAll();
        UserVM GetById(int id);
        UserVM Add(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
