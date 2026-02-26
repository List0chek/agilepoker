using System;
using System.Linq;
using DataService;
using PlanPoker.Models;

namespace PlanPoker.Services
{
  /// <summary>
  /// Класс VoteService.
  /// </summary>
  public class VoteService
  {
    /// <summary>
    /// Экземпляр InMemoryVoteRepository.
    /// </summary>
    private readonly IRepository<Vote> voteRepository;

    /// <summary>
    /// Экземпляр InMemoryUserRepository.
    /// </summary>
    private readonly IRepository<User> userRepository;

    /// <summary>
    /// Экземпляр InMemoryCardRepository.
    /// </summary>
    private readonly IRepository<Card> cardRepository;

    /// <summary>
    /// Экземпляр InMemoryDiscussionRepository.
    /// </summary>
    private readonly IRepository<Discussion> discussionRepository;

    /// <summary>
    /// Конструктор класса VoteService.
    /// </summary>
    /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
    /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
    /// <param name="discussionRepository">Экземпляр InMemoryDiscussionRepository.</param>
    /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
    public VoteService(
        IRepository<Vote> voteRepository,
        IRepository<Card> cardRepository,
        IRepository<Discussion> discussionRepository,
        IRepository<User> userRepository)
    {
      this.voteRepository = voteRepository;
      this.cardRepository = cardRepository;
      this.discussionRepository = discussionRepository;
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Создает новую оценку.
    /// </summary>
    /// <param name="cardId">Id выбранной карты.</param>
    /// <param name="discussionId">Id обсуждения.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Возвращает экземпляр Vote.</returns>
    public Vote SetVote(Guid cardId, Guid discussionId, Guid userId)
    {
      var card = this.cardRepository.Get(cardId) ?? throw new ArgumentException("Card not found");
      var discussion = this.discussionRepository.Get(discussionId) ?? throw new ArgumentException("Discussion not found");
      var user = this.userRepository.Get(userId) ?? throw new ArgumentException("User not found");
      var userVotesCount = this.voteRepository
          .GetAll()
          .Where(item => item.UserId.Equals(user.Id) && item.DiscussionId.Equals(discussion.Id))
          .Count();

      if (userVotesCount == 0)
      {
        var newVote = this.voteRepository.Create();
        newVote.CardId = card.Id;
        newVote.DiscussionId = discussion.Id;
        newVote.UserId = user.Id;
        newVote.RoomId = discussion.RoomId;
        newVote.Card = card;
        this.voteRepository.Save(newVote);
        return newVote;
      }
      else if (userVotesCount == 1)
      {
        var voteId = this.voteRepository
            .GetAll()
            .FirstOrDefault(item => item.UserId.Equals(user.Id) && item.DiscussionId.Equals(discussion.Id)).Id;
        var vote = this.voteRepository.Get(voteId) ?? throw new ArgumentException("Vote not found");
        vote.CardId = card.Id;
        vote.Card = card;
        this.voteRepository.Save(vote);
        return vote;
      }
      else throw new ArgumentException("Wrong discussion");
    }
  }
}
