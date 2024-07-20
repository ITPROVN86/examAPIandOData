using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
    public class CategoryDTO
    {
        [Display(Name ="Mã danh mục")]
        [Required(ErrorMessage ="Nhập mã danh mục")]
        public int CategoryId { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Nhập tên danh mục")]
        public string CategoryName { get; set; }
        public virtual ICollection<ProductDTO>? Products { get; set; }
    }
}
