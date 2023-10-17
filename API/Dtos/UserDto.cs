using Domain.Entities;
namespace API.Dtos;

public class UserDto : BaseEntity
{
    public string Mail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}