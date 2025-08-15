namespace WebApp.Models
{
  public class Product
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public AppUser? ApprovedByUser { get; set; }
    public int? ApprovedByUserId { get; set; }
  }
}