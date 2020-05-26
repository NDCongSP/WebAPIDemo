using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductsModel
    {
        private static ProductsModel instance;

        public static ProductsModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsModel();
                }
                return instance;
            }
            set => instance = value;
        }
        private ProductsModel() { }

        public DataTable GetProduct(string query)
        {
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
