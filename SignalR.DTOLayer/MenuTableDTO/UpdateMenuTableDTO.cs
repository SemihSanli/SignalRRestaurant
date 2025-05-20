using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.MenuTableDTO
{
    public class UpdateMenuTableDTO
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
