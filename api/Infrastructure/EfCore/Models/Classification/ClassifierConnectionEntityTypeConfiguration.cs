using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models.Classification;

public abstract class ClassifierConnectionEntityTypeConfiguration<TClassifier, TConnection>
    : IEntityTypeConfiguration<TConnection>
    where TClassifier : class, IClassifier<TConnection>
    where TConnection : class, IClassifierConnection<TClassifier>
{
    public virtual void Configure(EntityTypeBuilder<TConnection> builder)
    {
        builder.HasKey(x => new { x.AncestorId, x.DescendantId });
        builder.HasOne(x => x.Ancestor)
            .WithMany(x => x.Descendants)
            .HasForeignKey(x => x.AncestorId);
        builder.HasOne(x => x.Descendant)
            .WithMany(x => x.Ancestors)
            .HasForeignKey(x => x.DescendantId);
    }
}