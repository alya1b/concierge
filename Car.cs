using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class Car
    {
        public Car()
        {
            CarTenantRelationships = new HashSet<CarTenantRelationship>();
        }

        public string Number { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public bool ParkingStatus { get; set; }

        public virtual ICollection<CarTenantRelationship> CarTenantRelationships { get; set; }
    }
}
