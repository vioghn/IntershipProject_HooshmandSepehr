using Purse.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace Purse.Infrastructure.Data.Config
{
    internal class PurseConfig : IEntityTypeConfiguration<PurseM>
    {
        public void Configure(EntityTypeBuilder<PurseM> builder)
        {
            builder.ToTable("Purse");
            builder.HasKey(x => x.PurseId);
            builder.Property(x => x.PurseBalance).HasDefaultValue(0.0);
            builder.HasOne(e => e.User).WithOne(c => c.Purse).HasForeignKey<User>(a => a.PurseId);

        }
    }
}
