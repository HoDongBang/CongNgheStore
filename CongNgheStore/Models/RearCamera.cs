using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace CongNgheStore.Models
{
    public class RearCamera
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
        public virtual Product Product { get; set; }

    }
}
