using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging.Debug;
using WebApiBase.Extensions;
using WebApiBase.Models;

namespace WebApiBase.Db
{
    public class BaseDbContext : DbContext
    {
        //public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //optionsBuilder.UseMySql(
            //    @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.28-mysql"));

            //string DbString = "server=192.168.100.139;database=net6coretest;uid=root;pwd=60728160";
            //optionsBuilder.UseMySql(DbString, new MySqlServerVersion(new Version(8, 0, 22)));
            //optionsBuilder.UseLoggerFactory(LoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name);
            modelBuilder.RegisterEntities(assembly);
            base.OnModelCreating(modelBuilder);
        }

        public BaseDbContext(DbContextOptions<BaseDbContext> option) : base(option)
        {
            //DBDatabase = this.Database;
            //string conn = DBDatabase.GetConnectionString();
        }
    }
}

