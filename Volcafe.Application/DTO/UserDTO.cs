using Volcafe.Core.Entities;

namespace Volcafe.Application.DTO;

public class UserDTO
{
    public string Email { get; set; }

    public string Name { get; set; }

    public string UserRole { get; set; }

    public string UserType { get; set; }

    public string AgentId { get; set; }

    public int? AgentCategoryTypeId { get; set; }

    public string Reviewer { get; set; }
    public bool? Active { get; set; }

}