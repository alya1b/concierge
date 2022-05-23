using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            CarTenantRelationships = new HashSet<CarTenantRelationship>();
        }

        public int TenantId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "ПІП")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Пошта")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Телефон")]
        public int PhoneNumber { get; set; }
        public int AppartmentId { get; set; }

        public virtual Apartment Appartment { get; set; } = null!;
        public virtual ICollection<CarTenantRelationship> CarTenantRelationships { get; set; }
    }
}
