namespace DataAccessLayer.Entities.Dto;

public class ProgrammeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ContactId { get; set; }
    public bool IsActive { get; set; }
}