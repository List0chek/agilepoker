using System.Linq;
using DataService;
using DataService.Models;
using PlanPoker.Models;

namespace PlanPoker.DTO.Converters
{
  /// <summary>
  /// Класс RoomDTOConverter.
  /// </summary>
  public class RoomDTOConverter
  {
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
    /// Конструктор класса RoomDTOConverter.
    /// </summary>
    /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
    /// <param name="discussionRepository">Экземпляр InMemoryDiscussionRepository.</param>
    /// <param name="deckRepository">Экземпляр InMemoryDeckRepository.</param>
    /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
    /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
    public RoomDTOConverter(
        IRepository<Vote> voteRepository,
        IRepository<Discussion> discussionRepository,
        IRepository<Deck> deckRepository,
        IRepository<Card> cardRepository,
        IRepository<User> userRepository)
    {
      this.voteRepository = voteRepository;
      this.discussionRepository = discussionRepository;
      this.deckRepository = deckRepository;
      this.cardRepository = cardRepository;
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Метод конвертации Room в RoomDTO.
    /// </summary>
    /// <param name="room">Экземпляр Room.</param>
    /// <returns>Экземпляр RoomDTO.</returns>
    public RoomDTO Convert(Room room)
    {
      var discussionList = this.discussionRepository?.GetAll()
          .Select(item => new DiscussionDTOConverter(this.voteRepository, this.userRepository).Convert(item))
          .Where(item => item.RoomId.Equals(room.Id))
          .ToList();
      var deckDTOConverter = new DeckDTOConverter(this.cardRepository);
      return new RoomDTO()
      {
        Id = room.Id,
        Name = room.Name,
        OwnerId = room.OwnerId,
        HostId = room.HostId,
        Members = room.Members.Select(item => new UserDTOConverter().Convert(item)).ToList(),
        Discussions = discussionList,
        HashCode = room.HashCode,
        Deck = deckDTOConverter.Convert(this.deckRepository.GetAll().Where(item => item.Name.Contains("defaultDeck")).FirstOrDefault()),
      };
    }
  }
}
