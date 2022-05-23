using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConciergeWebApplication.Models;

namespace ConciergeWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ConciergeContext _context;
        public ChartController(ConciergeContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var apartments = _context.Apartments.ToList();
            List<object> apayment = new List<object>();
            apayment.Add(new[] { "Квартира", "Кількість неоплачених платежів" });
            foreach (var item in apartments)
            {
                var curpay = (from o in _context.Payments
                                 where (o.ApartmentId == item.ApartmentId) && (o.Status==false)
                                 select o).ToList();

                if (curpay != null)
                {
                    if (curpay.Count() != 0)
                    {
                        apayment.Add(new object[] { item.Number.ToString(), curpay.Count() });
                    }
                    else
                    {
                        apayment.Add(new object[] { item.Number.ToString(), 0 });
                    }
                }
            }
            return new JsonResult(apayment);
        }
        public JsonResult JsonData1()
        {
            var cars = _context.Cars.ToList();
            List<object> carparked = new List<object>();
            carparked.Add(new[] { "Авто", "На парковці" });
            foreach (var item in cars)
            {
                var curcar = (from o in _context.Payments
                              where  (o.Status == true)
                              select o).ToList();

                if (curcar != null)
                {
                    if (curcar.Count() != 0)
                    {
                        carparked.Add(new object[] { item.Number.ToString(), curcar.Count() });
                    }
                    else
                    {
                        carparked.Add(new object[] { item.Number.ToString(), 0 });
                    }
                }
            }
            return new JsonResult(carparked);
        }
    }
}
