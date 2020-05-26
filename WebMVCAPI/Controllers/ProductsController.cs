using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMVCAPI.Models;

namespace WebMVCAPI.Controllers
{
    public class ProductsController : ApiController
    {
        #region mau co san
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        #endregion

        #region tu thiet ke

        [HttpGet]
        public IEnumerable<Products> GetAllProducts()
        {
            DataTable data = ProductsModel.Instance.GetProduct($"select * from Products");
            List<Products> productsList = new List<Products>();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Debug.WriteLine($"ID={(int)data.Rows[i][0]}|name={data.Rows[i][1].ToString()}");
                    productsList.Add(new Products
                    {
                        id = (int)data.Rows[i][0],
                        name = data.Rows[i][1].ToString(),
                        descripption = data.Rows[i][2].ToString(),
                        price = (double)data.Rows[i][3],
                        unitInStock = (int)data.Rows[i][4],
                        catId = (int)data.Rows[i][5]
                    });
                }
            }
            return productsList;
        }

        public IEnumerable<Products> GetProductsByCatId(int catId)
        {
            DataTable data = ProductsModel.Instance.GetProduct($"select * from Products where catID={catId}");
            List<Products> productsList = new List<Products>();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    productsList.Add(new Products
                    {
                        id = (int)data.Rows[i][0],
                        name = data.Rows[i][1].ToString(),
                        descripption = data.Rows[i][2].ToString(),
                        price = (double)data.Rows[i][3],
                        unitInStock = (int)data.Rows[i][4],
                        catId = (int)data.Rows[i][5]
                    });
                }
            }
            data.Dispose();
            return productsList;
        }

        public Products GetProductsById(int id)
        {
            Products productId = null;
            DataTable data = ProductsModel.Instance.GetProduct($"select * from Products where id={id}");
            if (data.Rows.Count > 0)
            {
                productId = new Products
                {
                    id = (int)data.Rows[0][0],
                    name = data.Rows[0][1].ToString(),
                    descripption = data.Rows[0][2].ToString(),
                    price = (double)data.Rows[0][3],
                    unitInStock = (int)data.Rows[0][4],
                    catId = (int)data.Rows[0][5]
                };
            }
            return productId;
        }
        
        //public string GetProductsById(int id)
        //{
        //    Products productId = null;
        //    DataTable data = ProductsModel.Instance.GetProduct($"select * from Products where id={id}");
        //    if (data.Rows.Count > 0)
        //    {
        //        productId = new Products
        //        {
        //            id = (int)data.Rows[0][0],
        //            name = data.Rows[0][1].ToString(),
        //            descripption = data.Rows[0][2].ToString(),
        //            price = (double)data.Rows[0][3],
        //            unitInStock = (int)data.Rows[0][4],
        //            catId = (int)data.Rows[0][5]
        //        };
        //    }
        //    return JsonConvert.SerializeObject(productId);
        //}
        #endregion
    }
}