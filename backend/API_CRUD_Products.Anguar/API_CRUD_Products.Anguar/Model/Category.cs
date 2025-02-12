namespace API_CRUD_Products.Anguar.Model;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedDate { get; set; }
    public bool Activated { get; set; }
    // Navigation property for related products
    public ICollection<Product>? Products { get; set; }
}
