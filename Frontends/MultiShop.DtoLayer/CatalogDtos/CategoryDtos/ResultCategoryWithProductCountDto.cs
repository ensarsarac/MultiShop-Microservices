using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class ResultCategoryWithProductCountDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public int ProductCount { get; set; }
    }
}
