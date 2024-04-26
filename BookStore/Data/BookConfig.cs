using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired(true).HasMaxLength(50);
            builder.Property(b => b.Author).IsRequired(true);
            builder.Property(b => b.Price).IsRequired(true).HasColumnType("money");            
            builder.Property(b => b.ISBN).HasMaxLength(13);
        }
    }
}
