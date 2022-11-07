using Infrastructure.EfCore.Models.Classification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleConfiguration : ClassifierEntityTypeConfiguration<EfMuscle, EfMuscleConnection>
{
    public override void Configure(EntityTypeBuilder<EfMuscle> builder)
    {
        base.Configure(builder);
        builder.ToTable("Muscles");
    }
}