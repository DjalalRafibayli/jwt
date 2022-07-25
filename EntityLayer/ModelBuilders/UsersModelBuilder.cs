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
    public class UsersModelBuilder : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.username)
                .HasMaxLength(50);

            builder.Property(t => t.password)
                .HasMaxLength(50);
            builder.Property(t => t.active);
        }
    }
}
