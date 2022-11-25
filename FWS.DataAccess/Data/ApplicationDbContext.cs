using FWS.Models;

using Microsoft.EntityFrameworkCore;

namespace FWS.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }
        public DbSet<Customer> Customers { get; set; }
       public DbSet<ProjectManager> ProjectManagers { get; set; }
       public DbSet<Project> Projects { get; set; }

        public DbSet<Resource> Resources { get; set; }


        //Customers is the Table name ,Customer is the model name 
    }
}