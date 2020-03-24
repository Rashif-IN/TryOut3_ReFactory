using System;
namespace payment_handler.Models
{
    public class orderModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public double created_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public double updated_at { get; set; } = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
        public user_model user_Model { get; set; }
    }
}
