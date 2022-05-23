using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
{
    public partial class CarTenantRelationship
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер авто")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ключ жильця")]
        public int TenantId { get; set; }

        public virtual Car NumberNavigation { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;
    }
}
