using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NRDCL_API.Models.Cus;

namespace NRDCL_API.Data
{
    public class NRDCL_API_DB_Context : DbContext
    {
        public NRDCL_API_DB_Context(DbContextOptions<NRDCL_API_DB_Context> options)
        : base(options)
        {
        }
        public DbSet<Customer> Customer_Table { get; set; }
    }
}
