using System;
using System.Collections.Generic;
using urtk_courcework_v2.Domain;

namespace urtk_courcework_v2.Domain
{
    public partial class ProductDomain
    {
        public ProductDomain()
        {
            Sale = new HashSet<SaleDomain>();
        }

        public int IdProduct { get; set; }
        public DateTime ShelfLifeProduct { get; set; }
        /// <summary>
        /// Количество прибывшего товара
        /// </summary>
        public int CountProduct { get; set; }
        /// <summary>
        /// Остаток
        /// </summary>
        public int RestProduct { get; set; }
        public decimal Price { get; set; }
        public int IdDictionary { get; set; }
        public int IdWaybill { get; set; }

        public virtual DictionaryDomain IdDictionaryNavigation { get; set; }
        public virtual WaybillDomain IdWaybillNavigation { get; set; }
        public virtual ICollection<SaleDomain> Sale { get; set; }
    }
}
