using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace laptrinhweb.Models
{
    public class DatHang
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống.")]

        public string ShipName { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]

        public string ShipAddress { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]

        public string ShipPhoneNumber { get; set; }
        public string ShipEmail { get; set; }
        public int SanPhamId { get; set; }
        public int Quantity { get; set; }
        public virtual SanPham SanPham { get; set; }

    }
}