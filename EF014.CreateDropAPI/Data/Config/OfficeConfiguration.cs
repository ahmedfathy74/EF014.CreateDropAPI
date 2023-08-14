﻿using EF014.CreateDropAPI.Entities;
using EF014.CreateDropAPI.SeedDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF014.CreateDropAPI.Data.Config
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.OfficeName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.OfficeLocation)
             .HasColumnType("VARCHAR")
             .HasMaxLength(50).IsRequired();


            builder.ToTable("Offices");
            builder.HasData(SeedData.LoadOffices());


        }
    }
}
