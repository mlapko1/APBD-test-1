using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet("api/tasks/{id:int}")]
    public IActionResult GetTeamMemberWithTasks(int id)
    {
        var teamMemberWithTasksDto = _taskService.GetTeamMemberWithTasks(id);

        if (teamMemberWithTasksDto == null)
        {
            return NotFound($"Team member with id {id} wasn't found");
        }

        return Ok(teamMemberWithTasksDto);
    }
    
    [HttpDelete("/api/tasks{projectId:int}")]
    public IActionResult DeleteProject(int projectId)
    {
        _taskService.DeleteProjectAndTasks(projectId);
        return NoContent(); 
    }
}