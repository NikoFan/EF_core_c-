using System;
using System.ComponentModel.DataAnnotations;

namespace VideoGameShop
{
    public class UserOrder
    {
        [Key]
        public int order_id { get; set; }
        public DateTime order_date { get; set; }
        public int order_cost { get; set; }
        public int fk_client_id { get; set; }
        public int fk_product_id { get; set; }
    }
}