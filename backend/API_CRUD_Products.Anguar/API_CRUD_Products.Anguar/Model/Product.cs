namespace API_CRUD_Products.Anguar.Model;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public DateTime? CreatedDate { get; set; }
    public bool Activated { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }

    // Navigation property to related category
    public Category? Category { get; set; }
}
