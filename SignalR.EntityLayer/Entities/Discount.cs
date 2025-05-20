using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountImageURL { get; set; }
        public bool DiscountStatus { get; set; }
    }
}
