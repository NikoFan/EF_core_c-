using System;
using System.ComponentModel.DataAnnotations;

namespace VideoGameShop
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public string? client_login { get; set; }
        public string? client_password { get; set; }
        public string? client_email { get; set; }
    }
}