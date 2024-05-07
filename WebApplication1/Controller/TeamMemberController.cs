using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
public class TeamMemberController : ControllerBase
{
    private readonly ITeamMemberService _teamMemberService;

    public TeamMemberController(ITeamMemberService teamMemberService)
    {
        _teamMemberService = teamMemberService;
    }
    
    [HttpGet("api/tasks/{id:int}")]
    public IActionResult GetTeamMemberWithTasks(int id)
    {
        var teamMemberWithTasksDto = _teamMemberService.GetTeamMemberWithTasks(id);

        if (teamMemberWithTasksDto == null)
        {
            return NotFound($"Team member with id {id} wasn't found");
        }

        return Ok(teamMemberWithTasksDto);
    }
}