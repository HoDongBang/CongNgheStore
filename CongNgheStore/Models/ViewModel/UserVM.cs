using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        //relationship
        public int? RoleId { get; set; }
    }
}
