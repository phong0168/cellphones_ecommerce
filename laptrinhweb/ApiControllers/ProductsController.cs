using laptrinhweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace laptrinhweb.ApiControllers
{
    public class ProductsController : ApiController
    {
        public List<SanPham> Get()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return sanPhams;
        }
    }
}
