using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urtk_courcework_v2.Model
{
    public class ProductModel
    {
        public int IdProduct { get; set; }

        public string NameProduct { get; set; }

        public DateTime ShelfLifeProduct { get; set; }

        /// <summary>
        /// Количество прибывшего товара
        /// </summary>
        public int CountProduct { get; set; }

        /// <summary>
        /// Остаток
        /// </summary>
        public int RestProduct { get; set; }

        public decimal PriceProduct { get; set; }
    }
}
