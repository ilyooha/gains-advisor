using Infrastructure.EfCore.Models.Classification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleGroupConfiguration : ClassifierEntityTypeConfiguration<EfMuscleGroup, EfMuscleGroupConnection>
{
    public override void Configure(EntityTypeBuilder<EfMuscleGroup> builder)
    {
        base.Configure(builder);
        builder.ToTable("MuscleGroups");
    }
}