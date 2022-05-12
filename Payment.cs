using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public decimal Sum { get; set; }
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
    }
}
