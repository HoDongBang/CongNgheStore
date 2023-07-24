using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace CongNgheStore.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Khách hàng ghi chú")]
        public string CustomerNotes { get; set; }

        [Display(Name = "Của hàng ghi chú")]
        public string StoreNotes { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Trạng thái")]
        [DefaultValue("Chờ xác nhận")]
        public string Status { get; set; }


        //relationship
        public int? UserId { get; set; }

        public User User { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
