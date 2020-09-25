using Microsoft.EntityFrameworkCore;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Core.Model {
    public class OnesDataContext : DbContext {
        public DbSet<One> Ones { get; set; }
        public DbSet<OneArticle> Articles { get; set; }
        public DbSet<OneQuestion> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //todo 配置数据库
            optionsBuilder.UseSqlServer("Data Source=xxx.xxx.xxx.xxx;Initial Catalog=d4ubb9173y5p5;Persist Security Info=True;User ID=xxxx;Password=xxxx",option=> { option.EnableRetryOnFailure(); });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<One>()
                .HasKey(c => c.Href);
            modelBuilder.Entity<OneArticle>()
                .HasKey(c => c.Href);
            modelBuilder.Entity<OneQuestion>()
                .HasKey(c => c.Href);
        }
    }
}
