
using Microsoft.EntityFrameworkCore;

using ProjectName.DomainName.Domain.Models;
using ProjectName.DomainName.Infra.Server.Data.Configurations;

namespace ProjectName.DomainName.Infra.Server.Data.Context
{
    public class DomainName_Context : DbContext
    {
        #region Constructors

        public DomainName_Context()
        {

        }

        public DomainName_Context(DbContextOptions<DomainName_Context> options)
            : base(options)
        {

        }

        #endregion

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}