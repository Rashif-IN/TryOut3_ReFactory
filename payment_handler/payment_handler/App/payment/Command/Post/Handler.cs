using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using payment_handler.Models;
using RabbitMQ.Client;


namespace payment_handler.App.payment.Command.Post
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
            var paymentdata = new paymentModel
            {
                transaction_id = request.data.Attributes.transaction_id,
                payment_type = request.data.Attributes.payment_type,
                gross_amount = request.data.Attributes.gross_amount,
                bank = request.data.Attributes.bank,
                order_id = request.data.Attributes.order_id
            };
            konteks.payments.Add(paymentdata);
            await konteks.SaveChangesAsync(cancellationToken);

            var payment = konteks.payments.First(x => x.order_id == request.data.Attributes.order_id);
            var target = new TargetCommand() { Id = payment.id, Email_destination = "aaaaaa@aaa.ia" };
            var client = new HttpClient();
            var command = new PostCommand()
            {
                Title = "hjfrhftcutcuc6ello rtyxdrtxdye4ty",
                Message = "you think this is hello world, but it was me dio",
                Type = "email",
                From = 56,
                Target = new List<TargetCommand>() { target }
            };
            var attributes = new Data<PostCommand>() { Attributes = command };

            var httpContent = new RequestData<PostCommand>() { data = attributes };

            var jsonObj = JsonConvert.SerializeObject(httpContent);

            //send to rabbit
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var Body = Encoding.UTF8.GetBytes(jsonObj);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "", routingKey: "userData", basicProperties: null, body: Body);
                Console.WriteLine("user data has been forwarded");
                Console.ReadLine();
            }
            Console.ReadLine();

            //send to mail
            var _client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("ccdced0fc36ee1", "215162738c26d0"),
                EnableSsl = true
            };
            _client.Send("emailfrom@aaa.com", "emailTo@aaaa.com", "title: payment data", "msg: data has been sent to rabbitmq");
            Console.WriteLine("Sent");

            return new Dto
            {
                message = "payment posted",
                success = true
            };
        }
    }
}
