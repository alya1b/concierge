using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
{
    public partial class Car
    {
        public Car()
        {
            CarTenantRelationships = new HashSet<CarTenantRelationship>();
        }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Марка")]
        public string Brand { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Статус паркінгу")]
        public bool ParkingStatus { get; set; }

        public virtual ICollection<CarTenantRelationship> CarTenantRelationships { get; set; }
    }
}
