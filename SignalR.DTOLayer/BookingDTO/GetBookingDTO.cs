﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.BookingDTO
{
    public class GetBookingDTO
    {
        public int BookingID { get; set; }
        public string BookingName { get; set; }
        public string BookingDescription { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
