using System.ComponentModel.DataAnnotations;
using System;

namespace Emart.Data
{
    public class CartDetails
    {
        //for each user
        [KeyAttribute]
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

}