using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Radilovsoft.Rest.Data.Ef.Context;
using Radilovsoft.Rest.Data.Ef.Contract;
using Radilovsoft.Rest.Data.Ef.Extension;
using Sample.Db.Provider;
using Sample.Core.Common;

namespace Sample.Db.Context
{
    public class TesterDbContext : ResetDbContext
    {
        private readonly IModelStore _store;
        private readonly IIndexProvider _indexProvider;

        static TesterDbContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>();
        }

        public TesterDbContext(IModelStore store,
            IIndexProvider indexProvider,
            DbContextOptions options)
            : base(options)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
            _indexProvider = indexProvider ?? throw new ArgumentNullException(nameof(indexProvider));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasPostgresExtension("uuid-ossp");
            builder.BuildEntity(_store)
                .BuildIndex(_store, _indexProvider)
                .BuildAutoIncrement(_store)
                .BuildMultiKey(_store);

            FkProvider.BuildFk(builder);
            SeedingProvider.BuildSeeding(builder);

            builder.HasPostgresEnum<Gender>();
        }
    }
}