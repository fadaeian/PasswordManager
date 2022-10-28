using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Base.Helpers;
using PasswordManager.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entity.ModelsConf
{
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(p => p.UserId);
            builder.Property(p => p.UserName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Address).HasColumnType("nvarchar(max)");
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.RegisterDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Locked).HasDefaultValue(false);

            setData(builder);
        }

        private void setData(EntityTypeBuilder<User> builder)
        {

            builder.HasData(
                new User()
                {
                    UserId = -1,
                    UserName = "Administrator",
                    Email = "fadaeian.mohammad@Gmail.com",
                    Password = EncryptHelper.PasswordHash("m9230235"),
                    RegisterDate = DateTime.Now,
                    Locked = false,
                    FirstName = "Mohammad",
                    LastName = "Fadaeian",
                }
             );
        }
    }
}
