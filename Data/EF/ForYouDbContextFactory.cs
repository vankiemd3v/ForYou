﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class ForYouDbContextFactory : IDesignTimeDbContextFactory<ForYouDbContext>
    {
        public ForYouDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("KeyConnect");

            var optionsBuilder = new DbContextOptionsBuilder<ForYouDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ForYouDbContext(optionsBuilder.Options);
        }
    }
}
