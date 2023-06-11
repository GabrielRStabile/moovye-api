using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movye.Domain.Entities;

namespace Movye.Data.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
        }
    }
}
