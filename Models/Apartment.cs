using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
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

        
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Поверх")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Площа")]
        public decimal Area { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Під'їзд")]
        public int Porch { get; set; }
        
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер квартири")]

        public int Number { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<VisitingApplication> VisitingApplications { get; set; }
    }
}
