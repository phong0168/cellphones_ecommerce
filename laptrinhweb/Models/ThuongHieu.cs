using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laptrinhweb.Models
{
    public class ThuongHieu
    {
        [Key]
        public int ThuongHieuId { get; set; }
        public string Name { get; set; }
    }
}