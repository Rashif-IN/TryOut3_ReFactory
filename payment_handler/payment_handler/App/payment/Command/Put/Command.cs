
using MediatR;
using payment_handler.Models;

namespace payment_handler.App.payment.Command.Put
{
    public class Command : RequestData<paymentModel>, IRequest<Dto>
    {
      
    }
}
