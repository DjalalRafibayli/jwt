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
    public class ActiveModelBuilder : IEntityTypeConfiguration<Active>
    {
        public void Configure(EntityTypeBuilder<Active> builder)
        {
            builder.ToTable("Actives");
            builder.Property(t => t.Id);
 
            builder.Property(t => t.name)
                .HasMaxLength(50);
            
            builder.Property(t => t.sequ);
            
            builder.Property(t => t.active);
        }
    }
}
