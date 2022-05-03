namespace EntityFrameworkSample.Dal.TableModel
{
    using System.Collections.Generic;
    using EntityFrameworkSample.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// entityとテーブルの関連付けを行う
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public AppDbContext()
        {
            
        }

        /// <summary>
        /// SQL Serverへの接続
        /// </summary>
        /// <param name="option"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            var sqlServerConnection = SqlServerConnection.GetInstance();
            option.UseSqlServer(sqlServerConnection.Connection);
        }

        /// <summary>
        /// entityとテーブルの関連付け
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blog");
        }
    }
}
