using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Repository.Models
{
    public class Records
    {
        public string ApplicationNumber { get; set; }
        public string ApplicationLoggedBy { get; set; }
        public DateTime ApplicationLoggedInDate { get; set; } 
        public string ApplicationStatus { get; set; }
        public string CardDeliveryStatus { get; set; }
    }
}
