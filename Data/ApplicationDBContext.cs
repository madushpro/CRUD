using CRUD_opr.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_opr.Data
{
    public class ApplicationDBContext : DbContext { 

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>option):base (option) { 
        
        
        }
        public DbSet<Student> obj {  get; set; }



    }
}
