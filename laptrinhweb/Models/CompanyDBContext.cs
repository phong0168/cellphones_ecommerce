using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace laptrinhweb.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base("MyConnectionString") { }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DatHang> DatHangs { get; set; }
    }
}