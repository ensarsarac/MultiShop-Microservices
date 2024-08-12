using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Entity;

namespace MultiShop.Message.DAL.Concrete
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        public DbSet<MessageEntity> Messages{ get; set; }
    }
}
