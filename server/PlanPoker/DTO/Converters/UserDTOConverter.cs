using PlanPoker.Models;

namespace PlanPoker.DTO.Converters
{
  /// <summary>
  /// Класс UserDTOConverter.
  /// </summary>
  public class UserDTOConverter
  {
    /// <summary>
    /// Метод конвертации User в UserDTO.
    /// </summary>
    /// <param name="user">Экземпляр User.</param>
    /// <returns>Экземпляр UserDTO.</returns>
    public UserDTO Convert(User user)
    {
      {
        return new UserDTO()
        {
          Id = user.Id,
          Name = user.Name
        };
      }
    }
  }
}
