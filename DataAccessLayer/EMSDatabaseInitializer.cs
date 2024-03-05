using System.Data.Entity;

namespace DataAccessLayer
{
    public class EMSDatabaseInitializer : DropCreateDatabaseIfModelChanges<EMSDbContext>
    {
        protected override void Seed(EMSDbContext context)
        {
            context.DeptMasters.Add(new DeptMaster { DeptCode = 1, DeptName = "IT" });
            context.DeptMasters.Add(new DeptMaster { DeptCode = 2, DeptName = "HR" });

            context.SaveChanges();
        }
    }
}