using EF014.CreateDropAPI.Entities;
using EF014.CreateDropAPI.SeedDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF014.CreateDropAPI.Data.Config
{
    internal class CoporateConfiguration : IEntityTypeConfiguration<Corporate>
    {
        public void Configure(EntityTypeBuilder<Corporate> builder)
        {
            builder.ToTable("Coporates");
            builder.HasData(SeedData.LoadCorporates());

        }
    }
}
