using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Emart.Data;
using Emart.Repository;


namespace Emart.Repository
{
    public class ApplicationContext: DbContext  
    {  
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {  
            
        }  

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<ItemSubCategory> ItemSubCategories { get; set; }

        //public DbSet<CartDetails> CartDetails { get; set; }

        //public DbSet<Order> OrderDetails { get; set; }

        // public DbSet<Invoice> InvoiceDetails { get; set; }

    }
}