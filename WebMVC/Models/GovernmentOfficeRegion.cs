namespace WebMVC.Models;

public class GovernmentOfficeRegion
{
    public int GovernmentOfficeRegionId { get; set; }
    public required string GovernmentOfficeRegionName { get; set; }
    public required string Description { get; set; }
    public int CountyId { get; set; }
    public County? County { get; set; }
    public bool IsActive { get; set; }
}