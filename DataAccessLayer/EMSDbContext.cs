using System.Data.Entity;

namespace DataAccessLayer
{
    public class EMSDbContext : DbContext
    {
        public DbSet<DeptMaster> DeptMasters { get; set; }
        public DbSet<EmpProfile> EmpProfiles { get; set; }
        public EMSDbContext() : base("name=EMSDbContext")
        {
            Database.SetInitializer(new EMSDatabaseInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}