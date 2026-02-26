using System;
using System.Linq;
using DataService;
using PlanPoker.Models;

namespace PlanPoker.Services
{
  /// <summary>
  /// Класс UserService.
  /// </summary>
  public class UserService
  {
    /// <summary>
    /// Экземпляр InMemoryUserRepository.
    /// </summary>
    private readonly IRepository<User> userRepository;

    /// <summary>
    /// Экземпляр InMemoryRoomRepository.
    /// </summary>
    private readonly IRepository<Room> roomRepository;

    /// <summary>
    /// Конструктор класса UserService.
    /// </summary>
    /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
    /// <param name="roomRepository">Экземпляр InMemoryRoomRepository.</param>
    public UserService(IRepository<User> userRepository, IRepository<Room> roomRepository)
    {
      this.userRepository = userRepository;
      this.roomRepository = roomRepository;
    }

    /// <summary>
    /// Создает нового пользоваетля.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>Возвращает экземпляр User.</returns>
    public User Create(string name)
    {
      var newUser = this.userRepository.Create();
      var token = Convert.ToBase64String(newUser.Id.ToByteArray());

      if (name is null || name == string.Empty)
      {
        throw new ArgumentException("Wrong username");
      }

      newUser.Token = token;
      newUser.Name = name;
      this.userRepository.Save(newUser);
      return newUser;
    }

    /// <summary>
    /// Меняет имя пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <param name="token">Token пользователя.</param>
    /// <param name="newName">Новое имя пользоваетля.</param>
    /// <returns>Возвращает экземпляр User.</returns>
    public User ChangeName(Guid id, string token, string newName)
    {
      var user = this.userRepository.Get(id) ?? throw new UnauthorizedAccessException("User not found");

      if (newName is null || newName == string.Empty)
      {
        throw new ArgumentException("Wrong username");
      }

      if (token is null || !user.Token.Equals(token))
      {
        throw new ArgumentException("Wrong token");
      }

      user.Name = newName;
      this.userRepository.Save(user);
      return user;
    }

    /// <summary>
    /// Возвращает пользователя.
    /// </summary>
    /// <param name="token">Токен пользователя.</param>
    /// <returns>Возвращает экземпляр User.</returns>     
    public User Get(string token)
    {
      if (token is null || token == string.Empty || this.userRepository.GetAll().Where(item => item.Token == token).Count() == 0)
      {
        throw new UnauthorizedAccessException("Wrong token");
      }

      var user = this.userRepository
           .GetAll()
           .FirstOrDefault(item => item.Token == token) ?? throw new UnauthorizedAccessException("User not found");

      return user;
    }

    /// <summary>
    /// Удаляет пользователя из InMemoryUserRepository и из всех комнат, членом которых он являлся.
    /// </summary>
    /// <param name="token">Токен пользователя.</param>
    public void Delete(string token)
    {
      if (token is null || token == string.Empty)
      {
        throw new ArgumentException("Wrong token");
      }

      var user = this.userRepository
          .GetAll()
          .First(item => item.Token == token)
          ?? throw new UnauthorizedAccessException("User not found");
      var roomsWithUser = this.roomRepository
          .GetAll()
          .Where(item => item.Members.Contains(user))
          ?? throw new UnauthorizedAccessException("Room not found");

      // this.userRepository.Delete(user.Id); // если оставить, то будет лететь ошибка. Смотреть в сторону UserDTO и RoomDTO конвертеров.
      foreach (var room in roomsWithUser)
      {
        room.Members.Remove(user);
      }
    }
  }
}
