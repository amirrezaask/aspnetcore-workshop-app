﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;







namespace ConferenceApp.Domain
{
    public class Attendee
    {
        // salam
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(256)]
        public virtual string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {UserName} {EmailAddress}";
        }
    }
}
