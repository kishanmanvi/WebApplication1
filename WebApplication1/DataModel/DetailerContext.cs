using Microsoft.EntityFrameworkCore;

namespace Post_put_Get_Del.DataModel
{
    public class DetailerContext : DbContext
    {
        public DetailerContext(DbContextOptions<DetailerContext> options) : base(options)
        {

        }

        public DbSet<Detailer> Detailer { get; set; }
    }
}
