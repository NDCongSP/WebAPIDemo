using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWinform.Models
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