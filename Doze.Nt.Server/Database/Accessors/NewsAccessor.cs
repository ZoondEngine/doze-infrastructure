using Doze.Nt.Server.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Database.Accessors
{
    public class NewsAccessor : BaseAccessor<Article>
    {
        public NewsAccessor(DbSet<Article> articles, DatabaseContext context)
             : base(articles, context)
        { }
    }
}
