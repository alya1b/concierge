using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class Tenant
    {
        public Tenant()
        {
            CarTenantRelationships = new HashSet<CarTenantRelationship>();
        }

        public int TenantId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public int AppartmentId { get; set; }

        public virtual Apartment Appartment { get; set; } = null!;
        public virtual ICollection<CarTenantRelationship> CarTenantRelationships { get; set; }
    }
}
