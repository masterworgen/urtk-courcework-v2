using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Product
    {
        public Product()
        {
            Sale = new HashSet<Sale>();
            Waybill = new HashSet<Waybill>();
        }

        public int IdProduct { get; set; }
        public DateTime ShelfLifeProduct { get; set; }
        public int CountProduct { get; set; }
        public int RestProduct { get; set; }
        public decimal Price { get; set; }
        public int IdDictionary { get; set; }

        public virtual Dictionary IdDictionaryNavigation { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<Waybill> Waybill { get; set; }
    }
}
