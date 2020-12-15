using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierAPI.ViewModel
{
    public class CourierSummaryViewModel
    {
        public int Id { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string FromContactNumber { get; set; }
        public string ToName { get; set; }
        public string ToAddress { get; set; }
        public string ToContactNumber { get; set; }
        public string Location { get; set; }
        public string Insured { get; set; }
    }
}
