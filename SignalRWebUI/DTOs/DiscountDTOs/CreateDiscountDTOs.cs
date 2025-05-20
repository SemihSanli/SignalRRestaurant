using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.DiscountDTOs
{
    public class CreateDiscountDTOs
    {
        public string DiscountTitle { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountImageURL { get; set; }
        public bool DiscountStatus { get; set; }
    }
}
