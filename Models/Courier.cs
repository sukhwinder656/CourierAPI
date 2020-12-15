using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourierAPI.Models
{
    /// <summary>
    /// Courier Model class
    /// </summary>
    public class Courier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FromName { get; set; }
        [Required]
        public string FromAddress { get; set; }
        [Required]
        public string FromContactNumber { get; set; }
        [Required]
        public string ToName { get; set; }
        [Required]
        public string ToAddress { get; set; }
        [Required]
        public string ToContactNumber { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string Insured { get; set; }

        public Location Location { get; set; }
    }
}
