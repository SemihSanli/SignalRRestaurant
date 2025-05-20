﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string SocialMediaTitle { get; set; }
        public string SocialMediaURL { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}
