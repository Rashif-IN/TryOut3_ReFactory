
using MediatR;
using payment_handler.Models;

namespace payment_handler.App.payment.Command.Delete
{
    public class Command : RequestData<user_model>, IRequest<Dto>
    {
        public int Id { get; set; }
        public Command(int id)
        {
            Id = id;
        }
    }
}