namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryWithProductCountDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public int ProductCount { get; set; }
    }
}
