using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.DataModels
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [StringLength(100, ErrorMessage = "Địa chỉ không được vượt quá 100 ký tự."), Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(11)"), Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public float TotalAmount { get; set; }

        public User User { get; set; }
    }
}
