//using Ballastlane.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

/// <summary>
/// Temp class that helps to avoid a scaffolding issue when trying to create
/// Views, this happens becuase DbContext class is in different project that 
/// the main one is.
/// 
/// After using you could comment it or delete it.
/// </summary>


//public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//{    public ApplicationDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

//        return new ApplicationDbContext(optionsBuilder.Options);
//    }
//}