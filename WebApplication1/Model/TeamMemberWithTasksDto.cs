namespace WebApplication1.Model;

public class TeamMemberWithTasksDto
{
    public TeamMember TeamMember { get; set; }
    public List<Task> AssignedTasks { get; set; }
    public List<Task> CreatedTasks { get; set; }
}