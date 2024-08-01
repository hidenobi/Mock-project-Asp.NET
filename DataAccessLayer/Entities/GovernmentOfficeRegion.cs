using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class GovernmentOfficeRegion
{
    public int GovernmentOfficeRegionId { get; set; }
    
    [StringLength(100)]
    public required string GovernmentOfficeRegionName { get; set; }
    
    [StringLength(200)]
    public required string Description { get; set; }
    public int CountyId { get; set; }
    public County? County { get; set; }
    public bool IsActive { get; set; }
}