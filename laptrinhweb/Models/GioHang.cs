using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laptrinhweb.Models
{
    public class CartItem
    {
        public SanPham SanPham { get; set; }
        public int SoLuong;
    }
    public class GioHang
    {
        List<CartItem> items  = new List<CartItem>();   
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(SanPham sp, int sl = 1)
        {
            var item = items.FirstOrDefault(s => s.SanPham.SanPhamId == sp.SanPhamId);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    SanPham = sp,
                    SoLuong = sl,
                });
            }
            else
            {
                item.SoLuong+=sl;
            }
        }
        public void Update(int id, int sl)
        {
            var item = items.Find(row => row.SanPham.SanPhamId == id);
            if(item != null)
            {
                item.SoLuong = sl;
            }
        }
        public float tinhTong()
        {
            var tong = items.Sum(row => row.SanPham.Price * row.SoLuong);
            return tong;
        }
        public void Remove(int id)
        {
            items.RemoveAll(row => row.SanPham.SanPhamId == id);

        }
   
    }
}