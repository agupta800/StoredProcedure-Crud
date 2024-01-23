using Microsoft.EntityFrameworkCore;
using StoredProcedure_Crud.Models;

namespace StoredProcedure_Crud.Data
{
    public class StoredContext:DbContext
    {
        public StoredContext(DbContextOptions<StoredContext>options):base(options)
        {
        }
       
        public DbSet<StoredModel> storeds{ get; set; }
    }
}
