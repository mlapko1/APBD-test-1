using WebApplication1.Model;

namespace WebApplication1.Service;

public interface ITeamMemberService
{
    public TeamMemberWithTasksDto GetTeamMemberWithTasks(int teamMemberId);
}