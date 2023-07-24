using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BackEndApi.Repositories
{
    public interface IAccountRepository
    {
        public Task<User> SignIn(SignInVM signInUser);
        public Task<bool> SignUpUser(SignUpVM signUpUser);
        public void SignOut();
    }
}
