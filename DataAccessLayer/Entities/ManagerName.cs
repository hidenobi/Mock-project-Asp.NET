using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class ManagerName
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }

}