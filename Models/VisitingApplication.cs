using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
{
    public partial class VisitingApplication
    {
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Початок часу відвідування")]
        public DateTime PeriodStart { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Кінець часу відвідування")]
        public DateTime PeriodEnd { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Відвідувач")]
        public string Visitor { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ключ квартири")]
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
    }
}
