using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.DataModels
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự."), Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Image { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0."), Required(ErrorMessage = "Vui lòng nhập giá sản phẩm.")]
        public float Price { get; set; }

        [DefaultValue(0)]
        public float SalePrice { get; set; }

        [StringLength(255, ErrorMessage = "Mô tả sản phẩm không được vượt quá 255 ký tự."), Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm.")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public List<Product> Mesh { get; set; }
        public List<Product> Arrivals { get; set; }

        public Category Category { get; set; }
    }
}
