using DataService;
using PlanPoker.Models;
using System.Data;
using System.Linq;

namespace PlanPoker.DTO.Converters
{
    /// <summary>
    /// Класс DiscussionDTOConverter.
    /// </summary>
    public class DiscussionDTOConverter
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
        /// Конструктор класса DiscussionDTOConverter.
        /// </summary>
        /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
        /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
        public DiscussionDTOConverter(IRepository<Vote> voteRepository, IRepository<User> userRepository)
        {
            this.voteRepository = voteRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Метод конвертации Discussion в DiscussionDTO.
        /// </summary>
        /// <param name="discussion">Экземпляр Discussion.</param>
        /// <returns>Экземпляр DiscussionDTO.</returns>
        public DiscussionDTO Convert(Discussion discussion)
        {
            double numerableValue = 0;
            int votesCounter = 0;
            double numerableVotesSum = 0;
            double averageResult = 0;
            var votesList = this.voteRepository.GetAll()
                .Select(item => new VoteDTOConverter(this.userRepository).Convert(item))
                .Where(item => item.DiscussionId.Equals(discussion.Id))
                .ToList();
            if (votesList?.Count > 0)
            {
                foreach (var vote in votesList)
                {
                    double.TryParse(vote.Card.Value, out numerableValue);
                    numerableVotesSum += numerableValue;
                    votesCounter++;
                }

                averageResult = numerableVotesSum / votesCounter;
                discussion.AverageResult = averageResult;
            }

            var discussionDuration = discussion.DateEnd - discussion.DateStart;
            return new DiscussionDTO()
            {
                Id = discussion.Id,
                RoomId = discussion.RoomId,
                Topic = discussion.Topic,
                DateStart = discussion.DateStart,
                DateEnd = discussion.DateEnd,
                Votes = votesList,
                AverageResult = discussion.AverageResult,
                Duration = (discussionDuration.HasValue is false) ? 0 : discussionDuration.Value.TotalMinutes,
            };
        }
    }
}
