using Infrastructure.EfCore.Models.Classification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleConnectionConfiguration
    : ClassifierConnectionEntityTypeConfiguration<EfMuscle, EfMuscleConnection>
{
    public override void Configure(EntityTypeBuilder<EfMuscleConnection> builder)
    {
        base.Configure(builder);
        builder.ToTable("MuscleConnections");
    }
}