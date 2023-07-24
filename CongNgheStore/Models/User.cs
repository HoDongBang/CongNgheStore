using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class User : IdentityUser<int>
    {

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }


        //relationship
        public ICollection<Order>? Orders { get; set; }
    }
}
