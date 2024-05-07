using Task = WebApplication1.Model.Task;

namespace WebApplication1.Repository;

public interface ITaskRepository
{
    public List<Task> GetTasksWithProjectNamesAssignedToTeamMember(int teamMemberId);
    
    public List<Task> GetTasksWithProjectNamesCreatedByTeamMember(int teamMemberId);
}