using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ModelBuilders
{
    public class UserModelBuilder : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.id);
            builder.Property(t => t.username).IsRequired(true)
                .HasMaxLength(50);

            builder.Property(t => t.password).IsRequired(true)
                .HasMaxLength(50);

            builder.Property(t => t.refreshtoken).IsRequired(false);

            builder.Property(t => t.refreshtokenExpireTime).IsRequired(false);

            builder.Property(t => t.active);
        }
    }
}
