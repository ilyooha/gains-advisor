using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleActivationDataConfiguration : IEntityTypeConfiguration<EfMuscleActivationData>
{
    public void Configure(EntityTypeBuilder<EfMuscleActivationData> builder)
    {
        builder.ToTable("MuscleActivationData");
        builder.HasKey(x => new { x.MoveId, x.MuscleId });

        builder.HasOne(x => x.Move)
            .WithMany(x => x.ActivationData)
            .HasForeignKey(x => x.MoveId);

        builder.HasOne(x => x.Muscle)
            .WithMany()
            .HasForeignKey(x => x.MuscleId);
    }
}