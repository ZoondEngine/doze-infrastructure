using Doze.Nt.Server.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Doze.Nt.Server.Database.Accessors
{
    public class UserAccessor : BaseAccessor<User>
    {
        public UserAccessor(DbSet<User> users, DatabaseContext context)
             : base(users, context)
        { }
    }
}
