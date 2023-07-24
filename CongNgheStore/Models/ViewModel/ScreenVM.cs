using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class ScreenVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Công nghệ màn hình")]
        public string ScreenTechnology { get; set; }

        [Display(Name = "Độ phân giải")]
        public string Resolution { get; set; }

        [Display(Name = "Màn hình rộng")]
        public string Widescreen { get; set; }

        [Display(Name = "Độ sáng tối đa")]
        public string MaximumBrightness { get; set; }

        [Display(Name = "Mặt kính cảm ứng")]
        public string TouchScreen { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
    }
}
