using API_CRUD_Products.Anguar.Context;
using API_CRUD_Products.Anguar.Model;

namespace API_CRUD_Products.Anguar.Repositories._Category;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductsDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Category>> fdsfsdfds()
    {
        throw new NotImplementedException();
    }
}
