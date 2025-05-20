using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.ContactDTOs
{
    public class CreateContactDTOs
    {
      
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFooterDescription { get; set; }
        public string ContactFooterTitle { get; set; }
        public string ContactFooterOpenDays { get; set; }
        public string ContactFooterOpenDaysDescription { get; set; }
        public string ContactFooterOpenHours { get; set; }
    }
}
