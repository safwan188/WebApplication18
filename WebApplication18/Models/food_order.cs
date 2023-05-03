using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Models
{
    public class food_order
    {
        [Key]
       public int id{get; set;} 
        public int client_id { get; set; }
        public int restaurant_id { get; set; }
        public int order_status_id { get; set; }
        public int assigned_driver_id { get; set; }
        public int client_adress_id { get; set; }
        public string order_datatime { get; set; }
        public int delivery_fee { get; set; }
        public int total_amunt { get; set; }
        public int cust_driver_rating { get; set; }
        public int cust_restaurant_raing { get; set; }
    }
}
