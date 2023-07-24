using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class OSAndCPUVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Hệ điều hành")]
        public string OperatingSystem { get; set; }

        [Display(Name = "CPU")]
        public string Cpu { get; set; }

        [Display(Name = "Tốc độ CPU")]
        public string CpuSpeed { get; set; }

        [Display(Name = "Chíp đồ họa (GPU)")]
        public string Gpu { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
    }
}
