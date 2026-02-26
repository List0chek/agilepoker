using System;
using DataService;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.DTO.Converters;
using PlanPoker.Models;
using PlanPoker.Services;

namespace PlanPoker.Controllers
{
  /// <summary>
  /// Класс RoomController.
  /// </summary>
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class RoomController : ControllerBase
  {
    /// <summary>
    /// Экземпляр RoomService.
    /// </summary>
    private readonly RoomService roomService;

    /// <summary>
    /// Экземпляр InMemoryVoteRepository.
    /// </summary>
    private readonly IRepository<Vote> voteRepository;

    /// <summary>
    /// Экземпляр InMemoryDiscussionRepository.
    /// </summary>
    private readonly IRepository<Discussion> discussionRepository;

    /// <summary>
    /// Экземпляр InMemoryDeckRepository.
    /// </summary>
    private readonly IRepository<Deck> deckRepository;

    /// <summary>
    /// Экземпляр InMemoryCardRepository.
    /// </summary>
    private readonly IRepository<Card> cardRepository;

    /// <summary>
    /// Экземпляр InMemoryUserRepository.
    /// </summary>
    private readonly IRepository<User> userRepository;

    /// <summary>
    /// Экземпляр UserService.
    /// </summary>
    private readonly UserService userService;

    /// <summary>
    /// Экземпляр DiscussionService.
    /// </summary>
    private readonly DiscussionService discussionService;


    /// <summary>
    /// Конструктор RoomController.
    /// </summary>
    /// <param name="roomService">Экземпляр RoomService.</param>
    /// <param name="userService">Экземпляр UserService.</param>
    /// <param name="discussionService">Экземпляр DiscussionService.</param>
    /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
    /// <param name="discussionRepository">Экземпляр InMemoryDiscussionRepository.</param>
    /// <param name="deckRepository">Экземпляр InMemoryDeckRepository.</param>
    /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
    /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
    public RoomController(
        UserService userService,
        RoomService roomService,
        DiscussionService discussionService,
        IRepository<Vote> voteRepository,
        IRepository<Discussion> discussionRepository,
        IRepository<Deck> deckRepository,
        IRepository<Card> cardRepository,
        IRepository<User> userRepository)
    {
      this.roomService = roomService;
      this.userService = userService;
      this.discussionService = discussionService;
      this.voteRepository = voteRepository;
      this.discussionRepository = discussionRepository;
      this.deckRepository = deckRepository;
      this.cardRepository = cardRepository;
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Создает новую комнату.
    /// </summary>
    /// <param name="name">Имя комнаты.</param>
    /// <param name="ownerId">Id создателя.</param>
    /// <param name="token">Token создателя.</param>
    /// <returns>Возвращает экземпляр RoomDTO.</returns>
    [HttpPost]
    public RoomDTO Create(string name, Guid ownerId, [FromHeader] string token)
    {
      var room = this.roomService.Create(name, ownerId, token);
      return new RoomDTOConverter(
          this.voteRepository,
          this.discussionRepository,
          this.deckRepository,
          this.cardRepository,
          this.userRepository)
          .Convert(room);
    }

    /// <summary>
    /// Делает пользователя участником комнаты.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="newUserId">Id пользователя, которого нужно добавить.</param>
    /// <returns>Возвращает экземпляр RoomDTO.</returns>
    [HttpPost]
    public RoomDTO AddMember(Guid roomId, Guid newUserId)
    {
      var room = this.roomService.AddMember(roomId, newUserId);
      return new RoomDTOConverter(
          this.voteRepository,
          this.discussionRepository,
          this.deckRepository,
          this.cardRepository,
          this.userRepository)
          .Convert(room);
    }

    /// <summary>
    /// Возвращает информацию о комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Возвращает экземпляр RoomDTO.</returns>
    [HttpGet]
    public RoomDTO GetRoomInfo(Guid roomId, Guid userId)
    {
      var room = this.roomService.GetRoomInfo(roomId, userId);
      return new RoomDTOConverter(
          this.voteRepository,
          this.discussionRepository,
          this.deckRepository,
          this.cardRepository,
          this.userRepository)
          .Convert(room);
    }


    /// <summary>
    /// Позволяет изменить ведущего.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="newHostId">Id пользователя, который будет новым ведущим.</param>
    /// <param name="ownerId">Id пользователя, который является владельцем комнаты.</param>
    /// <returns>Возвращает экземпляр RoomDTO.</returns>
    [HttpPost]
    public RoomDTO ChangeHost(Guid roomId, Guid newHostId, Guid ownerId)
    {
      var room = this.roomService.ChangeHost(roomId, newHostId, ownerId);
      return new RoomDTOConverter(
          this.voteRepository,
          this.discussionRepository,
          this.deckRepository,
          this.cardRepository,
          this.userRepository)
          .Convert(room);
    }

    /// <summary>
    /// Позволяет создать пользователя, комнату и обсуждение.
    /// </summary>
    /// <param name="userName">Имя создателя комнаты.</param>
    /// <param name="roomName">Имя комнаты.</param>
    /// <param name="discussionName">Название обсуждения.</param>
    /// <returns>Возвращает экземпляр UserWithTokenAndRoomDTO.</returns>
    [HttpPost]
    public UserWithTokenAndRoomDTO CreateUserAndRoomWithDiscussion(string userName, string roomName, string discussionName)
    {
      var room = this.roomService.CreateUserAndRoomWithDiscussion(userName, roomName, discussionName);
      var user = this.userRepository.Get(room.OwnerId);

      return new UserWithTokenAndRoomDTO()
      {
        User = new UserDTOConverter().Convert(user),
        Room = new RoomDTOConverter(
              this.voteRepository,
              this.discussionRepository,
              this.deckRepository,
              this.cardRepository,
              this.userRepository)
              .Convert(room),
        Token = user.Token,
      };
    }
  }
}
