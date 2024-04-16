using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.DataModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(32)"), Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(256)"), Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(128)"), Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [StringLength(64), Required(ErrorMessage = "Tên không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Role không được để trống")]
        public string Role { get; set; }
    }
}
