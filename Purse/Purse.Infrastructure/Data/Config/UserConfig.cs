using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purse.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse.Infrastructure.Data.Config
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.UserRole).HasMaxLength(50);
            builder.HasOne(e => e.Purse).WithOne(c => c.User).HasForeignKey<PurseM>(a => a.UserId);

        }

    }
}
