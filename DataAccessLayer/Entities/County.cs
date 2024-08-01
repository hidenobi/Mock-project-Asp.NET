using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class County
{
    public int CountyId { get; set; }
    
    [StringLength(50)] 
    public required string CountyName { get; set; }
}