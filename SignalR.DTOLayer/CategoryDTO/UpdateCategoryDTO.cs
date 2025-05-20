using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
