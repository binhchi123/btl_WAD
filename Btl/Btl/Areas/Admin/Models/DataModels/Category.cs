using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.DataModels
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự."), Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
        public string Name { get; set; }

        public bool Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
