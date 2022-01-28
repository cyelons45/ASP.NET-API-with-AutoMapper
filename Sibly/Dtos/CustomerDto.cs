using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Sibly.Models;


namespace Sibly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }


        [Required]
        public byte MembershipTypeId { get; set; }


        [Required]
  
        public DateTime? Birthdate { get; set; }
    }
}