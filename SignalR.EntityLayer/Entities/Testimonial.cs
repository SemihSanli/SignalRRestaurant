using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImageURL { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
