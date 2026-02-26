using PlanPoker.Models;

namespace PlanPoker.DTO
{
  public class UserWithTokenDTO
  {
    /// <summary>
    /// Пользователь.
    /// </summary>
    public UserDTO User { get; set; }

    /// <summary>
    /// Токен пользователя.
    /// </summary>
    public string Token { get; set; }
  }
}
