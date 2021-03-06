﻿using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mono.Options;
using Radilovsoft.Rest.Data.Ef.Contract;
using Sample.Db.Context;
using Sample.Db.Provider;
using Sample.Db.Store;

namespace Sample.Migrator
{
    public static class MigratorProgram
    {
        public static string EnvironmentName { get; private set; } = "Development";

        private static void Main(string[] args)
        {
            var dataOptions = new OptionSet
            {
                {"environment=", s => EnvironmentName = s}
            };
            var actionOptions = new OptionSet
            {
                {"migrate", s => Migrate()}
            };

            if (args.Any() == false)
            {
                Console.WriteLine("Support parameters");
                dataOptions.WriteOptionDescriptions(Console.Out);
                actionOptions.WriteOptionDescriptions(Console.Out);
                Console.ReadKey();
            }

            dataOptions.Parse(args);
            actionOptions.Parse(args);
        }

        private static void Migrate()
        {
            using var context = new DbContextFactory().CreateDbContext(Array.Empty<string>());
            context.Database.Migrate();
        }
    }

    public class DbContextFactory : IDesignTimeDbContextFactory<MigratorEfDataConnection>
    {
        public MigratorEfDataConnection CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{MigratorProgram.EnvironmentName}.json", true)
                .AddJsonFile("appsettings.local.json", true);

            var configuration = configurationBuilder.Build();

            var modelStore = new TesterDbModelStore();
            var indexProvider = new PostgresIndexProvider();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            var dbContextOptions = new DbContextOptionsBuilder()
                .UseNpgsql(configuration.GetConnectionString("Postgres"),
                    o => o.MigrationsAssembly("Sample.Migrator")
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, "service"))
                .Options;

            return new MigratorEfDataConnection(modelStore, indexProvider, dbContextOptions, loggerFactory);
        }
    }

    public class MigratorEfDataConnection : TesterDbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public MigratorEfDataConnection(IModelStore modelStore, IIndexProvider indexProvider,
            DbContextOptions options,
            ILoggerFactory loggerFactory) : base(modelStore, indexProvider, options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new ArgumentNullException(nameof(optionsBuilder));
            base.OnConfiguring(optionsBuilder);

            if (_loggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory);
            }
        }
    }
}