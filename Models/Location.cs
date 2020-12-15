using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourierAPI.Models
{
    /// <summary>
    /// Location Model class
    /// </summary>
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<Courier> couriers { get; set; }
    }
}
