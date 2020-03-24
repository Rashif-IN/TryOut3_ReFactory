
using System.Collections.Generic;
using payment_handler.Models;

namespace payment_handler.App.payment.Query.GetAll
{
    public class Dto : dto_model
    {
        public List<paymentModel> Data { get; set; }
    }
}
