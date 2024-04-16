using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.DataModels
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Image { get; set; }

        public float TotalAmount => Quantity * Price;
    }
}
