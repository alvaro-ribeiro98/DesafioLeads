using DesafioLeads.Data.Map;
using DesafioLeads.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioLeads.Data
{
    public class SystemLeadContext : DbContext
    {
        public SystemLeadContext(DbContextOptions<SystemLeadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeadMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
