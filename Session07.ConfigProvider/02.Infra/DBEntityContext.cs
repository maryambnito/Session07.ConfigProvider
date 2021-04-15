
using Microsoft.EntityFrameworkCore;
using Session07.ConfigProvider._01.Core;

namespace Session07.ConfigProvider
{
    public class EntityConfigurationContext : DbContext
    {

        public DbSet<DBEntity> DBEntities{ get; set; }
        public EntityConfigurationContext( DbContextOptions options) : base(options)
        {
        }
    }



}
