using System;
namespace payment_handler.Models
{
    public class paymentModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int transaction_id { get; set; }
        public string payment_type { get; set; }
        public string gross_amount { get; set; }
        public string bank { get; set; }
        public string transaction_time { get; set; } = DateTime.Now.ToString();
        public string transaction_status { get; set; } = "pending";
        public double created_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public double updated_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public orderModel OrderModel { get; set; }
        
    }
}
