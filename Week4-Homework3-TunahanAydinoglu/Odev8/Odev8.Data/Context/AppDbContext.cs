using Microsoft.EntityFrameworkCore;
using Odev8.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }



    }
}
