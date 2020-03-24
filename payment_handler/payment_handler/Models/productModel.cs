using System;
namespace payment_handler.Models
{
    public class productModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public double created_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public double updated_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
    }
}
