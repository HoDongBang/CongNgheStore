using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CongNgheStoreDBContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountRepository(CongNgheStoreDBContext context,
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> SignIn(SignInVM signInVM)
        {
            //var user = _context.Users.SingleOrDefault(u =>
            //    u.PhoneNumber == signInVM.PhoneNumber);
            var user = await _userManager.FindByNameAsync(signInVM.PhoneNumber);
            var result = await _signInManager.PasswordSignInAsync(user, signInVM.Password, signInVM.RememberMe, false);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> SignUpUser(SignUpVM signUpVM)
        {
            var verify = _context.Users.SingleOrDefault(u =>
                u.PhoneNumber == signUpVM.PhoneNumber);

            //neu sdt co tren he thong thi failed
            if (verify != null)
                return false;

            var user = new User
            {
                UserName = signUpVM.PhoneNumber,
                PhoneNumber = signUpVM.PhoneNumber,
                FirstName = signUpVM.FirstName,
                LastName = signUpVM.LastName
            };
            var result = await _userManager.CreateAsync(user, signUpVM.Password);
            if(result.Succeeded)
            {
                //them role
                var userCreated = await _userManager.FindByNameAsync(signUpVM.PhoneNumber);
                var role = _context.Roles.SingleOrDefault(r => r.Name == signUpVM.RoleName);
                if (userCreated == null || role == null)
                    return false;

                var resultAddRole = await _userManager.AddToRoleAsync(user, signUpVM.RoleName);
                if (resultAddRole.Succeeded)
                    return true;
            }
            return false;
        }

        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
