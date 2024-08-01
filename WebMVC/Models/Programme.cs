namespace WebMVC.Models;

public class Programme
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ContactId { get; set; }
    public bool IsActive { get; set; }
    public Contact Contact { get; set; }
}