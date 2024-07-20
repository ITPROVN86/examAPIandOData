using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
    public class CustomerDTO
    {
        [Display(Name="Mã khách hàng")]

        public int CustomerId { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage ="Yêu cầu nhập Tên khách hàng")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string Address { get; set; }
    }
}
