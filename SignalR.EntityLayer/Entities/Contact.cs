using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFooterDescription { get; set; }
        public string ContactFooterTitle { get; set; }
        public string ContactFooterOpenDays { get; set; }
        public string ContactFooterOpenDaysDescription{ get; set; }
        public string ContactFooterOpenHours{ get; set; }
    }
}
