using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Machine_Test_CRUD.Models
{
    public class ProductContext: DbContext
    {
        public DbSet<ProductList> products { get; set; }
    }
}