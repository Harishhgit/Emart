using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Emart.Data
{
    public class Order
    {
        [KeyAttribute]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get;set; }
        public string Contact { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public double OrderTotal { get;set; }        
        public DateTime PickupDateTime { get; set; }

    }

}