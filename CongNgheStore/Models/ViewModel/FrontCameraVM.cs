using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class FrontCameraVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Độ phân giải")]
        public string Resolution { get; set; }

        [Display(Name = "Tinh năng")]
        public string Feature { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
    }
}
