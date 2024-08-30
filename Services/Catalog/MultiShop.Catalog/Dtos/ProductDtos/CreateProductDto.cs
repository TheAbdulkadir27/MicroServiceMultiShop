namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string İmageUrl { get; set; }
        public string Description { get; set; }


        public string CategoryID { get; set; }
    }
}
