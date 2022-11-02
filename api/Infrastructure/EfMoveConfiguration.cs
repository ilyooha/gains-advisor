using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class EfMoveConfiguration : IEntityTypeConfiguration<EfMove>
{
    public void Configure(EntityTypeBuilder<EfMove> builder)
    {
        builder.ToTable("Moves");
        builder.HasKey(x => x.Id);
    }
}