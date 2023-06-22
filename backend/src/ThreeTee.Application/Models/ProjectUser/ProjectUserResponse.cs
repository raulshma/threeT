
namespace ThreeTee.Application.Models.ProjectUser;

public class ProjectUserResponse
{
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string? UserDesignationName { get; set; }
    public DateTime? UserJoiningDate { get; set; }
    public int? UserExperienceYears
    {
        get
        {
            if (UserJoiningDate.HasValue)
            {
                DateTime zeroTime = new(1, 1, 1);
                TimeSpan span = (TimeSpan)(DateTime.UtcNow - UserJoiningDate);
                int years = (zeroTime + span).Year - 1;
                return years;
            }
            return null;
        }
    }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}
