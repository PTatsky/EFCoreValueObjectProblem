using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSimpleExample
{
    public class MyDbContext : DbContext
    {
        private string dbConnectionString;

        public DbSet<ZoneState> ZoneStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                dbConnectionString = configuration.GetConnectionString("DefaultConnection");
            }

            options.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ZoneStateMapping());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ZoneState
    {
        public string ZoneKey { get; internal set; }

        public ControlPanelNodeId NodeId { get; internal set; }
    }

    public class ControlPanelNodeId : ValueObject
    {
        public short NodeId { get; private set; }

        public ControlPanelNodeId(short nodeId)
        {
            NodeId = nodeId;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return NodeId;
        }
    }

    public class ZoneStateMapping : IEntityTypeConfiguration<ZoneState>
    {
        public void Configure(EntityTypeBuilder<ZoneState> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ZoneKey);
            entityTypeBuilder.OwnsOne(z => z.NodeId);
        }
    }
}
