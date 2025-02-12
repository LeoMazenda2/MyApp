using System.ComponentModel;

namespace API_CRUD_Products.Anguar.Model;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Define a data automaticamente ao criar um novo registro
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public bool Activated { get; set; }
    // Navigation property for related products
    public ICollection<Product>? Products { get; set; }
}
