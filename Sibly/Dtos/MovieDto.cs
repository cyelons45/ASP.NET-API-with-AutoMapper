using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibly.Dtos
{
    public class MovieDto
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        public int? NumberInStock { get; set; }
    }
}