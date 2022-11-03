using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EfCore.Models.Classification;

public abstract class ClassifierEntityTypeConfiguration<TClassifier, TConnection>
    : IEntityTypeConfiguration<TClassifier>
    where TClassifier : class, IClassifier<TConnection>
    where TConnection : class, IClassifierConnection<TClassifier>
{
    public virtual void Configure(EntityTypeBuilder<TClassifier> builder)
    {
        builder.HasKey(x => x.Id);
    }
}