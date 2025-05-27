using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnSharp.Infra.Configuration
{
    internal class UserClassCompletedConfiguration : IEntityTypeConfiguration<UserClassCompleted>
    {
        public void Configure(EntityTypeBuilder<UserClassCompleted> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateCompleted)
                .IsRequired();

            builder.Property(x => x.Note)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserClassCompleteds)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Class)
                .WithMany(x => x.userClassCompleteds)
                .HasForeignKey(x => x.IdClass)
                .OnDelete(DeleteBehavior.Restrict);

            // Evitar duplicatas - um usuário só pode concluir uma aula uma vez
            builder.HasIndex(x => new { x.IdUser, x.IdClass }).IsUnique();
        }
    }
}