using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }    
        public string AboutImageURL { get; set; }    
        public string AboutTitle { get; set; }    
        public string AboutDescription { get; set; }    

    }
}
