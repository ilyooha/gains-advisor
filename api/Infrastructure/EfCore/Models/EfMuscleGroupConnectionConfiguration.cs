using Infrastructure.EfCore.Models.Classification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleGroupConnectionConfiguration
    : ClassifierConnectionEntityTypeConfiguration<EfMuscleGroup, EfMuscleGroupConnection>
{
    public override void Configure(EntityTypeBuilder<EfMuscleGroupConnection> builder)
    {
        base.Configure(builder);
        builder.ToTable("MuscleGroupConnections");
    }
}
