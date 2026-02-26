using PlanPoker.Models;

namespace PlanPoker.DTO
{
  public class UserWithTokenAndRoomDTO
  {
    /// <summary>
    /// Пользователь.
    /// </summary>
    public UserDTO User { get; set; }

    /// <summary>
    /// Комната.
    /// </summary>
    public RoomDTO Room { get; set; }

    /// <summary>
    /// Токен пользователя.
    /// </summary>
    public string Token { get; set; }
  }
}
