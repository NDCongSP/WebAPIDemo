using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CatagoryModel
    {
        public DataTable GetCategory(string query)
        {
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
