using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class VisitingApplication
    {
        public int ApplicationId { get; set; }
        public DateTime Date { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public string Visitor { get; set; } = null!;
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
    }
}
