using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class MemoryAndStorage
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ram")]
        public string Ram { get; set; }

        [Display(Name = "Rom")]
        public string Rom { get; set; }

        [Display(Name = "Ổ cứng")]
        public string HardDrive { get; set; }

        [Display(Name = "Loại ổ cứng")]
        public string HardDriveType { get; set; }

        [Display(Name = "Giá")]
        [DefaultValue(0)]
        public long Price { get; set; }


        //relationship
        public Guid? ProductId { get; set; }

        public Product Product { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
