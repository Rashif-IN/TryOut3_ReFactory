
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace payment_handler.App.payment.Query.Get
{
    public class Handler : IRequestHandler<Command, Dto>
    {
        private readonly Context konteks;

        public Handler(Context context)
        {
            konteks = context;
        }

        public async Task<Dto> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await konteks.payments.FirstOrDefaultAsync(X => X.id == request.Id);
            if (result != null)
            {
                return new Dto
                {
                    message = "payment retrieved",
                    success = true,
                    Data = result
                };
            }
            else { return null; }
        }
    }
}
