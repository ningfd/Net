using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Identity
{
  public  class AppIdentityContext :IdentityDbContext<AppUser,IdentityRole<string>,string,IdentityUserClaim<string>,
        IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppIdentityContext()
        {

        }
        public AppIdentityContext(DbContextOptions options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(entity => {
                entity.ToTable("AppUsers");
                //entity.Property("TwoFactorEnabled").HasConversion(new BoolToZeroOneConverter<Int16>());
                //entity.Property("PhoneNumberConfirmed").HasConversion(new BoolToZeroOneConverter<Int16>());
                //entity.Property("EmailConfirmed").HasConversion(new BoolToZeroOneConverter<Int16>());
                //entity.Property("LockoutEnabled").HasConversion(new BoolToZeroOneConverter<Int16>());
            });
            builder.Entity<IdentityRole>(entity => { entity.ToTable("AppRoles"); });
            
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("AppUserClaims"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("AppUserTokens"); entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name }); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("AppUserLogins"); entity.HasKey(key => new { key.ProviderKey, key.LoginProvider }); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("AppRoleClaims"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("AppUserRoles"); entity.HasKey(key => new { key.UserId, key.RoleId }); });
            //builder.Entity<AppUser>().ToTable("AppUsers").HasKey(l=>l.Id);
            //builder.Entity<IdentityRole>().ToTable("AppRoles").HasKey(l=>l.Id);
            //builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(l=>l.Id);
            //builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").
            //    HasKey(entity => new { entity.UserId, entity.LoginProvider, entity.Name });
            //builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").
            //    HasKey(entity => new { entity.LoginProvider, entity.ProviderKey });
            //builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(l=>l.Id);
            //builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").
            //    HasKey(entity=> new { entity.UserId,entity.RoleId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=localhost;UID=sa;pwd=123456a?!;database=chen_ze;");
           // optionsBuilder.UseMySQL("server=39.107.226.180;port=3306;database=BabyHome;uid=root;pwd=123456;CharSet=utf8");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
