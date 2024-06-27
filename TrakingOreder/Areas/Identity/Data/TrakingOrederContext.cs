﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrakingOreder.Areas.Identity.Data;

namespace TrakingOreder.Areas.Identity.Data;

public class TrakingOrederContext : IdentityDbContext<TrakingUser>
{
    public TrakingOrederContext(DbContextOptions<TrakingOrederContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new Usercofigration());

    }
}

public class Usercofigration : IEntityTypeConfiguration<TrakingUser>
{
    public void Configure(EntityTypeBuilder<TrakingUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
    }
}