using System;
using System.Collections.Generic;

namespace Concierge
{
    public partial class CarTenantRelationship
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public int TenantId { get; set; }

        public virtual Car NumberNavigation { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;
    }
}
