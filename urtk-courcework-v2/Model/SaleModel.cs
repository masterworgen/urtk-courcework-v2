using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urtk_courcework_v2.Domain;

namespace urtk_courcework_v2.Model
{
    public class SaleModel
    {
        public int IdSale { get; set; }

        public int CountSale { get; set; }

        public DateTime DateSale { get; set; }

        public ProductDomain Product { get; set; }
    }
}
