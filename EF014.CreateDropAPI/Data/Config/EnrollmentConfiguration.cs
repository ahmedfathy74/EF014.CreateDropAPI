using EF014.CreateDropAPI.Entities;
using EF014.CreateDropAPI.SeedDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF014.CreateDropAPI.Data.Config
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(x => new { x.SectionId, x.ParticipantId });

            builder.ToTable("Enrollments");
            builder.HasData(SeedData.LoadEnrollments());

        }
    }
}
