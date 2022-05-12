using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class Apartment
    {
        public Apartment()
        {
            Payments = new HashSet<Payment>();
            Tenants = new HashSet<Tenant>();
            VisitingApplications = new HashSet<VisitingApplication>();
        }

        public int ApartmentId { get; set; }
        public int Floor { get; set; }
        public decimal Area { get; set; }
        public int Porch { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<VisitingApplication> VisitingApplications { get; set; }
    }
}
