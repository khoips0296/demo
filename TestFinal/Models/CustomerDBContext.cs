using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestFinal.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext() : base("name = CustomerConnectionString")
        {
            //khởi tạo những gì cần thiết
        }
        public DbSet<CustomerType> CustomerTypes{ get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}