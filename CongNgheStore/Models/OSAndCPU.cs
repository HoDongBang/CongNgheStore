using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace CongNgheStore.Models
{
    public class OSAndCPU
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
        public virtual Product Product { get; set; }
    }
}
