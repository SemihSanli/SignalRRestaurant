using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class Feature
    {
        [Key]
        public  int FeatureID { get; set; }
        public  string FeatureTitle1 { get; set; }
        public  string FeatureDescription1 { get; set; }
        public string FeatureTitle2 { get; set; }
        public string FeatureDescription2 { get; set; }
        public string FeatureTitle3 { get; set; }
        public string FeatureDescription3 { get; set; }
    }
}
