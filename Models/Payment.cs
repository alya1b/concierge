using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConciergeWebApplication.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Статус оплати")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Сумма")]
        public decimal Sum { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ключ квартири")]
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; } = null!;
    }
}
