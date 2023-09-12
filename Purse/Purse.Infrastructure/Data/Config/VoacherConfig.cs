using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purse.Domain.Entites;

internal class VoacherConfig : IEntityTypeConfiguration<Voacher>
{
    public void Configure(EntityTypeBuilder<Voacher> builder)
    {
        builder.ToTable("Voacher");
        builder.HasKey(x => x.VoacherId);
        builder.Property(x => x.VoacherValue).HasDefaultValue(0.0);

        builder.HasOne<PurseM>(v => v.SourcePurse)
            .WithMany()
            .HasForeignKey(v => v.PurseSourceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PurseM>(v => v.DestinationPurse)
            .WithMany()
            .HasForeignKey(v => v.PurseDestinationID)
            .OnDelete(DeleteBehavior.Restrict);

        // Specify cascade delete behavior for the relationships
        builder.HasOne<PurseM>(v => v.SourcePurse)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<PurseM>(v => v.DestinationPurse)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}