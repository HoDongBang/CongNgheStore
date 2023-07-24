using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class RearCameraVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Độ phân giải")]
        public string Resolution { get; set; }

        [Display(Name = "Quay phim")]
        public string Film { get; set; }

        [Display(Name = "Đèn Flash")]
        public string FlashLight { get; set; }

        [Display(Name = "Công nghệ")]
        public string Feature { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
    }
}
