using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart.Data
{
    public class Invoice
    {
        [KeyAttribute]
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }  //from Order model
        [ForeignKey("OrderId")]
        public virtual Order Order{ get; set; }         
        public int InvoiceNumber { get; set; }  // it will be auto generative        
        public DateTime InvoiceDate { get; set; }

    }

}
