using API_CRUD_Products.Anguar.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_Products.Anguar.Data
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }
        
        public DbSet<Category> MyProperty { get; set; }
    }
}
