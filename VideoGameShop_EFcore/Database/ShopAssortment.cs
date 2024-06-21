using System;
using System.ComponentModel.DataAnnotations;

namespace VideoGameShop
{
    public class ShopAssortment
    {
        [Key]
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int product_cost { get; set; }
        public int product_count { get; set; }
        public string? product_country { get; set; }

    }
}