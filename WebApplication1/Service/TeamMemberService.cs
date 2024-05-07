using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Service;

public class TeamMemberService : ITeamMemberService
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly ITaskRepository _taskRepository;

    public TeamMemberService(ITeamMemberRepository teamMemberRepository, ITaskRepository taskRepository)
    {
        _teamMemberRepository = teamMemberRepository;
        _taskRepository = taskRepository;
    }

    public TeamMemberWithTasksDto GetTeamMemberWithTasks(int teamMemberId)
    {
        TeamMember teamMember = _teamMemberRepository.GetById(teamMemberId);

        if (teamMember == null)
        {
            return null;
        }

        var tasksAssigned = _taskRepository.GetTasksWithProjectNamesAssignedToTeamMember(teamMemberId);
        var tasksCreated = _taskRepository.GetTasksWithProjectNamesCreatedByTeamMember(teamMemberId);

        TeamMemberWithTasksDto teamMemberWithTasksDto = new TeamMemberWithTasksDto();
        teamMemberWithTasksDto.TeamMember = teamMember;
        teamMemberWithTasksDto.AssignedTasks = tasksAssigned;
        teamMemberWithTasksDto.CreatedTasks = tasksCreated;

        return teamMemberWithTasksDto;
    }
}