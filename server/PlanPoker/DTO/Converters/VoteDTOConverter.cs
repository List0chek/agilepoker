using DataService;
using PlanPoker.Models;

namespace PlanPoker.DTO.Converters
{
  /// <summary>
  /// Класс VoteDTOConverter.
  /// </summary>
  public class VoteDTOConverter
  {
    /// <summary>
    /// Экземпляр InMemoryUserRepository.
    /// </summary>
    private readonly IRepository<User> userRepository;

    /// <summary>
    /// Конструктор класса VoteDTOConverter.
    /// </summary>
    /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
    public VoteDTOConverter(IRepository<User> userRepository)
    {
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Метод конвертации Vote в VoteDTO.
    /// </summary>
    /// <param name="vote">Экземпляр Vote.</param>
    /// <returns>Экземпляр VoteDTO.</returns>
    public VoteDTO Convert(Vote vote)
    {
      var userDTOConverter = new UserDTOConverter();
      return new VoteDTO()
      {
        Id = vote.Id,
        CardId = vote.CardId,
        RoomId = vote.RoomId,
        DiscussionId = vote.DiscussionId,
        User = userDTOConverter.Convert(this.userRepository.Get(vote.UserId)),
        Card = new CardDTOConverter().Convert(vote.Card)
      };
    }
  }
}
