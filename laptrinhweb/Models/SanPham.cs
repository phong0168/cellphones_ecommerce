using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laptrinhweb.Models
{
    public class SanPham
    {
        [Key]

        public int SanPhamId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Giá không được để trống.")]

        public float Price { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống.")]

        public string Description { get; set; }
        [Required(ErrorMessage = "ImgUrl không được để trống.")]

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Thương hiệu không được để trống.")]

        public int ThuongHieuId { get; set; }
        [Required(ErrorMessage = "Chủ đề không được để trống.")]

        public int ChuDeId { get; set; }
        public virtual ChuDe ChuDe { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }

    }
}