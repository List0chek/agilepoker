using System;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Converters;
using PlanPoker.Models;
using PlanPoker.Services;

namespace PlanPoker.Controllers
{
  /// <summary>
  /// Класс UserController.
  /// </summary>
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    /// <summary>
    /// Экземпляр класса UserService.
    /// </summary>
    private readonly UserService userService;

    /// <summary>
    /// Конструктор класса UserController.
    /// </summary>
    /// <param name="userService">Экземпляр класса UserService.</param>
    public UserController(UserService userService)
    {
      this.userService = userService;
    }

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>Возвращает экземпляр UserDTO.</returns>
    [HttpPost]
    public UserWithTokenDTO Create(string name)
    {
      var user = this.userService.Create(name);
      return new UserWithTokenDTO()
      {
        User = new UserDTOConverter().Convert(user),
        Token = user.Token
      };
    }

    /// <summary>
    /// Меняет имя пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <param name="token">Token пользователя.</param>
    /// <param name="newName">Новое имя пользоваетля.</param>
    /// <returns>Возвращает экземпляр UserDTO.</returns>
    [HttpPost]
    public UserDTO ChangeName(Guid id, [FromHeader] string token, string newName)
    {
      var user = this.userService.ChangeName(id, token, newName);
      return new UserDTOConverter().Convert(user);
    }

    /// <summary>
    /// Возвращает пользователя.
    /// </summary>
    /// <param name="token">Токен пользователя.</param>
    /// <returns>Возвращает экземпляр User.</returns>
    [HttpGet]
    public UserDTO Get([FromHeader] string token)
    {
      var user = this.userService.Get(token);
      return new UserDTOConverter().Convert(user);
    }

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="token">Токен пользователя.</param>
    [HttpGet]
    public void Delete([FromHeader] string token)
    {
      this.userService.Delete(token);
    }
  }
}
