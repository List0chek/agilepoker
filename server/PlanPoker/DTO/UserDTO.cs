using System;

namespace PlanPoker.Models
{
  /// <summary>
  /// Класс UserDTO.
  /// </summary>
  public class UserDTO
  {
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
  }
}
