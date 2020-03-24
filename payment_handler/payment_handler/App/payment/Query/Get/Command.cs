
using MediatR;

namespace payment_handler.App.payment.Query.Get
{
    public class Command : IRequest<Dto>
    {
        public int Id { get; set; }
        public Command(int id)
        {
            Id = id;
        }
    }
}
