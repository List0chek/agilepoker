using DataService;
using PlanPoker.Models;
using System;

namespace PlanPoker.Services
{
    /// <summary>
    /// Класс DiscussionService.
    /// </summary>
    public class DiscussionService
    {
        /// <summary>
        /// Экземпляр InMemoryDiscussionRepository.
        /// </summary>
        private readonly IRepository<Discussion> discussionRepository;

        /// <summary>
        /// Экземпляр InMemoryRoomRepository.
        /// </summary>
        private readonly IRepository<Room> roomRepository;

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
        /// Экземпляр VoteService.
        /// </summary>
        private readonly VoteService voteService;


        /// <summary>
        /// Конструктор класса DiscussionService.
        /// </summary>
        /// <param name="discussionRepository">Экземпляр InMemoryDiscussionRepository.</param>
        /// <param name="roomRepository">Экземпляр InMemoryRoomRepository.</param>
        /// <param name="voteRepository">Экземпляр InMemoryVoteRepository.</param>
        /// <param name="userRepository">Экземпляр InMemoryUserRepository.</param>
        /// <param name="voteService">Экземпляр VoteService.</param>
        /// <param name="cardRepository">Экземпляр InMemoryCardRepository.</param>
        public DiscussionService(
            IRepository<Discussion> discussionRepository,
            IRepository<Room> roomRepository,
            IRepository<Vote> voteRepository,
            IRepository<User> userRepository,
            VoteService voteService,
            IRepository<Card> cardRepository)
        {
            this.discussionRepository = discussionRepository;
            this.roomRepository = roomRepository;
            this.voteRepository = voteRepository;
            this.userRepository = userRepository;
            this.voteService = voteService;
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// Создает новое обсуждение.
        /// </summary>
        /// <param name="roomId">Id комнаты, в которой создается новое обсуждение.</param>
        /// <param name="topic">Название темы обсуждения.</param>
        /// <param name="hostId">Id ведущего.</param>
        /// <param name="hostToken">Token ведущего.</param>
        /// <returns>Возвращает экземпляр Discussion.</returns>
        public Discussion Create(Guid roomId, string topic, Guid hostId, string hostToken)
        {
            var discussion = this.discussionRepository.Create();
            var room = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");
            var host = this.userRepository.Get(hostId) ?? throw new UnauthorizedAccessException("User not found"); // возможно стоит получать хоста из рума и hostId не запрашивать.
            if (topic is null || topic == string.Empty)
            {
                throw new UnauthorizedAccessException("Discussion topic name is not valid");
            }

            if (hostToken is null || !host.Token.Equals(hostToken))
            {
                throw new UnauthorizedAccessException("Token is not valid");
            }

            if (!room.HostId.Equals(host.Id))
            {
                throw new UnauthorizedAccessException("Host is not valid");
            }

            discussion.RoomId = room.Id;
            discussion.Topic = topic;
            discussion.DateStart = DateTime.Now;
            discussion.DateEnd = null;
            this.discussionRepository.Save(discussion);
            return discussion;
        }

        /// <summary>
        /// Метод позволяет выставить и сменить оценку в обсуждении.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="userId">Id пользователя.</param>
        /// <param name="cardId">Id выбранной карты.</param>
        /// <returns>Возвращает экземпляр Discussion.</returns>
        public Discussion SetVote(Guid discussionId, Guid userId, Guid cardId)
        {
            var discussion = this.discussionRepository.Get(discussionId) ?? throw new UnauthorizedAccessException("Discussion not found");
            var room = this.roomRepository.Get(discussion.RoomId) ?? throw new UnauthorizedAccessException("Room not found");
            var card = this.cardRepository.Get(cardId) ?? throw new UnauthorizedAccessException("Card not found");
            if (!discussion.RoomId.Equals(room.Id))
            {
                throw new UnauthorizedAccessException("Discussion is not containing in Room");
            }

            if (discussion.DateEnd == null)
            {
                var user = this.userRepository.Get(userId) ?? throw new UnauthorizedAccessException("User not found");

                if (room.Members.Contains(user))
                {
                    this.voteService.SetVote(card.Id, discussion.Id, user.Id);
                }
                else if (!room.Members.Contains(user))
                {
                    throw new UnauthorizedAccessException("User is not valid");
                }
            }

            return discussion;
        }

        /// <summary>
        /// Закрывает обсуждение.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="hostId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр Discussion.</returns>
        public Discussion Close(Guid roomId, Guid discussionId, Guid hostId)
        {
            var discussion = this.discussionRepository.Get(discussionId) ?? throw new UnauthorizedAccessException("Discussion not found");
            var room = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");
            var host = this.userRepository.Get(hostId) ?? throw new UnauthorizedAccessException("User not found");
            if (!discussion.RoomId.Equals(room.Id))
            {
                throw new UnauthorizedAccessException("Discussion is not containing in Room");
            }

            if (!room.HostId.Equals(host.Id))
            {
                throw new UnauthorizedAccessException("Host is not valid");
            }

            if (discussion.DateEnd == null)
            {
                discussion.DateEnd = DateTime.Now;
                this.discussionRepository.Save(discussion);
            }

            return discussion;
        }

        /// <summary>
        /// Удаляет обсуждение.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="hostId">Id пользователя.</param>
        public void Delete(Guid roomId, Guid discussionId, Guid hostId)
        {
            var discussion = this.discussionRepository.Get(discussionId) ?? throw new UnauthorizedAccessException("Discussion not found");
            var room = this.roomRepository.Get(roomId) ?? throw new UnauthorizedAccessException("Room not found");
            var host = this.userRepository.Get(hostId) ?? throw new UnauthorizedAccessException("User not found");
            if (!discussion.RoomId.Equals(room.Id))
            {
                throw new UnauthorizedAccessException("Discussion is not containing in Room");
            }

            if (!room.HostId.Equals(host.Id))
            {
                throw new UnauthorizedAccessException("Host is not valid");
            }

            this.discussionRepository.Delete(discussion.Id);
        }

        /// <summary>
        /// Возвращает оценки участников обсуждения и итоговую среднюю оценку.
        /// </summary>
        /// <param name="discussionId">Id обсуждения.</param>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Возвращает экземпляр Discussion.</returns>
        public Discussion GetResults(Guid discussionId, Guid userId)
        {
            var discussion = this.discussionRepository.Get(discussionId) ?? throw new UnauthorizedAccessException("Discussion not found");
            var room = this.roomRepository.Get(discussion.RoomId) ?? throw new UnauthorizedAccessException("Room not found");
            var user = this.userRepository.Get(userId) ?? throw new UnauthorizedAccessException("User not found");
            if (!room.Members.Contains(user))
            {
                throw new UnauthorizedAccessException("User is not valid");
            }

            return discussion;
        }
    }
}
