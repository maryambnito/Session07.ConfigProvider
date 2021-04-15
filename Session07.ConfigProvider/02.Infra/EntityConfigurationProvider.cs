using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session07.ConfigProvider
{
    public class EntityConfigurationProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public EntityConfigurationProvider(
            Action<DbContextOptionsBuilder> optionsAction) =>
            _optionsAction = optionsAction;

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<EntityConfigurationContext>();
            _optionsAction(builder);
            using var dbContext = new EntityConfigurationContext(builder.Options);

            dbContext.Database.EnsureCreated();

           if(dbContext.DBEntities.Any())
               Data =dbContext.DBEntities.ToDictionary(c => c.ID.ToString(), c => c.Value);
        }

    }
}

