using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class SignUpVM
    {
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
        public string? RoleName { get; set; }
    }
}
