using WebApplication1.Model;

namespace WebApplication1.Service;

public interface ITaskService
{
    public TeamMemberWithTasksDto GetTeamMemberWithTasks(int teamMemberId);

    public void DeleteProjectAndTasks(int projectId);
}