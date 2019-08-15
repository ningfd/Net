using Domain.Model;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EntityFrameCore
{
   public class EFDBContext: DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options):base(options)
        {

        }
        public DbSet<JournalModel> JournalModels
        {
            get;set;
        }
        public DbSet<BabyPhotoModel> BabyPhotoModels
        {
            get;set;
        }
        /// <summary>
        /// 创建EFCore需要的数据库连接信息
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=localhost;UID=sa;pwd=123456a?!;database=BabyHome;");
            //optionsBuilder.UseMySQL("server=39.107.226.180;port=3306;database=BabyHome;uid=root;pwd=123456;CharSet=utf8");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //为模型Journal设置主键
            modelBuilder.Entity<JournalModel>().HasKey(c=>c.JournalID);
            modelBuilder.Entity<JournalModel>().
                ToTable("JournalModel").
                HasOne<AppUser>(user=>user.User);

            modelBuilder.Entity<BabyPhotoModel>().HasKey(key=>key.Id);
            modelBuilder.Entity<BabyPhotoModel>().ToTable("BabyPhoto").HasOne<AppUser>(user=>user.User);
            //modelBuilder.Entity<AppUser>(entity => {
            //    entity.ToTable("AppUsers");
            //    entity.Property("TwoFactorEnabled").HasConversion(new BoolToZeroOneConverter<Int16>());
            //    entity.Property("PhoneNumberConfirmed").HasConversion(new BoolToZeroOneConverter<Int16>());
            //    entity.Property("EmailConfirmed").HasConversion(new BoolToZeroOneConverter<Int16>());
            //    entity.Property("LockoutEnabled").HasConversion(new BoolToZeroOneConverter<Int16>());
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
