using Microsoft.Data.SqlClient;
using Task = WebApplication1.Model.Task;

namespace WebApplication1.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly IConfiguration _configuration;

    public TaskRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Task> GetTasksWithProjectNamesAssignedToTeamMember(int teamMemberId)
    { 
        List<Task> tasks = new List<Task>();

        using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            connection.Open();

            string query = @"
                SELECT 
                    t.Name AS TaskName, 
                    t.Description, 
                    t.Deadline, 
                    p.Name AS ProjectName, 
                    tt.Name AS TaskType
                FROM 
                    Task t
                JOIN 
                    Project p ON t.IdProject = p.IdProject
                JOIN 
                    TaskType tt ON t.IdTaskType = tt.IdTaskType
                WHERE 
                    t.IdAssignedTo = @TeamMemberId
                ORDER BY 
                    t.Deadline DESC;
            ";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TeamMemberId", teamMemberId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Name = reader["TaskName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            ProjectName = reader["ProjectName"].ToString(),
                            TaskType = reader["TaskType"].ToString()
                        });
                    }
                }
            }
        }

        return tasks;
    }

    public List<Task> GetTasksWithProjectNamesCreatedByTeamMember(int teamMemberId)
    {
        List<Task> tasks = new List<Task>();

        using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            connection.Open();

            string query = @"
                SELECT 
                    t.Name AS TaskName, 
                    t.Description, 
                    t.Deadline, 
                    p.Name AS ProjectName, 
                    tt.Name AS TaskType
                FROM 
                    Task t
                JOIN 
                    Project p ON t.IdProject = p.IdProject
                JOIN 
                    TaskType tt ON t.IdTaskType = tt.IdTaskType
                WHERE 
                    t.IdCreator = @TeamMemberId
                ORDER BY 
                    t.Deadline DESC;
            ";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TeamMemberId", teamMemberId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Name = reader["TaskName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            ProjectName = reader["ProjectName"].ToString(),
                            TaskType = reader["TaskType"].ToString()
                        });
                    }
                }
            }
        }

        return tasks;
    }
}