
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace payment_handler.App.payment.Command.Put
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
            var paymentdata = konteks.payments.Find(request.data.Attributes.id);
            
            paymentdata.payment_type = request.data.Attributes.payment_type;
            paymentdata.gross_amount = request.data.Attributes.gross_amount;
            paymentdata.bank = request.data.Attributes.bank;
            paymentdata.transaction_status = request.data.Attributes.transaction_status;
            paymentdata.updated_at = request.data.Attributes.updated_at;

            if(paymentdata.transaction_status == "paid")
            {
                BackgroundJob.Enqueue(() => Console.WriteLine("Someone's requesting and getting a data"));

            }

            await konteks.SaveChangesAsync(cancellationToken);
            return new Dto
            {
                message = "payment updated",
                success = true
            };
           

        }
    }
}
