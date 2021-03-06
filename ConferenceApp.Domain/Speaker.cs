﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferenceApp.Domain
{
    public class Speaker
    {
        public int ID { get; set; }
        [StringLength(4000)]
        public string Bio { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Website { get; set; }
    }
}
