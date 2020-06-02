using Doze.Nt.Server.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Database.Accessors
{
    public class ProductAccessor : BaseAccessor<Product>
    {
        public ProductAccessor(DbSet<Product> products, DatabaseContext context)
             : base(products, context)
        { }
    }
}
