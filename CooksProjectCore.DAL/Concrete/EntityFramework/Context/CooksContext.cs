using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.DAL.Concrete.EntityFramework.Context
{
    public class CooksContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"workstation id=CooksDB.mssql.somee.com;packet size=4096;user id=sefakarakayaa_SQLLogin_1;pwd=qblfnj45z7;data source=CooksDB.mssql.somee.com;persist security info=False;initial catalog=CooksDB");
        }
        public DbSet<Food> Foods{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<FollowTable> FollowTables{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
    }
}
