using Microsoft.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repository;

public class TeamMemberRepository : ITeamMemberRepository
{
    private readonly IConfiguration _configuration;

    public TeamMemberRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TeamMember GetById(int id)
    {
        TeamMember teamMember = null;
        
        using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            connection.Open();

            string query = "SELECT IdTeamMember, FirstName, LastName, Email FROM TeamMember WHERE IdTeamMember = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
                    
                    teamMember = new TeamMember
                    {
                        IdTeamMember = (int)reader["IdTeamMember"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
        }
        
        return teamMember;
    }
}