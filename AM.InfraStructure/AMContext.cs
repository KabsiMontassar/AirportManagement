using AM.InfraStructure.Configuration;
using Class_Library.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.InfraStructure
{
    public class AMContext : DbContext
    {

        // 1 Dbset
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Traveller> Travellers { get; set; }

        // 2 Chaine de connexion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=4arctic4;Integrated Security=true"); 
            base.OnConfiguring(optionsBuilder);
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        }




    }
}
