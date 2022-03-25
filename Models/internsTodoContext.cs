using System;
using Microsoft.EntityFrameworkCore;

namespace internsfcsamericaTodoList.Models
{
    public class internsTodoContext: DbContext
    {
        public internsTodoContext(DbContextOptions<internsTodoContext> options): base(options) { }

        public DbSet<internsTodo> internsTodo { get; set; }
    }
}
// si klk chose n march po dans sql try internsTodos//