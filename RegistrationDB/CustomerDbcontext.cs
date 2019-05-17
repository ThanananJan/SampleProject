using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using RegistrationContact;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace RegistrationDB
{
   public class CustomerDbcontext :DbContext
    {
       public DbSet<Customer> customer { get; set; }
        dynamic config;
        string dataSource;
        public CustomerDbcontext():base()
        {
            config = JsonConvert.DeserializeObject(File.ReadAllText($"{Environment.CurrentDirectory}/DbConfig.json"));
           dataSource = config.DB.Source.ToString();
        }
        public CustomerDbcontext(string dbSource) : base() {
            dataSource = dbSource;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source= {dataSource}");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x =>
            x.Property(a => a.code)
            .IsRequired()
            .IsUnicode()
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
