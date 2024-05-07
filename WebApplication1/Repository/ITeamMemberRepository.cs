using WebApplication1.Model;

namespace WebApplication1.Repository;

public interface ITeamMemberRepository
{
    public TeamMember GetById(int id);
}