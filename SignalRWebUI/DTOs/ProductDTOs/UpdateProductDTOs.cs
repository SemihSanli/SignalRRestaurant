namespace SignalRWebUI.DTOs.ProductDTOs
{
    public class UpdateProductDTOs
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
    }
}
