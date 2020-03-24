using System;
namespace payment_handler.Models
{
    public class order_detailsModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public double created_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public double updated_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
    }
}
