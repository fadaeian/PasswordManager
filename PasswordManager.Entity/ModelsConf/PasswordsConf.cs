using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entity.ModelsConf
{
    public class PasswordsConf : IEntityTypeConfiguration<Passwords>
    {
        public void Configure(EntityTypeBuilder<Passwords> builder)
        {

            builder.HasKey(p => p.PasswordId);
            builder.Property(p => p.Name).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.SiteURL).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.UserName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.ModifiedDate).IsRequired();
            
        }
    }
}
