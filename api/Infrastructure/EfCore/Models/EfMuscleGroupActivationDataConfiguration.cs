using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models;

public class EfMuscleGroupActivationDataConfiguration : IEntityTypeConfiguration<EfMuscleGroupActivationData>
{
    public void Configure(EntityTypeBuilder<EfMuscleGroupActivationData> builder)
    {
        builder.ToTable("MuscleGroupActivationData");
        builder.HasKey(x => new { x.MoveId, x.MuscleGroupId });

        builder.HasOne(x => x.Move)
            .WithMany(x => x.ActivationData)
            .HasForeignKey(x => x.MoveId);

        builder.HasOne(x => x.MuscleGroup)
            .WithMany()
            .HasForeignKey(x => x.MuscleGroupId);
    }
}