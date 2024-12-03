using DesafioLeads.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioLeads.Data.Map
{
    public class LeadMap : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(300);
            builder.Property(x => x.Email).HasMaxLength(300);
            builder.Property(x => x.FirstName).HasMaxLength(300);
            builder.Property(x => x.Suburb).HasMaxLength(300);
            builder.Property(x => x.Status).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Category).HasMaxLength(300);
            builder.Property(x => x.FullName).HasMaxLength(300);
            builder.Property(x => x.CreateDate).HasColumnType("datetime");

        }
    }
}
