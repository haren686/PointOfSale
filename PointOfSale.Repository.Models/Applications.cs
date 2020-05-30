using System;
using System.Collections.Generic;

namespace PointOfSale.Repository.Models
{
    public partial class Applications
    {
        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public string ApplicationLoggedBy { get; set; }
        public DateTime? ApplicationLoggedInDate { get; set; }
        public string ApplicationStatus { get; set; }
        public string CardDeliveryStatus { get; set; }
    }
}
