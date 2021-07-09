using MaritimeExercise.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaritimeExercise.Database
{
    public class ValuesDB : DbContext
    {
        public DbSet<GDValue> GDValues { get; set; }

        public ValuesDB(DbContextOptions<ValuesDB> dbContextOptions)
         : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<GDValue>> GetAllValues()
        {
            return await GDValues.ToListAsync();
        }

        public void SaveGDValues(IEnumerable<GDValue> gdValues)
        {
            try
            {
                GDValues.AddRange(gdValues);
                this.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to save Values into DB. Exception: " + e.Message);

                throw;
            }
        }

        /// <summary>
        /// This method is only suitable for low amounts of row numbers. 
        /// It is not an efficient way to clear a table.
        /// </summary>
        public void ClearValues()
        {
            try
            {
                GDValues.RemoveRange(GDValues);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to clear Values from DB. Exception: " + e.Message);

                throw;
            }
        }
    }
}
