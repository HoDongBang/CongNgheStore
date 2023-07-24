using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class BatteryAndChargerVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Dung lượng pin")]
        public string BatteryCapacity { get; set; }

        [Display(Name = "Loại pin")]
        public string BatteryType { get; set; }

        [Display(Name = "Hổ trợ sạc tối đa")]
        public string MaximumChargingSupport { get; set; }

        [Display(Name = "Công nghệ pin")]
        public string BatteryTechnology { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
    }
}
