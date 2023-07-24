using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class SignInVM
    {
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập")]
        public bool RememberMe { get; set; }
        public string? RoleName { get; set; }
    }
}
