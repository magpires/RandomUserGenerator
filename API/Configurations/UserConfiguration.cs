using API.Configurations.Base;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public UserConfiguration() : base("users") { }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(u => u.Email).HasColumnName("email").IsRequired();
            builder.Property(u => u.Username).HasColumnName("username").IsRequired();
            builder.Property(u => u.Password).HasColumnName("password").IsRequired();
            builder.Property(u => u.Gender).HasColumnName("gender");
            builder.Property(u => u.Phone).HasColumnName("phone");
            builder.Property(u => u.Cell).HasColumnName("cell");
            builder.Property(u => u.PictureLarge).HasColumnName("picture_large");
            builder.Property(u => u.PictureMedium).HasColumnName("picture_medium");
            builder.Property(u => u.PictureThumbnail).HasColumnName("picture_thumbnail");
            builder.Property(u => u.DateOfBirth).HasColumnName("date_of_birth");
            builder.Property(u => u.Age).HasColumnName("age");
        }
    }
}
