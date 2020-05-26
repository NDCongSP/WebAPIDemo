using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVCAPI.Models
{
    public class Products
    {
        public int id { set; get; }
        public string name { set; get; }
        public string descripption { set; get; }
        public double price { set; get; }
        public int unitInStock { set; get; }
        public int catId { set; get; }
    }
}