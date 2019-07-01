using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urtk_courcework_v2.Model
{
    public class WaybillModel
    {
        public int IdWaybill { get; set; }

        public string NameProvider { get; set; }

        public List<ProductModel> ProductModels { get; set; }

        public DateTime DateWaybill { get; set; }
    }
}
